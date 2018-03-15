#region Copyright notice and license
// Protocol Buffers - Google's data interchange format
// Copyright 2015 Google Inc.  All rights reserved.
// https://developers.google.com/protocol-buffers/
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//     * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//     * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion

using Google.Protobuf.Collections;
using Google.Protobuf.Compatibility;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;

namespace Google.Protobuf
{
    /// <summary>
    /// Factory methods for <see cref="FieldCodec{T}"/>.
    /// </summary>
    public static class FieldCodec
    {
        // TODO: Avoid the "dual hit" of lambda expressions: create open delegates instead. (At least test...)

        /// <summary>
        /// Retrieves a codec suitable for a string field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<string> ForString(uint tag, string defaultValue = "")
        {
            return new FieldCodec<string>(
                input => input.ReadString(),
                (output, value) => output.WriteString(value),
                (ref string old, string newVal) => old = newVal,
                CodedOutputStream.ComputeStringSize,
                tag, null,
                defaultValue ?? "");
        }

        /// <summary>
        /// Retrieves a codec suitable for a bytes field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<ByteString> ForBytes(uint tag, ByteString defaultValue = null)
        {
            return new FieldCodec<ByteString>(
                input => input.ReadBytes(),
                (output, value) => output.WriteBytes(value),
                (ref ByteString old, ByteString newVal) => old = newVal,
                CodedOutputStream.ComputeBytesSize,
                tag, null,
                defaultValue ?? ByteString.Empty);
        }

        /// <summary>
        /// Retrieves a codec suitable for a bool field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<bool> ForBool(uint tag, bool defaultValue = false)
        {
            return new FieldCodec<bool>(
                input => input.ReadBool(),
                (output, value) => output.WriteBool(value),
                (ref bool old, bool newVal) => old = newVal,
                CodedOutputStream.ComputeBoolSize,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for an int32 field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<int> ForInt32(uint tag, int defaultValue = 0)
        {
            return new FieldCodec<int>(
                input => input.ReadInt32(),
                (output, value) => output.WriteInt32(value),
                (ref int old, int newVal) => old = newVal,
                CodedOutputStream.ComputeInt32Size,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for an sint32 field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<int> ForSInt32(uint tag, int defaultValue = 0)
        {
            return new FieldCodec<int>(
                input => input.ReadSInt32(),
                (output, value) => output.WriteSInt32(value),
                (ref int old, int newVal) => old = newVal,
                CodedOutputStream.ComputeSInt32Size,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for a fixed32 field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<uint> ForFixed32(uint tag, uint defaultValue = 0)
        {
            return new FieldCodec<uint>(
                input => input.ReadFixed32(),
                (output, value) => output.WriteFixed32(value),
                (ref uint old, uint newVal) => old = newVal,
                4,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for an sfixed32 field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<int> ForSFixed32(uint tag, int defaultValue = 0)
        {
            return new FieldCodec<int>(
                input => input.ReadSFixed32(),
                (output, value) => output.WriteSFixed32(value),
                (ref int old, int newVal) => old = newVal,
                4,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for a uint32 field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<uint> ForUInt32(uint tag, uint defaultValue = 0)
        {
            return new FieldCodec<uint>(
                input => input.ReadUInt32(),
                (output, value) => output.WriteUInt32(value),
                (ref uint old, uint newVal) => old = newVal,
                CodedOutputStream.ComputeUInt32Size,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for an int64 field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<long> ForInt64(uint tag, long defaultValue = 0)
        {
            return new FieldCodec<long>(
                input => input.ReadInt64(),
                (output, value) => output.WriteInt64(value),
                (ref long old, long newVal) => old = newVal,
                CodedOutputStream.ComputeInt64Size,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for an sint64 field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<long> ForSInt64(uint tag, long defaultValue = 0)
        {
            return new FieldCodec<long>(
                input => input.ReadSInt64(),
                (output, value) => output.WriteSInt64(value),
                (ref long old, long newVal) => old = newVal,
                CodedOutputStream.ComputeSInt64Size, 
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for a fixed64 field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<ulong> ForFixed64(uint tag, ulong defaultValue = 0)
        {
            return new FieldCodec<ulong>(
                input => input.ReadFixed64(),
                (output, value) => output.WriteFixed64(value),
                (ref ulong old, ulong newVal) => old = newVal,
                8,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for an sfixed64 field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<long> ForSFixed64(uint tag, long defaultValue = 0)
        {
            return new FieldCodec<long>(
                input => input.ReadSFixed64(),
                (output, value) => output.WriteSFixed64(value),
                (ref long old, long newVal) => old = newVal,
                8,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for a uint64 field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<ulong> ForUInt64(uint tag, ulong defaultValue = 0)
        {
            return new FieldCodec<ulong>(
                input => input.ReadUInt64(),
                (output, value) => output.WriteUInt64(value),
                (ref ulong old, ulong newVal) => old = newVal,
                CodedOutputStream.ComputeUInt64Size,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for a float field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<float> ForFloat(uint tag, float defaultValue = 0)
        {
            return new FieldCodec<float>(
                input => input.ReadFloat(),
                (output, value) => output.WriteFloat(value),
                (ref float old, float newVal) => old = newVal,
                CodedOutputStream.ComputeFloatSize,
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for a double field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<double> ForDouble(uint tag, double defaultValue = 0)
        {
            return new FieldCodec<double>(
                input => input.ReadDouble(),
                (output, value) => output.WriteDouble(value),
                (ref double old, double newVal) => old = newVal,
                CodedOutputStream.ComputeDoubleSize,
                tag, null,
                defaultValue);
        }

        // Enums are tricky. We can probably use expression trees to build these delegates automatically,
        // but it's easy to generate the code for it.

        /// <summary>
        /// Retrieves a codec suitable for an enum field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="toInt32">A conversion function from <see cref="Int32"/> to the enum type.</param>
        /// <param name="fromInt32">A conversion function from the enum type to <see cref="Int32"/>.</param>
        /// <param name="defaultValue">The default value of the codec</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<T> ForEnum<T>(uint tag, Func<T, int> toInt32, Func<int, T> fromInt32, T defaultValue = default(T))
        {
            return new FieldCodec<T>(
                input => fromInt32(input.ReadEnum()),
                (output, value) => output.WriteEnum(toInt32(value)),
                (ref T old, T newVal) => old = newVal,
                value => CodedOutputStream.ComputeEnumSize(toInt32(value)),
                tag, null,
                defaultValue);
        }

        /// <summary>
        /// Retrieves a codec suitable for a message field with the given tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="parser">A parser to use for the message type.</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<T> ForMessage<T>(uint tag, MessageParser<T> parser) where T : IMessage<T>
        {
            return new FieldCodec<T>(
                input => 
                {
                    var value = parser.CreateTemplate();
                    input.ReadMessage(value);
                    return value;
                },
                (output, value) => output.WriteMessage(value),
                (ref T old, T newVal) => old.MergeFrom(newVal),
                message => CodedOutputStream.ComputeMessageSize(message),
                tag,
                null,
                default(T));
        }

        /// <summary>
        /// Retrieves a codec suitable for a group field with the given start tag
        /// </summary>
        /// <param name="startTag">The start tag of the group</param>
        /// <param name="endTag">The end tag of the group</param>
        /// <param name="parser">A parser to use for the message type.</param>
        /// <returns>A codec for the given tag.</returns>
        public static FieldCodec<T> ForGroup<T>(uint startTag, uint endTag, MessageParser<T> parser) where T : IMessage<T>
        {
            return new FieldCodec<T>(
                input =>
                {
                    var value = parser.CreateTemplate();
                    input.ReadGroup(value);
                    return value;
                },
                (output, value) => output.WriteGroup(value),
                (ref T old, T newVal) => old.MergeFrom(newVal),
                message => CodedOutputStream.ComputeGroupSize(message),
                startTag,
                endTag,
                default(T));
        }

        /// <summary>
        /// Creates a codec for a wrapper type of a class - which must be string or ByteString.
        /// </summary>
        public static FieldCodec<T> ForClassWrapper<T>(uint tag) where T : class
        {
            var nestedCodec = WrapperCodecs.GetCodec<T>();
            return new FieldCodec<T>(
                input => WrapperCodecs.Read(input, nestedCodec),
                (output, value) => WrapperCodecs.Write(output, value, nestedCodec),
                (ref T old, T newVal) => old = newVal,
                value => WrapperCodecs.CalculateSize(value, nestedCodec),
                tag,
                null,
                null);
        }

        /// <summary>
        /// Creates a codec for a wrapper type of a struct - which must be Int32, Int64, UInt32, UInt64,
        /// Bool, Single or Double.
        /// </summary>
        public static FieldCodec<T?> ForStructWrapper<T>(uint tag) where T : struct
        {
            var nestedCodec = WrapperCodecs.GetCodec<T>();
            return new FieldCodec<T?>(
                input => WrapperCodecs.Read(input, nestedCodec),
                (output, value) => WrapperCodecs.Write(output, value.Value, nestedCodec),
                (ref T? value, T? newValue) => value = newValue,
                value => value == null ? 0 : WrapperCodecs.CalculateSize(value.Value, nestedCodec),
                tag,
                null,
                null);
        }

        /// <summary>
        /// Helper code to create codecs for wrapper types.
        /// </summary>
        /// <remarks>
        /// Somewhat ugly with all the static methods, but the conversions involved to/from nullable types make it
        /// slightly tricky to improve. So long as we keep the public API (ForClassWrapper, ForStructWrapper) in place,
        /// we can refactor later if we come up with something cleaner.
        /// </remarks>
        private static class WrapperCodecs
        {
            private static readonly Dictionary<System.Type, object> Codecs = new Dictionary<System.Type, object>
            {
                { typeof(bool), ForBool(WireFormat.MakeTag(WrappersReflection.WrapperValueFieldNumber, WireFormat.WireType.Varint)) },
                { typeof(int), ForInt32(WireFormat.MakeTag(WrappersReflection.WrapperValueFieldNumber, WireFormat.WireType.Varint)) },
                { typeof(long), ForInt64(WireFormat.MakeTag(WrappersReflection.WrapperValueFieldNumber, WireFormat.WireType.Varint)) },
                { typeof(uint), ForUInt32(WireFormat.MakeTag(WrappersReflection.WrapperValueFieldNumber, WireFormat.WireType.Varint)) },
                { typeof(ulong), ForUInt64(WireFormat.MakeTag(WrappersReflection.WrapperValueFieldNumber, WireFormat.WireType.Varint)) },
                { typeof(float), ForFloat(WireFormat.MakeTag(WrappersReflection.WrapperValueFieldNumber, WireFormat.WireType.Fixed32)) },
                { typeof(double), ForDouble(WireFormat.MakeTag(WrappersReflection.WrapperValueFieldNumber, WireFormat.WireType.Fixed64)) },
                { typeof(string), ForString(WireFormat.MakeTag(WrappersReflection.WrapperValueFieldNumber, WireFormat.WireType.LengthDelimited)) },
                { typeof(ByteString), ForBytes(WireFormat.MakeTag(WrappersReflection.WrapperValueFieldNumber, WireFormat.WireType.LengthDelimited)) }
            };

            /// <summary>
            /// Returns a field codec which effectively wraps a value of type T in a message.
            /// 
            /// </summary>
            internal static FieldCodec<T> GetCodec<T>()
            {
                object value;
                if (!Codecs.TryGetValue(typeof(T), out value))
                {
                    throw new InvalidOperationException("Invalid type argument requested for wrapper codec: " + typeof(T));
                }
                return (FieldCodec<T>) value;
            }

            internal static T Read<T>(CodedInputStream input, FieldCodec<T> codec)
            {
                int length = input.ReadLength();
                int oldLimit = input.PushLimit(length);

                uint tag;
                T value = codec.DefaultValue;
                while ((tag = input.ReadTag()) != 0)
                {
                    if (tag == codec.Tag)
                    {
                        value = codec.Read(input);
                    }
                    else
                    {
                        input.SkipLastField();
                    }

                }
                input.CheckReadEndOfStreamTag();
                input.PopLimit(oldLimit);

                return value;
            }

            internal static void Write<T>(CodedOutputStream output, T value, FieldCodec<T> codec)
            {
                output.WriteLength(codec.CalculateSizeWithTag(value));
                codec.WriteTagAndValue(output, value);
            }

            internal static int CalculateSize<T>(T value, FieldCodec<T> codec)
            {
                int fieldLength = codec.CalculateSizeWithTag(value);
                return CodedOutputStream.ComputeLengthSize(fieldLength) + fieldLength;
            }
        }
    }

    /// <summary>
    /// <para>
    /// An encode/decode pair for a single field. This effectively encapsulates
    /// all the information needed to read or write the field value from/to a coded
    /// stream.
    /// </para>
    /// <para>
    /// This class is public and has to be as it is used by generated code, but its public
    /// API is very limited - just what the generated code needs to call directly.
    /// </para>
    /// </summary>
    /// <remarks>
    /// This never writes default values to the stream, and does not address "packedness"
    /// in repeated fields itself, other than to know whether or not the field *should* be packed.
    /// </remarks>
    public sealed class FieldCodec<T>
    {
        private static readonly EqualityComparer<T> EqualityComparer = ProtobufEqualityComparers.GetEqualityComparer<T>();
        private static readonly T DefaultDefault;
        // Only non-nullable value types support packing. This is the simplest way of detecting that.
        private static readonly bool TypeSupportsPacking = default(T) != null;

        static FieldCodec()
        {
            if (typeof(T) == typeof(string))
            {
                DefaultDefault = (T)(object)"";
            }
            else if (typeof(T) == typeof(ByteString))
            {
                DefaultDefault = (T)(object)ByteString.Empty;
            }
            // Otherwise it's the default value of the CLR type
        }

        internal static bool IsPackedRepeatedField(uint tag) =>
            TypeSupportsPacking && WireFormat.GetTagWireType(tag) == WireFormat.WireType.LengthDelimited;

        internal bool PackedRepeatedField { get; }

        /// <summary>
        /// Returns a delegate to write a value (unconditionally) to a coded output stream.
        /// </summary>
        internal Action<CodedOutputStream, T> ValueWriter { get; }

        /// <summary>
        /// Returns the size calculator for just a value.
        /// </summary>
        internal Func<T, int> ValueSizeCalculator { get; }

        /// <summary>
        /// Returns a delegate to read a value from a coded input stream. It is assumed that
        /// the stream is already positioned on the appropriate tag.
        /// </summary>
        internal Func<CodedInputStream, T> ValueReader { get; }

        internal MergeDelegate ValueMerger { get; }

        /// <summary>
        /// Returns the fixed size for an entry, or 0 if sizes vary.
        /// </summary>
        internal int FixedSize { get; }

        /// <summary>
        /// Gets the tag of the codec.
        /// </summary>
        /// <value>
        /// The tag of the codec.
        /// </value>
        internal uint Tag { get; }

        /// <summary>
        /// Gets the end tag of the codec
        /// </summary>
        internal uint? EndTag { get; }
        
        /// <summary>
        /// Default value for this codec. Usually the same for every instance of the same type, but
        /// for string/ByteString wrapper fields the codec's default value is null, whereas for
        /// other string/ByteString fields it's "" or ByteString.Empty.
        /// </summary>
        /// <value>
        /// The default value of the codec's type.
        /// </value>
        internal T DefaultValue { get; }

        private readonly int tagSize;

        internal FieldCodec(
            Func<CodedInputStream, T> reader,
            Action<CodedOutputStream, T> writer,
            MergeDelegate merger,
            int fixedSize,
            uint tag,
            uint? endTag,
            T defaultValue)
        {
            ValueReader = reader;
            ValueWriter = writer;
            ValueMerger = merger;
            ValueSizeCalculator = (_) => fixedSize;
            FixedSize = fixedSize;
            Tag = tag;
            EndTag = endTag;
            DefaultValue = defaultValue;
            tagSize = CodedOutputStream.ComputeRawVarint32Size(tag);
            if (EndTag != null)
                tagSize *= 2;
            // Detect packed-ness once, so we can check for it within RepeatedField<T>.
            PackedRepeatedField = IsPackedRepeatedField(tag);
        }

        internal FieldCodec(
            Func<CodedInputStream, T> reader,
            Action<CodedOutputStream, T> writer,
            MergeDelegate merger,
            Func<T, int> sizeCalculator,
            uint tag,
            uint? endTag,
            T defaultValue)
        {
            ValueReader = reader;
            ValueWriter = writer;
            ValueMerger = merger;
            ValueSizeCalculator = sizeCalculator;
            FixedSize = 0;
            Tag = tag;
            EndTag = endTag;
            DefaultValue = defaultValue;
            tagSize = CodedOutputStream.ComputeRawVarint32Size(tag);
            if (EndTag != null)
                tagSize *= 2;
            // Detect packed-ness once, so we can check for it within RepeatedField<T>.
            PackedRepeatedField = IsPackedRepeatedField(tag);
        }

        internal delegate void MergeDelegate(ref T value, T newValue);

        /// <summary>
        /// Write a tag and the given value, *if* the value is not the default.
        /// </summary>
        public void WriteTagAndValue(CodedOutputStream output, T value)
        {
            if (!IsDefault(value))
            {
                output.WriteTag(Tag);
                ValueWriter(output, value);
                if (EndTag != null)
                    output.WriteTag(EndTag.Value);
            }
        }

        /// <summary>
        /// Unconditionally writes a tag and the given value to the stream
        /// </summary>
        internal void ForceWriteTagAndValue(CodedOutputStream output, T value)
        {
            output.WriteTag(Tag);
            ValueWriter(output, value);
            if (EndTag != null)
                output.WriteTag(EndTag.Value);
        }

        /// <summary>
        /// Reads a value of the codec type from the given <see cref="CodedInputStream"/>.
        /// </summary>
        /// <param name="input">The input stream to read from.</param>
        /// <returns>The value read from the stream.</returns>
        public T Read(CodedInputStream input) => ValueReader(input);

        /// <summary>
        /// Merges the value of the codec type into the specified reference from the given new value
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="value"></param>
        public void Merge(ref T value, T newValue) => ValueMerger(ref value, newValue);

        /// <summary>
        /// Calculates the size required to write the given value, with a tag,
        /// if the value is not the default.
        /// </summary>
        public int CalculateSizeWithTag(T value) => IsDefault(value) ? 0 : ValueSizeCalculator(value) + tagSize;

        /// <summary>
        /// Calculates the size required to write the given value, with a tag,
        /// even if the value is the default
        /// </summary>
        internal int ForceCalculateSizeWithTag(T value) => ValueSizeCalculator(value) + tagSize;

        private bool IsDefault(T value) => EqualityComparer.Equals(value, DefaultValue);
    }
}
