using System.Collections.Generic;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestCollectionHelper
    {
        [Test]
        public void AddRange_AddsAllItemsInOrder()
        {
            var list = new List<int> { 1 };
            list.AddRange(new[] { 2, 3, 4 });

            Assert.That(list, Is.EqualTo(new[] { 1, 2, 3, 4 }));
        }
    }
}
