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
    public partial class StartPage : ContentPage
    {
        public StartPage(ViewModels.StartPageViewModel vm)
        {
            vm.Navigation = Navigation;
            InitializeComponent();
            BindingContext = new StartPageViewModel(Navigation);
        }
    }
}