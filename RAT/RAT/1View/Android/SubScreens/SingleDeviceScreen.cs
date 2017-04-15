using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAT.ZTry;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using RAT._2ViewModel.Test;
using Xamarin.Forms;

namespace Mobile
{
        public class DeviceScreen : Grid
        {
            private Button overviewButton, memoryButton, wifiButton, diskButton, cpuButton;
            int fontSize = 13;

            //Current screen on display
            private ScreenState myScreenState;
            private ScrollView myScrollView;
            //SubScreen
            private OverviewScreen overviewScreen;
            private CPUScreen cpuScreen;
            private RamScreen ramScreen;
            private DiskScreen diskScreen;
            private WifiScreen wifiScreen;
            private String deviceId = "";

            public DeviceScreen(string deviceId)
            {
                this.deviceId = deviceId;

                myScreenState = ScreenState.CPU;

                #region Buttons

                overviewButton = new Button();
                overviewButton.Text = "Debug-JSon";
                overviewButton.FontSize = fontSize;
                overviewButton.VerticalOptions = LayoutOptions.Center;
                overviewButton.HorizontalOptions = LayoutOptions.Center;
                overviewButton.BorderWidth = .000001;
                overviewButton.WidthRequest = 100;
                overviewButton.HeightRequest = 35;
            overviewButton.BackgroundColor = Color.Transparent;

            cpuButton = new Button();
                cpuButton.Text = "CPU";
                cpuButton.VerticalOptions = LayoutOptions.Center;
                cpuButton.HorizontalOptions = LayoutOptions.Center;
                cpuButton.BorderColor = Color.Transparent;
                cpuButton.TextColor = Color.Maroon;
            cpuButton.FontAttributes = FontAttributes.Bold;
                cpuButton.BorderWidth = .000001;
                cpuButton.WidthRequest = 100;
                cpuButton.HeightRequest = 35;
            cpuButton.BackgroundColor = Color.Transparent;

            memoryButton = new Button();
                memoryButton.Text = "Ram";
                memoryButton.FontSize = fontSize;
                memoryButton.VerticalOptions = LayoutOptions.Center;
                memoryButton.HorizontalOptions = LayoutOptions.Center;
                memoryButton.BorderColor = Color.Transparent;
                memoryButton.BorderWidth = .000001;
                memoryButton.WidthRequest = 100;
                memoryButton.HeightRequest = 35;
            memoryButton.BackgroundColor = Color.Transparent;

            diskButton = new Button();
                diskButton.Text = "Disk";
                diskButton.FontSize = fontSize;
                diskButton.VerticalOptions = LayoutOptions.Center;
                diskButton.HorizontalOptions = LayoutOptions.Center;
                diskButton.BorderColor = Color.Transparent;
                diskButton.BorderWidth = .000001;
                diskButton.WidthRequest = 100;
                diskButton.HeightRequest = 35;
            diskButton.BackgroundColor = Color.Transparent;

            wifiButton = new Button();
                wifiButton.Text = "WIFI";
                wifiButton.FontSize = fontSize;
                wifiButton.VerticalOptions = LayoutOptions.Center;
                wifiButton.HorizontalOptions = LayoutOptions.Center;
                wifiButton.BorderColor = Color.Transparent;
                wifiButton.BorderWidth = .000001;
                wifiButton.WidthRequest = 100;
                wifiButton.HeightRequest = 35;
            wifiButton.BackgroundColor = Color.Transparent;
            #endregion

            //Mid button grid
            Grid midGrid2 = new Grid();
                midGrid2.RowDefinitions.Add(new RowDefinition {Height = 35});
                midGrid2.ColumnSpacing = 0;
                midGrid2.RowSpacing = 0;
                midGrid2.HorizontalOptions = LayoutOptions.Center;
                midGrid2.Children.Add(cpuButton, 0, 0);
                midGrid2.Children.Add(memoryButton, 1, 0);
                midGrid2.Children.Add(diskButton, 2, 0);
                midGrid2.Children.Add(wifiButton, 3, 0);
            //Screen used for debugging purposes
                //midGrid2.Children.Add(overviewButton, 4, 0);

                //Adding to mid-grid
                Children.Add(midGrid2, 0, 0);

                myScrollView = new ScrollView();
            RowDefinitions.Add(new RowDefinition() { Height = 35 });


            //Initialising Overview Screen
            //Adding Cpu Screen
            cpuScreen = new CPUScreen(deviceId);

                //cpuScreen.Margin = new Thickness(0, 50, 0, 0);
                myScrollView.Content = cpuScreen;
                Children.Add(myScrollView, 0, 1);

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
                    wifiButton.TextColor = Color.Maroon;
                wifiButton.FontAttributes = FontAttributes.Bold;

                RemoveScreen();

                    //Adding Wifi Screen
                    wifiScreen = new WifiScreen(deviceId);
                    //wifiScreen.Margin = new Thickness(0, 50, 0, 0);
                    myScrollView.Content = wifiScreen;

                    myScreenState = ScreenState.WIFI;
                }
            }

            private void DiskButtonOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != ScreenState.DISK)
                {
                    diskButton.TextColor = Color.Maroon;
                diskButton.FontAttributes = FontAttributes.Bold;
                RemoveScreen();

                    //Adding Dsik Screen
                    diskScreen = new DiskScreen(deviceId);
                    //diskScreen.Margin = new Thickness(0, 50, 0, 0);
                    myScrollView.Content = diskScreen;

                    myScreenState = ScreenState.DISK;
                }
            }

            private void MemoryButtonOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != ScreenState.RAM)
                {
                    memoryButton.TextColor = Color.Maroon;
                memoryButton.FontAttributes = FontAttributes.Bold;
                RemoveScreen();

                    //Adding Ram Screen
                    ramScreen = new RamScreen(deviceId);
                    //ramScreen.Margin = new Thickness(0, 50, 0, 0);
                    myScrollView.Content = ramScreen;

                    myScreenState = ScreenState.RAM;
                }
            }

            private void CpuButtonOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != ScreenState.CPU)
                {
                    cpuButton.TextColor = Color.Maroon;
                cpuButton.FontAttributes = FontAttributes.Bold;
                RemoveScreen();

                    //Adding Cpu Screen
                    cpuScreen = new CPUScreen(deviceId);
                    //cpuScreen.Margin = new Thickness(0, 50, 0, 0);
                    myScrollView.Content = cpuScreen;

                    myScreenState = ScreenState.CPU;
                }
            }

            private void OverviewButtonOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != ScreenState.OVERVIEW)
                {
                    overviewButton.TextColor = Color.Maroon;
                overviewButton.FontAttributes = FontAttributes.Bold;
                RemoveScreen();

                    //Adding Overview Screen
                    overviewScreen = new OverviewScreen();
                    //overviewScreen.Margin = new Thickness(0, 50, 0, 0);
                    myScrollView.Content = overviewScreen;

                    myScreenState = ScreenState.OVERVIEW;
                }
            }

            public void RemoveScreen()
            {
                //Removes screen, sets button off
                if (myScreenState == ScreenState.OVERVIEW)
                {
                    overviewButton.TextColor = Color.Black;
                overviewButton.FontAttributes = FontAttributes.None;
                Children.Remove(overviewScreen);
                    overviewScreen.GC();
                    overviewScreen.BindingContext = null;
                    overviewScreen = null;
                }
                else if (myScreenState == ScreenState.CPU)
                {
                    cpuButton.TextColor = Color.Black;
                cpuButton.FontAttributes = FontAttributes.None;
                Children.Remove(cpuScreen);
                    cpuScreen.GC();
                    cpuScreen.BindingContext = null;
                    cpuScreen = null;

                }
                else if (myScreenState == ScreenState.RAM)
                {
                    memoryButton.TextColor = Color.Black;
                memoryButton.FontAttributes = FontAttributes.None;
                Children.Remove(ramScreen);
                    ramScreen.GC();
                    ramScreen.BindingContext = null;
                    ramScreen = null;

                }
                else if (myScreenState == ScreenState.WIFI)
                {
                    wifiButton.TextColor = Color.Black;
                wifiButton.FontAttributes = FontAttributes.None;
                Children.Remove(wifiScreen);
                    wifiScreen.GC();
                    wifiScreen.BindingContext = null;
                    wifiScreen = null;

                }
                else if (myScreenState == ScreenState.DISK)
                {
                    diskButton.TextColor = Color.Black;
                diskButton.FontAttributes = FontAttributes.None;
                Children.Remove(diskScreen);
                    diskScreen.GC();
                    diskScreen.BindingContext = null;
                    diskScreen = null;

                }
            }

            #endregion
        }
}