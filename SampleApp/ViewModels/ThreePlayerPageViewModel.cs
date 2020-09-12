using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SampleApp.Models;

namespace SampleApp.ViewModels
{
    class ThreePlayerPageViewModel : INotifyPropertyChanged
    {
        Player Player1 = new Player();
        Player Player2 = new Player();
        Player Player3 = new Player();


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
        public Command EndGameCommand { get; set; }
        public Command SwipeP1Command { get; set; }
        public Command SwipeP2Command { get; set; }
        public Command SwipeP3Command { get; set; }

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

        public ThreePlayerPageViewModel()
        {
            //if (String.IsNullOrEmpty(name1) || String.IsNullOrEmpty(name2))
            //{
                Player1.Name = "Player 1";
                Player2.Name = "Player 2";
            Player3.Name = "Player 3";
            //}
            //else
            //{
             //   Player1.Name = name1;
               // Player2.Name = name2;
            //}
            Player1.LifeTotal = 20;
            Player2.LifeTotal = 20;
            Player3.LifeTotal = 20;
            IncrementValCommand = new Command(() => IncrementVal());
            DecrementValCommand = new Command(() => DecrementVal());
            IncrementP2ValCommand = new Command(() => IncrementP2Val());
            DecrementP2ValCommand = new Command(() => DecrementP2Val());
            IncrementP3ValCommand = new Command(() => IncrementP3Val());
            DecrementP3ValCommand = new Command(() => DecrementP3Val());
            EndGameCommand = new Command(() => EndGame());
            SwipeP1Command = new Command(() => SwipeP1());
            SwipeP2Command = new Command(() => SwipeP2());
            SwipeP3Command = new Command(() => SwipeP3());
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
        private void EndGame()
        {
            //fill this in
        }
        private void SwipeP1()
        {
            LifeTotalP1 = 999;
        }
        private void SwipeP2()
        {
            LifeTotalP2 = 999;
        }
        private void SwipeP3()
        {
            LifeTotalP3 = 999;
        }

    }
}

