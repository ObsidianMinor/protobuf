using System;
using Google.Protobuf.Reflection;

namespace Google.Protobuf
{
    /// <summary>
    /// Represents an non-generic extension definition
    /// </summary>
    public abstract class Extension
    {
        internal Extension(FieldType type, int number, object defaultValue)
        {
            Number = number;
            FieldType = type;
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// Gets the type this extension is for
        /// </summary>
        internal abstract Type TargetType { get; }

        /// <summary>
        /// Gets the type of value this extension represents
        /// </summary>
        internal abstract Type ValueType { get; }

        /// <summary>
        /// Gets the field number this extension uses
        /// </summary>
        internal int Number { get; }

        /// <summary>
        /// Gets the default value of this extension
        /// </summary>
        internal object DefaultValue { get; }

        /// <summary>
        /// Gets the field type of this extension field
        /// </summary>
        internal FieldType FieldType { get; }
    }

    /// <summary>
    /// An extension identifier which can be used to get an extension's value
    /// </summary>
    public sealed class Extension<TTarget, TValue> : Extension where TTarget : IExtensionMessage<TTarget>
    {
        /// <summary>
        /// Creates a new extension identifier with the specified field type, number, and default value
        /// </summary>
        /// <param name="type"></param>
        /// <param name="number"></param>
        /// <param name="defaultValue"></param>
        public Extension(FieldType type, int number, TValue defaultValue) : base(type, number, defaultValue)
        {
            ValueType = typeof(TValue);
            TargetType = typeof(TTarget);
        }
        
        internal override Type ValueType { get; }

        internal override Type TargetType { get; }
    }
}
