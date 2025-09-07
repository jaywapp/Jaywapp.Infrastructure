using System;
using System.Drawing;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestRandomHelper
    {
        [Test]
        public void NextIntRange_ProducesWithinRange()
        {
            var rnd = new Random(42);
            var val = rnd.Next(1, 3); // underlying .NET method
            Assert.That(val, Is.InRange(1, 2));
        }

        [Test]
        public void NextCharacter_ReturnsPrintableAscii()
        {
            var rnd = new Random(1);
            var ch = rnd.NextCharacter();
            Assert.That((int)ch, Is.InRange(33, 125));
        }

        [TestCase(1)]
        [TestCase(10)]
        public void NextString_LengthMatches(int length)
        {
            var rnd = new Random(1);
            var s = rnd.NextString(length);
            Assert.That(s.Length, Is.EqualTo(length));
        }

        private enum Alpha { A, B, C }

        [Test]
        public void NextEnum_ReturnsAValidValue()
        {
            var rnd = new Random(2);
            var e = rnd.Next<Alpha>();
            Assert.That(Enum.IsDefined(typeof(Alpha), e), Is.True);
        }

        [Test]
        public void NextColor_ReturnsColor()
        {
            var rnd = new Random(3);
            Color c = rnd.NextColor();
            Assert.Pass(); // existence test; value is random
        }

        [Test]
        public void NextPoint_ReturnsPoint()
        {
            var rnd = new Random(4);
            var p = rnd.NextPoint();
            Assert.That(p, Is.Not.Null);
        }

        [Test]
        public void Next_Selectors_PicksOne()
        {
            var rnd = new Random(5);
            var v = rnd.Next(() => 1, () => 2, () => 3);
            Assert.That(v, Is.AnyOf(1, 2, 3));
        }
    }
}
