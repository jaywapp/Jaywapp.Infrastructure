using System.Xml.Linq;
using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestXmlHelper
    {
        [Test]
        public void GetAttributeValue_ReturnsValue()
        {
            var el = new XElement("root");
            el.SetAttributeValue("name", "john");
            Assert.That(el.GetAttributeValue("name"), Is.EqualTo("john"));
            Assert.That(el.GetAttributeValue("age", "0"), Is.EqualTo("0"));
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
