using System;
using System.ComponentModel;
using System.Linq;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestEnumHelper
    {
        private enum Sample
        {
            [Description("Alpha")] A = 0,
            [Description("Beta")] B = 1,
            C = 2
        }

        [Test]
        public void GetValues_ReturnsAllValues()
        {
            var vals = EnumHelper.GetValues<Sample>().ToArray();
            Assert.That(vals, Is.EqualTo(new[] { Sample.A, Sample.B, Sample.C }));
        }

        [Test]
        public void TryGetDescription_FindsAttribute()
        {
            Assert.That(EnumHelper.TryGetDescription(Sample.A, out var descA), Is.True);
            Assert.That(descA, Is.EqualTo("Alpha"));
            Assert.That(EnumHelper.TryGetDescription(Sample.C, out _), Is.False);
        }

        [Test]
        public void GetDescriptionOrToString_Works()
        {
            Assert.That(Sample.B.GetDescriptionOrToString(), Is.EqualTo("Beta"));
            Assert.That(Sample.C.GetDescriptionOrToString(), Is.EqualTo("C"));
        }

        [Test]
        public void GetValueFromDescription_Parses()
        {
            Assert.That("Alpha".GetValueFromDescription<Sample>(), Is.EqualTo(Sample.A));
            Assert.That("C".GetValueFromDescription<Sample>(), Is.EqualTo(Sample.C));
        }

        [Test]
        public void TryParseValueFromDescription_ByType_Works()
        {
            Assert.That(EnumHelper.TryParseValueFromDescription("Beta", typeof(Sample), out var value), Is.True);
            Assert.That(value, Is.EqualTo(Sample.B));
            Assert.That(EnumHelper.TryParseValueFromDescription("ZZZ", typeof(Sample), out _), Is.False);
        }
    }
}
