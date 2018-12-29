using System;
using ColorBlender;
using Xwt.Drawing;

namespace VS4Mac.ColorHelper.Extensions
{
    public static class ColorExtensions
    {
        public static Color ToXwtColor(this RGB rgb)
        {
            return ToColor(rgb);
        }

        public static Color ToXwtColor(this HSV hsv)
        {
            return ToColor(hsv);
        }

        public static string ToHexString(this Color color)
        {
            return $"#{((byte)color.Red).ToString("X2")}{((byte)color.Green).ToString("X2")}{((byte)color.Blue).ToString("X2")}";
        }

        internal static Color ToColor(this HSV hsv)
        {
            return ToColor(hsv.ToRGB());
        }

        internal static Color ToColor(this RGB rgb)
        {
            return Color.FromBytes(
                (byte)Math.Round(rgb.R),
                (byte)Math.Round(rgb.G),
                (byte)Math.Round(rgb.B));
        }
    }
}