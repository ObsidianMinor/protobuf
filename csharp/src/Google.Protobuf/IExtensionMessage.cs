using Google.Protobuf.Collections;

namespace Google.Protobuf
{
    /// <summary>
    /// Interface for a Protocol Buffers message, supporting basic operations for serialization as well as getting and setting extension field values
    /// </summary>
    public interface IExtensionMessage : IMessage
    {
        /// <summary>
        /// Registers an extension in this message
        /// </summary>
        /// <param name="extension">The extension</param>
        void RegisterExtension(Extension extension);
    }

    /// <summary>
    /// Generic interface for a Protocol Buffers message containing one or more extensions, where the type parameter is expected to be the same type as the implementation class
    /// </summary>
    public interface IExtensionMessage<T> : IExtensionMessage, IMessage<T> where T : IExtensionMessage<T>
    {
        /// <summary>
        /// Gets the value of the specified extension
        /// </summary>
        TValue GetExtension<TValue>(Extension<T, TValue> extension);

        /// <summary>
        /// Gets the value of the specified repeated extension
        /// </summary>
        RepeatedField<TValue> GetExtension<TValue>(RepeatedExtension<T, TValue> extension);

        /// <summary>
        /// Sets the value of the specified extension
        /// </summary>
        void SetExtension<TValue>(Extension<T, TValue> extension, TValue value);

        /// <summary>
        /// Gets whether the value of the specified extension is set
        /// </summary>
        bool HasExtension<TValue>(Extension<T, TValue> extension);

        /// <summary>
        /// Clears the value of the specified extension
        /// </summary>
        void ClearExtension<TValue>(Extension<T, TValue> extension);
    }
}
