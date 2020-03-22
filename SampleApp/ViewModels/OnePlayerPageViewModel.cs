using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SampleApp.Models;

namespace SampleApp.ViewModels
{
    class OnePlayerPageViewModel : INotifyPropertyChanged
    {
        Player Player1 = new Player();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Command IncrementValCommand { get; set; }
        public Command DecrementValCommand { get; set; }




        public OnePlayerPageViewModel()
        {
            Player1.LifeTotal = 20;
            IncrementValCommand = new Command(() => IncrementVal());
            DecrementValCommand = new Command(() => DecrementVal());
        }

        private void IncrementVal()
        {
            Player1.LifeTotal++;
        }
        private void DecrementVal()
        {
            Player1.LifeTotal--;
        }
    }
}
