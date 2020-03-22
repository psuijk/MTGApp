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
        Player Player1 = new Player();
        Player Player2 = new Player();


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

        
        public TwoPlayerPageViewModel()
        {
            Player1.LifeTotal = 20;
            Player2.LifeTotal = 20;
            IncrementValCommand = new Command(() => IncrementVal());
            DecrementValCommand = new Command(() => DecrementVal());
            IncrementP2ValCommand = new Command(() => IncrementP2Val());
            DecrementP2ValCommand = new Command(() => DecrementP2Val());
        }

        private void IncrementVal()
        {
            Player1.LifeTotal++;
        }
        private void DecrementVal()
        {
            Player1.LifeTotal--;
        }
        private void IncrementP2Val()
        {
            Player2.LifeTotal++;
        }
        private void DecrementP2Val()
        {
            Player2.LifeTotal--;
        }
    }
}

