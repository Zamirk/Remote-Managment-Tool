using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Folder;
using RAT._1View.Desktop.Manage;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen
{
    public partial class GraphSelection : PopupPage
    {
        private Button area, bar, column, line, bubble, candle, doughnut, fastline, funnel, hiLo,
            pieseries, polar, pyramid, radar, rangeArea, rangeColumn, scatterPlot, splineArea, spline,
            stackingArea100, stackingArea, stackingBar, stackingColumn100, stackingColumn, stepArea, stepLine;

        private Grid mainGrid;
        //private List<Cell> myCellList = new List<Cell>();
        private ImageCell[][] myCells = new ImageCell[4][];

        private string[] names = new string[]
        {
            "Area", "Bar", "Column", "Line", "Fastline", "Doughnut", "Pie", "Pyramid,"
            ,"Scatter plot","Spline","Spline area", "Step Line","Step Area"
        };
        private string[] dataSources = new string[]
{
            "Cpu", "Cpu Frequency", "Thread Count", "Cpu Temperature", "No. Processes", "CPU Util Percent", "Ram left", "Ram In Use"
            ,"Ram Cache","Ram Committed","Paged Pool", "Non Paged Pool","Disk Read Time", "Disk Write Time", "Disk Read Bytes", "Disk Write Bytes",
            "Free MB","Idle Time", "Disk Time", "Download Rate", "Upload Rate", "Band width", "Packets Received", "Packets Sent", "Packets"
};
        //List of buttons
        private List<Button> myButtons = new List<Button>();
        public Picker selectDataSource;
        public Picker selectDevice;

        public GraphSelection()
        {
            myCells[0] = new ImageCell[4];
            myCells[1] = new ImageCell[4];
            myCells[2] = new ImageCell[4];
            myCells[3] = new ImageCell[4];

            mainGrid = new Grid();
            mainGrid.ColumnSpacing = 3;
            mainGrid.RowSpacing = 3;
            mainGrid.BackgroundColor = Color.White;
            mainGrid.HorizontalOptions = LayoutOptions.Center;
            mainGrid.VerticalOptions = LayoutOptions.Center;

            mainGrid.Padding = new Thickness(5, 5, 5, 5);
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = 30 });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            int z = 0;

            #region My pickers

            selectDevice = new Picker();
            selectDevice.VerticalOptions = LayoutOptions.CenterAndExpand;

            for (int i = 0; i < GetTelemetry.devices.Count; i++)
            {
                selectDevice.Items.Add(GetTelemetry.devices[i]);
            }
            selectDevice.SelectedIndex = 0;
            selectDevice.WidthRequest = 200;
            selectDevice.HeightRequest = 30;
            selectDevice.HorizontalOptions = LayoutOptions.End;

            selectDataSource = new Picker();
            selectDataSource.VerticalOptions = LayoutOptions.CenterAndExpand;

            for (int i = 0; i < dataSources.Length; i++)
            {
                selectDataSource.Items.Add(dataSources[i]);
            }
            selectDataSource.SelectedIndex = 0;
            selectDataSource.WidthRequest = 200;
            selectDataSource.HeightRequest = 30;
            selectDataSource.HorizontalOptions = LayoutOptions.End;

            mainGrid.Children.Add(selectDevice, 0, 0);
            mainGrid.Children.Add(selectDataSource, 3, 0);
            #endregion

            //Addings cells, X and Y grid
            for (int yAxis = 1; yAxis < 4; yAxis++)
            {
                for (int xAxis = 0; xAxis < 4; xAxis++)
                {
                    //Generate button
                    myButtons.Add(GenerateButton());
                    //Generate image cell
                    ImageCell myCell = new ImageCell();
                    myCell.Children.Add(myButtons[z]);
                    myCells[xAxis][yAxis] = myCell;
                    //Setting image
                    myCell.SetImage(z);
                    mainGrid.Children.Add(myCell, xAxis, yAxis);
                    z++;
                }
            }
            //TODO CURRENTLY DOING
            mainGrid.WidthRequest = 700;
            mainGrid.HeightRequest = 500;
            mainGrid.MinimumWidthRequest = 500;
            Content = mainGrid;
        }

        private Button GenerateButton()
        {
        //Generates and returns a button
        Button myButton = new Button();
        myButton.Text = "";
            myButton.FontSize = 25;
            myButton.VerticalOptions = LayoutOptions.Center;
            myButton.HorizontalOptions = LayoutOptions.Center;
            myButton.BorderColor = Color.Transparent;
            myButton.BackgroundColor = Color.Transparent;
            myButton.BorderWidth = .000001;
            myButton.WidthRequest = 500;
            myButton.HeightRequest = 500;
            return myButton;
        }

        public Button AreaChart()
        {
            return myButtons[0];
        }

        public Button BarChart()
        {
            return myButtons[1];
        }

        public Button ColumnChart()
        {
            return myButtons[2];
        }

        public Button LineChart()
        {
            return myButtons[3];
        }

        public Button StepAreaChart()
        {
            return myButtons[4];
        }

           public Button PyramidChart()
        {
            return myButtons[5];
        }

        public Button ScatterplotChart()
        {
            return myButtons[6];
        }

        public Button SplineChart()
        {
            return myButtons[7];
        }

        public Button SplineAreaChart()
        {
            return myButtons[8];
        }

        public Button StepLineChart()
        {
            return myButtons[9];
        }

        public Button PieChart()
        {
            return myButtons[10];
        }

        public Button DoughnutChart()
        {
            return myButtons[11];
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // Method for animation child in PopupPage
        // Invoced after custom animation end
        protected virtual Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        protected virtual Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1); ;
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            //return base.OnBackButtonPressed();
            return true;
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return default value - CloseWhenBackgroundIsClicked
            return base.OnBackgroundClicked();
        }
    }
}
