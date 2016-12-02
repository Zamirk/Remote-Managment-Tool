using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using RAT.ZTry;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class SystemPerformanceScreen : Grid
    {
        private Button overviewButton, memoryButton, wifiButton, diskButton, cpuButton;
        int fontSize = 13;

        //Current screen on display
        private ScreenState myScreenState;

        //SubScreen
        private OverviewScreen overviewScreen;
        private CPUScreen cpuScreen;
        private RamScreen ramScreen;
        private WIFIScreen wifiScreen;
        private DiskScreen diskScreen;

        public SystemPerformanceScreen()
        {
            myScreenState = ScreenState.OVERVIEW;
            #region Buttons
            overviewButton = new Button();
            overviewButton.Text = "Overview";
            overviewButton.FontSize = fontSize;
            overviewButton.VerticalOptions = LayoutOptions.Center;
            overviewButton.HorizontalOptions = LayoutOptions.Center;
            overviewButton.BorderColor = Color.Transparent;
            overviewButton.BackgroundColor = Color.Transparent;
            overviewButton.BorderWidth = .000001;
            overviewButton.WidthRequest = 100;
            overviewButton.HeightRequest = 50;
            overviewButton.BackgroundColor = Color.Gray;

            cpuButton = new Button();
            cpuButton.Text = "CPU";
            cpuButton.FontSize = fontSize;
            cpuButton.VerticalOptions = LayoutOptions.Center;
            cpuButton.HorizontalOptions = LayoutOptions.Center;
            cpuButton.BorderColor = Color.Transparent;
            cpuButton.BackgroundColor = Color.Transparent;
            cpuButton.BorderWidth = .000001;
            cpuButton.WidthRequest = 100;
            cpuButton.HeightRequest = 50;

            memoryButton = new Button();
            memoryButton.Text = "Ram";
            memoryButton.FontSize = fontSize;
            memoryButton.VerticalOptions = LayoutOptions.Center;
            memoryButton.HorizontalOptions = LayoutOptions.Center;
            memoryButton.BorderColor = Color.Transparent;
            memoryButton.BackgroundColor = Color.Transparent;
            memoryButton.BorderWidth = .000001;
            memoryButton.WidthRequest = 100;
            memoryButton.HeightRequest = 50;

            diskButton = new Button();
            diskButton.Text = "Disk";
            diskButton.FontSize = fontSize;
            diskButton.VerticalOptions = LayoutOptions.Center;
            diskButton.HorizontalOptions = LayoutOptions.Center;
            diskButton.BorderColor = Color.Transparent;
            diskButton.BackgroundColor = Color.Transparent;
            diskButton.BorderWidth = .000001;
            diskButton.WidthRequest = 100;
            diskButton.HeightRequest = 50;

            wifiButton = new Button();
            wifiButton.Text = "WIFI";
            wifiButton.FontSize = fontSize;
            wifiButton.VerticalOptions = LayoutOptions.Center;
            wifiButton.HorizontalOptions = LayoutOptions.Center;
            wifiButton.BorderColor = Color.Transparent;
            wifiButton.BackgroundColor = Color.Transparent;
            wifiButton.BorderWidth = .000001;
            wifiButton.WidthRequest = 100;
            wifiButton.HeightRequest = 50;
            #endregion

            //Mid button grid
            Grid midGrid2 = new Grid();
            midGrid2.RowDefinitions.Add(new RowDefinition { Height = 50 });
            midGrid2.ColumnSpacing = 0;
            midGrid2.RowSpacing = 0;
            midGrid2.HorizontalOptions = LayoutOptions.Center;
            midGrid2.Children.Add(overviewButton, 0, 0);
            midGrid2.Children.Add(cpuButton, 1, 0);
            midGrid2.Children.Add(memoryButton, 2, 0);
            midGrid2.Children.Add(diskButton, 3, 0);
            midGrid2.Children.Add(wifiButton, 4, 0);

            //Adding to mid-grid
            Children.Add(midGrid2, 0, 0);

            //Initialising Overview Screen
            overviewScreen = new OverviewScreen();
            overviewScreen.Margin = new Thickness(50, 50, 50, 0);
            Children.Add(overviewScreen, 0, 0);

            //Centre Buttons
            overviewButton.Clicked += OverviewButtonOnClicked;
            cpuButton.Clicked += CpuButtonOnClicked;
            memoryButton.Clicked += MemoryButtonOnClicked;
            diskButton.Clicked += DiskButtonOnClicked;
            wifiButton.Clicked += WifiButtonOnClicked;
        }

        #region Button Click Handlers

        private void WifiButtonOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ScreenState.WIFI)
            {
                wifiButton.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Ram Screen
                wifiScreen = new WIFIScreen();
                wifiScreen.Margin = new Thickness(50, 50, 50, 0);
                Children.Add(wifiScreen, 0, 0);

                GC.Collect();
                myScreenState = ScreenState.WIFI;
            }
        }

        private void DiskButtonOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ScreenState.DISK)
            {
                diskButton.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Ram Screen
                diskScreen = new DiskScreen();
                diskScreen.Margin = new Thickness(50, 50, 50, 0);
                Children.Add(diskScreen, 0, 0);

                GC.Collect();
                myScreenState = ScreenState.DISK;
            }
        }

        private void MemoryButtonOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ScreenState.RAM)
            {
                memoryButton.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Ram Screen
                ramScreen = new RamScreen();
                ramScreen.Margin = new Thickness(50, 50, 50, 0);
                Children.Add(ramScreen, 0, 0);

                GC.Collect();
                myScreenState = ScreenState.RAM;
            }
        }

        private void CpuButtonOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ScreenState.CPU)
            {
                cpuButton.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Cpu Screen
                cpuScreen = new CPUScreen();
                cpuScreen.Margin = new Thickness(50, 50, 50, 0);
                Children.Add(cpuScreen, 0, 0);

                GC.Collect();
                myScreenState = ScreenState.CPU;
            }
        }

        private void OverviewButtonOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ScreenState.OVERVIEW)
            {
                overviewButton.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Overview Screen
                overviewScreen = new OverviewScreen();
                overviewScreen.Margin = new Thickness(50, 50, 50, 0);
                Children.Add(overviewScreen, 0, 0);

                GC.Collect();
                myScreenState = ScreenState.OVERVIEW;
            }
        }

        public void RemoveScreen()
        {
            //Removes screen, sets button off
            if (myScreenState == ScreenState.OVERVIEW)
            {
                overviewButton.BackgroundColor = Color.Transparent;
                Children.Remove(overviewScreen);
            }
            else if (myScreenState == ScreenState.CPU)
            {
                cpuButton.BackgroundColor = Color.Transparent;
                Children.Remove(cpuScreen);
            }
            else if (myScreenState == ScreenState.RAM)
            {
                memoryButton.BackgroundColor = Color.Transparent;
                Children.Remove(ramScreen);
            }
            else if (myScreenState == ScreenState.WIFI)
            {
                wifiButton.BackgroundColor = Color.Transparent;
                Children.Remove(wifiScreen);
            }
            else if (myScreenState == ScreenState.DISK)
            {
                diskButton.BackgroundColor = Color.Transparent;
                Children.Remove(diskScreen);
            }
        }

        #endregion
    }
}