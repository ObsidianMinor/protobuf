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

        internal IExtensionValue GetValueFor(Extension extension)
        {
            if (extension.TargetType != targetType)
                throw new ArgumentException($"Type of extension does not match target type of set: Expected {targetType}, got {extension.TargetType}");

            if (valuesByIdentifier.TryGetValue(extension, out var value))
                return value;
            else
                throw new InvalidOperationException("The set does not have a registered extension for this extension");
        }

        internal bool TryGetValueFor(Extension extension, out IExtensionValue extensionValue)
        {
            return valuesByIdentifier.TryGetValue(extension, out extensionValue);
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
                throw new InvalidOperationException("The specified extension is already registered in this set");

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
        public override int GetHashCode() => throw new NotImplementedException();

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
    }

    /// <summary>
    /// Contains a set of extension values
    /// </summary>
    /// <typeparam name="TTarget"></typeparam>
    public sealed class ExtensionSet<TTarget> : ExtensionSet where TTarget : IExtensionMessage<TTarget>
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
            var value = (ExtensionValue<TValue>)GetValueFor(extension);
            return value.GetValue();
        }

        /// <summary>
        /// Gets the value of the specified repeated extension
        /// </summary>
        public RepeatedField<TValue> Get<TValue>(RepeatedExtension<TTarget, TValue> extension) => throw new NotImplementedException();

        /// <summary>
        /// Sets the value of the specified extension
        /// </summary>
        public void Set<TValue>(Extension<TTarget, TValue> extension, TValue value)
        {
            var extensionValue = (ExtensionValue<TValue>)GetValueFor(extension);
            extensionValue.SetValue(value);
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
        public void MergeFrom(ExtensionSet<TTarget> other) => throw new NotImplementedException();

        /// <summary>
        /// Creates a new <see cref="ExtensionSet{TTarget}"/> from this set
        /// </summary>
        /// <returns>Returns a new <see cref="ExtensionSet{TTarget}"/> with the same extensions and values from this set</returns>
        public ExtensionSet<TTarget> Clone() => throw new NotImplementedException();
    }
}
