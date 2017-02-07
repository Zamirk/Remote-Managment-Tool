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
    public partial class SelectItemPopup : PopupPage
    {
        private Button area, bar, column, line, bubble, candle, doughnut, fastline, funnel, hiLo,
            pieseries, polar, pyramid, radar, rangeArea, rangeColumn, scatterPlot, splineArea, spline,
            stackingArea100, stackingArea, stackingBar, stackingColumn100, stackingColumn, stepArea, stepLine;


        private string[] names = new string[]
        {
            "Area", "Bar", "Column", "Line", "Bubble", "Candle", "Doughnut", "Fastline", "Funnel", "Hilo,"
            ,"","","","","","","","","","","","","","","","","","","","","",
            "","","","","","","","","","","","","","","","","","",
            "","","","","","","","","","","","","","","","","",""
        };

        private List<Button> myButtons = new List<Button>();

        public SelectItemPopup()
        {
            Grid grid = new Grid();
            grid.VerticalOptions = LayoutOptions.FillAndExpand;
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            int z = 0;
            int x = 0;
            for (int i = 0; i < 24; i++)
            {
                myButtons.Add(new Button());
                myButtons[i].Text = names[i];
                myButtons[i].WidthRequest = 150;
                myButtons[i].HeightRequest = 85;
                myButtons[i].HorizontalOptions = LayoutOptions.Center;
                myButtons[i].VerticalOptions = LayoutOptions.Center;
                myButtons[i].BackgroundColor = Color.Black;
                myButtons[i].TextColor = Color.White;


                if (i < 8)
                {
                    grid.Children.Add(myButtons[i], 0, i);
                }
                else if (i < 16)
                {
                    grid.Children.Add(myButtons[i], 1, z);
                    z++;
                }
                else
                {
                    grid.Children.Add(myButtons[i], 2, x);
                    x++;
                }
            }
            Content = grid;
        }

        public Button AreaChart()
        {
            return myButtons[0];
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
