using NUnit.Framework;
using System;
using System.Collections.Generic;
using Graph;

namespace tests
{
    public class Tests
    {
        [Test]
        public void Expect_ArgumentNullException_When_NullPassedToContructor()
        {
            Assert.Throws<ArgumentNullException>(() => new Vertex<Nullable<int>>(null));
            Assert.Throws<ArgumentNullException>(() => new Vertex<int?>(null,
                new List<Vertex<int?>>() { new Vertex<int?>(0) }));
            Assert.Throws<ArgumentNullException>(() => new Vertex<int?>(0, null));
        }

        [Test]
        public void Expect_NoException_When_NotNullPassedToContructor()
        {
            Assert.DoesNotThrow(() => new Vertex<int?>(0));
            Assert.DoesNotThrow(() => new Vertex<int?>(0,
                new List<Vertex<int?>>() { new Vertex<int?>(0) }));
        }

        [Test]
        public void Expect_ArgumentNullException_When_NullPassedToValueSetter()
        {
            Assert.Throws<ArgumentNullException>(() => new Vertex<int?>(0).Value = null);
        }

        [Test]
        public void Expect_NoException_When_NotNullPassedToValueSetter()
        {
            Assert.DoesNotThrow(() => new Vertex<int?>(0).Value = 0);
        }

        [Test]
        public void Expect_ArgumentException_When_SequenceWithNullPassedToConstructor()
        {
            Assert.Throws<ArgumentException>(() => new Vertex<int?>(0, new List<Vertex<int?>>() { null }));
        }

        [Test]
        public void Expect_ArgumentException_When_SequenceWithDuplicatesPassedToConstructor()
        {
            var duplicate = new Vertex<int?>(0);
            Assert.Throws<ArgumentException>(() => new Vertex<int?>(0, new List<Vertex<int?>>() { duplicate, duplicate }));
        }
    }
}
