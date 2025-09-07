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

        [TestCase(Sample.A, true, "Alpha")]
        [TestCase(Sample.C, false, null)]
        public void TryGetDescription_Cases(Sample value, bool expected, string expectedDesc)
        {
            var ok = EnumHelper.TryGetDescription(value, out var desc);
            Assert.That(ok, Is.EqualTo(expected));
            if (expected) Assert.That(desc, Is.EqualTo(expectedDesc));
            else Assert.That(desc, Is.Null);
        }

        [TestCase(Sample.B, "Beta")]
        [TestCase(Sample.C, "C")]
        public void GetDescriptionOrToString_Cases(Sample value, string expected)
        {
            Assert.That(value.GetDescriptionOrToString(), Is.EqualTo(expected));
        }

        [TestCase("Alpha", Sample.A)]
        [TestCase("C", Sample.C)]
        public void GetValueFromDescription_Parses(string input, Sample expected)
        {
            Assert.That(input.GetValueFromDescription<Sample>(), Is.EqualTo(expected));
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
