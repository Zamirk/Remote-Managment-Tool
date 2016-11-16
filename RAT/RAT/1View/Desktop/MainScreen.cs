using System;
using RAT._1View;
using RAT._2ViewModel;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT.ZTry
{
    public class MainScreen : ContentPage
    {
        private StackLayout myStackLayout;
        private ContentView maroonView, grayView, redView, yellowView, greenView, tealView, aquaView, blackView, blueView;
        private Button signOutButton;
        private Button performanceButton;
        private Button button3;
        private Button button4;
        private Button backButton;
        private Button forwardButton;
        private bool debugMode = true;
        Label resultsLabel;
        SearchBar searchBar;

        public MainScreen()
        {
            MainScreenViewModel myModel = new MainScreenViewModel();
            this.BindingContext = myModel;

            NavigationPage.SetHasNavigationBar(this, false);

            redView = new ContentView() { BackgroundColor = Color.White };
            greenView = new ContentView { BackgroundColor = Color.FromRgb(237, 237, 235) };
            grayView = new ContentView() { BackgroundColor = Color.FromRgb(17, 150, 205) };
            blueView = new ContentView {BackgroundColor = Color.FromRgb(237, 237, 235)};

            myStackLayout = new StackLayout();
            myStackLayout.VerticalOptions = LayoutOptions.FillAndExpand;
            myStackLayout.Orientation = StackOrientation.Vertical;
            myStackLayout.BackgroundColor = Color.FromRgb(17, 150, 205);

            performanceButton = new Button();
            performanceButton.Text = "Performance";
            performanceButton.FontSize = 20;
            performanceButton.BorderColor = Color.Black;
            performanceButton.BackgroundColor = Color.Gray;
            performanceButton.VerticalOptions = LayoutOptions.Center;
            performanceButton.HorizontalOptions = LayoutOptions.End;
            performanceButton.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));

            button3 = new Button();
            button3.Text = "Button 3";
            button3.FontSize = 20;
            button3.BorderColor = Color.Black;
            button3.BackgroundColor = Color.Gray;
            button3.VerticalOptions = LayoutOptions.Center;
            button3.HorizontalOptions = LayoutOptions.End;
            button3.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));

            button4 = new Button();
            button4.Text = "Button 4";
            button4.FontSize = 20;
            button4.BorderColor = Color.Black;
            button4.BackgroundColor = Color.Gray;
            button4.VerticalOptions = LayoutOptions.Center;
            button4.HorizontalOptions = LayoutOptions.End;
            button4.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));

            //Top Header
            Grid topGrid = new Grid();
            topGrid.RowDefinitions.Add(new RowDefinition { Height = 100 });

            backButton = new Button();
            backButton.Text = "<";
            backButton.FontSize = 35;
            backButton.BorderColor = Color.Black;
            backButton.BackgroundColor = Color.Gray;
            backButton.VerticalOptions = LayoutOptions.End;
            backButton.HorizontalOptions = LayoutOptions.Start;
            backButton.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));

            forwardButton = new Button();
            forwardButton.Text = ">";
            forwardButton.FontSize = 35;
            forwardButton.BorderColor = Color.Black;
            forwardButton.BackgroundColor = Color.Gray;
            forwardButton.VerticalOptions = LayoutOptions.End;
            forwardButton.HorizontalOptions = LayoutOptions.Start;
            forwardButton.Clicked += ForwardButtonOnClicked;
            forwardButton.Margin = new Thickness(50,0,0,0);

            signOutButton = new Button();
            signOutButton.Text = "Sign Out";
            signOutButton.VerticalOptions = LayoutOptions.End;
            signOutButton.HorizontalOptions = LayoutOptions.End;
            signOutButton.SetBinding(Button.CommandProperty, new Binding("SignOutCommand"));

            Label resultsLabel = new Label
            {
                Text = "Result will appear here.",
                VerticalOptions = LayoutOptions.FillAndExpand,
                FontSize = 25

            };
            //topGrid.Children.Add(grayView);
            topGrid.Children.Add(backButton);
            topGrid.Children.Add(forwardButton);
            topGrid.Children.Add(signOutButton);

            //Second Header
            Grid second = new Grid();
            StackLayout myStackLayout2 = new StackLayout();
            myStackLayout2.HorizontalOptions = LayoutOptions.Center;
            myStackLayout2.VerticalOptions = LayoutOptions.FillAndExpand;
            second.VerticalOptions = LayoutOptions.FillAndExpand;
            second.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            second.Children.Add(blueView, 0, 0);
            second.Children.Add(redView, 1, 0);
            second.Children.Add(greenView, 2, 0);
            myStackLayout2.Children.Add(performanceButton);
            myStackLayout2.Children.Add(button3);
            myStackLayout2.Children.Add(button4);
            second.Children.Add(myStackLayout2, 0, 0);
            second.ColumnDefinitions.Add(new ColumnDefinition() { Width = 225 });
            second.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Star });
            second.ColumnDefinitions.Add(new ColumnDefinition() { Width = 100 });
            second.ColumnSpacing = 0;
            second.RowSpacing = 0;
            topGrid.RowSpacing = 0;
            topGrid.ColumnSpacing = 0;

            myStackLayout.Children.Add(topGrid);
            myStackLayout.Children.Add(second);

            Content = myStackLayout;
        }

        private void ForwardButtonOnClicked(object sender, EventArgs eventArgs)
        {
            if (debugMode)
            {
                debugMode = false;
                myStackLayout.BackgroundColor = Color.Transparent;
            }
            else
            {
                debugMode = true;
                myStackLayout.BackgroundColor = Color.Gray;
            }
            grayView.IsVisible = debugMode;
            redView.IsVisible = debugMode;
            //yellowView.IsVisible = debugMode;

            greenView.IsVisible = debugMode;
            //tealView.IsVisible = debugMode;
            //aquaView.IsVisible = debugMode;

            //blackView.IsVisible = debugMode;
            blueView.IsVisible = debugMode;
            //maroonView.IsVisible = debugMode;
        }
    }
}
