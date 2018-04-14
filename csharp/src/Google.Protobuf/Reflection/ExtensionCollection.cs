using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Google.Protobuf.Reflection
{
    /// <summary>
    /// Represents a collection of extension fields in a message or file
    /// </summary>
    public class ExtensionCollection
    {
        private readonly FileDescriptor file;
        private readonly MessageDescriptor message;

        private IDictionary<MessageDescriptor, IList<FieldDescriptor>> extensionsByTypeInDeclarationOrder;
        private IDictionary<MessageDescriptor, IList<FieldDescriptor>> extensionsByTypeInNumberOrder;

        internal ExtensionCollection(FileDescriptor file, Extension[] extensions)
        {
            this.file = file;
            UnorderedExtensions = DescriptorUtil.ConvertAndMakeReadOnly(
                file.Proto.Extension,
                (extension, i) => new FieldDescriptor(extension, file, null, i, null, extensions[i]));
        }

        internal ExtensionCollection(MessageDescriptor message, Extension[] extensions)
        {
            this.message = message;
            UnorderedExtensions = DescriptorUtil.ConvertAndMakeReadOnly(
                message.Proto.Extension,
                (extension, i) => new FieldDescriptor(extension, message.File, message, i, null, extensions[i]));
        }

        /// <summary>
        /// Returns a readonly list of all the extensions defined in this type in 
        /// the order they were defined in the source .proto file
        /// </summary>
        public IList<FieldDescriptor> UnorderedExtensions { get; }

        /// <summary>
        /// Returns a readonly list of all the extensions define in this type that extend 
        /// the provided descriptor type in the order they were defined in the source .proto file
        /// </summary>
        public IList<FieldDescriptor> GetExtensionsInDeclarationOrder(MessageDescriptor descriptor)
        {
            return extensionsByTypeInDeclarationOrder[descriptor];
        }

        /// <summary>
        /// Returns a readonly list of all the extensions define in this type that extend 
        /// the provided descriptor type in accending field order
        /// </summary>
        public IList<FieldDescriptor> GetExtensionsInNumberOrder(MessageDescriptor descriptor)
        {
            return extensionsByTypeInNumberOrder[descriptor];
        }

        internal void CrossLink()
        {
            Dictionary<MessageDescriptor, IList<FieldDescriptor>> declarationOrder = new Dictionary<MessageDescriptor, IList<FieldDescriptor>>();
            foreach(FieldDescriptor descriptor in UnorderedExtensions)
            {
                descriptor.CrossLink();

                if (!declarationOrder.TryGetValue(descriptor.ExtendeeType, out _))
                    declarationOrder.Add(descriptor.ExtendeeType, new List<FieldDescriptor>());

                declarationOrder[descriptor.ExtendeeType].Add(descriptor);
            }

            extensionsByTypeInDeclarationOrder = declarationOrder
                .ToDictionary(kvp => kvp.Key, kvp => (IList<FieldDescriptor>)new ReadOnlyCollection<FieldDescriptor>(kvp.Value));
            extensionsByTypeInNumberOrder = declarationOrder
                .ToDictionary(kvp => kvp.Key, kvp => (IList<FieldDescriptor>)new ReadOnlyCollection<FieldDescriptor>(kvp.Value.OrderBy(field => field.FieldNumber).ToArray()));
        }
    }
}
