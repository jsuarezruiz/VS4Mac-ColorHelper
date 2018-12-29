using System;
using VS4Mac.ColorHelper.Helper;
using VS4Mac.ColorHelper.Models;
using Xwt;
using Xwt.Drawing;

namespace VS4Mac.ColorHelper.Controls
{
    public class ColorConverterWidget : VBox
    {
        VBox _mainBox;
        Label _titleLabel;
        Label _colorLabel;
        TextEntry _colorEntry;
        Frame _colorBox;
        HBox _rgbBox;
        Label _rgbLabel;
        TextEntry _rgbEntry;
        HBox _hexBox;
        Label _hexLabel;
        TextEntry _hexEntry;

        Color _initialColor;

        public ColorConverterWidget(Color? color = null)
        {
            Init(); 
            BuildGui();
            AttachEvents();

            LoadColor(color);
        }

        void Init()
        {
            _mainBox = new VBox
            {
                Margin = new WidgetSpacing(12)
            };

            _titleLabel = new Label("Enter a Color")
            {
                Font = Font.SystemFont.WithSize(20),
                Margin = new WidgetSpacing(0, 6)
            };

            _colorLabel = new Label("hex, rgb:")
            {
                TextColor = Colors.LightGray
            };

            _colorEntry = new TextEntry();

            _colorBox = new Frame
            {
                HorizontalPlacement = WidgetPlacement.Center,
                ExpandVertical = false,
                ExpandHorizontal = false,
                HeightRequest = 100,
                WidthRequest = 100,
                Margin = new WidgetSpacing(0, 6)
            };

            _rgbBox = new HBox();

            _rgbLabel = new Label("Rgb:")
            {
                WidthRequest = 36
            };

            _rgbEntry = new TextEntry
            {
                ReadOnly = true
            };

            _hexBox = new HBox();

            _hexLabel = new Label("Hex:")
            {
                WidthRequest = 36
            };

            _hexEntry = new TextEntry
            {
                ReadOnly = true
            };
        }

        void BuildGui()
        {
            _mainBox.PackStart(_titleLabel);
            _mainBox.PackStart(_colorLabel);
            _mainBox.PackStart(_colorEntry);
            _mainBox.PackStart(_colorBox, false);

            _rgbBox.PackStart(_rgbLabel, false);
            _rgbBox.PackStart(_rgbEntry, true);
            _mainBox.PackStart(_rgbBox, false);

            _hexBox.PackStart(_hexLabel, false);
            _hexBox.PackStart(_hexEntry, true);
            _mainBox.PackStart(_hexBox, false);

            PackStart(_mainBox, true);
        }

        void AttachEvents()
        {
            _colorEntry.Changed += OnColorChanged;
        }

        void LoadColor(Color? color)
        {
            if (color != null)
            {
                _initialColor = color.Value;
                _colorEntry.Text = _initialColor.ToHexString();
                ConvertHexColor(_initialColor.ToHexString());
            }
        }

        void OnColorChanged(object sender, EventArgs args)
        {
            var input = _colorEntry.Text;

            if(!string.IsNullOrEmpty(input))
                ConverColor(input);
        }

        void ConverColor(string input)
        {
            var colorFormat = DetectFormat(input);

            switch(colorFormat)
            {
                case ColorFormat.Hex:
                    ConvertHexColor(input);
                    break;
                case ColorFormat.Rgb:
                    ConvertRgbColor(input);
                    break;
                default:
                    ConvertHexColor(input);
                    break;
            }
        }

        ColorFormat DetectFormat(string input)
        {
            if (input.StartsWith("#", StringComparison.InvariantCultureIgnoreCase))
                return ColorFormat.Hex;
            if (input.StartsWith("rgb", StringComparison.InvariantCultureIgnoreCase))
                return ColorFormat.Rgb;

            return ColorFormat.Unknown;
        }

        void ConvertHexColor(string hex)
        {
            _colorBox.BackgroundColor = ColorConverter.GetColorFromHex(hex);
            _rgbEntry.Text = ColorConverter.ConvertHexToRgb(hex);
            _hexEntry.Text = hex;
        }

        void ConvertRgbColor(string rgb)
        {
            _colorBox.BackgroundColor = ColorConverter.GetColorFromRgb(rgb);
            _rgbEntry.Text = rgb;
            _hexEntry.Text = ColorConverter.ConvertRgbToHex(rgb);
        }
    }
}