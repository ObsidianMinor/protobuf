﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Google.Protobuf
{
    /// <summary>
    /// Provides extensions to messages
    /// </summary>
    public sealed class ExtensionRegistry : ICollection<Extension>, IDeepCloneable<ExtensionRegistry>
    {
        private Dictionary<Type, ICollection<Extension>> extensions;

        /// <summary>
        /// Creates a new empty extension registry
        /// </summary>
        public ExtensionRegistry() : this(new Dictionary<Type, ICollection<Extension>>()) { }

        private ExtensionRegistry(Dictionary<Type, ICollection<Extension>> collection)
        {
            extensions = collection;
        }

        /// <summary>
        /// Gets the total number of extensions in this extension registry
        /// </summary>
        public int Count => extensions.Values.Sum(c => c.Count);

        /// <summary>
        /// Returns whether the registry is readonly
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds the specified extension to the registry
        /// </summary>
        public void Add(Extension extension)
        {
            if (extension is null)
                throw new ArgumentNullException(nameof(extension));

            if (extensions.TryGetValue(extension.TargetType, out var collection))
            {
                collection.Add(extension);
            }
            else
            {
                extensions.Add(extension.TargetType, new List<Extension> { extension });
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
        /// Clears the registry of all values
        /// </summary>
        public void Clear()
        {
            extensions.Clear();
        }

        /// <summary>
        /// Gets whether the extension registry contains the specified extension
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(Extension item)
        {
            return extensions.TryGetValue(item.TargetType, out var collection) && collection.Contains(item);
        }

        /// <summary>
        /// Copies the arrays in the registry set to the specified array at the specified index
        /// </summary>
        /// <param name="array">The array to copy to</param>
        /// <param name="arrayIndex">The array index to start at</param>
        public void CopyTo(Extension[] array, int arrayIndex)
        {
            foreach(var collection in extensions.Values)
            {
                collection.CopyTo(array, arrayIndex);
                arrayIndex += collection.Count;
            }
        }

        /// <summary>
        /// Returns an enumerator to enumerate through the items in the registry
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Extension> GetEnumerator()
        {
            foreach (var collection in extensions.Values)
                foreach (var extension in collection)
                    yield return extension;
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

        /// <summary>
        /// Removes the specified extension from the set
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(Extension item)
        {
            return extensions.TryGetValue(item.TargetType, out var collection) && collection.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Clones the registry into a new registry
        /// </summary>
        public ExtensionRegistry Clone()
        {
            return new ExtensionRegistry(extensions.ToDictionary(kvp => kvp.Key, kvp => (ICollection<Extension>)new List<Extension>(kvp.Value)));
        }
    }
}
