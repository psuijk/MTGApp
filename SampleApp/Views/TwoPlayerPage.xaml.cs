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
        }

        protected override void OnAppearing()
        {
            Player1LifeView.BindingContext = BindingContext;
            Player1LifeView.SetOrientation(0);
            Player1LifeView.SetTopColor(Color.Blue);
            Player1LifeView.SetLabelBinding("LifeTotalP1");
            Player1LifeView.SetIncrementBinding("IncrementValCommand");
            Player1LifeView.SetDecrementBinding("DecrementValCommand");

            Player2LifeView.BindingContext = BindingContext;
            Player2LifeView.SetOrientation(180);
            Player2LifeView.SetTopColor(Color.Red);
            Player2LifeView.SetLabelBinding("LifeTotalP2");
            Player2LifeView.SetIncrementBinding("IncrementP2ValCommand");
            Player2LifeView.SetDecrementBinding("DecrementP2ValCommand");
        }
    }
}