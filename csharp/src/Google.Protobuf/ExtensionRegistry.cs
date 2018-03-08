using System;
using System.Collections.Generic;

namespace Google.Protobuf
{
    /// <summary>
    /// Provides extensions to messages
    /// </summary>
    public sealed class ExtensionRegistry
    {
        private Dictionary<Type, ICollection<Extension>> extensions = new Dictionary<Type, ICollection<Extension>>();

        public void Add(Extension extension)
        {
            if (extensions.TryGetValue(extension.GetType(), out var collection))
            {
                collection.Add(extension);
            }
            else
            {
                extensions.Add(extension.GetType(), new List<Extension> { extension });
            }
        }

        public void Add(params Extension[] newExtensions) => Add((IEnumerable<Extension>)newExtensions);

        public void Add(IEnumerable<Extension> newExtensions)
        {
            foreach (var extension in newExtensions)
                Add(extension);
        }

        public void Remove(Extension extension)
        {

        }

        /// <summary>
        /// Searches the registry for extensions
        /// </summary>
        /// <param name="message"></param>
        public void RegisterExtensionsFor(IExtensionMessage message)
        {
            if (extensions.TryGetValue(message.GetType(), out var collection))
            {
                foreach(var extension in collection)
                {
                    message.RegisterExtension(extension);
                }
            }
        }
    }
}
