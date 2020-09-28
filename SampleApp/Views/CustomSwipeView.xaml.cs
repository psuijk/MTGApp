using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomSwipeView : ContentView
    {
        public CustomSwipeView()
        {
            InitializeComponent();
             _isFlyoutOpen = false;

           // Add event listeners for SizeChanged - Allows us to capture page values after it is rendered
           // MainContent.SizeChanged += OnMainContentSizeChanged;
        }

        bool _isFlyoutOpen;
        //uint _flyoutSpeed = 300;
        double y;
        double _height;
        double panThreshold = 0.25;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            _height = height;
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                    if ((!_isFlyoutOpen && e.TotalY > 0) || (_isFlyoutOpen && e.TotalY < 0))
                    {
                        CustomMainContent.TranslationY = y + e.TotalY;
                    }
                    break;

                case GestureStatus.Completed:
                    // Check if panned more than some percent threshold (30%, 50%?)
                    // if so, open fully
                    //if not, close back down
                    // Store the translation applied during the pan
                    if (CustomMainContent.TranslationY > (_height * panThreshold) && !_isFlyoutOpen)
                    {
                        CustomMainContent.TranslationY = y + (_height * .9);
                        _isFlyoutOpen = true;
                    }
                    else if (CustomMainContent.TranslationY < (_height * panThreshold) && !_isFlyoutOpen)
                    {
                        CustomMainContent.TranslationY = -y;
                    }
                    else if ((- _height + CustomMainContent.TranslationY) < -(_height * panThreshold) && _isFlyoutOpen)
                    {
                        CustomMainContent.TranslationY = y - (_height * .9);
                        _isFlyoutOpen = false;
                    }
                    else if ((- _height + CustomMainContent.TranslationY) > -(_height * panThreshold) && _isFlyoutOpen)
                    {
                        CustomMainContent.TranslationY = y;
                    }

                    //x = CustomMainContent.TranslationX;
                    y = CustomMainContent.TranslationY;
                    break;
            }
        }
    }
}