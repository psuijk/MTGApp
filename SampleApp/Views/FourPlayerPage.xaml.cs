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
    public partial class FourPlayerPage : ContentPage
    {
        public FourPlayerPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new FourPlayerPageViewModel();
        }

        protected override void OnAppearing()
        {
            Player1LifeView.BindingContext = BindingContext;
            Player1LifeView.SetOrientation(90);
            Player1LifeView.SetTopColor(Color.Blue);
            Player1LifeView.SetLabelBinding("LifeTotalP1");
            Player1LifeView.SetIncrementBinding("IncrementValCommand");
            Player1LifeView.SetDecrementBinding("DecrementValCommand");

            Player2LifeView.BindingContext = BindingContext;
            Player2LifeView.SetOrientation(-90);
            Player2LifeView.SetTopColor(Color.Red);
            Player2LifeView.SetLabelBinding("LifeTotalP2");
            Player2LifeView.SetIncrementBinding("IncrementP2ValCommand");
            Player2LifeView.SetDecrementBinding("DecrementP2ValCommand");

            Player3LifeView.BindingContext = BindingContext;
            Player3LifeView.SetOrientation(90);
            Player3LifeView.SetTopColor(Color.MediumPurple);
            Player3LifeView.SetLabelBinding("LifeTotalP3");
            Player3LifeView.SetIncrementBinding("IncrementP3ValCommand");
            Player3LifeView.SetDecrementBinding("DecrementP3ValCommand");

            Player4LifeView.BindingContext = BindingContext;
            Player4LifeView.SetOrientation(-90);
            Player4LifeView.SetTopColor(Color.Green);
            Player4LifeView.SetLabelBinding("LifeTotalP4");
            Player4LifeView.SetIncrementBinding("IncrementP4ValCommand");
            Player4LifeView.SetDecrementBinding("DecrementP4ValCommand");
        }
    }
}