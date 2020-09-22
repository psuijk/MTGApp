using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleApp.ViewModels;

namespace SampleApp
{
    public partial class App : Application
    {
        public App()
        {
            Device.SetFlags(new[] { "SwipeView_Experimental" });
            InitializeComponent();
            MainPage = new NavigationPage(new Views.HomePage());
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
