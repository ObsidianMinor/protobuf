using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace Google.Protobuf.Reflection
{
    internal sealed class ExtensionAccessor : IFieldAccessor
    {
        private readonly Extension extension;
        private readonly ReflectionUtil.IExtensionReflectionHelper helper;

        internal ExtensionAccessor(FieldDescriptor descriptor)
        {
            Descriptor = descriptor;
            extension = descriptor.Extension;
            helper = ReflectionUtil.CreateExtensionHelper(extension);
        }

        public FieldDescriptor Descriptor { get; }

        public void Clear(IMessage message)
        {
            helper.ClearExtension(message, extension);
        }

        public object GetValue(IMessage message)
        {
            return helper.GetExtension(message, extension);
        }

        public void SetValue(IMessage message, object value)
        {
            helper.SetExtension(message, extension, value);
        }
    }
}
