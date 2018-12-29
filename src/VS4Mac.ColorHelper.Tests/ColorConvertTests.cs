using NUnit.Framework;
using VS4Mac.ColorHelper.Helper;

namespace VS4Mac.ColorHelper.Tests
{
    [TestFixture]
    public class ColorConvertTests
    {
        const string RedHex = "#ff0000ff";
        const string RedRGB = "rgb (255,0,0)";

        [Test]
        public void ConvertHexToRgbTest()
        {
            var result = ColorConverter.ConvertHexToRgb(RedHex);

            Assert.AreEqual(RedRGB, result);
        }

        [Test]
        public void ConvertRgbToHexTest()
        {
            var result = ColorConverter.ConvertRgbToHex(RedRGB);

            Assert.AreEqual(RedHex, result);
        }
    }
}
