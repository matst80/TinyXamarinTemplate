using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;

namespace defaulttemplate.Droid
{
    internal class PlatformHelper : IPlatformHelper
    {
        public static FormsAppCompatActivity Context { get; internal set; }

       
    }
}