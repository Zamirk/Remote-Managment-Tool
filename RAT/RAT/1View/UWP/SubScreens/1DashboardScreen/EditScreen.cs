using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RAT._1View.Desktop.Manage;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen
{
    public partial class EditScreen : PopupPage
    {
        private StackLayout mainLayout, titleLayout;
        private StackLayout[] layouts;
        private Switch[] switches;
        private Label[] labels;

        private Stepper myStepper;
        private Label title, myLabel, switchLabel1, switchLabel2;
        private Switch mySwitch;
        private Switch mySwitch2;
        public string cellName = "Cell 2";

        public EditScreen()
        {
            //Initialising
            layouts = new StackLayout[10];
            switches = new Switch[10];
            labels = new Label[10];

            //Layout
            mainLayout = new StackLayout();
            mainLayout.Orientation = StackOrientation.Vertical;
            mainLayout.HorizontalOptions = LayoutOptions.Center;
            mainLayout.VerticalOptions = LayoutOptions.Center;
            mainLayout.BackgroundColor = Color.Black;
            mainLayout.WidthRequest = 300;
            mainLayout.HeightRequest = 200;

            //Title
            title = new Label();
            title.Text = cellName;
            title.VerticalOptions = LayoutOptions.Start;
            title.HorizontalOptions = LayoutOptions.Start;
            title.TextColor = Color.White;
            titleLayout = new StackLayout();
            titleLayout.Children.Add(title);

            //Title
            mainLayout.Children.Add(titleLayout);

            //Generating components
            for (int i = 0; i < 6; i++)
            {
                layouts[i] = new StackLayout();
                layouts[i].Orientation = StackOrientation.Horizontal;
                layouts[i].BackgroundColor = Color.Gray;

                labels[i] = new Label();
                labels[i].FontSize = 20;
                labels[i].TextColor = Color.Lime;
                labels[i].HorizontalOptions = LayoutOptions.CenterAndExpand;
                labels[i].VerticalOptions = LayoutOptions.CenterAndExpand;
                labels[i].Text = "" + i;

                switches[i] = new Switch();
                switches[i].HorizontalOptions = LayoutOptions.CenterAndExpand;

                layouts[i].Children.Add(labels[i]);
                layouts[i].Children.Add(switches[i]);
                mainLayout.Children.Add(layouts[i]);
            }

            //Stepper
            myStepper = new Stepper();
            myStepper.Minimum = 0;
            myStepper.Maximum = 100;
            myStepper.HorizontalOptions = LayoutOptions.CenterAndExpand;
            //myStepper.ValueChanged += OnStepperValueChanged;

            this.Content = mainLayout;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // Method for animation child in PopupPage
        // Invoced after custom animation end
        protected virtual Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        protected virtual Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1); ;
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            //return base.OnBackButtonPressed();
            return true;
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return default value - CloseWhenBackgroundIsClicked
            return base.OnBackgroundClicked();
        }
    }
}
