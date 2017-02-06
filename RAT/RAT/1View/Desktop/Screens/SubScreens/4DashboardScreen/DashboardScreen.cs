﻿using System;
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
	public class DashboardScreen : Grid
    {
        //Debug visuals
        private ContentView aqua,
            black,blue,fuchsia,gray,green,lime,maroon,navy,
            olive,pink,purple,red,silver,teal,white,yellow;

        private bool debugMode = true;
        private Grid mainGrid;

        public DashboardScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;

            mainGrid = new Grid();
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

            List<ContentView> myContentViews = new List<ContentView>();
            Random rand = new Random();

            //Generating differnt colours
            for (int i = 0; i < 42; i++)
            {
                myContentViews.Add(new ContentView()
                {
                    //BackgroundColor = Color.FromRgb(rand.Next(255), rand.Next(255), rand.Next(255))
                });
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
            SelectItemPopup aaa = new SelectItemPopup();
            aaa.aaaa().Clicked += MyButtonOnClicked;
            await Navigation.PushPopupAsync(aaa);
        }

        private void MyButtonOnClicked(object sender, EventArgs eventArgs)
        {
            //Button aaaaaaaa = sender as Button;
            mainGrid.Children.Add(GenerateLineChart(), 0, 1);
        }

        public SfChart GenerateLineChart()
        {
            //Chart
            SfChart myChart = new SfChart();

            myChart.Series.Add(new StepAreaSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            //myChart.Series[0].ItemsSource = myViewModel.Data;
            myChart.Series[0].EnableTooltip = true;

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;
            Children.Add(myChart, 0, 0);

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            //TODO ONLY USE AS TESTING
                    ObservableCollection<ChartDataPoint> data = new ObservableCollection<ChartDataPoint>();
            int z = 0;
        bool a = true;
                   double value = 50;
            for (var i = 0; i < 25; i++)
            {
                z++;
                if (a)
                {
                    data.Add(new ChartDataPoint(z, value+20));
                    a = false;
                }
                else
                {
                    data.Add(new ChartDataPoint(z, value-20));
                    a = true;
                }
                myChart.Series[0].ItemsSource = data;
                myChart.PrimaryAxis.IsVisible = false;
                myChart.SecondaryAxis.IsVisible = false;
            }
            return myChart;
        }

    }
}
