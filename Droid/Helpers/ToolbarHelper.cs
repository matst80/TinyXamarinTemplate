using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;

namespace defaulttemplate.Droid
{
    internal class ToolbarHelper : IToolbarHelper
    {
        public static FormsAppCompatActivity Context { get; internal set; }

        public void SetBackgroundColor(int r, int g, int b, int a = 255)
        {
            var clr = new Color(r, g, b, a);
            var toolbar = Context.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            toolbar.SetBackgroundColor(clr);
            Context.SetStatusBarColor(clr.ToColor().AddLuminosity(-5).ToAndroid());
        }

        public ToolbarHelper()
        {
            
        }
    }
}