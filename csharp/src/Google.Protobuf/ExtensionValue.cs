using System;
using Google.Protobuf.Collections;

namespace Google.Protobuf
{

    internal interface IExtensionValue : IEquatable<IExtensionValue>, IDeepCloneable<IExtensionValue>
    {
        void MergeForm(CodedInputStream input);
        void MergeFrom(IExtensionValue value);
        void WriteTo(CodedOutputStream output);
        int CalculateSize();
    }

    internal sealed class ExtensionValue<T> : IExtensionValue
    {
        private bool hasValue;
        private T field;
        private FieldCodec<T> codec;

        internal ExtensionValue(FieldCodec<T> codec)
        {
            this.codec = codec;
            field = codec.DefaultValue;
        }

        public int CalculateSize()
        {
            return codec.ForceCalculateSizeWithTag(field);
        }

        public IExtensionValue Clone()
        {
            return new ExtensionValue<T>(codec) 
            {
                hasValue = this.hasValue,
                field = this.field
            };
        }

        public bool Equals(IExtensionValue other)
        {
            throw new NotImplementedException();
        }

        public void MergeForm(CodedInputStream input)
        {
            hasValue = true;
            field = codec.Read(input);
        }

        public void MergeFrom(IExtensionValue value)
        {
            if (value is ExtensionValue<T> extensionValue)
            {
                if (extensionValue.hasValue)
                {
                    field = extensionValue.field;
                    hasValue = true;
                }
            }
        }

        public void WriteTo(CodedOutputStream output)
        {
            if (hasValue)
            {
                codec.ForceWriteTagAndValue(output, field);
            }
        }

        public T GetValue()
        {
            return field;
        }

        public void SetValue(T value)
        {
            hasValue = true;
            field = value;
        }

        public bool HasValue => hasValue;

        public void ClearValue() 
        { 
            hasValue = false;
            field = codec.DefaultValue;
        }
    }

    internal sealed class RepeatedExtensionValue<T> : IExtensionValue
    {
        private readonly RepeatedField<T> field;
        private readonly FieldCodec<T> codec;

        internal RepeatedExtensionValue(FieldCodec<T> codec)
        {
            this.codec = codec;
            field = new RepeatedField<T>();
        }

        public int CalculateSize()
        {
            return field.CalculateSize(codec);
        }

        public IExtensionValue Clone()
        {
            throw new NotImplementedException();
        }

        public bool Equals(IExtensionValue other)
        {
            throw new NotImplementedException();
        }

        public void MergeForm(CodedInputStream input)
        {
            field.AddEntriesFrom(input, codec);
        }

        public void MergeFrom(IExtensionValue value)
        {
            throw new NotImplementedException();
        }

        public void WriteTo(CodedOutputStream output)
        {
            field.WriteTo(output, codec);
        }
    }
}
