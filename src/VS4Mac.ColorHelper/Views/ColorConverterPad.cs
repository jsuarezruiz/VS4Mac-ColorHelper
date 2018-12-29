using MonoDevelop.Components;
using MonoDevelop.Ide.Gui;
using VS4Mac.ColorHelper.Controls;
using Xwt.Drawing;

namespace VS4Mac.ColorHelper.Views
{
    public class ColorConverterPad : PadContent
    {
        ColorConverterWidget _colorConverterWidget;

        public override string Id => "ColorHelper.Pad.ColorConverterPad";

        public override Control Control { get { return new XwtControl(_colorConverterWidget); } }

        protected override void Initialize(IPadWindow window)
        {
            base.Initialize(window);

            Init();
        }

        void Init()
        {
            _colorConverterWidget = new ColorConverterWidget(Colors.Red);
        }
    }
}