using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SampleApp.Models;

namespace SampleApp.ViewModels
{
    class HomePageViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Command SinglePhonePlayCommand { get; set; }
        public Command MultiPhonePlayCommand { get; set; }
        public Command SettingsCommand { get; set; }

        public HomePageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            SinglePhonePlayCommand = new Command(() => SinglePhonePlay());
            MultiPhonePlayCommand = new Command(() => MultiPhonePlay());
            SettingsCommand = new Command(() => Settings());
        }

        private void SinglePhonePlay()
        {
            this.Navigation.PushAsync(new Views.StartPage());
        }

        private void MultiPhonePlay()
        {
            //fill this in
        }
        private void Settings()
        {
            //fill this in
        }
    }
}
