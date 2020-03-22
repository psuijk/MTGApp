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

        private int val;

        public int Val
        {
            get
            {
                return val;
            }
            set
            {
                if (val != value)
                {
                    val = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Val"));
                }
            }
        }

        public OnePlayerPageViewModel()
        {
            val = 20;
            IncrementValCommand = new Command(() => IncrementVal());
            DecrementValCommand = new Command(() => DecrementVal());
        }

        private void IncrementVal()
        {
            Val++;
        }
        private void DecrementVal()
        {
            Val--;
        }
    }
}
