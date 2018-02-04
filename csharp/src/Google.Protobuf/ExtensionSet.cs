using System;

namespace Google.Protobuf
{
    /// <summary>
    /// Used to get and set the values of extension fields defined on other types
    /// </summary>
    public abstract class ExtensionSet
    {
        internal void RegisterInternal(Extension extension) => throw new NotImplementedException();
    }

    /// <summary>
    /// Contains a set of extension values
    /// </summary>
    /// <typeparam name="TTarget"></typeparam>
    public sealed class ExtensionSet<TTarget> : ExtensionSet where TTarget : IExtensionMessage<TTarget>
    {
        /// <summary>
        /// Registers the specified Extension as a 
        /// </summary>
        /// <param name="extension"></param>
        public void Register<TValue>(Extension<TTarget, TValue> extension) => throw new NotImplementedException();
    }
}
