namespace Google.Protobuf
{
    /// <summary>
    /// Interface for a Protocol Buffers message, supporting basic operations for serialization as well as getting and setting extension field values
    /// </summary>
    public interface IExtensionMessage : IMessage
    {
        /// <summary>
        /// Gets the extension set for this message
        /// </summary>
        ExtensionSet Extensions { get; }
    }

    /// <summary>
    /// Generic interface for a Protocol Buffers message containing one or more extensions, where the type parameter is expected to be the same type as the implementation class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IExtensionMessage<T> : IExtensionMessage, IMessage<T> where T : IExtensionMessage<T>
    {
        /// <summary>
        /// Gets the extension set for this message
        /// </summary>
        new ExtensionSet<T> Extensions { get; }
    }

}
