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
    public partial class TwoPlayerPage : ContentPage
    {
        public TwoPlayerPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new TwoPlayerPageViewModel();
            ChangeMe.BackgroundColor = Color.Orange;
        }

        void OnSwipedP1(object sender, EventArgs args)
        {
            ChangeMe.BackgroundColor = Color.DarkRed;
            var counterChooserView = new BoxView { BackgroundColor = Color.SandyBrown };
            Player1LifeGrid.Children.Add(counterChooserView, 0, 0);
        }

    }
}