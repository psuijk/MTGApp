using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SampleApp
{
    class TestPageViewModel : INotifyPropertyChanged
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

        private int val;

        public int Val { 
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

        public TestPageViewModel()
        {
            val = 0;
            IncrementValCommand = new Command(() => IncrementVal());
        }

        private void IncrementVal()
        {
            Val++;
        }
    }
}

