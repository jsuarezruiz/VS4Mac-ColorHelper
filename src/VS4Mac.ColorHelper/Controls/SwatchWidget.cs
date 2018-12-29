using Xwt;
using Xwt.Drawing;

namespace VS4Mac.ColorHelper.Controls
{
    public class SwatchWidget : VBox
    {
        FrameBox _colorBox;
        TextEntry _hexTextEntry;
        HBox _rgbBox;
        TextEntry _rTextEntry;
        TextEntry _gTextEntry;
        TextEntry _bTextEntry;

        Color _boxColor;

        public SwatchWidget()
        {
            Init();
            BuildGui();
        }

        public Color BoxColor 
        { 
            get { return _boxColor; }
            set 
            {
                _boxColor = value;
                UpdateBoxColor(_boxColor); 
            }
        }

        void Init()
        {
            _colorBox = new FrameBox
            {
                BorderColor = Colors.Black,
                HeightRequest = 220,
                WidthRequest = 100
            };

            _hexTextEntry = new TextEntry
            {
                ReadOnly = true
            };

            _rgbBox = new HBox();

            _rTextEntry = new TextEntry
            {
                ReadOnly = true
            };

            _gTextEntry = new TextEntry
            {
                ReadOnly = true
            };

            _bTextEntry = new TextEntry
            {
                ReadOnly = true
            };
        }

        void BuildGui()
        {
            PackStart(_colorBox);
            PackStart(_hexTextEntry);

            _rgbBox.PackStart(_rTextEntry);
            _rgbBox.PackStart(_gTextEntry);
            _rgbBox.PackStart(_bTextEntry);

            PackStart(_rgbBox);
        }

        void UpdateBoxColor(Color? boxColor)
        {
            if (boxColor != null)
            {
                var color = boxColor.Value;
                _colorBox.BackgroundColor = color;

                _hexTextEntry.Text = color.ToHexString();

                _rTextEntry.Text = (color.Red * 255).ToString();
                _gTextEntry.Text = (color.Green * 255).ToString();
                _bTextEntry.Text = (color.Blue * 255).ToString();
            }
        }
    }
}
