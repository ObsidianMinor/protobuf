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
        bool IsInitialized();
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
            if (hasValue)
            {
                return codec.ForceCalculateSizeWithTag(field);
            }
            else
            {
                return 0;
            }
        }

        public IExtensionValue Clone()
        {
            return new ExtensionValue<T>(codec) 
            {
                hasValue = hasValue,
                field = field
            };
        }

        public bool Equals(IExtensionValue other)
        {
            if (ReferenceEquals(this, other))
                return true;

            return other is ExtensionValue<T> value && codec.Equals(value.codec) && hasValue.Equals(value.hasValue) && Equals(field, value.field);
            // we check for equality in the codec since we could have equal field values however the values could be written in different ways
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + hasValue.GetHashCode();
                hash = hash * 31 + field.GetHashCode();
                hash = hash * 31 + codec.GetHashCode();
                return hash;
            }
        }

        public void MergeForm(CodedInputStream input)
        {
            hasValue = true;
            if (field == null)
            {
                field = codec.Read(input);
            }
            else
            {
                codec.Merge(ref field, codec.Read(input));
            }
        }

        public void MergeFrom(IExtensionValue value)
        {
            if (value is ExtensionValue<T> extensionValue)
            {
                if (extensionValue.hasValue)
                {
                    codec.Merge(ref field, extensionValue.field);
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

        public bool IsInitialized()
        {
            return field is IMessage message ? message.IsInitialized() : true;
        }

        public T GetValue() => field;

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
        private RepeatedField<T> field;
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
            return new RepeatedExtensionValue<T>(codec)
            {
                field = field
            };
        }

        public bool Equals(IExtensionValue other)
        {
            if (ReferenceEquals(this, other))
                return true;

            return other is RepeatedExtensionValue<T> value && field.Equals(value.field) && codec.Equals(value.codec);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + field.GetHashCode();
                hash = hash * 31 + codec.GetHashCode();
                return hash;
            }
        }

        public void MergeForm(CodedInputStream input)
        {
            field.AddEntriesFrom(input, codec);
        }

        public void MergeFrom(IExtensionValue value)
        {
            if (value is RepeatedExtensionValue<T> repeated)
            {
                field.Add(repeated.field);
            }
        }

        public void WriteTo(CodedOutputStream output)
        {
            field.WriteTo(output, codec);
        }

        public bool IsInitialized() => field.IsInitialized();

        public RepeatedField<T> GetValue() => field;
    }
}
