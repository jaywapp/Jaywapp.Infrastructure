using System.Collections.Generic;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestHashSetHelper
    {
        [Test]
        public void AddRange_AddsUnique()
        {
            var hs = new HashSet<int> { 1 };
            hs.AddRange(new[] { 1, 2, 3 });
            Assert.That(hs.SetEquals(new[] { 1, 2, 3 }), Is.True);
        }

        [Test]
        public void RemoveRange_RemovesSpecified()
        {
            var hs = new HashSet<int> { 1, 2, 3 };
            hs.RemoveRange(new[] { 2, 4 });
            Assert.That(hs.SetEquals(new[] { 1, 3 }), Is.True);
        }
    }
}
