using System;
using RAT._1View;
using RAT._1View.Desktop;
using RAT._1View.Desktop.Tools;
using RAT._2ViewModel;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT.ZTry
{
    public class MainScreen : ContentPage
    {
        private Grid midGrid;

        //SubScreen
        private OverviewScreen overviewScreen;
        private CPUScreen cpuScreen;
        private RamScreen ramScreen;
        private WIFIScreen wifiScreen;
        private DiskScreen diskScreen;

        //Current screen on display
        private ScreenState myScreenState;

        private StackLayout mainStack;
        private Button signOutButton, performanceButton, manageButton, applicationButton, backButton, forwardButton,
            overviewButton, memoryButton, wifiButton, diskButton, cpuButton;
        private ContentView leftColour, rightColour;

        public MainScreen()
        {
            //ViewModel
            MainScreenViewModel myViewModel = new MainScreenViewModel();
            this.BindingContext = myViewModel;

            NavigationPage.SetHasNavigationBar(this, false);

            myScreenState = ScreenState.OVERVIEW;

            leftColour = new ContentView { BackgroundColor = Color.FromRgb(237, 237, 235) };
            rightColour = new ContentView {BackgroundColor = Color.FromRgb(237, 237, 235)};

            int fontSize = 13;

            #region
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
            forwardButton.Margin = new Thickness(50,0,0,0);

            signOutButton = new Button();
            signOutButton.Text = "Sign Out";
            signOutButton.VerticalOptions = LayoutOptions.End;
            signOutButton.HorizontalOptions = LayoutOptions.End;

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

            //Bindings
            //applicationButton.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));
            //manageButton.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));
            //performanceButton.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));
            backButton.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));
            forwardButton.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));
            signOutButton.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));

            //Layouts
            mainStack = new StackLayout();
            Grid topGrid = new Grid();
            midGrid = new Grid();
            StackLayout leftButtonStack = new StackLayout();
            StackLayout midButtonStack = new StackLayout();

            //Main Stack
            mainStack.VerticalOptions = LayoutOptions.FillAndExpand;
            mainStack.Orientation = StackOrientation.Vertical;
            mainStack.Spacing = 0;

            //Top-grid
            topGrid.Children.Add(new ContentView() { BackgroundColor = Color.FromRgb(17, 150, 205) });
            topGrid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            topGrid.ColumnSpacing = 0;
            topGrid.RowSpacing = 0;

            //Mid-grid
            midGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            midGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            midGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 225 });
            midGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            midGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = 100 });
            midGrid.ColumnSpacing = 0;
            midGrid.RowSpacing = 0;

            //Button stack
            leftButtonStack.HorizontalOptions = LayoutOptions.Center;
            leftButtonStack.VerticalOptions = LayoutOptions.FillAndExpand;
            leftButtonStack.Spacing = 0;

            //Adding to top-grid
            topGrid.Children.Add(backButton);
            topGrid.Children.Add(forwardButton);
            topGrid.Children.Add(signOutButton);

            //Left button stack
            leftButtonStack.Spacing = 0;
            leftButtonStack.Children.Add(manageButton);
            leftButtonStack.Children.Add(performanceButton);
            leftButtonStack.Children.Add(applicationButton);

            //Mid button grid
            Grid midGrid2 = new Grid();
            midGrid2.RowDefinitions.Add(new RowDefinition { Height = 50 });
            midGrid2.ColumnSpacing = 0;
            midGrid2.RowSpacing = 0;
            midGrid2.HorizontalOptions = LayoutOptions.Center;
            midGrid2.Children.Add(overviewButton,0,0);
            midGrid2.Children.Add(cpuButton,1,0);
            midGrid2.Children.Add(memoryButton, 2, 0);
            midGrid2.Children.Add(diskButton, 3, 0);
            midGrid2.Children.Add(wifiButton, 4, 0);

            leftColour.HorizontalOptions = LayoutOptions.Fill;

            //Adding to mid-grid
            midGrid.Children.Add(leftColour, 0, 0);
            midGrid.Children.Add(leftButtonStack, 0, 0);
            midGrid.Children.Add(rightColour, 2, 0);
            midGrid.Children.Add(midGrid2, 1, 0);

            //Initialising Overview Screen
            overviewScreen = new OverviewScreen();
            overviewScreen.Margin = new Thickness(50, 50, 50, 0);
            midGrid.Children.Add(overviewScreen, 1, 0);

            mainStack.Children.Add(topGrid);
            mainStack.Children.Add(midGrid);
            midGrid.Children.Add(midButtonStack, 0, 0);

            //Left Buttons
            manageButton.Clicked += (sender, args) =>
            {
                manageButton.BackgroundColor = Color.Gray;
                performanceButton.BackgroundColor = Color.Transparent;
                applicationButton.BackgroundColor = Color.Transparent;

            };

            performanceButton.Clicked += (sender, args) =>
            {
                manageButton.BackgroundColor = Color.Transparent;
                performanceButton.BackgroundColor = Color.Gray;
                applicationButton.BackgroundColor = Color.Transparent;
            };

            applicationButton.Clicked += (sender, args) =>
            {
                manageButton.BackgroundColor = Color.Transparent;
                performanceButton.BackgroundColor = Color.Transparent;
                applicationButton.BackgroundColor = Color.Gray;
            };

            //Centre Buttons
            overviewButton.Clicked += OverviewButtonOnClicked;
            cpuButton.Clicked += CpuButtonOnClicked;
            memoryButton.Clicked += MemoryButtonOnClicked;
            diskButton.Clicked += DiskButtonOnClicked;
            wifiButton.Clicked += WifiButtonOnClicked;

            Content = mainStack;
        }

        private void WifiButtonOnClicked(object sender, EventArgs eventArgs)
        {
            if (myScreenState != ScreenState.WIFI)
            {
                wifiButton.BackgroundColor = Color.Gray;
                RemoveScreen();

                //Adding Ram Screen
                wifiScreen = new WIFIScreen();
                wifiScreen.Margin = new Thickness(50, 50, 50, 0);
                midGrid.Children.Add(wifiScreen, 1, 0);

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
                midGrid.Children.Add(diskScreen, 1, 0);

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
                midGrid.Children.Add(ramScreen, 1, 0);

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
                midGrid.Children.Add(cpuScreen, 1, 0);

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
                midGrid.Children.Add(overviewScreen, 1, 0);

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
                midGrid.Children.Remove(overviewScreen);
            }
            else if (myScreenState == ScreenState.CPU)
            {
                cpuButton.BackgroundColor = Color.Transparent;
                midGrid.Children.Remove(cpuScreen);
            }
            else if (myScreenState == ScreenState.RAM)
            {
                memoryButton.BackgroundColor = Color.Transparent;
                midGrid.Children.Remove(ramScreen);
            }
            else if (myScreenState == ScreenState.WIFI)
            {
                wifiButton.BackgroundColor = Color.Transparent;
                midGrid.Children.Remove(wifiScreen);
            }
            else if (myScreenState == ScreenState.DISK)
            {
                diskButton.BackgroundColor = Color.Transparent;
                midGrid.Children.Remove(diskScreen);
            }
        }
    }
}
