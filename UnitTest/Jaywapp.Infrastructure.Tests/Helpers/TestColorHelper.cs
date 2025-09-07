using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;
using System.Windows.Media;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestColorHelper
    {
        [Test]
        public void GetColorName_KnownColor_ReturnsName()
        {
            var name = Colors.Red.GetColorName();
            Assert.That(name, Is.EqualTo("Red"));
        }

        [Test]
        public void ToColor_ParsesStringOrReturnsDefault()
        {
            var c1 = "#FF0000".ToColor();
            Assert.That(c1, Is.EqualTo(Colors.Red));

            var c2 = "not-a-color".ToColor(Colors.Blue);
            Assert.That(c2, Is.EqualTo(Colors.Blue));
        }

        [Test]
        public void TryConvertColor_ReturnsTrueWhenParsable()
        {
            Assert.That("#00FF00".TryConvertColor(out var green), Is.True);
            Assert.That(green, Is.EqualTo(Colors.Lime));

            Assert.That("invalid".TryConvertColor(out _), Is.False);
        }
    }
}
