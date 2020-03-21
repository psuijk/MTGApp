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


            //Add labels
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

            
            



        }
    }
}