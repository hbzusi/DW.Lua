using System.Linq;
using DW.Lua.Enumerators;
using DW.Lua.Extensions;
using NUnit.Framework;

namespace DW.Lua.UnitTests.Enumerators
{
    [TestFixture]
    public class NextAwareEnumeratorTests
    {
        private readonly int[] _testSequence = Enumerable.Range(1, 10).Select(x => x*5).ToArray();

        [Test]
        public void StockEnumeratorShouldEnumerateSequence()
        {
            var enumerator = _testSequence.GetEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
                Assert.AreEqual(_testSequence[i++], enumerator.Current);
        }

        [Test]
        public void ShouldEnumerateSequence()
        {
            var enumerator = _testSequence.AsEnumerable().GetNextAwareEnumerator();
            int i = 0;
            while (enumerator.MoveNext())
                Assert.AreEqual(_testSequence[i++], enumerator.Current);
        }

        [Test]
        public void NextShouldBeAheadOfPrev()
        {
            var enumerator = _testSequence.AsEnumerable().GetNextAwareEnumerator();
            int i = 0;
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
        public void ShouldWorkRecursively()
        {
            var enumerator = new NextAwareEnumerator<int>(new NextAwareEnumerator<int>(_testSequence.AsEnumerable().GetNextAwareEnumerator()));
            int i = 0;
            while (enumerator.MoveNext())
                Assert.AreEqual(_testSequence[i++], enumerator.Current);

        }
    }
}
