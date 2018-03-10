using Google.Protobuf.Reflection;
using NUnit.Framework;

namespace Google.Protobuf
{
    public class ExtensionSetTest
    {
        [Test]
        public void EmptyEquality()
        {
            ExtensionSet<MessageOptions> set1 = new ExtensionSet<MessageOptions>();
            ExtensionSet<MessageOptions> set2 = new ExtensionSet<MessageOptions>();
            Assert.AreEqual(set1, set2);
            Assert.AreEqual(set1.GetHashCode(), set2.GetHashCode());
        }

        [Test]
        public void OneValueEquality()
        {
            ExtensionSet<MessageOptions> set1 = new ExtensionSet<MessageOptions>();
            ExtensionSet<MessageOptions> set2 = new ExtensionSet<MessageOptions>();
            set1.Set(UnitTest.Issues.TestProtos.UnittestCustomOptionsProto3Extensions.ComplexOpt1, new UnitTest.Issues.TestProtos.ComplexOptionType1 { Foo = 1 });
            set2.Set(UnitTest.Issues.TestProtos.UnittestCustomOptionsProto3Extensions.ComplexOpt1, new UnitTest.Issues.TestProtos.ComplexOptionType1 { Foo = 1 });

            Assert.AreEqual(set1, set2);
            Assert.AreEqual(set1.GetHashCode(), set2.GetHashCode());
        }
    }
}
