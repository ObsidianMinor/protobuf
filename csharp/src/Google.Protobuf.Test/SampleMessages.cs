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

using System;
using Google.Protobuf.TestProtos;
using Google.Protobuf.TestProtos.Proto2;
using UnitTestExtensions = Google.Protobuf.TestProtos.Proto2.UnittestExtensions;

namespace Google.Protobuf
{
    /// <summary>
    /// Helper methods to create sample instances of types generated from unit test messages.
    /// </summary>
    public class SampleMessages
    {
        /// <summary>
        /// Creates a new sample TestAllTypes message with all fields populated.
        /// The "oneof" field is populated with the string property (OneofString).
        /// </summary>
        public static TestProtos.TestAllTypes CreateFullTestAllTypes()
        {
            return new TestProtos.TestAllTypes
            {
                SingleBool = true,
                SingleBytes = ByteString.CopyFrom(1, 2, 3, 4),
                SingleDouble = 23.5,
                SingleFixed32 = 23,
                SingleFixed64 = 1234567890123,
                SingleFloat = 12.25f,
                SingleForeignEnum = TestProtos.ForeignEnum.ForeignBar,
                SingleForeignMessage = new TestProtos.ForeignMessage { C = 10 },
                SingleImportEnum = ImportEnum.ImportBaz,
                SingleImportMessage = new ImportMessage { D = 20 },
                SingleInt32 = 100,
                SingleInt64 = 3210987654321,
                SingleNestedEnum = TestProtos.TestAllTypes.Types.NestedEnum.Foo,
                SingleNestedMessage = new TestProtos.TestAllTypes.Types.NestedMessage { Bb = 35 },
                SinglePublicImportMessage = new PublicImportMessage { E = 54 },
                SingleSfixed32 = -123,
                SingleSfixed64 = -12345678901234,
                SingleSint32 = -456,
                SingleSint64 = -12345678901235,
                SingleString = "test",
                SingleUint32 = UInt32.MaxValue,
                SingleUint64 = UInt64.MaxValue,
                RepeatedBool = { true, false },
                RepeatedBytes = { ByteString.CopyFrom(1, 2, 3, 4), ByteString.CopyFrom(5, 6), ByteString.CopyFrom(new byte[1000]) },
                RepeatedDouble = { -12.25, 23.5 },
                RepeatedFixed32 = { UInt32.MaxValue, 23 },
                RepeatedFixed64 = { UInt64.MaxValue, 1234567890123 },
                RepeatedFloat = { 100f, 12.25f },
                RepeatedForeignEnum = { TestProtos.ForeignEnum.ForeignFoo, TestProtos.ForeignEnum.ForeignBar },
                RepeatedForeignMessage = { new TestProtos.ForeignMessage(), new TestProtos.ForeignMessage { C = 10 } },
                RepeatedImportEnum = { ImportEnum.ImportBaz, ImportEnum.Unspecified },
                RepeatedImportMessage = { new ImportMessage { D = 20 }, new ImportMessage { D = 25 } },
                RepeatedInt32 = { 100, 200 },
                RepeatedInt64 = { 3210987654321, Int64.MaxValue },
                RepeatedNestedEnum = { TestProtos.TestAllTypes.Types.NestedEnum.Foo, TestProtos.TestAllTypes.Types.NestedEnum.Neg },
                RepeatedNestedMessage = { new TestProtos.TestAllTypes.Types.NestedMessage { Bb = 35 }, new TestProtos.TestAllTypes.Types.NestedMessage { Bb = 10 } },
                RepeatedPublicImportMessage = { new PublicImportMessage { E = 54 }, new PublicImportMessage { E = -1 } },
                RepeatedSfixed32 = { -123, 123 },
                RepeatedSfixed64 = { -12345678901234, 12345678901234 },
                RepeatedSint32 = { -456, 100 },
                RepeatedSint64 = { -12345678901235, 123 },
                RepeatedString = { "foo", "bar" },
                RepeatedUint32 = { UInt32.MaxValue, UInt32.MinValue },
                RepeatedUint64 = { UInt64.MaxValue, UInt32.MinValue },
                OneofString = "Oneof string"
            };
        }

        public static TestAllExtensions CreateFullTestAllExtensions()
        {
            var message = new TestProtos.Proto2.TestAllExtensions();
            message.SetExtension(UnitTestExtensions.OptionalInt32Extension, 31);
            message.SetExtension(UnitTestExtensions.OptionalInt64Extension, 32);
            message.SetExtension(UnitTestExtensions.OptionalUint32Extension, 33u);
            message.SetExtension(UnitTestExtensions.OptionalUint64Extension, 34u);
            message.SetExtension(UnitTestExtensions.OptionalSint32Extension, 35);
            message.SetExtension(UnitTestExtensions.OptionalSint64Extension, 36);
            message.SetExtension(UnitTestExtensions.OptionalFixed32Extension, 37u);
            message.SetExtension(UnitTestExtensions.OptionalFixed64Extension, 38u);
            message.SetExtension(UnitTestExtensions.OptionalSfixed32Extension, 39);
            message.SetExtension(UnitTestExtensions.OptionalSfixed64Extension, 40);
            message.SetExtension(UnitTestExtensions.OptionalFloatExtension, 41.5f);
            message.SetExtension(UnitTestExtensions.OptionalDoubleExtension, 42.65d);
            message.SetExtension(UnitTestExtensions.OptionalBoolExtension, true);
            message.SetExtension(UnitTestExtensions.OptionalStringExtension, "Hello World!");
            message.SetExtension(UnitTestExtensions.OptionalBytesExtension, ByteString.CopyFromUtf8("Hello World!"));
            message.SetExtension(UnitTestExtensions.OptionalGroupExtension, new TestProtos.Proto2.OptionalGroup_extension { A = 10 });
            message.SetExtension(UnitTestExtensions.OptionalNestedMessageExtension, new TestProtos.Proto2.TestAllTypes.Types.NestedMessage { Bb = 11 });
            message.SetExtension(UnitTestExtensions.OptionalForeignMessageExtension, new TestProtos.Proto2.ForeignMessage { C = 12, D = 13 });
            message.SetExtension(UnitTestExtensions.OptionalImportMessageExtension, new ImportMessage { D = 14 });
            message.SetExtension(UnitTestExtensions.OptionalNestedEnumExtension, TestProtos.Proto2.TestAllTypes.Types.NestedEnum.Bar);
            message.SetExtension(UnitTestExtensions.OptionalForeignEnumExtension, TestProtos.Proto2.ForeignEnum.ForeignBaz);
            message.SetExtension(UnitTestExtensions.OptionalImportEnumExtension, ImportEnum.ImportFoo);
            message.SetExtension(UnitTestExtensions.OptionalStringPieceExtension, "Hello World!");
            message.SetExtension(UnitTestExtensions.OptionalCordExtension, "Hello World!");
            message.SetExtension(UnitTestExtensions.OptionalPublicImportMessageExtension, new PublicImportMessage { E = 15 });
            message.SetExtension(UnitTestExtensions.OptionalLazyMessageExtension, new TestProtos.Proto2.TestAllTypes.Types.NestedMessage { Bb = 16 });
            message.GetExtension(UnitTestExtensions.RepeatedInt32Extension).Add(new[] { 31, 31 });
            message.GetExtension(UnitTestExtensions.RepeatedInt64Extension).Add(new[] { 32L, 32L });
            message.GetExtension(UnitTestExtensions.RepeatedUint32Extension).Add(new[] { 33u, 33u });
            message.GetExtension(UnitTestExtensions.RepeatedUint64Extension).Add(new[] { 34ul, 34ul });
            message.GetExtension(UnitTestExtensions.RepeatedSint32Extension).Add(new[] { 35, 35 });
            message.GetExtension(UnitTestExtensions.RepeatedSint64Extension).Add(new[] { 36L, 36L });
            message.GetExtension(UnitTestExtensions.RepeatedFixed32Extension).Add(new[] { 37u, 37u });
            message.GetExtension(UnitTestExtensions.RepeatedFixed64Extension).Add(new[] { 38ul, 38ul });
            message.GetExtension(UnitTestExtensions.RepeatedSfixed32Extension).Add(new[] { 39, 39 });
            message.GetExtension(UnitTestExtensions.RepeatedSfixed64Extension).Add(new[] { 40L, 40L });
            message.GetExtension(UnitTestExtensions.RepeatedFloatExtension).Add(new[] { 41.5f, 41.5f });
            message.GetExtension(UnitTestExtensions.RepeatedDoubleExtension).Add(new[] { 42.65d, 42.65d });
            message.GetExtension(UnitTestExtensions.RepeatedBoolExtension).Add(new[] { true, true });
            message.GetExtension(UnitTestExtensions.RepeatedStringExtension).Add(new[] { "Hello World!", "Hello World!" });
            message.GetExtension(UnitTestExtensions.RepeatedBytesExtension).Add(new[] { ByteString.CopyFromUtf8("Hello World!"), ByteString.CopyFromUtf8("Hello World!") });
            message.GetExtension(UnitTestExtensions.RepeatedGroupExtension).Add(new[] { new TestProtos.Proto2.RepeatedGroup_extension { A = 10 }, new TestProtos.Proto2.RepeatedGroup_extension { A = 10 } });
            message.GetExtension(UnitTestExtensions.RepeatedNestedMessageExtension).Add(new[] { new TestProtos.Proto2.TestAllTypes.Types.NestedMessage { Bb = 11 }, new TestProtos.Proto2.TestAllTypes.Types.NestedMessage { Bb = 11 } });
            message.GetExtension(UnitTestExtensions.RepeatedForeignMessageExtension).Add(new[] { new TestProtos.Proto2.ForeignMessage { C = 12, D = 13 }, new TestProtos.Proto2.ForeignMessage { C = 12, D = 13 } });
            message.GetExtension(UnitTestExtensions.RepeatedImportMessageExtension).Add(new[] { new ImportMessage { D = 14 }, new ImportMessage { D = 14 } });
            message.GetExtension(UnitTestExtensions.RepeatedNestedEnumExtension).Add(new[] { TestProtos.Proto2.TestAllTypes.Types.NestedEnum.Bar, TestProtos.Proto2.TestAllTypes.Types.NestedEnum.Bar });
            message.GetExtension(UnitTestExtensions.RepeatedForeignEnumExtension).Add(new[] { TestProtos.Proto2.ForeignEnum.ForeignBaz, TestProtos.Proto2.ForeignEnum.ForeignBaz });
            message.GetExtension(UnitTestExtensions.RepeatedImportEnumExtension).Add(new[] { ImportEnum.ImportFoo, ImportEnum.ImportFoo });
            message.GetExtension(UnitTestExtensions.RepeatedStringPieceExtension).Add(new[] { "Hello World!", "Hello World!" });
            message.GetExtension(UnitTestExtensions.RepeatedCordExtension).Add(new[] { "Hello World!", "Hello World!" });
            message.GetExtension(UnitTestExtensions.RepeatedLazyMessageExtension).Add(new[] { new TestProtos.Proto2.TestAllTypes.Types.NestedMessage { Bb = 16 }, new TestProtos.Proto2.TestAllTypes.Types.NestedMessage { Bb = 16 } });
            return message;
        }
    }
}