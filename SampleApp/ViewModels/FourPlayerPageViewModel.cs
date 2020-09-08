using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SampleApp.Models;

namespace SampleApp.ViewModels
{
    class FourPlayerPageViewModel : INotifyPropertyChanged
    {
        Player Player1 = new Player();
        Player Player2 = new Player();
        Player Player3 = new Player();
        Player Player4 = new Player();

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
        public Command IncrementP3ValCommand { get; set; }
        public Command DecrementP3ValCommand { get; set; }
        public Command IncrementP4ValCommand { get; set; }
        public Command DecrementP4ValCommand { get; set; }
        public Command EndGameCommand { get; set; }

        public string NameP1
        {
            get
            {
                return Player1.Name;
            }
            set
            {
                if (Player1.Name != value)
                {
                    Player1.Name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameP1"));
                }
            }
        }

        public string NameP2
        {
            get
            {
                return Player2.Name;
            }
            set
            {
                if (Player2.Name != value)
                {
                    Player2.Name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NameP2"));
                }
            }
        }

        public int LifeTotalP1
        {
            get
            {
                return Player1.LifeTotal;
            }
            set
            {
                if (Player1.LifeTotal != value)
                {
                    Player1.LifeTotal = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LifeTotalP1"));
                }
            }
        }

        public int LifeTotalP2
        {
            get
            {
                return Player2.LifeTotal;
            }
            set
            {
                if (Player2.LifeTotal != value)
                {
                    Player2.LifeTotal = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LifeTotalP2"));
                }
            }
        }

        public int LifeTotalP3
        {
            get
            {
                return Player3.LifeTotal;
            }
            set
            {
                if (Player3.LifeTotal != value)
                {
                    Player3.LifeTotal = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LifeTotalP3"));
                }
            }
        }

        public int LifeTotalP4
        {
            get
            {
                return Player4.LifeTotal;
            }
            set
            {
                if (Player4.LifeTotal != value)
                {
                    Player4.LifeTotal = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LifeTotalP4"));
                }
            }
        }

        public FourPlayerPageViewModel()
        {
            //if (String.IsNullOrEmpty(name1) || String.IsNullOrEmpty(name2))
            //{
                Player1.Name = "Player 1";
                Player2.Name = "Player 2";
            Player3.Name = "Player 3";
            Player4.Name = "Player 4";
            //}
            //else
            //{
            //   Player1.Name = name1;
            // Player2.Name = name2;
            //}
            Player1.LifeTotal = 20;
            Player2.LifeTotal = 20;
            Player3.LifeTotal = 20;
            Player4.LifeTotal = 20;
            IncrementValCommand = new Command(() => IncrementVal());
            DecrementValCommand = new Command(() => DecrementVal());
            IncrementP2ValCommand = new Command(() => IncrementP2Val());
            DecrementP2ValCommand = new Command(() => DecrementP2Val());
            IncrementP3ValCommand = new Command(() => IncrementP3Val());
            DecrementP3ValCommand = new Command(() => DecrementP3Val());
            IncrementP4ValCommand = new Command(() => IncrementP4Val());
            DecrementP4ValCommand = new Command(() => DecrementP4Val());
            EndGameCommand = new Command(() => EndGame());
        }

        private void IncrementVal()
        {
            LifeTotalP1++;
        }
        private void DecrementVal()
        {
            LifeTotalP1--;
        }
        private void IncrementP2Val()
        {
            LifeTotalP2++;
        }
        private void DecrementP2Val()
        {
            LifeTotalP2--;
        }
        private void IncrementP3Val()
        {
            LifeTotalP3++;
        }
        private void DecrementP3Val()
        {
            LifeTotalP3--;
        }
        private void IncrementP4Val()
        {
            LifeTotalP4++;
        }
        private void DecrementP4Val()
        {
            LifeTotalP4--;
        }
        private void EndGame()
        {
            //fill this in
        }

    }
}

