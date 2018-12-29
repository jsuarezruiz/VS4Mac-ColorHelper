using System;
using ColorBlender;
using VS4Mac.ColorHelper.Controls;
using VS4Mac.ColorHelper.Extensions;
using Xwt;

namespace VS4Mac.ColorHelper.Views
{
    public class ColorBlenderDialog : Dialog
    {
        VBox _mainBox;
        HBox _swatchBox;
        SwatchWidget _swatch1;
        SwatchWidget _swatch2;
        SwatchWidget _swatch3;
        SwatchWidget _swatch4;
        SwatchWidget _swatch5;
        SwatchWidget _swatch6;
        VBox _editRgbBox;
        Label _editRgbLabel;
        HBox _redBox;
        Label _redLabel;
        Slider _redSlider;
        TextEntry _redTextEntry;
        HBox _greenBox;
        Label _greenLabel;
        Slider _greenSlider;
        TextEntry _greenTextEntry;
        HBox _blueBox;
        Label _blueLabel;
        Slider _blueSlider;
        TextEntry _blueTextEntry;
        VBox _editHslBox;
        Label _editHslLabel;
        HBox _hueBox;
        Label _hueLabel;
        Slider _hueSlider;
        TextEntry _hueTextEntry;
        HBox _saturationBox;
        Label _saturationLabel;
        Slider _saturationSlider;
        TextEntry _saturationTextEntry;
        HBox _lightnessBox;
        Label _lightnessLabel;
        Slider _lightnessSlider;
        TextEntry _lightnessTextEntry;

        bool _updating;

        public ColorBlenderDialog()
        {
            Init();
            BuildGui();
            AttachEvents();

            UpdateSwatches();
            UpdateSliderRGB();
            UpdateSliderHSV();
        }

        public ColorMatch ColorMatch { get; set; }

        void Init()
        {
            ColorMatch = new ColorMatch(213, 46, 49);

            _mainBox = new VBox
            {
                HeightRequest = 600,
                WidthRequest = 1200
            };

            _swatchBox = new HBox();
            _swatch1 = new SwatchWidget();
            _swatch2 = new SwatchWidget();
            _swatch3 = new SwatchWidget();
            _swatch4 = new SwatchWidget();
            _swatch5 = new SwatchWidget();
            _swatch6 = new SwatchWidget();

            _editRgbBox = new VBox
            {
                Margin = new WidgetSpacing(0, 12, 0, 0)
            };

            _editRgbLabel = new Label("Edit Red / Green / Blue");
            _redBox = new HBox();
            _redLabel = new Label("Red");

            _redSlider = new HSlider
            {
                MinimumValue = 0,
                Value = 0,
                MaximumValue = 255
            };

            _redTextEntry = new TextEntry
            {
                ReadOnly = true,
                WidthRequest = 48
            };

            _greenBox = new HBox();
            _greenLabel = new Label("Green");

            _greenSlider = new HSlider
            {
                MinimumValue = 0,
                Value = 0,
                MaximumValue = 255
            };

            _greenTextEntry = new TextEntry
            {
                ReadOnly = true,
                WidthRequest = 48
            };

            _blueBox = new HBox();
            _blueLabel = new Label("Blue");

            _blueSlider = new HSlider
            {
                MinimumValue = 0,
                Value = 0,
                MaximumValue = 255
            };

            _blueTextEntry = new TextEntry
            {
                ReadOnly = true,
                WidthRequest = 48
            };

            _editHslBox = new VBox 
            {
                Margin = new WidgetSpacing(0, 12, 0, 0)
            };

            _editHslLabel = new Label("Edit Hue / Saturation / Lightness");

            _hueBox = new HBox();
            _hueLabel = new Label("Hue");

            _hueSlider = new HSlider
            {
                MinimumValue = 0,
                Value = 0,
                MaximumValue = 359
            };

            _hueTextEntry = new TextEntry
            {
                ReadOnly = true,
                WidthRequest = 48
            };

            _saturationBox = new HBox();
            _saturationLabel = new Label("Hue");

            _saturationSlider = new HSlider
            {
                MinimumValue = 0,
                Value = 0,
                MaximumValue = 100
            };

            _saturationTextEntry = new TextEntry
            {
                ReadOnly = true,
                WidthRequest = 48
            };

            _lightnessBox = new HBox();
            _lightnessLabel = new Label("Hue");

            _lightnessSlider = new HSlider
            {
                MinimumValue = 0,
                Value = 0,
                MaximumValue = 100
            };

            _lightnessTextEntry = new TextEntry
            {
                ReadOnly = true,
                WidthRequest = 48
            };
        }

        void BuildGui()
        {
            Title = "Color Blender";

            _swatchBox.PackEnd(_swatch1);
            _swatchBox.PackEnd(_swatch2);
            _swatchBox.PackEnd(_swatch3);
            _swatchBox.PackEnd(_swatch4);
            _swatchBox.PackEnd(_swatch5);
            _swatchBox.PackEnd(_swatch6);

            _redBox.PackStart(_redLabel, false);
            _redBox.PackStart(_redSlider, true);
            _redBox.PackStart(_redTextEntry, false);

            _blueBox.PackStart(_blueLabel, false);
            _blueBox.PackStart(_blueSlider, true);
            _blueBox.PackStart(_blueTextEntry, false);

            _greenBox.PackStart(_greenLabel, false);
            _greenBox.PackStart(_greenSlider, true);
            _greenBox.PackStart(_greenTextEntry, false);

            _editRgbBox.PackStart(_editRgbLabel);
            _editRgbBox.PackStart(_redBox);
            _editRgbBox.PackStart(_blueBox);
            _editRgbBox.PackStart(_greenBox);

            _hueBox.PackStart(_hueLabel, false);
            _hueBox.PackStart(_hueSlider, true);
            _hueBox.PackStart(_hueTextEntry, false);

            _saturationBox.PackStart(_saturationLabel, false);
            _saturationBox.PackStart(_saturationSlider, true);
            _saturationBox.PackStart(_saturationTextEntry, false);

            _lightnessBox.PackStart(_lightnessLabel, false);
            _lightnessBox.PackStart(_lightnessSlider, true);
            _lightnessBox.PackStart(_lightnessTextEntry, false);

            _editHslBox.PackStart(_editHslLabel);
            _editHslBox.PackStart(_hueBox);
            _editHslBox.PackStart(_saturationBox);
            _editHslBox.PackStart(_lightnessBox);

            _mainBox.PackStart(_swatchBox);
            _mainBox.PackStart(_editRgbBox);
            _mainBox.PackStart(_editHslBox);

            Content = _mainBox;
            Resizable = false;
        }

        void AttachEvents()
        {
            _redSlider.ValueChanged += OnSliderRGBValueChanged;
            _greenSlider.ValueChanged += OnSliderRGBValueChanged;
            _blueSlider.ValueChanged += OnSliderRGBValueChanged;

            _hueSlider.ValueChanged += OnSlideHSVValueChanged;
            _saturationSlider.ValueChanged += OnSlideHSVValueChanged;
            _lightnessSlider.ValueChanged += OnSlideHSVValueChanged;
        }


        void OnSliderRGBValueChanged(object sender, EventArgs args)
        {
            if (!_updating)
            {
                HandleSliderValueChangedRGB();
            }

            UpdateTextRGB();
        }

        void OnSlideHSVValueChanged(object sender, EventArgs e)
        {
            if (!_updating)
            {
                HandleSliderValueChangedHSV();
            }

            UpdateTextHSV();
        }

        void HandleSliderValueChangedRGB()
        {
            ColorMatch.CurrentRGB = new RGB(_redSlider.Value, _greenSlider.Value, _blueSlider.Value);
            ColorMatch.CurrentHSV = ColorMatch.CurrentRGB.ToHSV();
            ColorMatch.CurrentRGB = ColorMatch.CurrentHSV.ToRGB();
            ColorMatch.Update();

            UpdateSwatches();
            UpdateSliderHSV();
        }

        void HandleSliderValueChangedHSV()
        {
            ColorMatch.CurrentHSV = new HSV(_hueSlider.Value, _saturationSlider.Value, _lightnessSlider.Value);
            ColorMatch.CurrentRGB = ColorMatch.CurrentHSV.ToRGB();
            ColorMatch.Update();

            UpdateSwatches();
            UpdateSliderRGB();
        }

        void UpdateSwatches()
        {
            if (ColorMatch != null && ColorMatch.CurrentBlend != null)
            {
                _swatch1.BoxColor = ColorMatch.CurrentBlend.Colors[0].ToXwtColor();
                _swatch2.BoxColor = ColorMatch.CurrentBlend.Colors[1].ToXwtColor();
                _swatch3.BoxColor = ColorMatch.CurrentBlend.Colors[2].ToXwtColor();
                _swatch4.BoxColor = ColorMatch.CurrentBlend.Colors[3].ToXwtColor();
                _swatch5.BoxColor = ColorMatch.CurrentBlend.Colors[4].ToXwtColor();
                _swatch6.BoxColor = ColorMatch.CurrentBlend.Colors[5].ToXwtColor();
            }
        }

        void UpdateSliderHSV()
        {
            if (ColorMatch != null && ColorMatch.CurrentHSV != null)
            {
                _updating = true;

                _hueSlider.Value = ColorMatch.CurrentHSV.H;
                _saturationSlider.Value = ColorMatch.CurrentHSV.S;
                _lightnessSlider.Value = ColorMatch.CurrentHSV.V;

                UpdateTextHSV();

                _updating = false;
            }
        }

        void UpdateTextHSV()
        {
            _hueTextEntry.Text = _hueSlider.Value.ToString();
            _saturationTextEntry.Text = _saturationSlider.Value.ToString();
            _lightnessTextEntry.Text = _lightnessSlider.Value.ToString();
        }

        void UpdateSliderRGB()
        {
            if (ColorMatch != null && ColorMatch.CurrentRGB != null)
            {
                _updating = true;

                _redSlider.Value = ColorMatch.CurrentRGB.R;
                _greenSlider.Value = ColorMatch.CurrentRGB.G;
                _blueSlider.Value = ColorMatch.CurrentRGB.B;

                UpdateTextRGB();

                _updating = false;
            }
        }

        void UpdateTextRGB()
        {
            _redTextEntry.Text = _redSlider.Value.ToString();
            _greenTextEntry.Text = _greenSlider.Value.ToString();
            _blueTextEntry.Text = _blueSlider.Value.ToString();
        }
    }
}