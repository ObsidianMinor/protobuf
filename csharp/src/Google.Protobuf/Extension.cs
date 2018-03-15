using System;

namespace Google.Protobuf
{
    /// <summary>
    /// Represents an non-generic extension definition
    /// </summary>
    public abstract class Extension
    {
        private readonly int fieldNumber;

        internal Extension(uint tag)
        {
            fieldNumber = WireFormat.GetTagFieldNumber(tag);
        }

        internal abstract Type TargetType { get; }

        internal abstract IExtensionValue GetValue();

        /// <summary>
        /// Gets the field number of this extension
        /// </summary>
        public int FieldNumber => fieldNumber;
    }

    /// <summary>
    /// An extension identifier which can be used to get an extension's value
    /// </summary>
    public sealed class Extension<TTarget, TValue> : Extension where TTarget : IExtensionMessage<TTarget>
    {
        private FieldCodec<TValue> codec;

        /// <summary>
        /// Creates a new extension identifier with the specified codec
        /// </summary>
        public Extension(FieldCodec<TValue> codec) : base(codec.Tag)
        {
            this.codec = codec;
        }

        internal override Type TargetType => typeof(TTarget);
        
        internal TValue DefaultValue => codec.DefaultValue;

        internal override IExtensionValue GetValue()
        {
            return new ExtensionValue<TValue>(codec);
        }
    }

    /// <summary>
    /// An extension identifier which can be used to get a repeated extension's value
    /// </summary>
    public sealed class RepeatedExtension<TTarget, TValue> : Extension where TTarget : IExtensionMessage<TTarget>
    {
        private FieldCodec<TValue> codec;

        /// <summary>
        /// Creates a new extension identifier with the specified codec
        /// </summary>
        public RepeatedExtension(FieldCodec<TValue> codec) : base(codec.Tag)
        {
            this.codec = codec;
        }

        internal override Type TargetType => typeof(TTarget);
        
        internal override IExtensionValue GetValue()
        {
            return new RepeatedExtensionValue<TValue>(codec);
        }
    }
}
