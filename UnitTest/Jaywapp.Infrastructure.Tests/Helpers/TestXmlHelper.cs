using System.Xml.Linq;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestXmlHelper
    {
        [TestCase("name", "john", "john")]
        [TestCase("age", null, "0")]
        public void GetAttributeValue_Cases(string key, string value, string expected)
        {
            var el = new XElement("root");
            if (value != null) el.SetAttributeValue(key, value);
            Assert.That(el.GetAttributeValue(key, "0"), Is.EqualTo(expected));
        }

        [Test]
        public void TryGetAttributeValue_Works()
        {
            var el = new XElement("root");
            Assert.That(el.TryGetAttributeValue("x", out var v1), Is.False);
            Assert.That(v1, Is.Null);
            el.SetAttributeValue("x", "1");
            Assert.That(el.TryGetAttributeValue("x", out var v2), Is.True);
            Assert.That(v2, Is.EqualTo("1"));
        }

        [Test]
        public void GetAttributeValueOrEmpty_ReturnsEmptyWhenMissing()
        {
            var el = new XElement("root");
            Assert.That(el.GetAttributeValueOrEmpty("none"), Is.EqualTo(""));
        }
    }
}
