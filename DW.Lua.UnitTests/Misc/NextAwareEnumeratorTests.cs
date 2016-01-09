using System;
using System.Linq;
using DW.Lua.Extensions;
using DW.Lua.Misc;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Misc
{
    [TestFixture]
    public class NextAwareEnumeratorTests
    {
        private readonly int[] _testSequence = Enumerable.Range(1, 10).Select(x => x*5).ToArray();

        [Test]
        public void NextShouldBeAheadOfPrev()
        {
            var enumerator = _testSequence.AsEnumerable().GetNextAwareEnumerator();
            var i = 0;
            while (enumerator.MoveNext())
            {
                Assert.AreEqual(_testSequence[i], enumerator.Current);
                if (enumerator.HasNext)
                    Assert.AreEqual(_testSequence[i + 1], enumerator.Next);
                else
                    Assert.AreEqual(_testSequence.Last(), enumerator.Current);
                i++;
            }
        }

        [Test]
        public void ShouldEnumerateSequence()
        {
            var enumerator = _testSequence.AsEnumerable().GetNextAwareEnumerator();
            CollectionAssert.AreEqual(_testSequence, enumerator.Enumerate());
        }

        [Test]
        public void ShouldThrowOnTryingToEnumeratePastEnd()
        {
            var enumerator = _testSequence.AsEnumerable().GetNextAwareEnumerator();
            for (var i = 0; i < _testSequence.Length; i++)
                Assert.True(enumerator.MoveNext());
            Assert.False(enumerator.MoveNext());
            Assert.Throws<InvalidOperationException>(() => { enumerator.MoveNext(); });
        }

        [Test]
        public void ShouldWorkRecursively()
        {
            var enumerator =
                new NextAwareEnumerator<int>(
                    new NextAwareEnumerator<int>(_testSequence.AsEnumerable().GetNextAwareEnumerator()));
            var i = 0;
            while (enumerator.MoveNext())
                Assert.AreEqual(_testSequence[i++], enumerator.Current);
        }

        [Test]
        public void StockEnumeratorShouldEnumerateSequence()
        {
            var enumerator = _testSequence.GetEnumerator();
            var i = 0;
            while (enumerator.MoveNext())
                Assert.AreEqual(_testSequence[i++], enumerator.Current);
        }
    }
}