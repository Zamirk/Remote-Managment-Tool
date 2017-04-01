using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Label = Xamarin.Forms.Label;

namespace Mobile
{
	public class DashboardScreen : ScrollView
	{
        private bool moving = false;
        private bool resizing = false;

        double width = 109.25;
        double height = 99.6;

        private Grid superGrid;
        private Grid mainGrid;
        //private List<Cell> myCellList = new List<Cell>();
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

            Button resizing = new Button();
            resizing.Text = "Resize";
            resizing.FontSize = 15;
            resizing.WidthRequest = 150;
            resizing.HeightRequest = 150;
            resizing.HorizontalOptions = LayoutOptions.CenterAndExpand;
            resizing.VerticalOptions = LayoutOptions.CenterAndExpand;
            resizing.BackgroundColor = Color.Black;
            resizing.TextColor = Color.White;
            resizing.Clicked += ResizingOnClicked;
            buttonGrid.Children.Add(resizing, 2, 0);

            Button movingButton = new Button();
            movingButton.Text = "Move";
            movingButton.FontSize = 15;
            movingButton.WidthRequest = 150;
            movingButton.HeightRequest = 150;
            movingButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            movingButton.VerticalOptions = LayoutOptions.CenterAndExpand;
            movingButton.BackgroundColor = Color.Black;
            movingButton.TextColor = Color.White;
            movingButton.Clicked += MovingButton;
            buttonGrid.Children.Add(movingButton, 3, 0);

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.FontSize = 15;
            deleteButton.WidthRequest = 150;
            deleteButton.HeightRequest = 150;
            deleteButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            deleteButton.VerticalOptions = LayoutOptions.CenterAndExpand;
            deleteButton.BackgroundColor = Color.Black;
            deleteButton.TextColor = Color.White;
            buttonGrid.Children.Add(deleteButton, 4, 0);

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

                    //Max Spans in grid
                    myCells[xAxis][yAxis].MaxSpanColumn = 8 - xAxis;
                    myCells[xAxis][yAxis].MaxSpanRow = 5 - yAxis;

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
            superGrid.WidthRequest = 900;
            superGrid.HeightRequest = 550;
            superGrid.MinimumWidthRequest = 500;
            superGrid.HorizontalOptions = LayoutOptions.Start;
            superGrid.VerticalOptions = LayoutOptions.Start;

            Content = superGrid;
            //Point of reference for animation movment


        }

	    private void MovingButton(object sender, EventArgs eventArgs)
	    {
            //When moving button clicked, show buttons or hide dashboard cell buttons, resizing is turned off
	        if (moving)
	        {
	            moving = false;
	            HideButtons();
	        }
	        else
	        {
                ShowButtons();
                moving = true;
                resizing = false;
            }
        }

	    private void ResizingOnClicked(object sender, EventArgs e)
        {
            //When resizing button clicked, show buttons or hide dashboard cell buttons, moving is turned off
            if (resizing)
            {
                resizing = false;
                HideButtons();
            }
            else
            {
                ShowButtons();
                resizing = true;
                moving = false;
            }
        }

        private void HideButtons()
        {
            //mainGrid.ColumnSpacing = 5;
            //mainGrid.RowSpacing = 5;
            //mainGrid.ForceLayout();
            //Hide all of the dashboard cell buttons
            for (int yAxis = 0; yAxis < 5; yAxis++)
            {
                for (int xAxis = 0; xAxis < 8; xAxis++)
                {
                    myCells[xAxis][yAxis].RemoveMovementButtons();
                    myCells[xAxis][yAxis].EnableButton();
                        myCells[xAxis][yAxis].InputTransparent = false;
                    if (myCells[xAxis][yAxis].Opacity == 0)
                    {
                        myCells[xAxis][yAxis].Opacity = 1.1;
                    }
                }
            }
        }

        private void ShowButtons()
	    {
            //Show all of the dashboard cell buttons
            for (int yAxis = 0; yAxis < 5; yAxis++)
            {
                for (int xAxis = 0; xAxis < 8; xAxis++)
                {
                    myCells[xAxis][yAxis].PositionalButtons();
                    myCells[xAxis][yAxis].DisableButton();
                    if (!myCells[xAxis][yAxis].hasGraph)
                    {
                        myCells[xAxis][yAxis].InputTransparent = true;
                        myCells[xAxis][yAxis].Opacity = 0;
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

            if (moving)
            {
                if (y > 0)
                {
                    //Animation
                    //Displacement: Relative distance from its original position + the the cell width its switching with
                    double displacement = (myCells[x][y].TranslationY - (height + 3));
                    double displacement2 = (myCells[x2][y2].TranslationY + (height + 3));

                    myCells[x][y].TranslateTo(myCells[x][y].TranslationX, displacement, 500, Easing.CubicInOut);
                    myCells[x][y2].TranslateTo(myCells[x2][y2].TranslationX, displacement2, 500, Easing.CubicInOut);

                    //Swapping
                    swap(ref myCells[x][y], ref myCells[x2][y2]);

                    //Swapping location value
                    myCells[x][y].SetLocation(x, y);
                    myCells[x2][y2].SetLocation(x2, y2);
                }
            } else if (resizing)
            {
                if (Grid.GetRowSpan(myCells[x][y]) != 1)
                {
                    Grid.SetRowSpan(myCells[x][y], Grid.GetRowSpan(myCells[x][y]) - 1);
                }
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

            if (moving)
            {
                if (y < 4)
                {
                    //Animation
                    //Displacement: Relative distance from its original position + the the cell width its switching with
                    double displacement = (myCells[x][y].TranslationY + (height + 3));
                    double displacement2 = (myCells[x2][y2].TranslationY - (height + 3));

                    myCells[x][y].TranslateTo(myCells[x][y].TranslationX, displacement, 500, Easing.CubicInOut);
                    myCells[x2][y2].TranslateTo(myCells[x2][y2].TranslationX, displacement2, 500, Easing.CubicInOut);

                    //Swapping
                    swap(ref myCells[x][y], ref myCells[x2][y2]);

                    //Swapping location value
                    myCells[x][y].SetLocation(x, y);
                    myCells[x2][y2].SetLocation(x2, y2);
                }
            } else if (resizing)
            {
                //Checking max row span
                if ((Grid.GetRowSpan(myCells[x][y]) + 1 <= myCells[x][y].MaxSpanRow)
                    && Grid.GetRowSpan(myCells[x][y]) + y < 5)
                {
                    Grid.SetRowSpan(myCells[x][y], Grid.GetRowSpan(myCells[x][y]) + 1);
                }
                //myCells[x2][y2].IsVisible = false;
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

	        if (moving)
	        {
	        if (x > 0)
	        {
                    //TODO
                    //Prevents moving off the screen, when spanning is > 1
                //Animation
                //Displacement: Relative distance from its original position + the the cell width its switching with
                double displacement = (myCells[x][y].TranslationX - (width + 3));
                double displacement2 = (myCells[x2][y2].TranslationX + (width + 3));

                myCells[x][y].TranslateTo(displacement, myCells[x][y].TranslationY, 500, Easing.CubicInOut);
                myCells[x2][y2].TranslateTo(displacement2, myCells[x2][y2].TranslationY, 500, Easing.CubicInOut);

                //Swapping
                swap(ref myCells[x][y], ref myCells[x2][y2]);

                //Swapping location value
                myCells[x][y].SetLocation(x, y);
                myCells[x2][y2].SetLocation(x2, y2);
            }
            } else if (resizing)
	        {
	            if (Grid.GetColumnSpan(myCells[x][y]) != 1)
	            {
	                Grid.SetColumnSpan(myCells[x][y], Grid.GetColumnSpan(myCells[x][y]) - 1);
	            }
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

	        if (moving)
	        {
            if (x < 7)
            {
            //Animation
            //Displacement: Relative distance from its original position + the the cell width its switching with
	        double displacement = (myCells[x][y].TranslationX + (width + 3));
            double displacement2 = (myCells[x2][y2].TranslationX - (width + 3));

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
            } else if (resizing)
	        {
                //Checking max collumn span
	            if ((Grid.GetColumnSpan(myCells[x][y]) + 1 <= myCells[x][y].MaxSpanColumn)
                    && Grid.GetColumnSpan(myCells[x][y]) + x < 8 )
	            {
                Grid.SetColumnSpan(myCells[x][y], Grid.GetColumnSpan(myCells[x][y]) + 1);
                }
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
