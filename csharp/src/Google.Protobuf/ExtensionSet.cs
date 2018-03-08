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
        private readonly Dictionary<Extension, IExtensionValue> extensionValues;

        internal ExtensionSet(Type target)
        {
            targetType = target;
        }

        internal IExtensionValue GetValueFor(Extension extension)
        {
            if (extension.TargetType != targetType)
                throw new ArgumentException("Cannot register extension for wrong target type");

            if (extensionValues.TryGetValue(extension, out var value))
                return value;
            else
                throw new InvalidOperationException("The set does not have a registered extension for this extension");
        }

        /// <summary>
        /// Registers the specified extension in the set
        /// </summary>
        /// <param name="extension">The extension to register</param>
        public void Register(Extension extension)
        {
            if (extension.TargetType != targetType)
                throw new ArgumentException("Cannot register extension for wrong target type");

            if (extensionValues.ContainsKey(extension))
                throw new InvalidOperationException("The specified extension is already registered in this set");

            extensionValues.Add(extension, extension.GetValue());
        }

        /// <summary>
        /// Attempts to merge a field from the specified input stream.
        /// If the set does not contain an extension for the field number in the stream this returns false.
        /// </summary>
        /// <param name="stream">The field to merge from</param>
        /// <returns>True if the field was merged, false otherwise</returns>
        public bool TryMergeFieldFrom(CodedInputStream stream) => throw new NotImplementedException();

        /// <summary>
        /// Writes this set into the specified <see cref="CodedOutputStream"/>
        /// </summary>
        /// <param name="stream"></param>
        public void WriteTo(CodedOutputStream stream) => throw new NotImplementedException();

        /// <summary>
        /// Gets the extension set's hash code
        /// </summary>
        /// <returns>This extension set's hash code</returns>
        public override int GetHashCode() => throw new NotImplementedException();

        /// <summary>
        /// Gets the number of bytes required to encode this set
        /// </summary>
        /// <returns>The number of bytes required to encode this set</returns>
        public int CalculateSize() => throw new NotImplementedException();
    }

    /// <summary>
    /// Contains a set of extension values
    /// </summary>
    /// <typeparam name="TTarget"></typeparam>
    public sealed class ExtensionSet<TTarget> : ExtensionSet where TTarget : IExtensionMessage<TTarget>
    {
        public ExtensionSet() : base(typeof(TTarget)) { }

        /// <summary>
        /// Registers the specified extension
        /// </summary>
        /// <param name="extension">The extension to register</param>
        public void Register<TValue>(Extension<TTarget, TValue> extension) => Register((Extension)extension);

        public TValue Get<TValue>(Extension<TTarget, TValue> extension) => throw new NotImplementedException();

        public RepeatedField<TValue> Get<TValue>(RepeatedExtension<TTarget, TValue> extension) => throw new NotImplementedException();

        public void Set<TValue>(Extension<TTarget, TValue> extension, TValue value) => throw new NotImplementedException();

        public bool Has(Extension extension) => throw new NotImplementedException();

        public void Clear(Extension extension) => throw new NotImplementedException();

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
