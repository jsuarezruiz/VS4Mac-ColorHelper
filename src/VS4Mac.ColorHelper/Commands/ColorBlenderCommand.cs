using MonoDevelop.Components.Commands;
using VS4Mac.ColorHelper.Views;

namespace VS4Mac.ColorHelper.Commands
{
    public class ColorBlenderCommand : CommandHandler
    {
        protected override void Run()
        {
            using (var colorBlenderDialog = new ColorBlenderDialog())
            {
                colorBlenderDialog.Run(Xwt.MessageDialog.RootWindow);
            }
        }
    }
}