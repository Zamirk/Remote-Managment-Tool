using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Label = Xamarin.Forms.Label;

namespace RAT._1View.Desktop.Manage
{
	public class DashboardScreen : ScrollView
	{
        private bool editing = false;

        private Grid superGrid;
        private Grid mainGrid;
        //private List<DashboardCell> myCellList = new List<DashboardCell>();
        private DashboardCell[][] myCells = new DashboardCell[8][];
        private bool singleSquares = true;
        public DashboardScreen()
        {
            Orientation = ScrollOrientation.Both;
            superGrid = new Grid();
            superGrid.RowDefinitions.Add(new RowDefinition { Height = 35 });
            superGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            superGrid.ColumnSpacing = 0;
            superGrid.RowSpacing = 0;

            Grid buttonGrid = new Grid();
            //buttonGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            //buttonGrid.HorizontalOptions = LayoutOptions.Start;

            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            buttonGrid.ColumnSpacing = 0;
            buttonGrid.RowSpacing = 0;

            Button editButton = new Button();
            editButton.Text = "Move";
            editButton.FontSize = 15;
            editButton.WidthRequest = 150;
            editButton.HeightRequest = 150;
            editButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            editButton.VerticalOptions = LayoutOptions.CenterAndExpand;
            editButton.BackgroundColor = Color.Black;
            editButton.TextColor = Color.White;
            editButton.Clicked += EditButton_Clicked;
            buttonGrid.Children.Add(editButton, 2, 0);

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.FontSize = 15;
            deleteButton.WidthRequest = 150;
            deleteButton.HeightRequest = 150;
            deleteButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            deleteButton.VerticalOptions = LayoutOptions.CenterAndExpand;
            deleteButton.BackgroundColor = Color.Black;
            deleteButton.TextColor = Color.White;
            buttonGrid.Children.Add(deleteButton, 3, 0);

            Button sizeButton = new Button();
            sizeButton.Text = "Resize";
            sizeButton.FontSize = 15;
            sizeButton.WidthRequest = 150;
            sizeButton.HeightRequest = 150;
            sizeButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            sizeButton.VerticalOptions = LayoutOptions.CenterAndExpand;
            sizeButton.BackgroundColor = Color.Black;
            sizeButton.TextColor = Color.White;
            buttonGrid.Children.Add(sizeButton, 1, 0);

            superGrid.Children.Add(buttonGrid,0,0);

            myCells[0] = new DashboardCell[5];
            myCells[1] = new DashboardCell[5];
            myCells[2] = new DashboardCell[5];
            myCells[3] = new DashboardCell[5];
            myCells[4] = new DashboardCell[5];
            myCells[5] = new DashboardCell[5];
            myCells[6] = new DashboardCell[5];
            myCells[7] = new DashboardCell[5];

            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;

            mainGrid = new Grid();
            mainGrid.ColumnSpacing = 3;
            mainGrid.RowSpacing = 3;
            mainGrid.BackgroundColor = Color.FromRgb(237, 237, 235);
            int pos = 0;

            mainGrid.Padding = new Thickness(5,5,0,0);
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            Random rand = new Random();
            //Addings cells, X and Y grid
            for (int yAxis = 0; yAxis < 5; yAxis++)
            {
                for (int xAxis = 0; xAxis < 8; xAxis++)
                {
                    DashboardCell myCell = new DashboardCell();
                    myCells[xAxis][yAxis] = myCell;
                    //myCells[xAxis][yAxis].BackgroundColor = Color.FromRgb(rand.Next(255), rand.Next(255), rand.Next(255));
                    //Position in the grid/layout
                    myCells[xAxis][yAxis].XLocation = xAxis;
                    myCells[xAxis][yAxis].YLocation = yAxis;

                    //Movements
                    myCells[xAxis][yAxis].east.Clicked += EastOnClicked;
                    myCells[xAxis][yAxis].west.Clicked += WestOnClicked;
                    myCells[xAxis][yAxis].north.Clicked += NorthOnClicked;
                    myCells[xAxis][yAxis].south.Clicked += SouthOnClicked;

                    System.Diagnostics.Debug.WriteLine(":::"+(yAxis)+":"+ xAxis);
                    mainGrid.Children.Add(myCell, xAxis, yAxis);

                }
            }
            //TODO CURRENTLY DOING
            superGrid.Children.Add(mainGrid,0,1);
            superGrid.WidthRequest = 880;
            superGrid.HeightRequest = 550;
            superGrid.MinimumWidthRequest = 500;
            superGrid.HorizontalOptions = LayoutOptions.Start;
            superGrid.VerticalOptions = LayoutOptions.Start;
            Content = superGrid;
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            //mainGrid.ColumnSpacing = 5;
            //mainGrid.RowSpacing = 5;
            //mainGrid.ForceLayout();
            if (!editing)
            {
                for (int yAxis = 0; yAxis < 5; yAxis++)
                {
                    for (int xAxis = 0; xAxis < 8; xAxis++)
                    {
                        myCells[xAxis][yAxis].PositionalButtons();
                        myCells[xAxis][yAxis].DisableButton();
                    }
                }
                editing = true;
            }
            else
            {
                editing = false;
                for (int yAxis = 0; yAxis < 5; yAxis++)
                {
                    for (int xAxis = 0; xAxis < 8; xAxis++)
                    {
                        myCells[xAxis][yAxis].RemoveMovementButtons();
                        myCells[xAxis][yAxis].EnableButton();
                    }
                }
            }
        }

        private void NorthOnClicked(object sender, EventArgs e)
        {
            Button s = sender as Button;
            DashboardCell d = (DashboardCell)s.Parent;

            int x = d.XLocation;
            int y = d.YLocation;

            int x2 = d.XLocation;
            int y2 = d.YLocation - 1;

            if (y > 0)
            {
                //Animation
                //Displacement: Relative distance from its original position + the the cell width its switching with
                double displacement = (myCells[x][y].TranslationY - (myCells[x2][y2].Height + 3));
                double displacement2 = (myCells[x2][y2].TranslationY + (myCells[x][y].Height + 3));

                myCells[x][y].TranslateTo(myCells[x][y].TranslationX, displacement, 500, Easing.CubicInOut);
                myCells[x][y2].TranslateTo(myCells[x2][y2].TranslationX, displacement2, 500, Easing.CubicInOut);

                //Swapping
                swap(ref myCells[x][y], ref myCells[x2][y2]);

                //Swapping location value
                myCells[x][y].SetLocation(x, y);
                myCells[x2][y2].SetLocation(x2, y2);
            }
        }

        private void SouthOnClicked(object sender, EventArgs e)
        {
            Button s = sender as Button;
            DashboardCell d = (DashboardCell)s.Parent;

            int x = d.XLocation;
            int y = d.YLocation;

            int x2 = d.XLocation;
            int y2 = d.YLocation + 1;

            if (y < 4)
            {
                //Animation
                //Displacement: Relative distance from its original position + the the cell width its switching with
                double displacement = (myCells[x][y].TranslationY + (myCells[x2][y2].Height + 3));
                double displacement2 = (myCells[x2][y2].TranslationY - (myCells[x][y].Height + 3));

                myCells[x][y].TranslateTo(myCells[x][y].TranslationX, displacement, 500, Easing.CubicInOut);
                myCells[x2][y2].TranslateTo(myCells[x2][y2].TranslationX, displacement2, 500, Easing.CubicInOut);

                //Swapping
                swap(ref myCells[x][y], ref myCells[x2][y2]);

                //Swapping location value
                myCells[x][y].SetLocation(x, y);
                myCells[x2][y2].SetLocation(x2, y2);
            }
        }



        private void WestOnClicked(object sender, EventArgs e)
	    {
	        Button s = sender as Button;
	        DashboardCell d = (DashboardCell) s.Parent;

	        int x = d.XLocation;
	        int y = d.YLocation;

	        int x2 = d.XLocation - 1;
	        int y2 = d.YLocation;

	        if (x > 0)
	        {
                //Animation
                //Displacement: Relative distance from its original position + the the cell width its switching with
                double displacement = (myCells[x][y].TranslationX - (myCells[x2][y2].Width + 3));
                double displacement2 = (myCells[x2][y2].TranslationX + (myCells[x][y].Width + 3));

                myCells[x][y].TranslateTo(displacement, myCells[x][y].TranslationY, 500, Easing.CubicInOut);
                myCells[x2][y2].TranslateTo(displacement2, myCells[x2][y2].TranslationY, 500, Easing.CubicInOut);

                //Swapping
                swap(ref myCells[x][y], ref myCells[x2][y2]);

                //Swapping location value
                myCells[x][y].SetLocation(x, y);
                myCells[x2][y2].SetLocation(x2, y2);
            }
	    }

	    private void EastOnClicked(object sender, EventArgs eventArgs)
	    {
	        Button s = sender as Button;
            s.BackgroundColor = Color.Green;
	        DashboardCell d = (DashboardCell)s.Parent;

            int x = d.XLocation;
            int y = d.YLocation;

            int x2 = d.XLocation + 1;
            int y2 = d.YLocation;

            if (x < 7)
            {
            //Animation
            //Displacement: Relative distance from its original position + the the cell width its switching with
	        double displacement = (myCells[x][y].TranslationX + (myCells[x2][y2].Width + 3));
            double displacement2 = (myCells[x2][y2].TranslationX - (myCells[x][y].Width + 3));

            myCells[x][y].TranslateTo(displacement, myCells[x][y].TranslationY, 500, Easing.CubicInOut);
            myCells[x2][y2].TranslateTo(displacement2, myCells[x2][y2].TranslationY, 500, Easing.CubicInOut);

            //Swapping array reference locations
            swap(ref myCells[x][y], ref myCells[x2][y2]);

            //Swapping location value#
            myCells[x][y].SetLocation(x, y);
            myCells[x2][y2].SetLocation(x2, y2);

            System.Diagnostics.Debug.WriteLine("Translation X"+myCells[x][y].TranslationX);
            System.Diagnostics.Debug.WriteLine("Distance X" + displacement2);
            }
        }

        //Swapping values on Dashboard
        static void swap(ref DashboardCell a, ref DashboardCell b)
        {
            DashboardCell temp = a;
            a = b;
            b = temp;
        }
    }
}
