using System;
using System.IO;
using Xamarin.Forms;
using SampleApp.Models;


namespace SampleApp
{
    //contentpage is the base class for all pages.
    //You should make a base class for this page that isn't contentpage, but inherits from content page, then you can add custom methods that extend across all pages.
    //Like adding a progress spinner, or disabling all UI elements.
    public class OnePlayerPage : ContentPage
    {

        public OnePlayerPage(string name)
        {

            CreateUI(name);

            NavigationPage.SetHasNavigationBar(this, false);
        }

        public OnePlayerPage()
        {

            CreateUI();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void CreateUI(string name)
        {
            Player Player1 = new Player();
            Player1.Name = name;
            Player1.LifeTotal = 20;

            //abstracting out a function to build UI is good, but breaking this down further is better.
            var MainGrid = new Grid()//grids are the bread and butter of xamarin forms, the documentation has lots of good examples I won't try to replicate here.
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,//these are on all UI elements, gotta specify them or the default values will probably screw up.
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //I usually make a bunch of nice extensions on the Grid to add rows and columns easily
            MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //grid where life total label will live
            var GridForLifeTotal = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            GridForLifeTotal.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            GridForLifeTotal.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            GridForLifeTotal.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //grid where buttons will live
            var GridForButtons = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            GridForButtons.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            GridForButtons.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            GridForButtons.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            MainGrid.Children.Add(GridForLifeTotal, 0, 0); //add items to the grid based on position
            MainGrid.Children.Add(GridForButtons, 0, 1);

            //Add labels
            var lifeLabel = new Label()
            {
                Text = Player1.LifeTotal.ToString(),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 60
            };

            GridForLifeTotal.Children.Add(lifeLabel, 0, 0);

            //Add buttons
            var UpButton = new Button()
            {
                Text = "+",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 30
            };

            UpButton.Clicked += delegate {
                //delegates are bad form but it's late and I'm tired you should put this login in a view model class and have that view model be a private property on this view.
                //View (this), View Model (the logic layer) then a Model to hold the life total and any other user data?
                Player1.LifeTotal += 1;
                lifeLabel.Text = Player1.LifeTotal.ToString();
	        };

            var DownButton = new Button()
            {
                Text = "-",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 30
            };

            DownButton.Clicked += delegate {
                //delegates are bad form but it's late and I'm tired
                Player1.LifeTotal -= 1;
                lifeLabel.Text = Player1.LifeTotal.ToString();
            };

            var MorePlayers = new Button()
            {
                Text = "2 Player Game",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                FontSize = 30
            };

            MorePlayers.Clicked += delegate
            {
                this.Navigation.PushAsync(new TwoPlayerPage());
            };

            GridForButtons.Children.Add(UpButton, 0, 0);
            GridForButtons.Children.Add(DownButton, 1, 0);
            GridForButtons.Children.Add(MorePlayers, 0, 1);

            Content = MainGrid;//very important, otherwise you don't actually see anything you've built

        }


        private void CreateUI()
        {
            Player Player1 = new Player();
            Player1.Name = "Player 1";
            Player1.LifeTotal = 20;

            //abstracting out a function to build UI is good, but breaking this down further is better.
            var MainGrid = new Grid()//grids are the bread and butter of xamarin forms, the documentation has lots of good examples I won't try to replicate here.
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,//these are on all UI elements, gotta specify them or the default values will probably screw up.
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //I usually make a bunch of nice extensions on the Grid to add rows and columns easily
            MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            MainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            MainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //grid where life total label will live
            var GridForLifeTotal = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            GridForLifeTotal.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            GridForLifeTotal.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            GridForLifeTotal.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //grid where buttons will live
            var GridForButtons = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            GridForButtons.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            GridForButtons.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            GridForButtons.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            MainGrid.Children.Add(GridForLifeTotal, 0, 0); //add items to the grid based on position
            MainGrid.Children.Add(GridForButtons, 0, 1);

            //Add labels
            var lifeLabel = new Label()
            {
                Text = Player1.LifeTotal.ToString(),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 60
            };

            GridForLifeTotal.Children.Add(lifeLabel, 0, 0);

            //Add buttons
            var UpButton = new Button()
            {
                Text = "+",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 30
            };

            UpButton.Clicked += delegate {
                //delegates are bad form but it's late and I'm tired you should put this login in a view model class and have that view model be a private property on this view.
                //View (this), View Model (the logic layer) then a Model to hold the life total and any other user data?
                Player1.LifeTotal += 1;
                lifeLabel.Text = Player1.LifeTotal.ToString();
            };

            var DownButton = new Button()
            {
                Text = "-",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 30
            };

            DownButton.Clicked += delegate {
                //delegates are bad form but it's late and I'm tired
                Player1.LifeTotal -= 1;
                lifeLabel.Text = Player1.LifeTotal.ToString();
            };

            /*
            var MorePlayers = new Button()
            {
                Text = "2 Player Game",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                FontSize = 30
            };

            MorePlayers.Clicked += delegate
            {
                this.Navigation.PushAsync(new TwoPlayerPage());
            };
            */


            GridForButtons.Children.Add(UpButton, 0, 0);
            GridForButtons.Children.Add(DownButton, 1, 0);
            //GridForButtons.Children.Add(MorePlayers, 0, 1);

            Content = MainGrid;//very important, otherwise you don't actually see anything you've built

        }

    }
}
