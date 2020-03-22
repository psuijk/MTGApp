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
            InitializeComponent();
            BindingContext = new TwoPlayerPageViewModel();
        }
    }
}