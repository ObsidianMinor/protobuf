using System;

namespace Google.Protobuf
{
    /// <summary>
    /// Represents an non-generic extension definition
    /// </summary>
    public abstract class Extension
    {
        /// <summary>
        /// Gets the type this extension is for
        /// </summary>
        internal abstract Type TargetType { get; }
        
        internal abstract IExtensionValue GetValue();
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
        public Extension(FieldCodec<TValue> codec)
        {
            this.codec = codec;
        }

        internal override Type TargetType => typeof(TTarget);

        internal override IExtensionValue GetValue()
        {
            return new ExtensionValue<TValue>();
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
        public RepeatedExtension(FieldCodec<TValue> codec)
        {
            this.codec = codec;
        }

        internal override Type TargetType => typeof(TTarget);

        internal override IExtensionValue GetValue()
        {
            return new RepeatedExtensionValue<TValue>();
        }
    }
}
