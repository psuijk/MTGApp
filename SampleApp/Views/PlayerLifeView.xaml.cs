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

        bool _isFlyoutOpen;
        //uint _flyoutSpeed = 300;
        double x, y;
        double _height, _width;
        double panThreshold = 0.25;
        double orientation;
        double behindViewSizeRatio = 0.94;

        public PlayerLifeView()
        {
            InitializeComponent();
            _isFlyoutOpen = false;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            _height = height;
            _width = width;
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (orientation == 180)
            {
                Console.WriteLine("1 : " + e.TotalY);
            }
            // On Android, when the view element that a PanGesture lives on
            // moves while panning, it produces a jitter. The following 
            // checks if the Device is an Android and adjusts the EventArgs
            // to remove the jitter.
            if (Device.RuntimePlatform == Device.Android)
            {
                double TranslationX = CustomMainContent.TranslationX;
                double TranslationY = CustomMainContent.TranslationY;

                double TotalX_Modified = e.TotalX + TranslationX;
                double TotalY_Modified = e.TotalY + TranslationY;
                e = new PanUpdatedEventArgs(e.StatusType, e.GestureId, TotalX_Modified, TotalY_Modified);
            }

            if (orientation == 180)
            {
                Console.WriteLine("2 : " + e.TotalY);
            }

            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if (!_isFlyoutOpen)
                    {
                        if (orientation == 0 && e.TotalY > 0)
                            CustomMainContent.TranslationY = e.TotalY;
                        else if (orientation == 180 && e.TotalY < 0)
                            CustomMainContent.TranslationY = e.TotalY;
                        else if (orientation == 90 && e.TotalX < 0)
                            CustomMainContent.TranslationX = e.TotalX;
                        else if (orientation == -90 && e.TotalX > 0)
                            CustomMainContent.TranslationX = e.TotalX;
                    }
                    else if (_isFlyoutOpen)
                    {
                        if (orientation == 0 && CustomMainContent.TranslationY > 0)
                            CustomMainContent.TranslationY = Math.Max(e.TotalY, 0);
                        else if (orientation == 180 && CustomMainContent.TranslationY < 0)
                            CustomMainContent.TranslationY = Math.Min(e.TotalY, 0);
                        else if (orientation == 90 && CustomMainContent.TranslationX < 0)
                            CustomMainContent.TranslationX = Math.Min(e.TotalX, 0);
                        if (orientation == -90 && CustomMainContent.TranslationX > 0)
                            CustomMainContent.TranslationX = Math.Max(e.TotalX, 0);
                    }
                    break;

                case GestureStatus.Completed:
                    // Check if panned more than some percent threshold (30%, 50%?)
                    // if so, open fully
                    //if not, close back down
                    // Store the translation applied during the pan
                    if (!_isFlyoutOpen)
                    {
                        if (orientation == 0)
                        {
                            if (CustomMainContent.TranslationY > (_height * panThreshold))
                            {
                                CustomMainContent.TranslationY = y + (_height * behindViewSizeRatio);
                                _isFlyoutOpen = true;
                            }
                            else if (CustomMainContent.TranslationY < (_height * panThreshold))
                            {
                                CustomMainContent.TranslationY = -y;
                            }
                        }
                        else if (orientation == 180)
                        {
                            if (CustomMainContent.TranslationY < -(_height * panThreshold))
                            {
                                CustomMainContent.TranslationY = y - (_height * behindViewSizeRatio);
                                _isFlyoutOpen = true;
                            }
                            else if (CustomMainContent.TranslationY < (_height * panThreshold))
                            {
                                CustomMainContent.TranslationY = y;
                            }
                        }
                        else if (orientation == 90)
                        {
                            if (CustomMainContent.TranslationX < -(_width * panThreshold))
                            {
                                CustomMainContent.TranslationX = x - (_width * behindViewSizeRatio);
                                _isFlyoutOpen = true;
                            }
                            else if (CustomMainContent.TranslationX < (_width * panThreshold))
                            {
                                CustomMainContent.TranslationX = x;
                            }
                        }
                        else if (orientation == -90)
                        {
                            if (CustomMainContent.TranslationX > (_width * panThreshold))
                            {
                                CustomMainContent.TranslationX = x + (_width * behindViewSizeRatio);
                                _isFlyoutOpen = true;
                            }
                            else if (CustomMainContent.TranslationX < (_width * panThreshold))
                            {
                                CustomMainContent.TranslationX = -x;
                            }
                        }
                    }
                    else if (_isFlyoutOpen)
                    {
                        Console.WriteLine("FL  + h" + _height + " trY" + CustomMainContent.TranslationY + " e:" + e.TotalY + " y:" + y + " << " + _height * panThreshold + " ;; " + (_height * behindViewSizeRatio));
                        if (orientation == 0)
                        {
                            if (y - CustomMainContent.TranslationY > (_height * panThreshold))
                            {
                                CustomMainContent.TranslationY = y - (_height * behindViewSizeRatio);
                                _isFlyoutOpen = false;
                            }
                            else if (y - CustomMainContent.TranslationY <= (_height * panThreshold))
                            {
                                CustomMainContent.TranslationY = y;
                            }
                        }
                        else if (orientation == 180)
                        {
                            if (- y + CustomMainContent.TranslationY > (_height * panThreshold))
                            {
                                CustomMainContent.TranslationY = y + (_height * behindViewSizeRatio);
                                _isFlyoutOpen = false;
                            }
                            else if (- y + CustomMainContent.TranslationY <= (_height * panThreshold))
                            {
                                CustomMainContent.TranslationY = y;
                            }
                        }
                        else if (orientation == 90)
                        {
                            if (-x + CustomMainContent.TranslationX > (_width * panThreshold))
                            {
                                CustomMainContent.TranslationX = x + (_width * behindViewSizeRatio);
                                _isFlyoutOpen = false;
                            }
                            else if (-x + CustomMainContent.TranslationX <= (_width * panThreshold))
                            {
                                CustomMainContent.TranslationX = x;
                            }
                        }
                        else if (orientation == -90)
                        {
                            if (x - CustomMainContent.TranslationX > (_width * panThreshold))
                            {
                                CustomMainContent.TranslationX = x - (_width * behindViewSizeRatio);
                                _isFlyoutOpen = false;
                            }
                            else if (x - CustomMainContent.TranslationX <= (_width * panThreshold))
                            {
                                CustomMainContent.TranslationX = x;
                            }
                        }
                    }

                    y = CustomMainContent.TranslationY;
                    x = CustomMainContent.TranslationX;
                    break;
            }
        }

        /*private double orientPanValue(PanUpdatedEventArgs e)
        {
            switch (orientation)
            {
                case 90:
                    return 0;
                case 180:
                    return -e.TotalY;
                case -90:
                    return 0;
            }
            return e.TotalY; // orientation == 0 or error handling
        }*/

        public void SetTopColor(Color c)
        {
            CustomMainContent.BackgroundColor = c;//PlayerLifeSwipeView.BackgroundColor = c;
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
            orientation = degrees;
           if (degrees == 0)
           {  
                //Set Hidden Swipe View Size 
             //   PlayerLifeSwipeItemView.HeightRequest = PlayerLifeSwipeView.Height - 15;
             //   PlayerLifeSwipeItemView.WidthRequest = PlayerLifeSwipeView.Width;
            }
            else if (degrees == 90)
            {
                //Set Hidden Swipe View Size 
             //   PlayerLifeSwipeItemView.HeightRequest = PlayerLifeSwipeView.Height;
             //   PlayerLifeSwipeItemView.WidthRequest = PlayerLifeSwipeView.Width - 15;

             //   PlayerLifeSwipeView.RightItems = new SwipeItems(new SwipeItemView[] { PlayerLifeSwipeItemView });
             //   PlayerLifeSwipeView.TopItems.Remove(PlayerLifeSwipeItemView);

                LifeTotalLabel.Rotation = degrees;
               // HiddenViewLabel.Rotation = degrees;

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
                LifeTotalLabel.Rotation = degrees;

                Grid.SetColumn(DecrementBox, 0);
                Grid.SetColumnSpan(DecrementBox, 2);
                Grid.SetRow(DecrementBox, 0);
                Grid.SetRowSpan(DecrementBox, 1);

                Grid.SetColumn(IncrementBox, 0);
                Grid.SetColumnSpan(IncrementBox, 2);
                Grid.SetRow(IncrementBox, 1);
                Grid.SetRowSpan(IncrementBox, 1);

                //Set Hidden Swipe View Size 
                //   PlayerLifeSwipeItemView.HeightRequest = PlayerLifeSwipeView.Height - 15;
                //   PlayerLifeSwipeItemView.WidthRequest = PlayerLifeSwipeView.Width;

                // CustomMainContent.Rotation = 180;//PlayerLifeSwipeView.Rotation = 180;
            }
            else if (degrees == -90)
            {
                //Set Hidden Swipe View Size
             //   PlayerLifeSwipeItemView.HeightRequest = PlayerLifeSwipeView.Height;
             //   PlayerLifeSwipeItemView.WidthRequest = PlayerLifeSwipeView.Width - 15;

             //   PlayerLifeSwipeView.LeftItems = new SwipeItems(new SwipeItemView[] { PlayerLifeSwipeItemView });
              //  PlayerLifeSwipeView.TopItems.Remove(PlayerLifeSwipeItemView);

                LifeTotalLabel.Rotation = degrees;
          //      HiddenViewLabel.Rotation = degrees;

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
 