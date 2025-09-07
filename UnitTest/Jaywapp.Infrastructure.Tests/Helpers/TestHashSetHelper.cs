using System.Collections.Generic;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestHashSetHelper
    {
        [TestCase(new int[] { 1 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 2, 2, 3 }, new int[] { 2, 3 })]
        public void AddRange_AddsUnique(int[] initial, int[] toAdd, int[] expected)
        {
            var hs = new HashSet<int>(initial);
            hs.AddRange(toAdd);
            Assert.That(hs.SetEquals(expected), Is.True);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 4 }, new int[] { 1, 3 })]
        public void RemoveRange_RemovesSpecified(int[] initial, int[] toRemove, int[] expected)
        {
            var hs = new HashSet<int>(initial);
            hs.RemoveRange(toRemove);
            Assert.That(hs.SetEquals(expected), Is.True);
        }
    }
}
