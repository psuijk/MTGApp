using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleApp.Models;
using Xamarin.Forms;

namespace SampleApp
{
    public class TwoPlayerPage : ContentPage
    {
        protected override void OnAppearing()
          {

            base.OnAppearing();

            Player Player1 = new Player();

         

            Player1.LifeTotal = 20;

            Player Player2 = new Player();

            Player2.LifeTotal = 20;

            NavigationPage.SetHasNavigationBar(this, false);


            var MainGrid = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            

            //abstracting out a function to build UI is good, but breaking this down further is better.
            var P1Grid = new Grid()//grids are the bread and butter of xamarin forms, the documentation has lots of good examples I won't try to replicate here.
              {
                  HorizontalOptions = LayoutOptions.FillAndExpand,//these are on all UI elements, gotta specify them or the default values will probably screw up.
                  VerticalOptions = LayoutOptions.FillAndExpand
              };

            //main grid for player 2
            var P2Grid = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,//these are on all UI elements, gotta specify them or the default values will probably screw up.
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            MainGrid.Children.Add(P1Grid, 0, 0); 
            MainGrid.Children.Add(P2Grid, 0, 1);

            //I usually make a bunch of nice extensions on the Grid to add rows and columns easily
            P1Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            P1Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            //Extensions for player2 grid
            P2Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            P2Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });


            P1Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //column extension for p2 grid
            P2Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });


            //grid where life total label will live
            var GridForP1LifeTotal = new Grid()
              {
                  HorizontalOptions = LayoutOptions.FillAndExpand,
                  VerticalOptions = LayoutOptions.FillAndExpand
              };

            //Player 2's life total grid

            var GridForP2LifeTotal = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


              GridForP1LifeTotal.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
              GridForP1LifeTotal.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            //player 2's life total grid extensions
            GridForP2LifeTotal.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            GridForP2LifeTotal.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            //player1's life total column extension
            GridForP1LifeTotal.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //player 2's life total column extension
            GridForP2LifeTotal.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });





            //grid where buttons will live
            var GridForButtons = new Grid()
              {
                  HorizontalOptions = LayoutOptions.FillAndExpand,
                  VerticalOptions = LayoutOptions.FillAndExpand
              };

            var GridForP2Buttons = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            GridForButtons.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
              GridForButtons.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            //p2 button extensions
            GridForP2Buttons.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            GridForP2Buttons.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            //player1 button column extension
            GridForButtons.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //player 2 button column extensions
            GridForP2Buttons.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            //player 1 buttons
            P1Grid.Children.Add(GridForP1LifeTotal, 0, 0); //add items to the grid based on position
            P1Grid.Children.Add(GridForButtons, 0, 1);

            //player 2 buttons
            P2Grid.Children.Add(GridForP2LifeTotal, 0, 0); //add items to the grid based on position
            P2Grid.Children.Add(GridForP2Buttons, 0, 1);


            //Add labels
            var lifeLabel = new Label()
              {
                  Text = Player1.LifeTotal.ToString(),
                  FontAttributes = FontAttributes.Bold,
                  HorizontalOptions = LayoutOptions.Center,
                  VerticalOptions = LayoutOptions.Center,
                  FontSize = 60
              };

            //add player 2 lifetotal label
            var p2LifeLabel = new Label()
            {
                Text = Player2.LifeTotal.ToString(),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 60
            };


            GridForP1LifeTotal.Children.Add(lifeLabel, 0, 0);

            //player2
            GridForP2LifeTotal.Children.Add(p2LifeLabel, 0, 0);


            //Add buttons
            var UpButton = new Button()
              {
                  Text = "+",
                  FontAttributes = FontAttributes.Bold,
                  HorizontalOptions = LayoutOptions.Center,
                  VerticalOptions = LayoutOptions.Center,
                  FontSize = 30
              };

            //Add player2 buuttons
            var P2UpButton = new Button()
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

            //p2 upbutton eventhandler(?)
            P2UpButton.Clicked += delegate {
                //delegates are bad form but it's late and I'm tired you should put this login in a view model class and have that view model be a private property on this view.
                //View (this), View Model (the logic layer) then a Model to hold the life total and any other user data?
                Player2.LifeTotal += 1;
                p2LifeLabel.Text = Player2.LifeTotal.ToString();
            };

            var DownButton = new Button()
              {
                  Text = "-",
                  FontAttributes = FontAttributes.Bold,
                  HorizontalOptions = LayoutOptions.Center,
                  VerticalOptions = LayoutOptions.Center,
                  FontSize = 30
              };

            //p2 downbutton
            var P2DownButton = new Button()
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

            //p2
            P2DownButton.Clicked += delegate {
                //delegates are bad form but it's late and I'm tired
                Player2.LifeTotal -= 1;
                p2LifeLabel.Text = Player2.LifeTotal.ToString();
            };

            GridForButtons.Children.Add(UpButton, 0, 0);
              GridForButtons.Children.Add(DownButton, 1, 0);

            //p2 buttons
            GridForP2Buttons.Children.Add(P2UpButton, 0, 0);
            GridForP2Buttons.Children.Add(P2DownButton, 1, 0);

            Content = MainGrid;//very important, otherwise you don't actually see anything you've built

          }
    }
}