using System;
using RAT._1View;
using RAT._1View.Desktop;
using RAT._1View.Desktop.Manage;
using RAT._1View.Desktop.Screens.SubScreens.RAT._1View.Desktop;
using RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen;
using RAT._1View.Desktop._1Tools;
using RAT._1View.UWP.SubScreens;
using RAT._2ViewModel;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Services;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT.ZTry
{
    public class ParentScreen : ContentPage
    {
        #region Member Variables
        private MenuState myMenuState;
        private ViewDevicesScreen viewDevicesScreen;
        private ToolBar singleDeviceScreen;
        private AppScreen appScreen;
        //private AppsScreen applicationManagmentScreen;
        private DashboardScreen dashboardScreen;

        private Button signOutButton, performanceButton, manageButton, dashboardButton,
            applicationButton, backButton, forwardButton, secretGameButton, apphistory;
        ContentView leftColour = new ContentView { BackgroundColor = Color.FromRgb(237, 237, 235), HorizontalOptions = LayoutOptions.Fill };
        ContentView rightColour = new ContentView { BackgroundColor = Color.FromRgb(237, 237, 235) };
        private Grid midGrid;
        #endregion

        public ParentScreen()
        {
            //ViewModel
            MainScreenViewModel myViewModel = new MainScreenViewModel();
            this.BindingContext = myViewModel;

            NavigationPage.SetHasNavigationBar(this, false);
            myMenuState = MenuState.MANAGE_ALLDEVICES;

            #region Buttons
            secretGameButton = new Button();
            secretGameButton.Text = "Play";
            secretGameButton.FontSize = 20;
            secretGameButton.VerticalOptions = LayoutOptions.End;
            secretGameButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            secretGameButton.BorderColor = Color.Transparent;
            secretGameButton.BorderWidth = .000001;
            secretGameButton.WidthRequest = 500;
            secretGameButton.HeightRequest = 50;
            secretGameButton.Margin = new Thickness(0, 50, 0, 0);
            secretGameButton.BackgroundColor = Color.Gray;

            manageButton = new Button();
            manageButton.Text = "Manage";
            manageButton.FontSize = 20;
            manageButton.VerticalOptions = LayoutOptions.Center;
            manageButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            manageButton.BorderColor = Color.Transparent;
            manageButton.BorderWidth = .000001;
            manageButton.WidthRequest = 500;
            manageButton.HeightRequest = 50;
            manageButton.Margin = new Thickness(0, 50, 0, 0);
            manageButton.BackgroundColor = Color.Gray;

            dashboardButton = new Button();
            dashboardButton.Text = "Dashboards";
            dashboardButton.FontSize = 20;
            dashboardButton.VerticalOptions = LayoutOptions.Center;
            dashboardButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            dashboardButton.BorderColor = Color.Transparent;
            dashboardButton.BackgroundColor = Color.Transparent;
            dashboardButton.BorderWidth = .000001;
            dashboardButton.WidthRequest = 500;
            dashboardButton.HeightRequest = 50;

            performanceButton = new Button();
            performanceButton.Text = "System Performance";
            performanceButton.FontSize = 20;
            performanceButton.VerticalOptions = LayoutOptions.Center;
            performanceButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            performanceButton.BorderColor = Color.Transparent;
            performanceButton.BackgroundColor = Color.Transparent;
            performanceButton.BorderWidth = .000001;
            performanceButton.WidthRequest = 500;
            performanceButton.HeightRequest = 50;

            applicationButton = new Button();
            applicationButton.Text = "Applications";
            applicationButton.FontSize = 20;
            applicationButton.VerticalOptions = LayoutOptions.Center;
            applicationButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            applicationButton.BorderColor = Color.Transparent;
            applicationButton.BackgroundColor = Color.Transparent;
            applicationButton.BorderWidth = .000001;
            applicationButton.HeightRequest = 50;
            applicationButton.WidthRequest = 500;

            backButton = new Button();
            backButton.Text = "<";
            backButton.FontSize = 20;
            backButton.VerticalOptions = LayoutOptions.End;
            backButton.HorizontalOptions = LayoutOptions.Start;
            backButton.BorderColor = Color.Transparent;
            backButton.BackgroundColor = Color.Transparent;
            backButton.BorderWidth = .000001;

            forwardButton = new Button();
            forwardButton.Text = ">";
            forwardButton.FontSize = 20;
            forwardButton.VerticalOptions = LayoutOptions.End;
            forwardButton.HorizontalOptions = LayoutOptions.Start;
            forwardButton.BorderColor = Color.Transparent;
            forwardButton.BackgroundColor = Color.Transparent;
            forwardButton.BorderWidth = .000001;
            forwardButton.Margin = new Thickness(50, 0, 0, 0);

            signOutButton = new Button();
            signOutButton.Text = "Sign Out";
            signOutButton.VerticalOptions = LayoutOptions.End;
            signOutButton.HorizontalOptions = LayoutOptions.End;

            #endregion

            //Bindings
            signOutButton.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));

            //Layouts
            StackLayout mainStack = new StackLayout();
            Grid topGrid = new Grid();
            midGrid = new Grid();
            StackLayout leftButtonStack = new StackLayout();

            //Main Stack
            mainStack.VerticalOptions = LayoutOptions.FillAndExpand;
            mainStack.Orientation = StackOrientation.Vertical;
            mainStack.Spacing = 0;

            #region TopGrid
            //Top-grid
            //topGrid.Children.Add(new ContentView() { BackgroundColor = Color.FromRgb(17, 150, 205) });
            //TODO REMOVE AND REPLACE WITH MOBILE AND DESTOP SECTIONS 03/03/017
            if (Device.Idiom == TargetIdiom.Phone)
            {
                topGrid.RowDefinitions.Add(new RowDefinition {Height = 5});
            }
            else
            {
            topGrid.RowDefinitions.Add(new RowDefinition { Height = 60 });
            }
            topGrid.ColumnSpacing = 0;
            topGrid.RowSpacing = 0;
            topGrid.Children.Add(backButton, 0, 0);
            topGrid.Children.Add(forwardButton, 0, 0);
            ContentView aaaa = new ContentView() { BackgroundColor = Color.Gray };
            topGrid.Children.Add(aaaa, 0, 0);
            topGrid.Children.Add(signOutButton, 0, 0);

            #endregion

            #region SideBar Buttons
            //Sidebar Button stack
            leftButtonStack.HorizontalOptions = LayoutOptions.Center;
            leftButtonStack.VerticalOptions = LayoutOptions.FillAndExpand;
            leftButtonStack.Spacing = 0;
            leftButtonStack.Children.Add(manageButton);
            leftButtonStack.Children.Add(dashboardButton);
            leftButtonStack.Children.Add(performanceButton);
            leftButtonStack.Children.Add(applicationButton);
            //leftButtonStack.Children.Add(secretGameButton);
            #endregion

            //Mid-grid
            midGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            midGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            if (Device.Idiom == TargetIdiom.Phone)
            {
                midGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 50 });
            }
            else
            {
                midGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 225 });
            }
            midGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            //TODO REMOVE AND REPLACE WITH MOBILE AND DESTOP SECTIONS 03/03/017C
            if (Device.Idiom == TargetIdiom.Phone)
            {
                midGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 5 });
            }
            else
            {
                midGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 100 });
            }
            midGrid.ColumnSpacing = 0;
            midGrid.RowSpacing = 0;

            //Adding
            mainStack.Children.Add(topGrid);
            mainStack.Children.Add(midGrid);

            //Adding to mid-grid
            midGrid.Children.Add(leftColour, 0, 0);
            midGrid.Children.Add(leftButtonStack, 0, 0);
            midGrid.Children.Add(rightColour, 2, 0);

            //Initial Screen
            viewDevicesScreen = new ViewDevicesScreen();
            midGrid.Children.Add(viewDevicesScreen, 1, 0);
            viewDevicesScreen.aaaa.Clicked += PcOne_Clicked;

            //Left Buttons
            manageButton.Clicked += ManageButton_Clicked;
            dashboardButton.Clicked += DashboardButton_Clicked;
            performanceButton.Clicked += PerformanceButton_Clicked;
            applicationButton.Clicked += ApplicationButton_Clicked;
            secretGameButton.Clicked += Secret_Game;

            //TODO Temp, Should be removed and added when needed
            //deviceOverview = new DeviceOverview();
            //midGrid.Children.Add(deviceOverview, 1, 0);
            //deviceOverview.IsVisible = false;

            Content = mainStack;
        }



        #region Screen Changing Click Handlers

        // Button Click
        private async void Secret_Game(object sender, EventArgs e)
        {
            //var page = new MyPopupPage();
            GameParent page = new GameParent();

            await Navigation.PushPopupAsync(page);
            // or
            //await PopupNavigation.PushAsync(page);
        }
        private void PcOne_Clicked(object sender, EventArgs e)
        {
            RemoveScreen();
            manageButton.BackgroundColor = Color.Gray;

            singleDeviceScreen = new ToolBar();
            midGrid.Children.Add(singleDeviceScreen, 1, 0);

            myMenuState = MenuState.MANAGE_SINGLEDEVICE;
        }

        private void DashboardButton_Clicked(object sender, EventArgs e)
        {
            RemoveScreen();
            dashboardButton.BackgroundColor = Color.Gray;

            dashboardScreen = new DashboardScreen();
            midGrid.Children.Add(dashboardScreen, 1, 0);

            myMenuState = MenuState.DASHBOARDS;
        }

        private void ManageButton_Clicked(object sender, EventArgs e)
        {
            if (myMenuState != MenuState.MANAGE_ALLDEVICES)
            {
                RemoveScreen();
                manageButton.BackgroundColor = Color.Gray;

                //TODO: Remove Clickhandler and replace with ParentScreen Subscreen managment
                //TODO: Maybe this shouldnt be initialised instantly: 06/12/16
                viewDevicesScreen = new ViewDevicesScreen();
                viewDevicesScreen.aaaa.Clicked += PcOne_Clicked;
                midGrid.Children.Add(viewDevicesScreen, 1, 0);

                myMenuState = MenuState.MANAGE_ALLDEVICES;
            }
        }

        private void PerformanceButton_Clicked(object sender, EventArgs e)
        {
            if (myMenuState != MenuState.PERFORMANCE)
            {
                performanceButton.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Overview Screen
                appScreen = new AppScreen();
                midGrid.Children.Add(appScreen, 1, 0);

                myMenuState = MenuState.PERFORMANCE;
            }
        }

        private void ApplicationButton_Clicked(object sender, EventArgs e)
        {
            if (myMenuState != MenuState.APPLICATIONS)
            {
                applicationButton.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Overview Screen
                //applicationManagmentScreen = new AppsScreen();
                //midGrid.Children.Add(applicationManagmentScreen, 1, 0);

                myMenuState = MenuState.APPLICATIONS;
            }
        }

        public void RemoveScreen()
        {
            //Removes screen, sets button off
            //NOTE
            //ObjectS should be collected by Garbage Collector!
            //If Not, Check the async/Device.Timers/Extra Threads

            if (myMenuState == MenuState.MANAGE_ALLDEVICES)
            {
                manageButton.BackgroundColor = Color.Transparent;
                midGrid.Children.Remove(viewDevicesScreen);
            }
            else if (myMenuState == MenuState.DASHBOARDS)
            {
                dashboardButton.BackgroundColor = Color.Transparent;
                midGrid.Children.Remove(dashboardScreen);
            }
            else if (myMenuState == MenuState.PERFORMANCE)
            {
                performanceButton.BackgroundColor = Color.Transparent;
                midGrid.Children.Remove(appScreen);
            }
            else if (myMenuState == MenuState.APPLICATIONS)
            {
                applicationButton.BackgroundColor = Color.Transparent;
                //midGrid.Children.Remove(applicationManagmentScreen);
            }
            else if (myMenuState == MenuState.MANAGE_SINGLEDEVICE)
            {
                manageButton.BackgroundColor = Color.Transparent;
                midGrid.Children.Remove(singleDeviceScreen);
            }
        }
        #endregion


    }
}