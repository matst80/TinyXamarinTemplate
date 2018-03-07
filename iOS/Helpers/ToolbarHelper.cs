using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace defaulttemplate.iOS
{
    internal class ToolbarHelper : IToolbarHelper
    {
        public void SetBackgroundColor(string hexColor)
        {
            
        }

        public void SetBackgroundColor(int r, int g, int b, int a = 255)
        {
            UINavigationBar.Appearance.BarTintColor = UIColor.FromRGBA(r,b,g,a);
        }
    }
}