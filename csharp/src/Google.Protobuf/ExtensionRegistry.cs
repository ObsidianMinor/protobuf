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

        /// <summary>
        /// Adds the specified extension to the registry
        /// </summary>
        public void Add(Extension extension)
        {
            if (extension is null)
                throw new ArgumentNullException(nameof(extension));

            if (extensions.TryGetValue(extension.GetType(), out var collection))
            {
                collection.Add(extension);
            }
            else
            {
                extensions.Add(extension.GetType(), new List<Extension> { extension });
            }
        }

        /// <summary>
        /// Adds the specified extensions to the registry
        /// </summary>
        public void Add(params Extension[] newExtensions) 
        { 
            if (newExtensions is null)
                throw new ArgumentNullException(nameof(newExtensions));

            Add((IEnumerable<Extension>)newExtensions);
        }

        /// <summary>
        /// Adds the specified extensions to the reigstry
        /// </summary>
        public void Add(IEnumerable<Extension> newExtensions)
        {
            if (newExtensions is null)
                throw new ArgumentNullException(nameof(newExtensions));
                
            foreach (var extension in newExtensions)
                Add(extension);
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
