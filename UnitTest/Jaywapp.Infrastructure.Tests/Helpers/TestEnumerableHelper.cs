using System.Collections.Generic;
using System.Linq;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestEnumerableHelper
    {
        [TestCase(null, ExpectedResult = true)]
        [TestCase(new int[] { }, ExpectedResult = true)]
        [TestCase(new int[] { 1 }, ExpectedResult = false)]
        public bool IsNullOrEmpty_Cases(int[] input)
        {
            IEnumerable<int> col = input;
            return EnumerableHelper.IsNullOrEmpty(col);
        }

        [TestCase(new int[] { 10, 20 }, 2, 10, 20)]
        [TestCase(new int[] { }, 0, 0, 0)]
        public void ToObservableCollection_CreatesCollectionWithItems(int[] src, int expectedCount, int first, int last)
        {
            var oc = src.ToObservableCollection();
            Assert.That(oc.Count, Is.EqualTo(expectedCount));
            if (expectedCount > 0)
            {
                Assert.That(oc[0], Is.EqualTo(first));
                Assert.That(oc[^1], Is.EqualTo(last));
            }
        }

        [TestCase(3, false, 2)]
        [TestCase(3, true, 3)]
        public void ChainPairing_CountMatches(int length, bool circular, int expectedCount)
        {
            var src = Enumerable.Range(1, length).ToArray();
            var pairs = src.ChainPairing(circular).ToList();
            Assert.That(pairs.Count, Is.EqualTo(expectedCount));
        }
    }
}
