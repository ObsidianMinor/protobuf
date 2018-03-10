using Google.Protobuf.Reflection;
using Google.Protobuf.TestProtos.Proto2;
using NUnit.Framework;
using UnitTest.Issues.TestProtos;

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
            set1.Set(UnittestCustomOptionsProto3Extensions.ComplexOpt1, new ComplexOptionType1 { Foo = 1 });
            set2.Set(UnittestCustomOptionsProto3Extensions.ComplexOpt1, new ComplexOptionType1 { Foo = 1 });

            Assert.AreEqual(set1, set2);
            Assert.AreEqual(set1.GetHashCode(), set2.GetHashCode());
        }

        /// <summary>
        /// Sets with the same values but in seperate orders should be equal with equal hash codes
        /// </summary>
        [Test]
        public void SeperateOrderEquality()
        {
            ExtensionSet<MessageOptions> set1 = new ExtensionSet<MessageOptions>();
            ExtensionSet<MessageOptions> set2 = new ExtensionSet<MessageOptions>();

            set1.Set(UnittestCustomOptionsProto3Extensions.BoolOpt, true);
            set1.Set(UnittestCustomOptionsProto3Extensions.Int32Opt, 1);

            set2.Set(UnittestCustomOptionsProto3Extensions.Int32Opt, 1);
            set2.Set(UnittestCustomOptionsProto3Extensions.BoolOpt, true);

            Assert.AreEqual(set1, set2);
            Assert.AreEqual(set1.GetHashCode(), set2.GetHashCode());
        }

        [Test]
        public void SeperateValueNoEquality()
        {
            ExtensionSet<MessageOptions> set1 = new ExtensionSet<MessageOptions>();
            ExtensionSet<MessageOptions> set2 = new ExtensionSet<MessageOptions>();

            set1.Set(UnittestCustomOptionsProto3Extensions.BoolOpt, true);
            set2.Set(UnittestCustomOptionsProto3Extensions.Int32Opt, 1);

            Assert.AreNotEqual(set1, set2);
            Assert.AreNotEqual(set1.GetHashCode(), set2.GetHashCode());
        }

        [Test]
        public void RepeatedValueEquality()
        {
            ExtensionSet<TestAllExtensions> set1 = new ExtensionSet<TestAllExtensions>();
            ExtensionSet<TestAllExtensions> set2 = new ExtensionSet<TestAllExtensions>();

            set1.Get(UnittestExtensions.RepeatedInt32Extension).AddRange(new[] { 1, 2, 3 });
            set2.Get(UnittestExtensions.RepeatedInt32Extension).AddRange(new[] { 1, 2, 3 });

            Assert.AreEqual(set1, set2);
            Assert.AreEqual(set1.GetHashCode(), set2.GetHashCode());
        }

        [Test]
        public void RepeatedSeperateOrderEquality()
        {
            ExtensionSet<TestAllExtensions> set1 = new ExtensionSet<TestAllExtensions>();
            ExtensionSet<TestAllExtensions> set2 = new ExtensionSet<TestAllExtensions>();

            set1.Get(UnittestExtensions.RepeatedInt32Extension).AddRange(new[] { 1, 2, 3 });
            set1.Get(UnittestExtensions.RepeatedFixed32Extension).AddRange(new[] { 2u, 3u, 4u });

            set2.Get(UnittestExtensions.RepeatedFixed32Extension).AddRange(new[] { 2u, 3u, 4u });
            set2.Get(UnittestExtensions.RepeatedInt32Extension).AddRange(new[] { 1, 2, 3 });

            Assert.AreEqual(set1, set2);
            Assert.AreEqual(set1.GetHashCode(), set2.GetHashCode());
        }

        [Test]
        public void HasFieldPresence()
        {
            ExtensionSet<TestAllExtensions> set1 = new ExtensionSet<TestAllExtensions>();
            Assert.False(set1.Has(UnittestExtensions.DefaultBoolExtension));

            set1.Set(UnittestExtensions.DefaultBoolExtension, true);
            Assert.True(set1.Has(UnittestExtensions.DefaultBoolExtension));

            set1.Set(UnittestExtensions.DefaultBoolExtension, false);
            Assert.True(set1.Has(UnittestExtensions.DefaultBoolExtension));

            set1.Clear(UnittestExtensions.DefaultBoolExtension);
            Assert.False(set1.Has(UnittestExtensions.DefaultBoolExtension));
        }
    }
}
