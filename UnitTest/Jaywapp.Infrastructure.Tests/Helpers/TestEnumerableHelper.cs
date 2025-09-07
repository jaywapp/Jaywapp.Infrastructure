using System.Collections.Generic;
using System.Linq;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestEnumerableHelper
    {
        [Test]
        public void IsNullOrEmpty_Works()
        {
            IEnumerable<int> nullEnum = null;
            Assert.That(EnumerableHelper.IsNullOrEmpty(nullEnum), Is.True);
            Assert.That(EnumerableHelper.IsNullOrEmpty(new int[0]), Is.True);
            Assert.That(EnumerableHelper.IsNullOrEmpty(new[] { 1 }), Is.False);
        }

        [Test]
        public void ToObservableCollection_CreatesCollectionWithItems()
        {
            var src = new[] { 10, 20 };
            var oc = src.ToObservableCollection();
            Assert.That(oc.Count, Is.EqualTo(2));
            Assert.That(oc[0], Is.EqualTo(10));
            Assert.That(oc[1], Is.EqualTo(20));
        }

        [Test]
        public void ChainPairing_NonCircular_PairsSequentially()
        {
            var pairs = new[] { 1, 2, 3 }.ChainPairing().ToList();
            Assert.That(pairs, Is.EqualTo(new[] { (1, 2), (2, 3) }));
        }

        [Test]
        public void ChainPairing_Circular_IncludesWrapPair()
        {
            var pairs = new[] { 1, 2, 3 }.ChainPairing(isCircular: true).ToList();
            Assert.That(pairs, Is.EqualTo(new[] { (1, 2), (2, 3), (3, 1) }));
        }
    }
}
