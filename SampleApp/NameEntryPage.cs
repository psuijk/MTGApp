using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleApp.Models;
using Xamarin.Forms;

namespace SampleApp
{

    public class NameEntryPage : ContentPage
    {

        protected override void OnAppearing()
        {

            base.OnAppearing();

            var PageGrid = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //row and column extensions for PageGrid
            PageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            PageGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            PageGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            var EntryGrid = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //row and column extensions for PageGrid
            EntryGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            EntryGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            EntryGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });



            //Add label for Name Entry 1
            var Name1Instruction = new Label()
            {
                Text = "Enter a name for Player 1",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 60
            };

            PageGrid.Children.Add(Name1Instruction, 0, 0);


            var Name1Entry = new Entry { Text = Console.ReadLine() };

            string name1 = Name1Entry.Text;

           

            //Add label for name entry 2
            var Name2Instruction = new Label()
            {
                Text = "Enter a name for Player 1",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 60
            };

            PageGrid.Children.Add(Name2Instruction, 0, 1);


            var Name2Entry = new Entry { Text = Console.ReadLine() };

            string name2 = Name2Entry.Text;

            var GridForButtons = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            GridForButtons.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            GridForButtons.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            GridForButtons.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            var Start = new Button()
            {
                Text = "Start Game",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 30
            };

            Start.Clicked += delegate {
                this.Navigation.PushAsync(new TwoPlayerPage(name1, name2));

            };

            GridForButtons.Children.Add(Start, 0, 0);

            PageGrid.Children.Add(EntryGrid, 0, 0);
            PageGrid.Children.Add(GridForButtons, 0, 1);

            Content = PageGrid;
        }
    }
}