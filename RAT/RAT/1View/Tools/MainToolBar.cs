using System;
using System.Collections.Generic;
using System.Text;
using IoTHubAmqpService;
using RAT.ZTry;
using RAT._1.RAT._1View.Desktop;
using RAT._1View.Desktop;
using RAT._1View.Desktop.Screens.SubScreens.RAT._1View.Desktop;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using RAT._1View.Desktop._1Tools;
using Xamarin.Forms;

namespace RAT._1View.UWP.SubScreens
{
    class ToolBar : Grid
    {
        private Button processes, systemResources, apphistory, temp;
        int fontSize = 13;

        //Current screen on display
        private ToolBarState myScreenState;

        //SubScreen
        private SystemResourcesToolbar systemResourcesSc;
        private Processes processesSc;
        private CommandToolbar commandSc;
        private string deviceId = "";
        private int deviceNum = 9;

        public ToolBar(string name, int num)
        {
            deviceId = name;
            deviceNum = num;

            myScreenState = ToolBarState.SYSTEMRESOURCES;

            ContentView colour = new ContentView { BackgroundColor = Color.FromRgb(237, 237, 235), HorizontalOptions = LayoutOptions.Fill };
            colour.VerticalOptions = LayoutOptions.Start;
            colour.MinimumHeightRequest = 40;
            colour.HeightRequest = 40;
            Children.Add(colour, 0,0);

            #region Buttons

            if (Device.OS == TargetPlatform.Android)
            {
                systemResources = new Button();
                systemResources.Text = "System Resources";
                systemResources.FontSize = 14;
                systemResources.VerticalOptions = LayoutOptions.Center;
                systemResources.HorizontalOptions = LayoutOptions.CenterAndExpand;
                systemResources.BorderColor = Color.Transparent;
                systemResources.BackgroundColor = Color.Transparent;
                systemResources.BorderWidth = .000001;
                systemResources.WidthRequest = 180;
                systemResources.HeightRequest = 35;
                systemResources.TextColor = Color.Maroon;
                systemResources.FontAttributes = FontAttributes.Bold;

                processes = new Button();
                processes.Text = "Processes";
                processes.FontSize = 14;
                processes.VerticalOptions = LayoutOptions.Center;
                processes.HorizontalOptions = LayoutOptions.CenterAndExpand;
                processes.BorderColor = Color.Transparent;
                processes.BackgroundColor = Color.Transparent;
                processes.BorderWidth = .000001;
                processes.WidthRequest = 180;
                processes.HeightRequest = 35;
                processes.TextColor = Color.Maroon;

                apphistory = new Button();
                apphistory.Text = "App History";
                apphistory.FontSize = 14;
                apphistory.VerticalOptions = LayoutOptions.Center;
                apphistory.HorizontalOptions = LayoutOptions.CenterAndExpand;
                apphistory.BorderColor = Color.Transparent;
                apphistory.BackgroundColor = Color.Transparent;
                apphistory.BorderWidth = .000001;
                processes.HeightRequest = 35;
                processes.TextColor = Color.Maroon;
                processes.WidthRequest = 180;

                temp = new Button();
                temp.Text = "Command";
                temp.FontSize = 14;
                temp.VerticalOptions = LayoutOptions.Center;
                temp.HorizontalOptions = LayoutOptions.CenterAndExpand;
                temp.BorderColor = Color.Transparent;
                temp.BackgroundColor = Color.Transparent;
                temp.BorderWidth = .000001;
                temp.HeightRequest = 35;
                temp.TextColor = Color.Maroon;
                temp.WidthRequest = 180;
            }
            else
            {
                systemResources = new Button();
                systemResources.Text = "System Resources";
                systemResources.FontSize = 14;
                systemResources.VerticalOptions = LayoutOptions.Center;
                systemResources.HorizontalOptions = LayoutOptions.CenterAndExpand;
                systemResources.BorderColor = Color.Transparent;
                systemResources.BackgroundColor = Color.Gray;
                systemResources.BorderWidth = .000001;
                systemResources.WidthRequest = 180;
                systemResources.HeightRequest = 40;

                processes = new Button();
                processes.Text = "Processes";
                processes.FontSize = 14;
                processes.VerticalOptions = LayoutOptions.Center;
                processes.HorizontalOptions = LayoutOptions.CenterAndExpand;
                processes.BorderColor = Color.Transparent;
                processes.BackgroundColor = Color.Transparent;
                processes.BorderWidth = .000001;
                processes.WidthRequest = 180;
                processes.HeightRequest = 40;

                apphistory = new Button();
                apphistory.Text = "App History";
                apphistory.FontSize = 14;
                apphistory.VerticalOptions = LayoutOptions.Center;
                apphistory.HorizontalOptions = LayoutOptions.CenterAndExpand;
                apphistory.BorderColor = Color.Transparent;
                apphistory.BackgroundColor = Color.Transparent;
                apphistory.BorderWidth = .000001;
                apphistory.HeightRequest = 50;
                apphistory.WidthRequest = 180;

                temp = new Button();
                temp.Text = "Command";
                temp.FontSize = 14;
                temp.VerticalOptions = LayoutOptions.Center;
                temp.HorizontalOptions = LayoutOptions.CenterAndExpand;
                temp.BorderColor = Color.Transparent;
                temp.BackgroundColor = Color.Transparent;
                temp.BorderWidth = .000001;
                temp.HeightRequest = 50;
                temp.WidthRequest = 180;
            }


            #endregion

            //Mid button grid 1
            Grid midGrid1 = new Grid();
            midGrid1.RowDefinitions.Add(new RowDefinition { Height = 40 });
            midGrid1.ColumnSpacing = 0;
            midGrid1.RowSpacing = 0;
            midGrid1.HorizontalOptions = LayoutOptions.Center;
            midGrid1.Children.Add(systemResources, 0, 0);
            midGrid1.Children.Add(processes, 1, 0);
            //midGrid1.Children.Add(apphistory, 2, 0);
            midGrid1.Children.Add(temp, 2, 0);

            //Adding to mid-grid
            Children.Add(midGrid1, 0, 0);

            //Initialising Overview Screen
            //Adding Cpu Screen
            systemResourcesSc = new SystemResourcesToolbar(deviceId, num);
            systemResourcesSc.Margin = new Thickness(0, 40, 0, 0);
            Children.Add(systemResourcesSc, 0, 0);

            //Centre Buttons
            systemResources.Clicked += SystemResourcesOnClicked;
            processes.Clicked += ProcessesOnClicked;
            temp.Clicked += TempOnClicked;
        }

        #region Button Click Handlers

        private void TempOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ToolBarState.TEMP)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    temp.TextColor = Color.Maroon;
                    temp.FontAttributes = FontAttributes.Bold;
                }
                else
                {
                temp.BackgroundColor = Color.Gray;
                }
                RemoveScreen();

                //Adding Command Screen
                commandSc = new CommandToolbar(deviceId);
                commandSc.Margin = new Thickness(0, 40, 0, 0);
                Children.Add(commandSc, 0, 0);

                myScreenState = ToolBarState.TEMP;
            }
        }

        private void ProcessesOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ToolBarState.PROCESSES)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    processes.TextColor = Color.Maroon;
                    processes.FontAttributes = FontAttributes.Bold;
                }
                else
                {
                    processes.BackgroundColor = Color.Gray;
                }
                RemoveScreen();

                //Adding Wifi Screen
                processesSc = new Processes(deviceNum);
                processesSc.Margin = new Thickness(50, 50, 50, 0);
                Children.Add(processesSc, 0, 0);

                myScreenState = ToolBarState.PROCESSES;
            }
        }

        private void SystemResourcesOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ToolBarState.SYSTEMRESOURCES)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    systemResources.TextColor = Color.Maroon;
                    systemResources.FontAttributes = FontAttributes.Bold;
                }
                else
                {
                    systemResources.BackgroundColor = Color.Gray;
                }
                RemoveScreen();

                //Adding Wifi Screen
                systemResourcesSc = new SystemResourcesToolbar(deviceId, deviceNum);
                systemResourcesSc.Margin = new Thickness(0, 40, 0, 0);
                Children.Add(systemResourcesSc, 0, 0);

                myScreenState = ToolBarState.SYSTEMRESOURCES;
            }
        }

        public void GC()
        {
            RemoveScreen();
        }
        public void RemoveScreen()
        {
            //Removes screen, sets button off
            if (myScreenState == ToolBarState.SYSTEMRESOURCES)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    systemResources.TextColor = Color.Black;
                    systemResources.FontAttributes = FontAttributes.None;
                }
                else
                {
                    systemResources.BackgroundColor = Color.Transparent;
                }
                systemResources.BackgroundColor = Color.Transparent;
                Children.Remove(systemResourcesSc);
                systemResourcesSc.GC();
                systemResourcesSc.BindingContext = null;
                systemResourcesSc = null;
            }
            else if (myScreenState == ToolBarState.PROCESSES)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    processes.TextColor = Color.Black;
                    processes.FontAttributes = FontAttributes.None;
                }
                else
                {
                    processes.BackgroundColor = Color.Transparent;
                }
                processes.BackgroundColor = Color.Transparent;
                Children.Remove(processesSc);
                processesSc.GC();
                processesSc.BindingContext = null;
                processesSc = null;

            }
            else if (myScreenState == ToolBarState.TEMP)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    temp.TextColor = Color.Black;
                    temp.FontAttributes = FontAttributes.None;
                }
                else
                {
                    temp.BackgroundColor = Color.Transparent;
                }
                BackgroundColor = Color.White;
                temp.BackgroundColor = Color.Transparent;
                Children.Remove(commandSc);
                commandSc.GC();
                commandSc.BindingContext = null;
                commandSc = null;
            }
        }
        #endregion
    }
}
