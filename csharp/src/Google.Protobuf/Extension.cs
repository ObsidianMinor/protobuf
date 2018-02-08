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
        /// Gets the tag number of this field
        /// </summary>
        int Tag { get; }

        /// <summary>
        /// Gets the default value of this extension
        /// </summary>
        object DefaultValue { get; }
    }

    /// <summary>
    /// An extension identifier which can be used to get an extension's value
    /// </summary>
    public sealed class Extension<TTarget, TValue> : IExtension where TTarget : IExtensionMessage<TTarget>
    {
        /// <summary>
        /// Creates a new extension identifier with the specified tag and default value
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="defaultValue"></param>
        public Extension(int tag, TValue defaultValue)
        {
            Tag = tag;
            DefaultValue = defaultValue;
        }

        /// <summary>
        /// Gets the tag number of this field
        /// </summary>
        public int Tag { get; }

        Type IExtension.ValueType => typeof(TValue);

        Type IExtension.TargetType => typeof(TTarget);

        object IExtension.DefaultValue => DefaultValue;

        /// <summary>
        /// Gets the default value of this extension
        /// </summary>
        public TValue DefaultValue { get; }
    }
}
