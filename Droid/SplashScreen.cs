
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace defaulttemplate.Droid
{
    //Add for Pixel launcher round icon: RoundIcon = "@drawable/ic_round"
    [Activity(Label = "defaulttemplate", Icon = "@drawable/icon", Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {
        static readonly string TAG = "X:" + typeof(SplashScreen).Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();

            var startupWork = new Task(() => { DoStartup(); });
            startupWork.Start();
        }

        private async void DoStartup()
        {
            Bootstrapper.EarlyInitialize();

            // TODO Add preloading here

            var intent = new Intent(Application.Context, typeof(MainActivity));

            StartActivity(intent); 
            // OverridePendingTransition(animIn, animOut);
        }
    }
}
