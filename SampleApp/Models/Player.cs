using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleApp.Models
{
    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public int LifeTotal { get; set; }

        private int lifeTotal;
        public int LifeTotal
        {
            get
            {
                return lifeTotal;
            }
            set
            {
                if (lifeTotal != value)
                {
                    lifeTotal = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LifeTotal"));
                }
            }
        }
        public string Name { get; set; }

    }
}
