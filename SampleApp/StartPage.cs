using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SampleApp
{
    public class StartPage : ContentPage
    {
        public StartPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            OnStart();
        }

        private void OnStart()
        {

            var OptionGrid = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            OptionGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            OptionGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            OptionGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

            OptionGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            var OnePlayerButton = new Button()
            {
                Text = "1 Player Game",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                FontSize = 30
            };

            OnePlayerButton.Clicked += delegate
            {
                this.Navigation.PushAsync(new OnePlayerPage());
            };


            var TwoPlayerButton = new Button()
            {
                Text = "2 Player Game",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                FontSize = 30
            };

            TwoPlayerButton.Clicked += delegate
            {
                this.Navigation.PushAsync(new NameEntryPage());
            };

            var TestPageButton = new Button()
            {
                Text = "Test Page",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.End,
                FontSize = 30
            };

            TestPageButton.Clicked += delegate
            {
                this.Navigation.PushAsync(new TestPage());
            };


            OptionGrid.Children.Add(OnePlayerButton, 0, 0);
            OptionGrid.Children.Add(TwoPlayerButton, 1, 0);
            OptionGrid.Children.Add(TestPageButton, 2, 0);


            Content = OptionGrid;
        }
    }
}