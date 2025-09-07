using System.Collections.Generic;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestCollectionHelper
    {
        [TestCase(new int[] { 1 }, new int[] { 2, 3, 4 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(new int[] { }, new int[] { 5 }, new int[] { 5 })]
        public void AddRange_AddsAllItemsInOrder(int[] initial, int[] items, int[] expected)
        {
            var list = new List<int>(initial);
            list.AddRange(items);
            Assert.That(list, Is.EqualTo(expected));
        }
    }
}
