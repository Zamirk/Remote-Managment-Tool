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
        private AppHistory appHistorySc;
        private CommandToolbar commandSc;
        public ToolBar()
        {
            myScreenState = ToolBarState.SYSTEMRESOURCES;

            ContentView colour = new ContentView { BackgroundColor = Color.FromRgb(237, 237, 235), HorizontalOptions = LayoutOptions.Fill };
            colour.VerticalOptions = LayoutOptions.Start;
            colour.MinimumHeightRequest = 40;
            colour.HeightRequest = 40;
            Children.Add(colour, 0,0);

            #region Buttons

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
            #endregion

            //Mid button grid 1
            Grid midGrid1 = new Grid();
            midGrid1.RowDefinitions.Add(new RowDefinition { Height = 40 });
            midGrid1.ColumnSpacing = 0;
            midGrid1.RowSpacing = 0;
            midGrid1.HorizontalOptions = LayoutOptions.Center;
            midGrid1.Children.Add(systemResources, 0, 0);
            midGrid1.Children.Add(processes, 1, 0);
            midGrid1.Children.Add(apphistory, 2, 0);
            midGrid1.Children.Add(temp, 3, 0);

            //Adding to mid-grid
            Children.Add(midGrid1, 0, 0);

            //Initialising Overview Screen
            //Adding Cpu Screen
            systemResourcesSc = new SystemResourcesToolbar();
            systemResourcesSc.Margin = new Thickness(0, 40, 0, 0);
            Children.Add(systemResourcesSc, 0, 0);

            //Centre Buttons
            systemResources.Clicked += SystemResourcesOnClicked;
            processes.Clicked += ProcessesOnClicked;
            apphistory.Clicked += ApphistoryOnClicked;
            temp.Clicked += TempOnClicked;
        }

        #region Button Click Handlers

        private void TempOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ToolBarState.TEMP)
            {
                temp.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Wifi Screen
                commandSc = new CommandToolbar();
                commandSc.Margin = new Thickness(0, 40, 0, 0);
                Children.Add(commandSc, 0, 0);

                myScreenState = ToolBarState.TEMP;
            }
        }

        private void ApphistoryOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ToolBarState.APPHISTORY)
            {
                apphistory.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Wifi Screen
                appHistorySc = new AppHistory();
                appHistorySc.Margin = new Thickness(50, 50, 50, 0);
                Children.Add(appHistorySc, 0, 0);

                myScreenState = ToolBarState.APPHISTORY;
            }
        }

        private void ProcessesOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ToolBarState.PROCESSES)
            {
                processes.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Wifi Screen
                processesSc = new Processes();
                processesSc.Margin = new Thickness(50, 50, 50, 0);
                Children.Add(processesSc, 0, 0);

                myScreenState = ToolBarState.PROCESSES;
            }
        }

        private void SystemResourcesOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ToolBarState.SYSTEMRESOURCES)
            {
                systemResources.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Wifi Screen
                systemResourcesSc = new SystemResourcesToolbar();
                systemResourcesSc.Margin = new Thickness(0, 40, 0, 0);
                Children.Add(systemResourcesSc, 0, 0);

                myScreenState = ToolBarState.SYSTEMRESOURCES;
            }
        }

        public void RemoveScreen()
        {
            //Removes screen, sets button off
            if (myScreenState == ToolBarState.SYSTEMRESOURCES)
            {
                systemResources.BackgroundColor = Color.Transparent;
                Children.Remove(systemResourcesSc);
                systemResourcesSc.GC();
                systemResourcesSc.BindingContext = null;
                systemResourcesSc = null;
            }
            else if (myScreenState == ToolBarState.PROCESSES)
            {
                processes.BackgroundColor = Color.Transparent;
                Children.Remove(processesSc);
                processesSc.GC();
                processesSc.BindingContext = null;
                processesSc = null;

            }
            else if (myScreenState == ToolBarState.APPHISTORY)
            {
                apphistory.BackgroundColor = Color.Transparent;
                Children.Remove(appHistorySc);
                appHistorySc.GC();
                appHistorySc.BindingContext = null;
                appHistorySc = null;

            }
            else if (myScreenState == ToolBarState.TEMP)
            {
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
