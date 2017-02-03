using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ConsoleApplication1.Folder;
using RAT._1View;
using Xamarin.Forms;

namespace RAT.ZTry
{
    public class LoginScreen : ContentPage
    {
        //Debug visuals
        private ContentView maroonView, grayView, redView, yellowView, greenView, tealView, aquaView, blackView, blueView;
        private bool debugMode = true;
        private Grid mainGrid;

        public LoginScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            //Gets the data IoT
            //Task t = Task.Factory.StartNew(() => {
            //        GetTelemetry.ReceiveTelemetry();

            //});

            //Binding to model
            LoginViewModel myModel = new LoginViewModel();
            BindingContext = myModel;

            //Username
            Entry username = new Entry();
            username.Placeholder = "Username";

            //Password
            Entry password = new Entry();
            password.Placeholder = "Password";
            password.IsPassword = true;

            //Button
            Button loginButton = new Button();
            loginButton.Text = "Login";
            loginButton.TextColor = Color.White;
            loginButton.BackgroundColor = Color.FromHex("33D615");

            //Button
            Button colourButton = new Button();
            colourButton.Text = "Color";
            colourButton.TextColor = Color.White;
            colourButton.BackgroundColor = Color.FromHex("33D615");
            colourButton.Clicked += DebugButtonOnClicked;

            //Layout
            StackLayout myStack = new StackLayout();
            myStack.VerticalOptions = LayoutOptions.Start;
            myStack.Children.Add(username);
            myStack.Children.Add(password);
            myStack.Children.Add(loginButton);
            myStack.Spacing = 20;
            myStack.Padding = 50;

            mainGrid = new Grid();
            mainGrid.ColumnSpacing = 0;
            mainGrid.RowSpacing = 0;

            mainGrid.RowDefinitions.Add(new RowDefinition {Height = 100});
            mainGrid.RowDefinitions.Add(new RowDefinition {Height = 10});
            mainGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});
            mainGrid.RowDefinitions.Add(new RowDefinition {Height = 10});

            mainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = 450});
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});

            ContentView silverView = new ContentView() {BackgroundColor = Color.FromRgb(17, 150, 205)};

            grayView = new ContentView() {BackgroundColor = Color.Gray};
            redView = new ContentView() {BackgroundColor = Color.Red};
            yellowView = new ContentView {BackgroundColor = Color.Yellow};

            greenView = new ContentView {BackgroundColor = Color.Green};
            tealView = new ContentView {BackgroundColor = Color.Teal};
            aquaView = new ContentView {BackgroundColor = Color.Aqua};

            blackView = new ContentView {BackgroundColor = Color.Black};
            blueView = new ContentView {BackgroundColor = Color.Blue};
            maroonView = new ContentView {BackgroundColor = Color.Maroon};

            mainGrid.Children.Add(silverView, 0, 0);

            mainGrid.Children.Add(redView, 0, 1);
            mainGrid.Children.Add(grayView, 1, 1);
            mainGrid.Children.Add(yellowView, 2, 1);

            mainGrid.Children.Add(greenView, 0, 2);
            mainGrid.Children.Add(tealView, 1, 2);
            mainGrid.Children.Add(aquaView, 2, 2);

            mainGrid.Children.Add(blackView, 0, 3);
            mainGrid.Children.Add(blueView, 1, 3);
            mainGrid.Children.Add(maroonView, 2, 3);

            mainGrid.Children.Add(myStack, 1, 2);
            mainGrid.Children.Add(colourButton, 2, 3);

            Grid.SetColumnSpan(silverView, 3);

            username.SetBinding(Entry.TextProperty, "UserName");
            password.SetBinding(Entry.TextProperty, "Password");
            loginButton.SetBinding(Button.CommandProperty, new Binding("LoginValidateCommand"));

            //Padding
            if (Device.OS == TargetPlatform.Windows)
            {
                Content = mainGrid;
            }
            else if (Device.OS == TargetPlatform.Android)
            {
                Content = myStack;
            }
            Debug();
        }

        public void DoStaticIoT()
        {
            GetTelemetry.ReceiveTelemetry();
        }

        //Debug Mode
        private void DebugButtonOnClicked(object sender, EventArgs eventArgs)
        {
            System.Diagnostics.Debug.WriteLine("Colour button clicked!\n");
            Debug();
        }

        public void Debug()
        {
            if (debugMode)
            {
                debugMode = false;
            }
            else
            {
                debugMode = true;
            }
            grayView.IsVisible = debugMode;
            redView.IsVisible = debugMode;
            yellowView.IsVisible = debugMode;

            greenView.IsVisible = debugMode;
            tealView.IsVisible = debugMode;
            aquaView.IsVisible = debugMode;

            blackView.IsVisible = debugMode;
            blueView.IsVisible = debugMode;
            maroonView.IsVisible = debugMode;
            maroonView.IsVisible = debugMode;
        }
    }
}