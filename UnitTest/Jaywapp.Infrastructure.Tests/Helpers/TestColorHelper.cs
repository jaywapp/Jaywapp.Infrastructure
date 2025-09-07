using Jaywapp.Infrastructure.Helpers;
using NUnit.Framework;
using System.Windows.Media;

namespace Jaywapp.Infrastructure.Tests
{
    public class TestColorHelper
    {
        [TestCase("Red")]
        [TestCase("Blue")]
        public void GetColorName_KnownColor_ReturnsName(string colorName)
        {
            var prop = typeof(Colors).GetProperty(colorName);
            var color = (Color)prop!.GetValue(null, null)!;
            var name = color.GetColorName();
            Assert.That(name, Is.EqualTo(colorName));
        }

        [TestCase("#FF0000", "Red")]
        [TestCase("#00FF00", "Lime")]
        public void ToColor_ParsesString(string hex, string expectedName)
        {
            var c = hex.ToColor();
            Assert.That(c, Is.EqualTo((Color)typeof(Colors).GetProperty(expectedName)!.GetValue(null, null)!));
        }

        [TestCase("not-a-color", "Blue")]
        public void ToColor_ReturnsDefaultOnFailure(string input, string defaultName)
        {
            var def = (Color)typeof(Colors).GetProperty(defaultName)!.GetValue(null, null)!;
            var c = input.ToColor(def);
            Assert.That(c, Is.EqualTo(def));
        }

        [TestCase("#00FF00", true)]
        [TestCase("invalid", false)]
        public void TryConvertColor_Cases(string input, bool expected)
        {
            var ok = input.TryConvertColor(out var color);
            Assert.That(ok, Is.EqualTo(expected));
        }
    }
}
