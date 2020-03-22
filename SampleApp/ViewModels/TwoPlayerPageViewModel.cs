using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SampleApp.Models;

namespace SampleApp.ViewModels
{
    class TwoPlayerPageViewModel : INotifyPropertyChanged
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
        public Command IncrementP2ValCommand { get; set; }
        public Command DecrementP2ValCommand { get; set; }

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
        private int valP2;

        public int ValP2
        {
            get
            {
                return valP2;
            }
            set
            {
                if (valP2 != value)
                {
                    valP2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ValP2"));
                }
            }
        }
        public TwoPlayerPageViewModel()
        {
            val = 20;
            valP2 = 20;
            IncrementValCommand = new Command(() => IncrementVal());
            DecrementValCommand = new Command(() => DecrementVal());
            IncrementP2ValCommand = new Command(() => IncrementP2Val());
            DecrementP2ValCommand = new Command(() => DecrementP2Val());
        }

        private void IncrementVal()
        {
            Val++;
        }
        private void DecrementVal()
        {
            Val--;
        }
        private void IncrementP2Val()
        {
            ValP2++;
        }
        private void DecrementP2Val()
        {
            ValP2--;
        }
    }
}

