﻿using TinyNavigationHelper.Abstraction;
using Xamarin.Forms;

namespace defaulttemplate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Bootstrapper.Initialize(this);

            NavigationHelper.Current.SetRootView("StartView", true);
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
