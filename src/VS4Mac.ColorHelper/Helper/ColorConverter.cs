using System;
using Xwt.Drawing;

namespace VS4Mac.ColorHelper.Helper
{
    public static class ColorConverter
    {
        public static Color GetColorFromHex(string hex)
        {
            return Color.FromName(hex);
        }

        public static Color GetColorFromRgb(string rgb)
        {
            var hex = ConvertRgbToHex(rgb);
            return Color.FromName(hex);
        }
        
        public static string ConvertHexToRgb(string hex)
        {
            try
            {
                var color = Color.FromName(hex);

                var r = Math.Round(color.Red, 1) * 255;
                var g = Math.Round(color.Green, 1) * 255;
                var b = Math.Round(color.Blue, 1) * 255;

                return string.Format("rgb ({0})", string.Join(",", r, g, b));
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string ConvertRgbToHex(string rgb)
        {
            try
            {
                var cleanRgb = SanitizeRgb(rgb);

                var parts = cleanRgb.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                byte r = Convert.ToByte(parts[0]);
                byte g = Convert.ToByte(parts[1]);
                byte b = Convert.ToByte(parts[2]);

                var color = Color.FromBytes(r, g, b);

                return color.ToHexString();
            }
            catch
            {
                return string.Empty;
            }
        }

        internal static string SanitizeRgb(string rgb)
        {
            int start = rgb.IndexOf("(", StringComparison.InvariantCultureIgnoreCase); 
            int end = rgb.IndexOf(")", StringComparison.InvariantCultureIgnoreCase);

            if (start == -1 || end == -1)
                return rgb;

            return rgb.Substring(start + 1, end - start - 1);
        }
    }
}