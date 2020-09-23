using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerLifeView : ContentView
    {
        // WHEN HIDDEN VIEW IS OPEN, WE SHOULD DISABLE THE TAP GESTURE SO
        // A PLAYER DOESN'T ACCIDENTALLY CHANGE THE LIFE TOTAL WHEN 
        // TRYING TO SWIPE BACK TO THE LIFE TOTAL VIEW!

        public PlayerLifeView()
        {
            InitializeComponent();
        }

        public void SetTopColor(Color c)
        {
            PlayerLifeSwipeView.BackgroundColor = c;
        }

        public void SetLabelBinding(String name)
        {
            LifeTotalLabel.SetBinding(Label.TextProperty, name);
        }

        public void SetIncrementBinding(String name)
        {
            IncrementTapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, name);
        }
        public void SetDecrementBinding(String name)
        {
            DecrementTapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, name);
        }
        /*
         * The ideal solution would be to use the Rotation attribute to rotate the player life view,
         * but unfortunately the sizing (height/width) of an object within a grid is determined
         * before rotation, and there is no recalculation of the size after rotation, so the view
         * ends up not filling the available space, except for 180 degree rotations.
         * 
         * I believe this is an issue with Xamarin itself based on similar complaints I found.
         * 
         * My workaround is to make the PlayerLifeView contain a 2x2 grid, and if an orientation
         * is changed by 90 degrees, transpose the grid rows/columns, so the sizing remains fixed
         * but the orientation is changed "manually". For 180 degree rotations, I cannot get the 
         * TapGestureRecognizer command to fire inside of a SwipeView with SwipeView.BottomItems
         * so instead I use Rotation=180 on the whole SwipeView (thankfully here there is no
         * sizing issue)
         */
        public void SetOrientation(int degrees)
        {
           if (degrees == 0)
           {  
                //Set Hidden Swipe View Size 
                PlayerLifeSwipeItemView.HeightRequest = PlayerLifeSwipeView.Height - 15;
                PlayerLifeSwipeItemView.WidthRequest = PlayerLifeSwipeView.Width;
            }
            else if (degrees == 90)
            {
                //Set Hidden Swipe View Size 
                PlayerLifeSwipeItemView.HeightRequest = PlayerLifeSwipeView.Height;
                PlayerLifeSwipeItemView.WidthRequest = PlayerLifeSwipeView.Width - 15;

                PlayerLifeSwipeView.RightItems = new SwipeItems(new SwipeItemView[] { PlayerLifeSwipeItemView });
                PlayerLifeSwipeView.TopItems.Remove(PlayerLifeSwipeItemView);

                LifeTotalLabel.Rotation = degrees;
                HiddenViewLabel.Rotation = degrees;

                Grid.SetColumn(DecrementBox, 0);
                Grid.SetColumnSpan(DecrementBox, 1);
                Grid.SetRow(DecrementBox, 0);
                Grid.SetRowSpan(DecrementBox, 2);

                Grid.SetColumn(IncrementBox, 1);
                Grid.SetColumnSpan(IncrementBox, 1);
                Grid.SetRow(IncrementBox, 0);
                Grid.SetRowSpan(IncrementBox, 2);
            }
            else if (degrees == 180)
            {
                //Set Hidden Swipe View Size 
                PlayerLifeSwipeItemView.HeightRequest = PlayerLifeSwipeView.Height - 15;
                PlayerLifeSwipeItemView.WidthRequest = PlayerLifeSwipeView.Width;

                PlayerLifeSwipeView.Rotation = 180;
            }
            else if (degrees == -90)
            {
                //Set Hidden Swipe View Size
                PlayerLifeSwipeItemView.HeightRequest = PlayerLifeSwipeView.Height;
                PlayerLifeSwipeItemView.WidthRequest = PlayerLifeSwipeView.Width - 15;

                PlayerLifeSwipeView.LeftItems = new SwipeItems(new SwipeItemView[] { PlayerLifeSwipeItemView });
                PlayerLifeSwipeView.TopItems.Remove(PlayerLifeSwipeItemView);

                LifeTotalLabel.Rotation = degrees;
                HiddenViewLabel.Rotation = degrees;

                Grid.SetColumn(DecrementBox, 1);
                Grid.SetColumnSpan(DecrementBox, 1);
                Grid.SetRow(DecrementBox, 0);
                Grid.SetRowSpan(DecrementBox, 2);

                Grid.SetColumn(IncrementBox, 0);
                Grid.SetColumnSpan(IncrementBox, 1);
                Grid.SetRow(IncrementBox, 0);
                Grid.SetRowSpan(IncrementBox, 2);
            }
        }
    }
}
 