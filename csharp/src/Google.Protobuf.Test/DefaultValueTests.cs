using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Google.Protobuf.TestProtos.Proto2;

namespace Google.Protobuf
{
    /// <summary>
    /// Test default values in proto2 message fields
    /// </summary>
    public class DefaultValueTests
    {
        [Test]
        public void SingularDefaults()
        {
            TestAllTypes types = new TestAllTypes();
            Assert.AreEqual(41, types.DefaultInt32);
            Assert.AreEqual(42, types.DefaultInt64);
            Assert.AreEqual(43, types.DefaultUint32);
            Assert.AreEqual(44, types.DefaultUint64);
            Assert.AreEqual(-45, types.DefaultSint32);
            Assert.AreEqual(46, types.DefaultSint64);
            Assert.AreEqual(47, types.DefaultFixed32);
            Assert.AreEqual(48, types.DefaultFixed64);
            Assert.AreEqual(49, types.DefaultSfixed32);
            Assert.AreEqual(-50, types.DefaultSfixed64);
            Assert.AreEqual(51.5, types.DefaultFloat);
            Assert.AreEqual(52e3, types.DefaultDouble);
            Assert.AreEqual(true, types.DefaultBool);
            Assert.AreEqual("hello", types.DefaultString);
            Assert.AreEqual(ByteString.CopyFromUtf8("world"), types.DefaultBytes);
        }

        [Test]
        public void ExtensionDefaults()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void ExtremeSingularDefaults()
        {
            TestExtremeDefaultValues extreme = new TestExtremeDefaultValues();
            Assert.AreEqual(ByteString.CopyFrom(0, 1, 7, 8, 12, 10, 13, 9, 11, 92, 39, 34, 254), extreme.EscapedBytes);
            Assert.AreEqual(0xFFFFFFFF, extreme.LargeUint32);
            Assert.AreEqual(0xFFFFFFFFFFFFFFFF, extreme.LargeUint64);
            Assert.AreEqual(-0x7FFFFFFF, extreme.SmallInt32);
            Assert.AreEqual(-0x7FFFFFFFFFFFFFFF, extreme.SmallInt64);
            Assert.AreEqual(-0x80000000, extreme.ReallySmallInt32);
            Assert.AreEqual(-0x8000000000000000, extreme.ReallySmallInt64);
            Assert.AreEqual("\u1234", extreme.Utf8String);
            Assert.AreEqual(0f, extreme.ZeroFloat);
            Assert.AreEqual(1f, extreme.OneFloat);
            Assert.AreEqual(1.5f, extreme.SmallFloat);
            Assert.AreEqual(-1f, extreme.NegativeOneFloat);
            Assert.AreEqual(-1.5f, extreme.NegativeFloat);
            Assert.AreEqual(2E8, extreme.LargeFloat);
            Assert.AreEqual(-8e-28, extreme.SmallNegativeFloat);
            Assert.AreEqual(double.PositiveInfinity, extreme.InfDouble);
            Assert.AreEqual(double.NegativeInfinity, extreme.NegInfDouble);
            Assert.AreEqual(double.NaN, extreme.NanDouble);
            Assert.AreEqual(float.PositiveInfinity, extreme.InfFloat);
            Assert.AreEqual(float.NegativeInfinity, extreme.NegInfFloat);
            Assert.AreEqual(float.NaN, extreme.NanFloat);
            Assert.AreEqual("? ? ?? ?? ??? ??/ ??-", extreme.CppTrigraph);
            Assert.AreEqual("hel\0lo", extreme.StringWithZero);
            Assert.AreEqual(ByteString.CopyFromUtf8("wor\0ld"), extreme.BytesWithZero);
            Assert.AreEqual("ab\0c", extreme.StringPieceWithZero);
            Assert.AreEqual("12\03", extreme.CordWithZero);
            Assert.AreEqual("${unknown}", extreme.ReplacementString);
        }
    }
}
