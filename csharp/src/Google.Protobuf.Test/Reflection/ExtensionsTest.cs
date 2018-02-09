#region Copyright notice and license
// Protocol Buffers - Google's data interchange format
// Copyright 2017 Google Inc.  All rights reserved.
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

using Google.Protobuf.Reflection;
using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;
using System.IO;
using System.Linq;
using UnitTest.Issues.TestProtos;
using static Google.Protobuf.WireFormat;
using static UnitTest.Issues.TestProtos.UnittestCustomOptionsProto3Extensions;
using static UnitTest.Issues.TestProtos.ComplexOptionType2.Types;
using static UnitTest.Issues.TestProtos.DummyMessageContainingEnum.Types;

namespace Google.Protobuf.Test.Reflection
{
    /// <summary>
    /// The majority of the testing here is done via parsed descriptors. That's simpler to
    /// achieve (and more important) than constructing a CodedInputStream manually.
    /// </summary>
    public class ExtensionsTest
    {
        delegate bool OptionFetcher<TTarget, T>(Extension<TTarget, T> field, out T value) where TTarget : IExtensionMessage<TTarget>;
        
        [Test]
        public void ScalarOptions()
        {
            var options = CustomOptionOtherValues.Descriptor;
            AssertOption(-100, options.TryGetOption, Int32Opt);
            AssertOption(12.3456789f, options.TryGetOption, FloatOpt);
            AssertOption(1.234567890123456789d, options.TryGetOption, DoubleOpt);
            AssertOption("Hello, \"World\"", options.TryGetOption, StringOpt);
            AssertOption(ByteString.CopyFromUtf8("Hello\0World"), options.TryGetOption, BytesOpt);
            AssertOption(TestEnumType.TestOptionEnumType2, options.TryGetOption, EnumOpt);
        }

        [Test]
        public void MessageOptions()
        {
            var options = VariousComplexOptions.Descriptor;
            AssertOption(new ComplexOptionType1 { Foo = 42, Foo4 = { 99, 88 } }, options.TryGetOption, ComplexOpt1);
            AssertOption(new ComplexOptionType2
            {
                Baz = 987,
                Bar = new ComplexOptionType1 { Foo = 743 },
                Fred = new ComplexOptionType4 { Waldo = 321 },
                Barney = { new ComplexOptionType4 { Waldo = 101 }, new ComplexOptionType4 { Waldo = 212 } }
            },
            options.TryGetOption, ComplexOpt2);
            AssertOption(new ComplexOptionType3 { Qux = 9 }, options.TryGetOption, ComplexOpt3);
        }

        [Test]
        public void OptionLocations()
        {
            var fileOptions = UnittestCustomOptionsProto3Reflection.Descriptor;
            AssertOption(9876543210UL, fileOptions.TryGetOption, FileOpt1);

            var messageOptions = TestMessageWithCustomOptions.Descriptor;
            AssertOption(-56, messageOptions.TryGetOption, MessageOpt1);

            var fieldOptions = TestMessageWithCustomOptions.Descriptor.Fields["field1"];
            AssertOption(8765432109UL, fieldOptions.TryGetOption, FieldOpt1);

            var oneofOptions = TestMessageWithCustomOptions.Descriptor.Oneofs[0];
            AssertOption(-99, oneofOptions.TryGetOption, OneofOpt1);

            var enumOptions = TestMessageWithCustomOptions.Descriptor.EnumTypes[0];
            AssertOption(-789, enumOptions.TryGetOption, EnumOpt1);

            var enumValueOptions = TestMessageWithCustomOptions.Descriptor.EnumTypes[0].FindValueByNumber(2);
            AssertOption(123, enumValueOptions.TryGetOption, EnumValueOpt1);

            var service = UnittestCustomOptionsProto3Reflection.Descriptor.Services
                .Single(s => s.Name == "TestServiceWithCustomOptions");
            var serviceOptions = service;
            AssertOption(-9876543210, serviceOptions.TryGetOption, ServiceOpt1);

            var methodOptions = service.Methods[0];
            AssertOption(UnitTest.Issues.TestProtos.MethodOpt1.Val2, methodOptions.TryGetOption, UnittestCustomOptionsProto3Extensions.MethodOpt1);
        }

        [Test]
        public void MinValues()
        {
            var options = CustomOptionMinIntegerValues.Descriptor;
            AssertOption(false, options.TryGetOption, BoolOpt);
            AssertOption(int.MinValue, options.TryGetOption, Int32Opt);
            AssertOption(long.MinValue, options.TryGetOption, Int64Opt);
            AssertOption(uint.MinValue, options.TryGetOption, Uint32Opt);
            AssertOption(ulong.MinValue, options.TryGetOption, Uint64Opt);
            AssertOption(int.MinValue, options.TryGetOption, Sint32Opt);
            AssertOption(long.MinValue, options.TryGetOption, Sint64Opt);
            AssertOption(uint.MinValue, options.TryGetOption, Fixed32Opt);
            AssertOption(ulong.MinValue, options.TryGetOption, Fixed64Opt);
            AssertOption(int.MinValue, options.TryGetOption, Sfixed32Opt);
            AssertOption(long.MinValue, options.TryGetOption, Sfixed64Opt);
        }

        [Test]
        public void MaxValues()
        {
            var options = CustomOptionMaxIntegerValues.Descriptor;
            AssertOption(true, options.TryGetOption, BoolOpt);
            AssertOption(int.MaxValue, options.TryGetOption, Int32Opt);
            AssertOption(long.MaxValue, options.TryGetOption, Int64Opt);
            AssertOption(uint.MaxValue, options.TryGetOption, Uint32Opt);
            AssertOption(ulong.MaxValue, options.TryGetOption, Uint64Opt);
            AssertOption(int.MaxValue, options.TryGetOption, Sint32Opt);
            AssertOption(long.MaxValue, options.TryGetOption, Sint64Opt);
            AssertOption(uint.MaxValue, options.TryGetOption, Fixed32Opt);
            AssertOption(ulong.MaxValue, options.TryGetOption, Fixed64Opt);
            AssertOption(int.MaxValue, options.TryGetOption, Sfixed32Opt);
            AssertOption(long.MaxValue, options.TryGetOption, Sfixed64Opt);
        }

        [Test]
        public void AggregateOptions()
        {
            // Just two examples
            var messageOptions = AggregateMessage.Descriptor;
            AssertOption(new Aggregate { I = 101, S = "MessageAnnotation" }, messageOptions.TryGetOption, Msgopt);

            var fieldOptions = AggregateMessage.Descriptor.Fields["fieldname"];
            AssertOption(new Aggregate { S = "FieldAnnotation" }, fieldOptions.TryGetOption, Fieldopt);
        }

        private void AssertOption<TTarget, TValue>(TValue expected, OptionFetcher<TTarget, TValue> fetcher, Extension<TTarget, TValue> field) where TTarget : IExtensionMessage<TTarget>
        {
            TValue actual;
            Assert.IsTrue(fetcher(field, out actual));
            Assert.AreEqual(expected, actual);
        }
    }
}
