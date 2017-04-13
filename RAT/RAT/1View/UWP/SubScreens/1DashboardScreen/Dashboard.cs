using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using DashboardModel;
using Newtonsoft.Json;
using RAT.ZTry;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen;
using RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen;
using RAT._3Model;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Cell = RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen.Cell;
using Label = Xamarin.Forms.Label;

namespace RAT._1View.Desktop.Manage
{
    public class Dashboard : ScrollView
    {
        private AzureLoginService updateItem;
        private DashboardButtonState buttonState;
        //Popup screens
        private GraphSelection selectGraph = new GraphSelection();
        private EditGraph editGraph = new EditGraph();

        private Button deleteButton, editing, movingButton, resizing, add;

        private Picker dashboardList;
        private int currentDashboard = 0;

        double width = 109.25; //Todo stop hardcoding values
        double height = 99.6;

        private Grid superGrid;
        private Grid mainGrid;
        private Cell[][] myCells = new Cell[8][];

        public bool changed = false;
        private const string replace = @"{""G"":false,""T"":0,""R"":0,""C"":0,""D"":0,""S"":0,""N"":null,""O"":0,""X"":false,""Y"":false,""L"":false}";
        private const string placeHolder = "¬";

        #region Eventhandlers

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

        #endregion

        //Edit screen event handler
        EventHandler handler12 = null;

        public Dashboard()
        {
            selectGraph.CloseWhenBackgroundIsClicked = false;
            editGraph.CloseWhenBackgroundIsClicked = false;

            Orientation = ScrollOrientation.Both;
            buttonState = buttonState = DashboardButtonState.Neutral;
            superGrid = new Grid();
            superGrid.RowDefinitions.Add(new RowDefinition {Height = 35});
            superGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});
            superGrid.ColumnSpacing = 0;
            superGrid.RowSpacing = 0;

            Grid buttonGrid = new Grid();
            //buttonGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            //buttonGrid.HorizontalOptions = LayoutOptions.Start;

            //Todo loops
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            buttonGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
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
            dashboardList.Items.Add("Dashboard 7");
            dashboardList.Items.Add("Dashboard 8");
            dashboardList.Items.Add("Dashboard 9");
            dashboardList.Items.Add("Dashboard 10");
            dashboardList.SelectedIndex = 0;
            dashboardList.SelectedIndexChanged += DashboardListOnSelectedIndexChanged;
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

            mainGrid.Padding = new Thickness(5, 5, 0, 0);
            mainGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});
            mainGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});
            mainGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});
            mainGrid.RowDefinitions.Add(new RowDefinition {Height = GridLength.Star});

            mainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Star});
            int pos = 0;

            //Reference for future sorting
            int[] posArray = new int[40] {000, 001, 002,003,004,005,006,007,008,009,010,011,012,013,014,015,016,017,018,019,020,021,022,023,024,025,026,027,028,029,030,031,032,033,034,035,036,037,038,039};

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

                    //Position for future sorting
                    myCells[xAxis][yAxis].Pos = posArray[pos];
                    pos++;

                    //Adding Movements
                    myCells[xAxis][yAxis].east.Clicked += EastOnClicked;
                    myCells[xAxis][yAxis].west.Clicked += WestOnClicked;
                    myCells[xAxis][yAxis].north.Clicked += NorthOnClicked;
                    myCells[xAxis][yAxis].south.Clicked += SouthOnClicked;

                    myCells[xAxis][yAxis].myButton.Clicked += MyButtonOnClicked;
                    System.Diagnostics.Debug.WriteLine(":::" + (yAxis) + ":" + xAxis);
                    mainGrid.Children.Add(myCell, xAxis, yAxis);
                }
            }
            superGrid.Children.Add(mainGrid, 0, 1);
            superGrid.WidthRequest = 900;
            superGrid.HeightRequest = 550;
            superGrid.MinimumWidthRequest = 500;
            superGrid.HorizontalOptions = LayoutOptions.Start;
            superGrid.VerticalOptions = LayoutOptions.Start;

            Content = superGrid;
            LoadDashboard();

            changed = false;
        }
        public void SaveDashboard()
        {
            DashboardCellModel[][] savingDashboard = new DashboardCellModel[8][];
            for (int i = 0; i < 8; i++)
            {
                savingDashboard[i] = new DashboardCellModel[5]
                {
                    new DashboardCellModel(), new DashboardCellModel(),
                    new DashboardCellModel(), new DashboardCellModel(),
                    new DashboardCellModel(),
                };
            }

            //Looping through dashboard cells
            for (int yAxis = 0; yAxis < 5; yAxis++)
            {
                for (int xAxis = 0; xAxis < 8; xAxis++)
                {
                    if (myCells[xAxis][yAxis].hasGraph)
                    {
                        savingDashboard[xAxis][yAxis].G = true;
                        savingDashboard[xAxis][yAxis].T = myCells[xAxis][yAxis].GraphType;
                        savingDashboard[xAxis][yAxis].R = myCells[xAxis][yAxis].RowSpan;
                        savingDashboard[xAxis][yAxis].C = myCells[xAxis][yAxis].ColumnSpan;
                        savingDashboard[xAxis][yAxis].D = myCells[xAxis][yAxis].Device;
                        savingDashboard[xAxis][yAxis].S = myCells[xAxis][yAxis].Datasource;

                        savingDashboard[xAxis][yAxis].N = myCells[xAxis][yAxis].title;
                        savingDashboard[xAxis][yAxis].O = myCells[xAxis][yAxis].colourValue;
                        savingDashboard[xAxis][yAxis].X = myCells[xAxis][yAxis].xAxisOn;
                        savingDashboard[xAxis][yAxis].Y = myCells[xAxis][yAxis].yAxisOn;
                        savingDashboard[xAxis][yAxis].L = myCells[xAxis][yAxis].GridLinesOn;
                    }
                }
            }

            //Saving to the previously selected dashboard
            DashboardFromDatabase.listOfDashboard[currentDashboard] = savingDashboard;

            //Saving dashbard to database
            if(changed) {
                var messageString = JsonConvert.SerializeObject(savingDashboard);
                messageString = messageString.Replace(replace, placeHolder);

                Dashboards updatedDashboard = new Dashboards()
                {
                    Id = DashboardFromDatabase.listOfIds[currentDashboard],
                    DashNo = "" + currentDashboard,
                    DashString = messageString,
                    Username = DashboardFromDatabase.userName
                };

                System.Diagnostics.Debug.WriteLine(messageString);
                updateItem = new AzureLoginService();
                updateItem.UpdateDashboard(updatedDashboard);
                changed = false;
            }
        }

        public void LoadDashboard()
        {
            //Loading dashboard based on selected option
            //Looping through dashboard cells
            for (int yAxis = 0; yAxis < 5; yAxis++)
            {
                for (int xAxis = 0; xAxis < 8; xAxis++)
                {
                    myCells[xAxis][yAxis].OriginalX = xAxis;
                    myCells[xAxis][yAxis].OriginalY = yAxis;

                    //If a graph is present
                    if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].G)
                    {
                        //Getting values
                        int columnSpan =
                            DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].C;
                        int rowSpan = DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].R;
                        int device = DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].D;
                        int dataSource =
                            DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].S;
                        int colour = DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].O;
                        string title =
                            DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].N;

                        bool x = DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].X;
                        bool y = DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].Y;
                        bool grid = DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].L;

                        if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 0)
                        {
                            myCells[xAxis][yAxis].AreaChart(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 1)
                        {
                            myCells[xAxis][yAxis].BarChart(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 2)
                        {
                            myCells[xAxis][yAxis].ColumnChart(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 3)
                        {
                            myCells[xAxis][yAxis].LineChart(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 4)
                        {
                            myCells[xAxis][yAxis].StepArea(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 5)
                        {
                            myCells[xAxis][yAxis].PyramidChart(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 6)
                        {
                            myCells[xAxis][yAxis].ScatterChart(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 7)
                        {
                            myCells[xAxis][yAxis].SplineSeriesChart(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 8)
                        {
                            myCells[xAxis][yAxis].SplineAreaChart(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 9)
                        {
                            myCells[xAxis][yAxis].StepLineSeries(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 10)
                        {
                            myCells[xAxis][yAxis].PieChart(device, dataSource);
                        }
                        else if (DashboardFromDatabase.listOfDashboard[dashboardList.SelectedIndex][xAxis][yAxis].T == 11)
                        {
                            myCells[xAxis][yAxis].DoughnutChart(device, dataSource);
                        }

                        //Setting column span
                        myCells[xAxis][yAxis].ColumnSpan = columnSpan;
                        Grid.SetColumnSpan(myCells[xAxis][yAxis], columnSpan);

                        //Setting row span
                        myCells[xAxis][yAxis].RowSpan = rowSpan;
                        Grid.SetRowSpan(myCells[xAxis][yAxis], rowSpan);

                        myCells[xAxis][yAxis].Device = device;
                        myCells[xAxis][yAxis].Datasource = dataSource;
                        myCells[xAxis][yAxis].ApplyChanges(x, y, grid, colour, title);
                    }
                }
            }
            changed = false;
        }

        public void ResetDashboard()
        {
            //Resetting the board for reuse when loading other dashboards

            //Resetting database saving
            changed = false;

            //Temp list for sorting
            List<Cell> myList = new List<Cell>();

            //Cleaning cell of current dashboard design
            for (int yAxis = 0; yAxis < 5; yAxis++)
            {
                for (int xAxis = 0; xAxis < 8; xAxis++)
                {
                    myCells[xAxis][yAxis].CleanCell();

                    //Resetting cell locations
                    myCells[xAxis][yAxis].TranslateTo(0, 0, 0, Easing.CubicInOut);

                    //Removing Movements
                    myCells[xAxis][yAxis].east.Clicked -= EastOnClicked;
                    myCells[xAxis][yAxis].west.Clicked -= WestOnClicked;
                    myCells[xAxis][yAxis].north.Clicked -= NorthOnClicked;
                    myCells[xAxis][yAxis].south.Clicked -= SouthOnClicked;

                    //Adding cells to list for sorting
                    myList.Add(myCells[xAxis][yAxis]);
                }
            }

            //Sorting list
            myList = myList.OrderBy(o => o.Pos).ToList();

            //Applying sorting
            int c = 0;
            for (int yAxis = 0; yAxis < 5; yAxis++)
            {
                for (int xAxis = 0; xAxis < 8; xAxis++)
                {
                    myCells[xAxis][yAxis] = myList[c];

                    //Reseting location values
                    myCells[xAxis][yAxis].SetLocation(myCells[xAxis][yAxis].OriginalX, myCells[xAxis][yAxis].OriginalY);

                    //Readding new click handlers
                    myCells[xAxis][yAxis].east.Clicked += EastOnClicked;
                    myCells[xAxis][yAxis].west.Clicked += WestOnClicked;
                    myCells[xAxis][yAxis].north.Clicked += NorthOnClicked;
                    myCells[xAxis][yAxis].south.Clicked += SouthOnClicked;
                    c++;
                }
            }

        }

        private void DashboardListOnSelectedIndexChanged(object sender, EventArgs eventArgs)
        {
            //Setting dashboard to add mode
            AddOnClickMethod();

            //Saving current dashboard
            SaveDashboard();

            //Resetting board
            ResetDashboard();

            //Value for saving dashboard
            currentDashboard = dashboardList.SelectedIndex;

            //Loading new dashboard
            LoadDashboard();
        }

        public void GC()
        {
            SaveDashboard();
            //Addings cells, X and Y grid
            for (int yAxis = 0; yAxis < 5; yAxis++)
            {
                for (int xAxis = 0; xAxis < 8; xAxis++)
                {
                    myCells[xAxis][yAxis].CleanCell();
                    mainGrid.Children.Clear();
                }
            }
            BindingContext = null;
            changed = false;
        }

        private async void MyButtonOnClicked(object sender, EventArgs eventArgs)
        {
            //Getting the references
            Button s = (Button) sender;
            Cell myCell = (Cell) s.Parent;

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
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler1 = (o, e) =>
                    {
                        myCell.BarChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler2 = (o, e) =>
                    {
                        myCell.ColumnChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler3 = (o, e) =>
                    {
                        myCell.LineChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler4 = (o, e) =>
                    {
                        myCell.StepArea(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler5 = (o, e) =>
                    {
                        myCell.PyramidChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler6 = (o, e) =>
                    {
                        myCell.ScatterChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler7 = (o, e) =>
                    {
                        myCell.SplineSeriesChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler8 = (o, e) =>
                    {
                        myCell.SplineAreaChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler9 = (o, e) =>
                    {
                        myCell.StepLineSeries(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler10 = (o, e) =>
                    {
                        myCell.PieChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };

                    handler11 = (o, e) =>
                    {
                        myCell.DoughnutChart(
                            selectGraph.selectDevice.SelectedIndex,
                            selectGraph.selectDataSource.SelectedIndex);
                        RemoveEventHandlers();
                        Navigation.PopPopupAsync(true);
                    };
                    //Connection events to select graph screen
                    AddEventHandlers();

                    await Navigation.PushPopupAsync(selectGraph);
                }
            }
            else if (myCell.buttonState == DashboardButtonState.Editing)
            {
                //If there is a graph
                if (myCell.hasGraph)
                {
                    if (myCell.CheckChartType())
                    {
                        editGraph.AddOptions();
                    }
                    //Set attributes of edit screen initially from the cell
                    editGraph.SetAttributes(
                        myCell.xAxisOn,
                        myCell.yAxisOn,
                        myCell.GridLinesOn,
                        myCell.title,
                        myCell.colourValue);

                    await Navigation.PushPopupAsync(editGraph);

                    handler12 = (o, e) =>
                    {
                        //Applying back the new changes
                        myCell.ApplyChanges(
                            editGraph.XAxisValue,
                            editGraph.YXaxisValue,
                            editGraph.GridLinesValues,
                            editGraph.ColourPicked,
                            editGraph.TitleTyped);

                        //Removing extra options
                        editGraph.RemoveOptions();

                        editGraph.saveButton.Clicked -= handler12;
                        Navigation.PopPopupAsync(true);
                    };

                    editGraph.saveButton.Clicked += handler12;

                    //Creating new edit popup screen, adding clickhandler
                    // editGraph = new EditGraph(xAxisOn, yAxisOn, GridLinesOn, title, colourValue);
                    //  editGraph.CloseWhenBackgroundIsClicked = false;
                    //  editGraph.saveButton.Clicked += SaveButtonOnClicked;
                    //  await Navigation.PushPopupAsync(editGraph);
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
            selectGraph.ScatterplotChart().Clicked += handler6;
            selectGraph.SplineChart().Clicked += handler7;
            selectGraph.SplineAreaChart().Clicked += handler8;
            selectGraph.StepLineChart().Clicked += handler9;
            selectGraph.PieChart().Clicked += handler10;
            selectGraph.DoughnutChart().Clicked += handler11;
        }

        public void RemoveEventHandlers()
        {
            selectGraph.AreaChart().Clicked -= handler0;
            selectGraph.BarChart().Clicked -= handler1;
            selectGraph.ColumnChart().Clicked -= handler2;
            selectGraph.LineChart().Clicked -= handler3;
            selectGraph.StepAreaChart().Clicked -= handler4;
            selectGraph.PyramidChart().Clicked -= handler5;
            selectGraph.ScatterplotChart().Clicked -= handler6;
            selectGraph.SplineChart().Clicked -= handler7;
            selectGraph.SplineAreaChart().Clicked -= handler8;
            selectGraph.StepLineChart().Clicked -= handler9;
            selectGraph.PieChart().Clicked -= handler10;
            selectGraph.DoughnutChart().Clicked -= handler11;
        }
        
        private void AddOnClicked(object sender, EventArgs eventArgs)
        {
            AddOnClickMethod();
        }

        public void AddOnClickMethod()
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
                        //If there is no graph
                        if (!myCells[xAxis][yAxis].hasGraph)
                        {
                            myCells[xAxis][yAxis].EnableButton();
                            myCells[xAxis][yAxis].IsVisible = true;
                            myCells[xAxis][yAxis].InputTransparent = false;
                        }
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
                        if (!myCells[xAxis][yAxis].hasGraph)
                        {
                            myCells[xAxis][yAxis].DisableButton();
                        }
                    }
                }
            }
            changed = true;
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
                        //If there is no graph
                        if (!myCells[xAxis][yAxis].hasGraph)
                        {
                            myCells[xAxis][yAxis].IsVisible = false;
                            myCells[xAxis][yAxis].InputTransparent = true;
                        }
                    }
                }
                changed = true;
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
            changed = true;
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
            changed = true;
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
                    myCells[xAxis][yAxis].GenerateMovementButtons();
                    myCells[xAxis][yAxis].DisableButton();
                    if (!myCells[xAxis][yAxis].hasGraph)
                    {
                        myCells[xAxis][yAxis].InputTransparent = true;
                    }
                }
            }
        }

        #region Cell movement animations

        private void NorthOnClicked(object sender, EventArgs e)
        {
            Button s = sender as Button;
            Cell d = (Cell) s.Parent;

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
            }
            else if (buttonState == DashboardButtonState.Resize)
            {
                if (Grid.GetRowSpan(myCells[x][y]) != 1)
                {
                    //Setting data
                    myCells[x][y].RowSpan = Grid.GetRowSpan(myCells[x][y]) - 1;
                    Grid.SetRowSpan(myCells[x][y], Grid.GetRowSpan(myCells[x][y]) - 1);
                }
            }
        }

        private void SouthOnClicked(object sender, EventArgs e)
        {
            Button s = sender as Button;
            Cell d = (Cell) s.Parent;

            int x = d.XLocation;
            int y = d.YLocation;

            int x2 = d.XLocation;
            int y2 = d.YLocation + 1;

            if (buttonState == DashboardButtonState.Move)
            {
                //If the cell has not reached the edge, If the span + relative location !> max size
                if ((y < 4) && (Grid.GetRowSpan(myCells[x][y]) + y < 5))
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
            }
            else if (buttonState == DashboardButtonState.Resize)
            {
                //Checking max row span
                if ((Grid.GetRowSpan(myCells[x][y]) + 1 <= myCells[x][y].MaxSpanRow)
                    && Grid.GetRowSpan(myCells[x][y]) + y < 5)
                {
                    //Setting data, next line is setting span
                    myCells[x][y].RowSpan = Grid.GetRowSpan(myCells[x][y]) + 1;
                    Grid.SetRowSpan(myCells[x][y], Grid.GetRowSpan(myCells[x][y]) + 1);
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
            }
            else if (buttonState == DashboardButtonState.Resize)
            {
                if (Grid.GetColumnSpan(myCells[x][y]) != 1)
                {
                    //Setting data, next line is setting span
                    myCells[x][y].ColumnSpan = Grid.GetColumnSpan(myCells[x][y]) - 1;
                    Grid.SetColumnSpan(myCells[x][y], Grid.GetColumnSpan(myCells[x][y]) - 1);
                }
            }
        }


        private void EastOnClicked(object sender, EventArgs eventArgs)
        {
            Button s = sender as Button;
            Cell d = (Cell) s.Parent;

            int x = d.XLocation;
            int y = d.YLocation;

            int x2 = d.XLocation + 1;
            int y2 = d.YLocation;

            //If the button state is set to move
            if (buttonState == DashboardButtonState.Move)
            {
                //If the x position is not past 7, and the span does not hit the edge of the screen
                if ((x < 7) && (Grid.GetColumnSpan(myCells[x][y]) + x < 8))
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

                    System.Diagnostics.Debug.WriteLine("Translation X" + myCells[x][y].TranslationX);
                    System.Diagnostics.Debug.WriteLine("Distance X" + displacement2);
                }
            }
            else if (buttonState == DashboardButtonState.Resize)
            {
                //Checking max collumn span
                if ((Grid.GetColumnSpan(myCells[x][y]) + 1 <= myCells[x][y].MaxSpanColumn)
                    && Grid.GetColumnSpan(myCells[x][y]) + x < 8)
                {
                    //Setting data, then setting the span
                    myCells[x][y].ColumnSpan = Grid.GetColumnSpan(myCells[x][y]) + 1;
                    Grid.SetColumnSpan(myCells[x][y], Grid.GetColumnSpan(myCells[x][y]) + 1);
                }
            }
        }

        #endregion

        //Swapping values on the Dashboard by swaping references in the 2D array
        static void swap(ref Cell a, ref Cell b)
        {
            Cell temp = a;
            a = b;
            b = temp;
        }
    }
}
