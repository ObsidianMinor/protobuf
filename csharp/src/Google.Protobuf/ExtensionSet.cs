using System;
using System.Collections.Generic;
using Google.Protobuf.Collections;

namespace Google.Protobuf
{
    /// <summary>
    /// Used to get and set the values of extension fields defined on other types
    /// </summary>
    public abstract class ExtensionSet
    {
        private readonly Type targetType;
        private readonly Dictionary<Extension, IExtensionValue> valuesByIdentifier = new Dictionary<Extension, IExtensionValue>();
        private readonly Dictionary<uint, IExtensionValue> valuesByTag = new Dictionary<uint, IExtensionValue>();

        internal ExtensionSet(Type target)
        {
            targetType = target;
        }

        internal bool TryGetValueFor(Extension extension, out IExtensionValue extensionValue)
        {
            if (valuesByIdentifier.TryGetValue(extension, out extensionValue))
            {
                return true;
            }
            else
            {
                Register(extension);
                extensionValue = valuesByIdentifier[extension];
                return true;
            }
        }

        internal bool TryGetValueFor(uint tag, out IExtensionValue extensionValue)
        {
            return valuesByTag.TryGetValue(tag, out extensionValue);
        }

        /// <summary>
        /// Registers the specified extension in the set
        /// </summary>
        /// <param name="extension">The extension to register</param>
        public void Register(Extension extension)
        {
            if (extension.TargetType != targetType)
                throw new ArgumentException("Cannot register extension for wrong target type");

            if (valuesByIdentifier.ContainsKey(extension))
                return;

            var value = extension.GetValue();
            valuesByTag.Add(extension.Tag, value);
            valuesByIdentifier.Add(extension, value);
        }

        /// <summary>
        /// Attempts to merge a field from the specified input stream.
        /// If the set does not contain an extension for the field number in the stream this returns false.
        /// </summary>
        /// <param name="stream">The field to merge from</param>
        /// <returns>True if the field was merged, false otherwise</returns>
        public bool TryMergeFieldFrom(CodedInputStream stream)
        {
            if (valuesByTag.TryGetValue(stream.LastTag, out var extensionValue))
            {
                extensionValue.MergeForm(stream);
                return true;
            }
            else 
            {
                return false;
            }
        }

        /// <summary>
        /// Writes this set into the specified <see cref="CodedOutputStream"/>
        /// </summary>
        /// <param name="stream"></param>
        public void WriteTo(CodedOutputStream stream)
        {
            foreach(var value in valuesByIdentifier.Values)
            {
                value.WriteTo(stream);
            }
        }

        /// <summary>
        /// Gets the extension set's hash code
        /// </summary>
        /// <returns>This extension set's hash code</returns>
        public override int GetHashCode()
        {
            int ret = 1;
            foreach (KeyValuePair<Extension, IExtensionValue> field in valuesByIdentifier)
            {
                // Use ^ here to make the field order irrelevant.
                int hash = field.Key.GetHashCode() ^ field.Value.GetHashCode();
                ret ^= hash;
            }
            return ret;
        }

        /// <summary>
        /// Gets the number of bytes required to encode this set
        /// </summary>
        /// <returns>The number of bytes required to encode this set</returns>
        public int CalculateSize()
        {
            int size = 0;
            foreach(var value in valuesByIdentifier.Values)
            {
                size += value.CalculateSize();
            }
            return size;
        }

        /// <summary>
        /// Clones the first set into the specified extension set
        /// </summary>
        protected static void Clone(ExtensionSet first, ExtensionSet second)
        {
            foreach(var extensionValuePair in first.valuesByIdentifier)
            {
                var clonedValue = extensionValuePair.Value.Clone();
                second.valuesByIdentifier[extensionValuePair.Key] = clonedValue;
                second.valuesByTag[extensionValuePair.Key.Tag] = clonedValue;
            }
        }

        /// <summary>
        /// Merges the first extension set into the second set
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        protected static void MergeSets(ExtensionSet first, ExtensionSet second)
        {
            if (first.targetType != second.targetType)
                return;

            foreach(var pair in first.valuesByIdentifier)
            {
                if (second.TryGetValueFor(pair.Key, out var value))
                {
                    value.MergeFrom(pair.Value);
                }
                else
                {
                    var newValue = pair.Value.Clone();
                    second.valuesByIdentifier[pair.Key] = newValue;
                    second.valuesByTag[pair.Key.Tag] = newValue;
                }
            }
        }

        /// <summary>
        /// Returns whether the first and second sets are equal
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        protected static bool SetsEqual(ExtensionSet first, ExtensionSet second)
        {
            if (first.targetType != second.targetType)
                return false;

            if (first.valuesByIdentifier.Count != second.valuesByIdentifier.Count)
                return false;

            foreach(var pair in first.valuesByIdentifier)
            {
                if (!second.valuesByIdentifier.TryGetValue(pair.Key, out var secondValue))
                {
                    return false;
                }

                if (!pair.Value.Equals(secondValue))
                {
                    return false;
                }
            }

            return true;
        }
    }

    /// <summary>
    /// Contains a set of extension values
    /// </summary>
    /// <typeparam name="TTarget"></typeparam>
    public sealed class ExtensionSet<TTarget> : ExtensionSet, IDeepCloneable<ExtensionSet<TTarget>>, IEquatable<ExtensionSet<TTarget>> where TTarget : IExtensionMessage<TTarget>
    {
        /// <summary>
        /// Creates a new empty extension set
        /// </summary>
        public ExtensionSet() : base(typeof(TTarget)) { }

        /// <summary>
        /// Registers the specified extension
        /// </summary>
        /// <param name="extension">The extension to register</param>
        public void Register<TValue>(Extension<TTarget, TValue> extension) => Register((Extension)extension);

        /// <summary>
        /// Gets the value of the specified extension
        /// </summary>
        public TValue Get<TValue>(Extension<TTarget, TValue> extension)
        {
            if (TryGetValueFor(extension, out var value))
            {
                return ((ExtensionValue<TValue>)value).GetValue();
            }
            else
            {
                return extension.DefaultValue; // trust the user to be safe
            }
        }

        /// <summary>
        /// Gets the value of the specified repeated extension
        /// </summary>
        public RepeatedField<TValue> Get<TValue>(RepeatedExtension<TTarget, TValue> extension)
        {
            if (TryGetValueFor(extension, out var value))
            {
                return ((RepeatedExtensionValue<TValue>)value).GetValue();
            }
            else
            {
                throw new InvalidOperationException("Could not find field for extension");
            }
        }

        /// <summary>
        /// Sets the value of the specified extension
        /// </summary>
        public void Set<TValue>(Extension<TTarget, TValue> extension, TValue value)
        {
            if (TryGetValueFor(extension, out var extensionValue))
            {
                ((ExtensionValue<TValue>)extensionValue).SetValue(value);
            }
            else
            {
                throw new InvalidOperationException("Could not find field for extension");
            }
        }

        /// <summary>
        /// Gets whether the specified extension has a value
        /// </summary>
        public bool Has<TValue>(Extension<TTarget, TValue> extension)
        {
            if (TryGetValueFor(extension, out var value))
            {
                return ((ExtensionValue<TValue>)value).HasValue;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Clears the value of the specified extension
        /// </summary>
        public void Clear<TValue>(Extension<TTarget, TValue> extension)
        {
            if (TryGetValueFor(extension, out var value))
            {
                ((ExtensionValue<TValue>)value).ClearValue();
            }
        }

        /// <summary>
        /// Merges the specified <see cref="ExtensionSet{TTarget}"/> into this set
        /// </summary>
        /// <param name="other">The set to merge from</param>
        public void MergeFrom(ExtensionSet<TTarget> other)
        {
            MergeSets(other, this);
        }

        /// <summary>
        /// Creates a new <see cref="ExtensionSet{TTarget}"/> from this set
        /// </summary>
        /// <returns>Returns a new <see cref="ExtensionSet{TTarget}"/> with the same extensions and values from this set</returns>
        public ExtensionSet<TTarget> Clone()
        {
            var newSet = new ExtensionSet<TTarget>();
            Clone(this, newSet);
            return newSet;
        }

        /// <summary>
        /// Returns whether this set and the provided set are equal
        /// </summary>
        /// <param name="other">The set to compare to</param>
        public bool Equals(ExtensionSet<TTarget> other) => SetsEqual(this, other);

        /// <summary>
        /// Returns whether this set is equal to the specified object
        /// </summary>
        /// <param name="obj">The object to compare to</param>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj is ExtensionSet<TTarget> set && Equals(set))
                return true;

            return false;
        }
    }
}
