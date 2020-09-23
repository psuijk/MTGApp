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
    public partial class OnePlayerPage : ContentPage
    {
        public OnePlayerPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new OnePlayerPageViewModel();
        }

        protected override void OnAppearing()
        {
            Player1LifeView.BindingContext = BindingContext;
            Player1LifeView.SetOrientation(0);
            Player1LifeView.SetTopColor(Color.Blue);
            Player1LifeView.SetLabelBinding("LifeTotalP1");
            Player1LifeView.SetIncrementBinding("IncrementValCommand");
            Player1LifeView.SetDecrementBinding("DecrementValCommand");
        }
    }
}