using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAT.ZTry;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using Xamarin.Forms;

namespace RAT._1View.Desktop.Screens.SubScreens
{

    namespace RAT._1View.Desktop
    {
        public class SystemResourcesToolbar : Grid
        {
            private Button overviewButton, memoryButton, wifiButton, diskButton, cpuButton;
            int fontSize = 13;

            //Current screen on display
            private ScreenState myScreenState;

            //SubScreen
            private OverviewScreen overviewScreen;
            private CPUScreen cpuScreen;
            private RamScreen ramScreen;
            private DiskScreen diskScreen;
            private WifiScreen wifiScreen;

            private string deviceId = "";
            private int deviceNum = 9;
            public SystemResourcesToolbar(String deviceId, int deviceNum)
            {
                this.deviceId = deviceId;
                this.deviceNum = deviceNum;
                myScreenState = ScreenState.CPU;

                #region Buttons

                if (Device.OS == TargetPlatform.Android)
                {
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
                }
                else
                {
                    overviewButton = new Button();
                    overviewButton.Text = "Debug-JSon";
                    overviewButton.FontSize = fontSize;
                    overviewButton.VerticalOptions = LayoutOptions.Center;
                    overviewButton.HorizontalOptions = LayoutOptions.Center;
                    overviewButton.BorderColor = Color.Transparent;
                    overviewButton.BackgroundColor = Color.Transparent;
                    overviewButton.BorderWidth = .000001;
                    overviewButton.WidthRequest = 100;
                    overviewButton.HeightRequest = 50;

                    cpuButton = new Button();
                    cpuButton.Text = "CPU";
                    cpuButton.FontSize = fontSize;
                    cpuButton.VerticalOptions = LayoutOptions.Center;
                    cpuButton.HorizontalOptions = LayoutOptions.Center;
                    cpuButton.BorderColor = Color.Transparent;
                    cpuButton.BackgroundColor = Color.Gray;
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
                }

                #endregion

                //Mid button grid
                Grid midGrid2 = new Grid();
                if (Device.OS == TargetPlatform.Android)
                {
                    midGrid2.RowDefinitions.Add(new RowDefinition {Height = 35});
                }
                else
                {
                    midGrid2.RowDefinitions.Add(new RowDefinition { Height = 50 });
                }
                midGrid2.ColumnSpacing = 0;
                midGrid2.RowSpacing = 0;
                midGrid2.HorizontalOptions = LayoutOptions.Center;
                midGrid2.Children.Add(cpuButton, 0, 0);
                midGrid2.Children.Add(memoryButton, 1, 0);
                midGrid2.Children.Add(diskButton, 2, 0);
                midGrid2.Children.Add(wifiButton, 3, 0);
                //midGrid2.Children.Add(overviewButton, 4, 0);

                //Adding to mid-grid
                Children.Add(midGrid2, 0, 0);

                //Initialising Overview Screen
                //Adding Cpu Screen
                cpuScreen = new CPUScreen(deviceNum);
                myScrollView = new ScrollView();
                if (Device.OS == TargetPlatform.Android)
                {
                    cpuScreen.Margin = new Thickness(0, 0, 0, 0);
                    myScrollView.Margin = new Thickness(0, 35, 0, 0);

                }
                else
                {
                    myScrollView.Margin = new Thickness(50, 50, 50, 0);
                }

                myScrollView.Content = cpuScreen;
                Children.Add(myScrollView, 0, 0);

                //Centre Buttons
                overviewButton.Clicked += OverviewButtonOnClicked;
                cpuButton.Clicked += CpuButtonOnClicked;
                memoryButton.Clicked += MemoryButtonOnClicked;
                diskButton.Clicked += DiskButtonOnClicked;
                wifiButton.Clicked += WifiButtonOnClicked;

        }
            private ScrollView myScrollView;

            #region Button Click Handlers

            private void WifiButtonOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != ScreenState.WIFI)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        wifiButton.TextColor = Color.Maroon;
                        wifiButton.FontAttributes = FontAttributes.Bold;
                    }
                    else
                    {
                        wifiButton.BackgroundColor = Color.Gray;
                    }
                    myScrollView.Content = null;

                    RemoveScreen();

                    //Adding Wifi Screen
                    wifiScreen = new WifiScreen(deviceNum);
                    myScrollView.Content = wifiScreen;
                    myScreenState = ScreenState.WIFI;
                }
            }

            private void DiskButtonOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != ScreenState.DISK)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        diskButton.TextColor = Color.Maroon;
                        diskButton.FontAttributes = FontAttributes.Bold;
                    }
                    else
                    {
                        diskButton.BackgroundColor = Color.Gray;
                    }
                    myScrollView.Content = null;

                    RemoveScreen();

                    //Adding Dsik Screen
                    diskScreen = new DiskScreen(deviceNum);
                    myScrollView.Content = diskScreen;
                    myScreenState = ScreenState.DISK;
                }
            }

            private void MemoryButtonOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != ScreenState.RAM)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        memoryButton.TextColor = Color.Maroon;
                        memoryButton.FontAttributes = FontAttributes.Bold;
                    }
                    else
                    {
                        memoryButton.BackgroundColor = Color.Gray;
                    }
                    myScrollView.Content = null;

                    RemoveScreen();

                    //Adding Ram Screen
                    ramScreen = new RamScreen(deviceNum);
                    myScrollView.Content = ramScreen;
                    myScreenState = ScreenState.RAM;
                }
            }

            private void CpuButtonOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != ScreenState.CPU)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        cpuButton.TextColor = Color.Maroon;
                        cpuButton.FontAttributes = FontAttributes.Bold;
                    }
                    else
                    {
                        cpuButton.BackgroundColor = Color.Gray;
                    }
                    myScrollView.Content = null;

                    RemoveScreen();

                    //Adding Cpu Screen
                    cpuScreen = new CPUScreen(deviceNum);
                    myScrollView.Content = cpuScreen;

                    myScreenState = ScreenState.CPU;
                }
            }

            private void OverviewButtonOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != ScreenState.OVERVIEW)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        overviewButton.TextColor = Color.Black;
                        overviewButton.FontAttributes = FontAttributes.None;
                    }
                    else
                    {
                        overviewButton.BackgroundColor = Color.Gray;
                    }
                    myScrollView.Content = null;

                    RemoveScreen();

                    //Adding Overview Screen
                    overviewScreen = new OverviewScreen();
                    myScrollView.Content = overviewScreen;

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
                    overviewScreen.GC();
                    overviewScreen.BindingContext = null;
                    overviewScreen = null;


                }
                else if (myScreenState == ScreenState.CPU)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        cpuButton.TextColor = Color.Black;
                        cpuButton.FontAttributes = FontAttributes.None;
                    }
                    else
                    {
                        cpuButton.BackgroundColor = Color.Transparent;
                    }
                    Children.Remove(cpuScreen);
                    cpuScreen.GC();
                    cpuScreen.BindingContext = null;
                    cpuScreen = null;

                }
                else if (myScreenState == ScreenState.RAM)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        memoryButton.TextColor = Color.Black;
                        memoryButton.FontAttributes = FontAttributes.None;
                    }
                    else
                    {
                        memoryButton.BackgroundColor = Color.Transparent;
                    }
                    Children.Remove(ramScreen);
                    ramScreen.GC();
                    ramScreen.BindingContext = null;
                    ramScreen = null;

                }
                else if (myScreenState == ScreenState.WIFI)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        wifiButton.TextColor = Color.Black;
                        wifiButton.FontAttributes = FontAttributes.None;
                    }
                    else
                    {
                        wifiButton.BackgroundColor = Color.Transparent;
                    }
                    Children.Remove(wifiScreen);
                    wifiScreen.GC();
                    wifiScreen.BindingContext = null;
                    wifiScreen = null;

                }
                else if (myScreenState == ScreenState.DISK)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        diskButton.TextColor = Color.Black;
                        diskButton.FontAttributes = FontAttributes.None;
                    }
                    else
                    {
                    diskButton.BackgroundColor = Color.Transparent;
                    }
                    Children.Remove(diskScreen);
                    diskScreen.GC();
                    diskScreen.BindingContext = null;
                    diskScreen = null;

                }
            }

            #endregion

            public void GC()
            {
                RemoveScreen();
            }
        }
    }
}