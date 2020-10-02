﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerLifeView : ContentView
    {
        bool _isFlyoutOpen;
        double x, y;
        double _height, _width;
        double panThreshold = 0.25;
        double orientation;
        double behindViewSizeRatio = 0.8;

        string IncrementCommand;
        string DecrementCommand;

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

        private void setFlyoutOpen()
        {
            _isFlyoutOpen = true;
            //Disable life increment/decrement gestures
            RemoveIncrementBinding();
            RemoveDecrementBinding();
        }

        private void setFlyoutClosed()
        {
            _isFlyoutOpen = false;
            //Enable life increment/decrement gestures
            SetIncrementBinding(IncrementCommand);
            SetDecrementBinding(DecrementCommand);
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
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

            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if (!_isFlyoutOpen)
                    {
                        //check for swipe up relative to orientation
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
                        //check for swipe down relative to orientation
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
                    // Check if panned more than panThreshold.
                    // If so, open fully.  If not, close back down.
                    // Store the translation applied during the pan.
                    if (!_isFlyoutOpen)
                    {
                        if (orientation == 0)
                        {
                            if (CustomMainContent.TranslationY > (_height * panThreshold))
                            {
                                CustomMainContent.TranslationY = y + (_height * behindViewSizeRatio);
                                setFlyoutOpen();
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
                                setFlyoutOpen();
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
                                setFlyoutOpen();
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
                                setFlyoutOpen();
                            }
                            else if (CustomMainContent.TranslationX < (_width * panThreshold))
                            {
                                CustomMainContent.TranslationX = -x;
                            }
                        }
                    }
                    else if (_isFlyoutOpen)
                    {
                        if (orientation == 0)
                        {
                            if (y - CustomMainContent.TranslationY > (_height * panThreshold))
                            {
                                CustomMainContent.TranslationY = y - (_height * behindViewSizeRatio);
                                setFlyoutClosed();
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
                                setFlyoutClosed();
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
                                setFlyoutClosed();
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
                                setFlyoutClosed();
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

        public void SetTopColor(Color c)
        {
            CustomMainContent.BackgroundColor = c;
        }

        public void SetLabelBinding(String name)
        {
            LifeTotalLabel.SetBinding(Label.TextProperty, name);
        }

        public void SetIncrementBinding(String name)
        {
            IncrementCommand = name;
            IncrementTapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, name);
        }

        public void SetDecrementBinding(String name)
        {
            DecrementCommand = name;
            DecrementTapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, name);
        }

        private void RemoveIncrementBinding()
        {
            IncrementTapGestureRecognizer.ClearValue(TapGestureRecognizer.CommandProperty);
        }

        private void RemoveDecrementBinding()
        {
            DecrementTapGestureRecognizer.ClearValue(TapGestureRecognizer.CommandProperty);
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
         * but the orientation is changed "manually". For 180 degree rotations, flip row 0 and row 1.
         */
        public void SetOrientation(int degrees)
        {
            orientation = degrees;
            if (degrees == 90)
            {
                LifeTotalLabel.Rotation = degrees;

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
            }
            else if (degrees == -90)
            {
                LifeTotalLabel.Rotation = degrees;

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
 