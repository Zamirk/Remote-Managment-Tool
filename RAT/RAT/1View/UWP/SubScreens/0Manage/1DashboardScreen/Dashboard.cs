using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using RAT.ZTry;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen;
using RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Cell = RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen.Cell;
using Label = Xamarin.Forms.Label;

namespace RAT._1View.Desktop.Manage
{
	public class Dashboard : ScrollView
	{
        private DashboardButtonState buttonState;
        //Popup screens
        private GraphSelection selectGraph = new GraphSelection();
        private EditGraph editChart = new EditGraph();

        private Button deleteButton, editing, movingButton, resizing, add;
	    private Picker dashboardList;
        double width = 109.25; //Todo stop hardcoding values
        double height = 99.6;

        private Grid superGrid;
        private Grid mainGrid;
        //private List<Cell> myCellList = new List<Cell>();
        private Cell[][] myCells = new Cell[8][];

        private bool singleSquares = true;

        EventHandler handler0 = null;
        EventHandler handler1 = null;
        EventHandler handler2 = null;
        EventHandler handler3 = null;
        EventHandler handler4 = null;
        EventHandler handler5 = null;
        EventHandler handler6 = null;
        EventHandler handler7 = null;
        EventHandler handler8 = null;
        EventHandler handler9 = null;
        EventHandler handler10 = null;
        EventHandler handler11 = null;

	    public void GenerateDashboard()
	    {
            //Looping through dashboard cells
            for (int yAxis = 0; yAxis < 5; yAxis++)
            {
                for (int xAxis = 0; xAxis < 8; xAxis++)
                {
                    //Getting values
                    int columnSpan = DashboardFromDatabase.myCells[xAxis][yAxis].ColumnSpan;
                    int rowSpan = DashboardFromDatabase.myCells[xAxis][yAxis].RowSpan;
                    int device = DashboardFromDatabase.myCells[xAxis][yAxis].Device;
                    int dataSource = DashboardFromDatabase.myCells[xAxis][yAxis].Datasource;
                    int colour = DashboardFromDatabase.myCells[xAxis][yAxis].Colour;
                    string title = DashboardFromDatabase.myCells[xAxis][yAxis].Title;

                    bool x = DashboardFromDatabase.myCells[xAxis][yAxis].xAx;
                    bool y = DashboardFromDatabase.myCells[xAxis][yAxis].yAx;
                    bool grid = DashboardFromDatabase.myCells[xAxis][yAxis].grid;

                    //If a graph is present
                    if (DashboardFromDatabase.myCells[xAxis][yAxis].hasGraph)
                    {
                            if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 0)
                            {
                                myCells[xAxis][yAxis].AreaChart(device, dataSource);
                            }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 1)
                            {
                                myCells[xAxis][yAxis].BarChart(device, dataSource);
                        }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 2)
                            {
                                myCells[xAxis][yAxis].ColumnChart(device, dataSource);
                        }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 3)
                            {
                                myCells[xAxis][yAxis].LineChart(device, dataSource);
                        }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 4)
                            {
                                myCells[xAxis][yAxis].StepArea(device, dataSource);
                        }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 5)
                            {
                                myCells[xAxis][yAxis].PyramidChart(device, dataSource);
                        }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 6)
                            {
                                myCells[xAxis][yAxis].ScatterChart(device, dataSource);
                        }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 7)
                            {
                                myCells[xAxis][yAxis].SplineSeriesChart(device, dataSource);
                        }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 8)
                            {
                                myCells[xAxis][yAxis].SplineAreaChart(device, dataSource);
                        }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 9)
                            {
                                myCells[xAxis][yAxis].StepLineSeries(device, dataSource);
                        }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 10)
                            {
                                myCells[xAxis][yAxis].PieChart(device, dataSource);
                        }
                            else if (DashboardFromDatabase.myCells[xAxis][yAxis].GraphType == 11)
                            {
                                myCells[xAxis][yAxis].DoughnutChart(device, dataSource);
                        }
                        myCells[xAxis][yAxis].ColumnSpan = columnSpan;
                        Grid.SetColumnSpan(myCells[xAxis][yAxis], columnSpan);

                        myCells[xAxis][yAxis].RowSpan = rowSpan;
                        Grid.SetRowSpan(myCells[xAxis][yAxis], rowSpan);

                        myCells[xAxis][yAxis].Device = device;
                        myCells[xAxis][yAxis].Datasource = dataSource;
                        myCells[xAxis][yAxis].ApplyChanges(x, y, grid, colour, title);

                    }
                }
            }
        }

        //Edit screen event handler
        EventHandler handler12 = null;
        public Dashboard()
        {
            selectGraph.CloseWhenBackgroundIsClicked = false;
            Orientation = ScrollOrientation.Both;
            superGrid = new Grid();
            superGrid.RowDefinitions.Add(new RowDefinition { Height = 35 });
            superGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            superGrid.ColumnSpacing = 0;
            superGrid.RowSpacing = 0;

            Grid buttonGrid = new Grid();
            //buttonGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            //buttonGrid.HorizontalOptions = LayoutOptions.Start;

            //Todo loops
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            buttonGrid.ColumnSpacing = 0;
            buttonGrid.RowSpacing = 0;

            #region myButtons and picker
            dashboardList = new Picker();
            dashboardList.HorizontalOptions = LayoutOptions.CenterAndExpand;
            dashboardList.VerticalOptions = LayoutOptions.CenterAndExpand;
            dashboardList.WidthRequest = 200;
            dashboardList.HeightRequest = 200;
            dashboardList.Items.Add("Dashboard 1");
            dashboardList.Items.Add("Dashboard 2");
            dashboardList.Items.Add("Dashboard 3");
            dashboardList.Items.Add("Dashboard 4");
            dashboardList.Items.Add("Dashboard 5");
            dashboardList.Items.Add("Dashboard 6");
            dashboardList.SelectedIndex = 0;
            buttonGrid.Children.Add(dashboardList, 0, 0);

            add = new Button();
            add.Text = "Add";
            add.FontSize = 15;
            add.WidthRequest = 200;
            add.HeightRequest = 150;
            add.HorizontalOptions = LayoutOptions.CenterAndExpand;
            add.VerticalOptions = LayoutOptions.Center;
            add.BorderColor = Color.Transparent;
            add.BackgroundColor = Color.Transparent;
            add.BorderWidth = .000001;
            add.Clicked += AddOnClicked;
            buttonGrid.Children.Add(add, 1, 0);

            editing = new Button();
            editing.Text = "Editing";
            editing.FontSize = 15;
            editing.WidthRequest = 200;
            editing.HeightRequest = 150;
            editing.HorizontalOptions = LayoutOptions.CenterAndExpand;
            editing.VerticalOptions = LayoutOptions.Center;
            editing.BackgroundColor = Color.Black;
            editing.BorderColor = Color.Transparent;
            editing.BackgroundColor = Color.Transparent;
            editing.BorderWidth = .000001;
            editing.Clicked += EditingOnClicked;
            buttonGrid.Children.Add(editing, 2, 0);

            resizing = new Button();
            resizing.Text = "Resize";
            resizing.FontSize = 15;
            resizing.WidthRequest = 150;
            resizing.HeightRequest = 150;
            resizing.HorizontalOptions = LayoutOptions.CenterAndExpand;
            resizing.VerticalOptions = LayoutOptions.Center;
            resizing.BorderColor = Color.Transparent;
            resizing.BackgroundColor = Color.Transparent;
            resizing.BorderWidth = .000001;
            resizing.Clicked += ResizingOnClicked;
            buttonGrid.Children.Add(resizing, 3, 0);

            movingButton = new Button();
            movingButton.Text = "Move";
            movingButton.FontSize = 15;
            movingButton.WidthRequest = 200;
            movingButton.HeightRequest = 150;
            movingButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            movingButton.VerticalOptions = LayoutOptions.Center;
            movingButton.BorderColor = Color.Transparent;
            movingButton.BackgroundColor = Color.Transparent;
            movingButton.BorderWidth = .000001;
            movingButton.Clicked += MovingButton;
            buttonGrid.Children.Add(movingButton, 4, 0);

            deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.FontSize = 15;
            deleteButton.WidthRequest = 200;
            deleteButton.HeightRequest = 150;
            deleteButton.HorizontalOptions = LayoutOptions.CenterAndExpand;
            deleteButton.VerticalOptions = LayoutOptions.Center;
            deleteButton.BorderColor = Color.Transparent;
            deleteButton.BackgroundColor = Color.Transparent;
            deleteButton.BorderWidth = .000001;
            deleteButton.Clicked += DeleteButtonOnClicked;
            buttonGrid.Children.Add(deleteButton, 5, 0);
            #endregion

            superGrid.Children.Add(buttonGrid, 0, 0);

            //Todo loops
            //Todo fix p key
            myCells[0] = new Cell[5];
            myCells[1] = new Cell[5];
            myCells[2] = new Cell[5];
            myCells[3] = new Cell[5];
            myCells[4] = new Cell[5];
            myCells[5] = new Cell[5];
            myCells[6] = new Cell[5];
            myCells[7] = new Cell[5];

            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;

            mainGrid = new Grid();
            mainGrid.ColumnSpacing = 3;
            mainGrid.RowSpacing = 3;
            mainGrid.BackgroundColor = Color.White;

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
                    Cell myCell = new Cell();
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
                    myCells[xAxis][yAxis].myButton.Clicked += MyButtonOnClicked;
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
            //GenerateDashboard();
            //Point of reference for animation movment
            GenerateDashboard();
        }

	    public void GC()
	    {
            //Addings cells, X and Y grid
            for (int yAxis = 0; yAxis < 5; yAxis++)
            {
                for (int xAxis = 0; xAxis < 8; xAxis++)
                {
                    myCells[xAxis][yAxis].CleanCell();
                    mainGrid.Children.Clear();
                    BindingContext = null;
                }
            }
        }
	    private async void MyButtonOnClicked(object sender, EventArgs eventArgs)
	    {
            //Getting the references
            Button s = (Button)sender;
	        Cell myCell = (Cell)s.Parent;

            //If adding option is selected
	        if (myCell.buttonState == DashboardButtonState.Add)
	        {
                //If the cell does not havea graph
	            if (!myCell.hasGraph)
	            {
	                //Event handlers which remove themselves(and all others) after a single use
	                handler0 = (o, e) =>
	                {
	                    myCell.AreaChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
	                    GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler1 = (o, e) =>
	                {
	                    myCell.BarChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler2 = (o, e) =>
	                {
	                    myCell.ColumnChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler3 = (o, e) =>
	                {
	                    myCell.LineChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler4 = (o, e) =>
	                {
	                    myCell.StepArea(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler5 = (o, e) =>
	                {
	                    myCell.PyramidChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler6 = (o, e) =>
	                {
	                    myCell.ScatterChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler7 = (o, e) =>
	                {
	                    myCell.SplineSeriesChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler8 = (o, e) =>
	                {
	                    myCell.SplineAreaChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler9 = (o, e) =>
	                {
	                    myCell.StepLineSeries(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler10 = (o, e) =>
	                {
	                    myCell.PieChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };

	                handler11 = (o, e) =>
	                {
	                    myCell.DoughnutChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        GCGraphSelect();
	                    Navigation.PopPopupAsync(true);
	                };
	            //Connection events to select graph screen
                AddEventHandlers();

                await Navigation.PushPopupAsync(selectGraph);
                }
            } else if (myCell.buttonState == DashboardButtonState.Editing)
            {
                //If there is a graph
                if (myCell.hasGraph)
                {
                    //Set attributes of edit screen initially from the cell
                    editChart.SetAttributes(
                        myCell.xAxisOn,
                        myCell.yAxisOn,
                        myCell.GridLinesOn,
                        myCell.title,
                        myCell.colourValue);

                    await Navigation.PushPopupAsync(editChart);

                    handler12 = (o, e) =>
                    {
                        //Applying back the new changes
                        myCell.ApplyChanges(
                            editChart.XAxisValue,
                            editChart.YXaxisValue,
                            editChart.GridLinesValues,
                            editChart.ColourPicked,
                            editChart.TitleTyped);

                        editChart.saveButton.Clicked -= handler12;
                        Navigation.PopPopupAsync(true);
                    };

                    editChart.saveButton.Clicked += handler12;

                    //Creating new edit popup screen, adding clickhandler
                    // editChart = new EditGraph(xAxisOn, yAxisOn, GridLinesOn, title, colourValue);
                    //  editChart.CloseWhenBackgroundIsClicked = false;
                    //  editChart.saveButton.Clicked += SaveButtonOnClicked;
                    //  await Navigation.PushPopupAsync(editChart);
                }
            }
            else if (myCell.buttonState == DashboardButtonState.Delete)
            {
                //If delete is selected, then invoke the clean cell method
                myCell.CleanCell();
            }
        }

	    public void AddEventHandlers()
	    {
            //Adding graph generating method to chart select buttons
            selectGraph.AreaChart().Clicked += handler0;
            selectGraph.BarChart().Clicked += handler1;
            selectGraph.ColumnChart().Clicked += handler2;
            selectGraph.LineChart().Clicked += handler3;
            selectGraph.StepAreaChart().Clicked += handler4;
            selectGraph.PyramidChart().Clicked += handler5;
            selectGraph.ScatterplotChart().Clicked += handler6; ;
            selectGraph.SplineChart().Clicked += handler7;
            selectGraph.SplineAreaChart().Clicked += handler8;
            selectGraph.StepLineChart().Clicked += handler9;
            selectGraph.PieChart().Clicked += handler10;
            selectGraph.DoughnutChart().Clicked += handler11;
        }

	    public void GCGraphSelect()
	    {
            selectGraph.AreaChart().Clicked -= handler0;
            selectGraph.BarChart().Clicked -= handler1;
            selectGraph.ColumnChart().Clicked -= handler2;
            selectGraph.LineChart().Clicked -= handler3;
            selectGraph.StepAreaChart().Clicked -= handler4;
            selectGraph.PyramidChart().Clicked -= handler5;
            selectGraph.ScatterplotChart().Clicked -= handler6; ;
            selectGraph.SplineChart().Clicked -= handler7;
            selectGraph.SplineAreaChart().Clicked -= handler8;
            selectGraph.StepLineChart().Clicked -= handler9;
            selectGraph.PieChart().Clicked -= handler10;
            selectGraph.DoughnutChart().Clicked -= handler11;
        }

        private void AddOnClicked(object sender, EventArgs eventArgs)
	    {
            if (buttonState != DashboardButtonState.Add)
            {
                add.BackgroundColor = Color.Gray;
                deleteButton.BackgroundColor = Color.Transparent;
                editing.BackgroundColor = Color.Transparent;
                resizing.BackgroundColor = Color.Transparent;
                movingButton.BackgroundColor = Color.Transparent;

                buttonState = DashboardButtonState.Add;
                HideButtons();

                for (int yAxis = 0; yAxis < 5; yAxis++)
                {
                    for (int xAxis = 0; xAxis < 8; xAxis++)
                    {
                        myCells[xAxis][yAxis].buttonState = DashboardButtonState.Add;
                    }
                }
            }
        }


        private void DeleteButtonOnClicked(object sender, EventArgs eventArgs)
	    {
	        if (buttonState != DashboardButtonState.Delete)
	        {
                deleteButton.BackgroundColor = Color.Gray;
                editing.BackgroundColor = Color.Transparent;
                resizing.BackgroundColor = Color.Transparent;
                movingButton.BackgroundColor = Color.Transparent;
                add.BackgroundColor = Color.Transparent;

                buttonState = DashboardButtonState.Delete;
                HideButtons();

                //Making all Dashboard Cells clickable clickable
                for (int yAxis = 0; yAxis < 5; yAxis++)
                {
                    for (int xAxis = 0; xAxis < 8; xAxis++)
                    {
                        myCells[xAxis][yAxis].buttonState = DashboardButtonState.Delete;
                    }
                }
            }
        }

	    private void EditingOnClicked(object sender, EventArgs eventArgs)
	    {
            if (buttonState != DashboardButtonState.Editing)
            {
                deleteButton.BackgroundColor = Color.Transparent;
                editing.BackgroundColor = Color.Gray;
                resizing.BackgroundColor = Color.Transparent;
                movingButton.BackgroundColor = Color.Transparent;
                add.BackgroundColor = Color.Transparent;

                buttonState = DashboardButtonState.Editing;
                HideButtons();

                //Making all Dashboard Cells clickable clickable
                for (int yAxis = 0; yAxis < 5; yAxis++)
                {
                    for (int xAxis = 0; xAxis < 8; xAxis++)
                    {
                        myCells[xAxis][yAxis].buttonState = DashboardButtonState.Editing;
                    }
                }
            }
        }

        private void MovingButton(object sender, EventArgs eventArgs)
	    {
            //When moving button clicked, show buttons or hide dashboard cell buttons, resizing is turned off
	        if (buttonState != DashboardButtonState.Move)
	        {
                deleteButton.BackgroundColor = Color.Transparent;
                editing.BackgroundColor = Color.Transparent;
                resizing.BackgroundColor = Color.Transparent;
                movingButton.BackgroundColor = Color.Gray;
                add.BackgroundColor = Color.Transparent;

                buttonState = DashboardButtonState.Move;
                ShowButtons();

                for (int yAxis = 0; yAxis < 5; yAxis++)
                {
                    for (int xAxis = 0; xAxis < 8; xAxis++)
                    {
                        myCells[xAxis][yAxis].buttonState = DashboardButtonState.Move;
                    }
                }
            }
        }

        private void ResizingOnClicked(object sender, EventArgs e)
        {
            //When resizing button clicked, show buttons or hide dashboard cell buttons, moving is turned off
            if (buttonState != DashboardButtonState.Resize)
            {
                deleteButton.BackgroundColor = Color.Transparent;
                editing.BackgroundColor = Color.Transparent;
                resizing.BackgroundColor = Color.Gray;
                movingButton.BackgroundColor = Color.Transparent;
                add.BackgroundColor = Color.Transparent;

                buttonState = DashboardButtonState.Resize;
                ShowButtons();

                for (int yAxis = 0; yAxis < 5; yAxis++)
                {
                    for (int xAxis = 0; xAxis < 8; xAxis++)
                    {
                        myCells[xAxis][yAxis].buttonState = DashboardButtonState.Resize;
                    }
                }
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
                    //TODO Remove opacity 24/03
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
            Cell d = (Cell)s.Parent;

            int x = d.XLocation;
            int y = d.YLocation;

            int x2 = d.XLocation;
            int y2 = d.YLocation - 1;

            if (buttonState == DashboardButtonState.Move)
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
            } else if (buttonState == DashboardButtonState.Resize)
            {
                if (Grid.GetRowSpan(myCells[x][y]) != 1)
                {
                    Grid.SetRowSpan(myCells[x][y], Grid.GetRowSpan(myCells[x][y]) - 1);
                    //Setting data
                    myCells[x][y].RowSpan = Grid.GetRowSpan(myCells[x][y]) - 1;
                }
            }
        }

        private void SouthOnClicked(object sender, EventArgs e)
        {
            Button s = sender as Button;
            Cell d = (Cell)s.Parent;

            int x = d.XLocation;
            int y = d.YLocation;

            int x2 = d.XLocation;
            int y2 = d.YLocation + 1;

            if (buttonState == DashboardButtonState.Move)
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
            } else if (buttonState == DashboardButtonState.Resize)
            {
                //Checking max row span
                if ((Grid.GetRowSpan(myCells[x][y]) + 1 <= myCells[x][y].MaxSpanRow)
                    && Grid.GetRowSpan(myCells[x][y]) + y < 5)
                {
                    Grid.SetRowSpan(myCells[x][y], Grid.GetRowSpan(myCells[x][y]) + 1);
                    myCells[x][y].RowSpan = Grid.GetRowSpan(myCells[x][y]) + 1;
                }
                //myCells[x2][y2].IsVisible = false;
            }
        }
        
        private void WestOnClicked(object sender, EventArgs e)
	    {
            Button s = sender as Button;
	        Cell d = (Cell) s.Parent;

	        int x = d.XLocation;
	        int y = d.YLocation;

	        int x2 = d.XLocation - 1;
	        int y2 = d.YLocation;

	        if (buttonState == DashboardButtonState.Move)
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
            } else if (buttonState == DashboardButtonState.Resize)
	        {
	            if (Grid.GetColumnSpan(myCells[x][y]) != 1)
	            {
	                Grid.SetColumnSpan(myCells[x][y], Grid.GetColumnSpan(myCells[x][y]) - 1);
                    //Setting data
	                myCells[x][y].ColumnSpan = Grid.GetColumnSpan(myCells[x][y]) - 1;
	            }
	        }

        }


        private void EastOnClicked(object sender, EventArgs eventArgs)
	    {
            Button s = sender as Button;
            Cell d = (Cell)s.Parent;

            int x = d.XLocation;
            int y = d.YLocation;

            int x2 = d.XLocation + 1;
            int y2 = d.YLocation;

	        if (buttonState == DashboardButtonState.Move)
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
            } else if (buttonState == DashboardButtonState.Resize)
	        {
                //Checking max collumn span
	            if ((Grid.GetColumnSpan(myCells[x][y]) + 1 <= myCells[x][y].MaxSpanColumn)
                    && Grid.GetColumnSpan(myCells[x][y]) + x < 8 )
	            {
                Grid.SetColumnSpan(myCells[x][y], Grid.GetColumnSpan(myCells[x][y]) + 1);
                    //Setting data
                    myCells[x][y].ColumnSpan = Grid.GetColumnSpan(myCells[x][y]) + 1;
                }
            }
        }

        //Swapping values on Dashboard
        static void swap(ref Cell a, ref Cell b)
        {
            Cell temp = a;
            a = b;
            b = temp;
        }
    }
}
