using System;
using System.Collections.Generic;
using System.Text;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen
{
    // Main Page

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //Button
            Button colourButton = new Button();
            colourButton.Text = "Render me";
            colourButton.TextColor = Color.White;
            colourButton.BackgroundColor = Color.FromHex("33D615");
            colourButton.Clicked += OnOpenPupup;
            Content = colourButton;
        }

        // Button Click
        private async void OnOpenPupup(object sender, EventArgs e)
        {
            var page = new MyPopupPage();

            await Navigation.PushPopupAsync(page);
            // or
            //await PopupNavigation.PushAsync(page);
        }
    }
}
