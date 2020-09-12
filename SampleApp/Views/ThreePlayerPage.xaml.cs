using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThreePlayerPage : ContentPage
    {
        public ThreePlayerPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new ThreePlayerPageViewModel();
            Player1Pancake.BackgroundColor = Color.Blue;
            Player2Pancake.BackgroundColor = Color.Red;
            Player3Pancake.BackgroundColor = Color.Green;
        }
        void OnSwipedP1(object sender, EventArgs args)
        {
            Player1Pancake.BackgroundColor = Color.DarkRed;
            var counterChooserView = new BoxView { BackgroundColor = Color.SandyBrown };
            Player1LifeGrid.Children.Add(counterChooserView, 0, 0);
        }
        void OnSwipedP2(object sender, EventArgs args)
        {
            Player2Pancake.BackgroundColor = Color.DarkRed;
            var counterChooserView = new BoxView { BackgroundColor = Color.SandyBrown };
            Player2LifeGrid.Children.Add(counterChooserView, 0, 2);
        }
        void OnSwipedP3(object sender, EventArgs args)
        {
            Player3Pancake.BackgroundColor = Color.DarkRed;
            var counterChooserView = new BoxView { BackgroundColor = Color.SandyBrown };
            Player3LifeGrid.Children.Add(counterChooserView, 4, 0);
        }
    }
}