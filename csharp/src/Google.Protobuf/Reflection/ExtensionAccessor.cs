using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace Google.Protobuf.Reflection
{
    internal sealed class ExtensionAccessor : IFieldAccessor
    {
        private readonly Action<IMessage, Extension> clearDelegate;
        private readonly Func<IMessage, Extension, object> getDelegate;
        private readonly Action<IMessage, Extension, object> setDelegate;
        private readonly Extension extension;

        internal ExtensionAccessor(FieldDescriptor descriptor)
        {
            Descriptor = descriptor;
            extension = descriptor.Extension;
            Type extensionType = descriptor.Extension.GetType();
            Type extensionTTarget = extension.TargetType;

            MethodInfo getMethod = GetExtensionMethod(extensionTTarget, "GetExtension", extensionType);
            getDelegate = ReflectionUtil.CreateFuncIMessageExtensionObject(getMethod);

            if (!descriptor.IsRepeated)
            {
                MethodInfo setMethod = GetExtensionMethod(extensionTTarget, "SetExtension", extensionType);
                MethodInfo clearMethod = GetExtensionMethod(extensionTTarget, "ClearExtension", extensionType);
                setDelegate = ReflectionUtil.CreateActionIMessageExtensionObject(setMethod);
                clearDelegate = ReflectionUtil.CreateActionIMessageExtension(clearMethod);
            }
            else
            {
                setDelegate = (_, __, ___) => throw new InvalidOperationException("SetValue is not implemented for repeated fields");
                clearDelegate = (m, e) => (getDelegate(m, e) as IList).Clear();
            }
        }

        private static MethodInfo GetExtensionMethod(Type extensionMessageType, string name, Type extensionType)
        {
            return extensionMessageType
                .GetRuntimeMethods()
                .Where(x => x.Name == name)
                .First(x => x
                    .GetParameters()
                    .First().ParameterType.GetGenericTypeDefinition() == extensionType.GetGenericTypeDefinition())
                .MakeGenericMethod(extensionType.GenericTypeArguments[1]);
        }

        public FieldDescriptor Descriptor { get; }

        public void Clear(IMessage message)
        {
            CheckIsExtensionMessage(message);
            clearDelegate(message, extension);
        }

        public object GetValue(IMessage message)
        {
            CheckIsExtensionMessage(message);
            return getDelegate(message, extension);
        }

        public void SetValue(IMessage message, object value)
        {
            CheckIsExtensionMessage(message);
            setDelegate(message, extension, value);
        }

        private void CheckIsExtensionMessage(IMessage message)
        {
            if (!(message is IExtensionMessage))
                throw new InvalidCastException("Cannot access extension on message that isn't IExtensionMessage");
        }
    }
}
