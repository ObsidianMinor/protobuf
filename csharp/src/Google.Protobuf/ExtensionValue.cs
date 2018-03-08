using System;

namespace Google.Protobuf
{
    public interface IExtensionValue : IEquatable<IExtensionValue>, IDeepCloneable<IExtensionValue>
    {
        void MergeForm(CodedInputStream stream);
        void MergeFrom(IExtensionValue value);
        void WriteTo(CodedOutputStream value);
        int CalculateSize();
    }

    internal sealed class ExtensionValue<T> : IExtensionValue
    {
        private T value;
        private FieldCodec<T> codec;

        public int CalculateSize()
        {
            throw new NotImplementedException();
        }

        public IExtensionValue Clone()
        {
            throw new NotImplementedException();
        }

        public bool Equals(IExtensionValue other)
        {
            throw new NotImplementedException();
        }

        public void MergeForm(CodedInputStream stream)
        {
            throw new NotImplementedException();
        }

        public void MergeFrom(IExtensionValue value)
        {
            throw new NotImplementedException();
        }

        public void WriteTo(CodedOutputStream value)
        {
            throw new NotImplementedException();
        }
    }

    internal sealed class RepeatedExtensionValue<T> : IExtensionValue
    {
        public int CalculateSize()
        {
            throw new NotImplementedException();
        }

        public IExtensionValue Clone()
        {
            throw new NotImplementedException();
        }

        public bool Equals(IExtensionValue other)
        {
            throw new NotImplementedException();
        }

        public void MergeForm(CodedInputStream stream)
        {
            throw new NotImplementedException();
        }

        public void MergeFrom(IExtensionValue value)
        {
            throw new NotImplementedException();
        }

        public void WriteTo(CodedOutputStream value)
        {
            throw new NotImplementedException();
        }
    }
}
