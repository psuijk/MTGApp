﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SampleApp.Models;

namespace SampleApp.ViewModels
{
    public class StartPageViewModel : INotifyPropertyChanged
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

        public Command StartOnePlayerGameCommand { get; set; }
        public Command StartTwoPlayerGameCommand { get; set; }
        public Command StartThreePlayerGameCommand { get; set; }
        public Command StartFourPlayerGameCommand { get; set; }


        public StartPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            StartOnePlayerGameCommand = new Command(() => StartOnePlayerGame());
            StartTwoPlayerGameCommand = new Command(() => StartTwoPlayerGame());
            StartThreePlayerGameCommand = new Command(() => StartThreePlayerGame());
            StartFourPlayerGameCommand = new Command(() => StartFourPlayerGame());
        }

        private void StartOnePlayerGame()
        {
            this.Navigation.PushAsync(new Views.OnePlayerPage());
        }

        private void StartTwoPlayerGame()
        {
            this.Navigation.PushAsync(new Views.NameEntryPage());
        }

        private void StartThreePlayerGame()
        {
            this.Navigation.PushAsync(new Views.ThreePlayerPage());
        }

        private void StartFourPlayerGame()
        {
            this.Navigation.PushAsync(new Views.FourPlayerPage());
        }
    }
}

