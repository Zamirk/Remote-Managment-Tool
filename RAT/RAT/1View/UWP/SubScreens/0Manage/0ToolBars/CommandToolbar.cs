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
using RAT._1View.Desktop;

namespace RAT._1
{

    namespace RAT._1View.Desktop
    {
        public class CommandToolbar : Grid
        {
            private Button standard, console, powershell;
            int fontSize = 13;

            //Current screen on display
            private CommandState myScreenState;

            //SubScreen
            private StandardCommands commandSc;
            private CmdConsole consoleSc;
            private PowerShell powershellSc;

            public CommandToolbar()
            {
                myScreenState = CommandState.Standard;
                BackgroundColor = Color.White;
                #region Buttons

                standard = new Button();
                standard.Text = "Standard";
                standard.FontSize = fontSize;
                standard.VerticalOptions = LayoutOptions.Center;
                standard.HorizontalOptions = LayoutOptions.Center;
                standard.BorderColor = Color.Transparent;
                standard.BackgroundColor = Color.Gray;
                standard.BorderWidth = .000001;
                standard.WidthRequest = 100;
                standard.HeightRequest = 40;

                console = new Button();
                console.Text = "Console";
                console.FontSize = fontSize;
                console.VerticalOptions = LayoutOptions.Center;
                console.HorizontalOptions = LayoutOptions.Center;
                console.BorderColor = Color.Transparent;
                console.BackgroundColor = Color.Transparent;
                console.BorderWidth = .000001;
                console.WidthRequest = 100;
                console.HeightRequest = 40;

                powershell = new Button();
                powershell.Text = "Powershell";
                powershell.FontSize = fontSize;
                powershell.VerticalOptions = LayoutOptions.Center;
                powershell.HorizontalOptions = LayoutOptions.Center;
                powershell.BorderColor = Color.Transparent;
                powershell.BackgroundColor = Color.Transparent;
                powershell.BorderWidth = .000001;
                powershell.WidthRequest = 100;
                powershell.HeightRequest = 40;

                #endregion

                //Mid button grid
                Grid midGrid2 = new Grid();
                midGrid2.RowDefinitions.Add(new RowDefinition { Height = 40 });
                midGrid2.ColumnSpacing = 0;
                midGrid2.RowSpacing = 0;
                midGrid2.HorizontalOptions = LayoutOptions.Center;

                midGrid2.Children.Add(standard, 0, 0);
                midGrid2.Children.Add(console, 1, 0);
                midGrid2.Children.Add(powershell, 2, 0);

                //Adding to mid-grid
                Children.Add(midGrid2, 0, 0);

                //Adding the first Screen
                commandSc = new StandardCommands();
                commandSc.Margin = new Thickness(0, 40, 0, 0);
                Children.Add(commandSc, 0, 0);

                //Centre Buttons
                standard.Clicked += StandardOnClicked;
                console.Clicked += ConsoleOnClicked;
                powershell.Clicked += PowershellOnClicked;
            }

            #region Button Click Handlers

            private void StandardOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != CommandState.Standard)
                {
                    standard.BackgroundColor = Color.Gray;
                    RemoveScreen();

                    //Adding Dsik Screen
                    commandSc = new StandardCommands();
                    commandSc.Margin = new Thickness(0, 40, 0, 0);
                    Children.Add(commandSc, 0, 0);

                    myScreenState = CommandState.Standard;
                }
            }

            private void ConsoleOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != CommandState.Console)
                {
                    console.BackgroundColor = Color.Gray;
                    RemoveScreen();

                    //Adding Ram Screen
                    consoleSc = new CmdConsole();
                    consoleSc.Margin = new Thickness(50, 40, 50, 0);
                    Children.Add(consoleSc, 0, 0);

                    myScreenState = CommandState.Console;
                }
            }


            private void PowershellOnClicked(object sender, EventArgs eventArgs)
            {
                if (myScreenState != CommandState.Powershell)
                {
                    powershell.BackgroundColor = Color.Gray;
                    RemoveScreen();

                    //Adding Wifi Screen
                    powershellSc = new PowerShell();
                    powershellSc.Margin = new Thickness(50, 40, 50, 0);
                    Children.Add(powershellSc, 0, 0);

                    myScreenState = CommandState.Powershell;
                }
            }

            public void RemoveScreen()
            {
                //Removes screen, sets button off
                if (myScreenState == CommandState.Console)
                {
                    console.BackgroundColor = Color.Transparent;
                    Children.Remove(consoleSc);
                    consoleSc.GC();
                    consoleSc.BindingContext = null;
                    consoleSc = null;
                }
                else if (myScreenState == CommandState.Powershell)
                {
                    powershell.BackgroundColor = Color.Transparent;
                    Children.Remove(powershellSc);
                    powershellSc.GC();
                    powershellSc.BindingContext = null;
                    powershellSc = null;

                }
                else if (myScreenState == CommandState.Standard)
                {
                    standard.BackgroundColor = Color.Transparent;
                    Children.Remove(commandSc);
                    commandSc.GC();
                    commandSc.BindingContext = null;
                    commandSc = null;
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