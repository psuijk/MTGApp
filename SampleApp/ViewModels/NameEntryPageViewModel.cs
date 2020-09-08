using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SampleApp.Models;

namespace SampleApp.ViewModels
{
    public class NameEntryPageViewModel : INotifyPropertyChanged
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

        private string nameP1;

        public string NameP1
        {
            get
            {
                return nameP1;
            }
            set
            {
                if (NameP1 != value)
                {
                    nameP1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameP1"));
                }
            }
        }

        private string nameP2;

        public string NameP2
        {
            get
            {
                return nameP2;
            }
            set
            {
                if (NameP2 != value)
                {
                    nameP2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameP1"));
                }
            }
        }


        public Command StartGameCommand { get; set; }


        public NameEntryPageViewModel(INavigation navigation, string name1, string name2)
        {
            nameP1 = name1;
            nameP2 = name2;
            this.Navigation = navigation;
            StartGameCommand = new Command(() => StartGame(nameP1, nameP2));

        }

        private void StartGame(string name1, string name2)
        {
            
            this.Navigation.PushAsync(new Views.TwoPlayerPage());
        }

    }
}
