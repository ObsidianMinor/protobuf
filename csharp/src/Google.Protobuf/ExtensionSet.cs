using System;

namespace Google.Protobuf
{
    /// <summary>
    /// Used to get and set the values of extension fields defined on other types
    /// </summary>
    public abstract class ExtensionSet
    {
        internal void Register(IExtension extension) => throw new NotImplementedException();

        /// <summary>
        /// Attempts to merge a field from the specified input stream. 
        /// If the set does not contain an extension for the field number in the stream this returns false.
        /// </summary>
        /// <param name="stream">The field to merge from</param>
        /// <returns>True if the field was merged, false otherwise</returns>
        public bool TryMergeFieldFrom(CodedInputStream stream) => throw new NotImplementedException();

        internal void MergeFieldFrom(CodedInputStream stream) => throw new NotImplementedException();

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
        /// <summary>
        /// Registers the specified Extension
        /// </summary>
        /// <param name="extension">The extension to register</param>
        public void Register<TValue>(Extension<TTarget, TValue> extension) => throw new NotImplementedException();

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
