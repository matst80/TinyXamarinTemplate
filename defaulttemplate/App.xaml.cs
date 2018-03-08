using System.Threading.Tasks;
using TinyNavigationHelper.Abstraction;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace defaulttemplate
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            Bootstrapper.Initialize(this);

            Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize | WindowSoftInputModeAdjust.Pan);
            SetupErrorHandling();

            NavigationHelper.Current.SetRootView("StartView", true);
        }

        private void SetupErrorHandling()
        {
            ErrorHandler.AddHandler(new InsightsErrorHandler());
#if DEBUG
            ErrorHandler.AddHandler(new DebugErrorHandler((msg) =>
            {
                Device.BeginInvokeOnMainThread(() => {
                    MainPage.DisplayAlert("Debug exception", msg, "Doh");
                });
            }));
#endif
            TaskScheduler.UnobservedTaskException += (sender, ex) =>
            {
                if (ErrorHandler.HandleSilent(ex.Exception.InnerException??ex.Exception))
                {
                    ex.SetObserved();
                }
            };

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
