using System;

namespace Google.Protobuf
{
    /// <summary>
    /// Used to get and set the values of extension fields defined on other types
    /// </summary>
    public abstract class ExtensionSet
    {
        public void Register(IExtension extension) => throw new NotImplementedException();

        /// <summary>
        /// Attempts to merge a field from the specified input stream. 
        /// If the set does not contain an extension for the field number in the stream this returns false.
        /// </summary>
        /// <param name="stream">The field to merge from</param>
        /// <returns>True if the field was merged, false otherwise</returns>
        public bool TryMergeFieldFrom(CodedInputStream stream) => throw new NotImplementedException();

        internal void MergeFieldFrom(CodedInputStream stream) => throw new NotImplementedException();

        public void WriteTo(CodedOutputStream stream) => throw new NotImplementedException();

        public override int GetHashCode() => throw new NotImplementedException();

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
        /// <param name="extension"></param>
        public void Register<TValue>(Extension<TTarget, TValue> extension) => throw new NotImplementedException();

        public void MergeFrom(ExtensionSet<TTarget> other) => throw new NotImplementedException();

        public ExtensionSet<TTarget> Clone() => throw new NotImplementedException();
    }
}
