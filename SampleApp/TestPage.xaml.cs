using Xamarin.Forms;

namespace SampleApp
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {

            InitializeComponent();
            BindingContext = new TestPageViewModel();
        }
    }
}