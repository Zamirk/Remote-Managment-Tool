using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using RAT._1View.Desktop.Screens.EasterEgg;
using RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Label = Xamarin.Forms.Label;

namespace RAT._1View.Desktop.Manage
{
	public class TheGame : Grid
    {
        Random rand = new Random();
        Grid mainGrid = new Grid();
        List<GameButton> myButtons = new List<GameButton>();
        Color color = Color.Black;

        List<Color> myColorTwins = new List<Color>();
        private bool useColorAgain = false;
        int pos = 0;
        private int lastOneClicked = 0;

        public TheGame()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;

            mainGrid.ColumnSpacing = 5;
            mainGrid.RowSpacing = 5;

            for (int i = 0; i < 7; i++)
            {
                for (int z = 0; z < 4; z++)
                {
                    //14 Duplicate colours are created
                    if (useColorAgain)
                    {
                        useColorAgain = false;
                    }
                    else
                    {
                        color = Color.FromRgba(rand.Next(256), rand.Next(256), rand.Next(256), 256);
                        useColorAgain = true;
                    }
                    myColorTwins.Add(color);
                    //Generating and adding 28 buttons
                    GenerateButton();
                    mainGrid.Children.Add(myButtons[pos], i, z);
                    pos++;
                }

            }

            //Randomly assigns the colours
            for (int i = 0; i < 27; i++)
            {
                int w = rand.Next(0, myColorTwins.Count);
                Debug.WriteLine("Number generated:"+w);
                Debug.WriteLine("Length:" + myColorTwins.Count);
                myButtons[i].HiddenColour = myColorTwins[w];
                myColorTwins.RemoveAt(w);
            }

            Children.Add(mainGrid);
        }

        public void GenerateButton()
        {
            GameButton myButton = new GameButton();
            myButton.Text = "";
            myButton.FontSize = 25;
            myButton.VerticalOptions = LayoutOptions.Center;
            myButton.HorizontalOptions = LayoutOptions.Center;
            //myButton.BackgroundColor = Color.FromRgb(rand.Next(255), rand.Next(255), rand.Next(255));
            myButton.BackgroundColor = Color.Blue;
            myButton.BorderRadius = 25;
            myButton.BorderWidth = 10;
            myButton.WidthRequest = 200;
            myButton.HeightRequest = 200;
            myButton.Clicked += CompareCards;
            myButton.Pos = myButtons.Count;
            myButtons.Add(myButton);
        }



        // Button Click
        private async void CompareCards(object sender, EventArgs e)
        {
            GameButton myButton = sender as GameButton;

           // myButton.FlipButton();
            if (myButtons[lastOneClicked].IsFlipped())
            {
                
            }
            else
            {
             //   myButtons[lastOneClicked]
            }
            lastOneClicked = myButton.Pos;

            //  flipped = true;
            //  IsEnabled = false;
            //  await Task.WhenAll(this.RotateYTo(90, 250));
            //  BackgroundColor = HiddenColour;
            //  await Task.WhenAll(this.RotateYTo(180, 250));
        }
    }
}
