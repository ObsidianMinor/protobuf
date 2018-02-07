using System;
using Google.Protobuf.Reflection;

namespace Google.Protobuf
{
    /// <summary>
    /// Represents an non-generic extension definition
    /// </summary>
    public interface IExtension
    {
        /// <summary>
        /// Gets the type this extension is for
        /// </summary>
        Type TargetType { get; }

        /// <summary>
        /// Gets the type of value this extension represents
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// Gets the field number this extension uses
        /// </summary>
        int FieldNumber { get; }

        /// <summary>
        /// Gets the default value of this extension
        /// </summary>
        object DefaultValue { get; }

        /// <summary>
        /// Gets the field type of this extension field
        /// </summary>
        FieldType FieldType { get; }
    }

    /// <summary>
    /// An extension identifier which can be used to get an extension's value
    /// </summary>
    public sealed class Extension<TTarget, TValue> : IExtension where TTarget : IExtensionMessage<TTarget>
    {
        /// <summary>
        /// Creates a new extension identifier with the specified field type, number, and default value
        /// </summary>
        /// <param name="type"></param>
        /// <param name="number"></param>
        /// <param name="defaultValue"></param>
        public Extension(FieldType type, int number, TValue defaultValue)
        {
            FieldNumber = number;
            FieldType = type;
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// Gets the field number this extension uses
        /// </summary>
        public int FieldNumber { get; }

        /// <summary>
        /// Gets the field type of this extension field
        /// </summary>
        public FieldType FieldType { get; }

        Type IExtension.ValueType => typeof(TValue);

        Type IExtension.TargetType => typeof(TTarget);

        object IExtension.DefaultValue => DefaultValue;

        /// <summary>
        /// Gets the default value of this extension
        /// </summary>
        public TValue DefaultValue { get; }
    }
}
