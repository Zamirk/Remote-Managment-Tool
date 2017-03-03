using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Label = Xamarin.Forms.Label;

namespace RAT._1View.Desktop.Manage
{
	public class DashboardScreen1 : Grid
    {
        //Debug visuals
        private ContentView aqua,
            black,blue,fuchsia,gray,green,lime,maroon,navy,
            olive,pink,purple,red,silver,teal,white,yellow;

        private bool debugMode = true;

        public DashboardScreen1()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;

            Grid mainGrid = new Grid();
            mainGrid.ColumnSpacing = 5;
            mainGrid.RowSpacing = 5;

            mainGrid.RowDefinitions.Add(new RowDefinition { Height = 25 });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            ContentView silverView = new ContentView() { BackgroundColor = Color.FromRgb(17, 150, 205) };

            List<ContentView> myContentViews = new List<ContentView>();
            Random rand = new Random();

            //Generating differnt colours
            for (int i = 0; i < 42; i++)
            {
                myContentViews.Add(new ContentView() {BackgroundColor = Color.FromRgb(rand.Next(255), rand.Next(255), rand.Next(255)) });
            }

            int pos = 0;
            //Addings colours
            for (int i = 0; i < 7; i++)
            {
                for (int z = 0; z < 6; z++)
                {
                    mainGrid.Children.Add(myContentViews[pos], i, z);
                    mainGrid.Children.Add(GenerateButton(),i,z);
                    pos++;
                }

            }
           // Grid.SetColumnSpan(silverView, 3);

            Children.Add(mainGrid);

       }

        public Button GenerateButton()
        {
            Button myButton = new Button();
            myButton.Text = "+";
            myButton.FontSize = 25;
            myButton.VerticalOptions = LayoutOptions.Center;
            myButton.HorizontalOptions = LayoutOptions.Center;
            myButton.BorderColor = Color.Transparent;
            myButton.BackgroundColor = Color.Transparent;
            myButton.BorderWidth = .000001;
            myButton.WidthRequest = 200;
            myButton.HeightRequest = 200;
            myButton.BackgroundColor = Color.Transparent;
            myButton.Clicked += OnOpenPupup;

            return myButton;
        }
        // Button Click
        private async void OnOpenPupup(object sender, EventArgs e)
        {
            //var page = new MyPopupPage();
            //MyPopupPage page = new MyPopupPage();
            //await Navigation.PushPopupAsync(page);
            // or
            //await PopupNavigation.PushAsync(page);

        }
    }
}
