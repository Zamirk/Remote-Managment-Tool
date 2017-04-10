using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using IoTHubAmqpService;
using RAT.zTest;
using RAT.ZTry;
using RAT._2ViewModel;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen
{
    class Cell: Grid, IComparable<Cell>
    {
        private DashboardViewModel viewModel;
        private SfChart myChart;
        public bool hasGraph = false;
        public DashboardButtonState buttonState;
        public int Pos { get; set; }
        public int OriginalX { get; set; }
        public int OriginalY { get; set; }
        #region Model data
        //Maxium span value
        public int MaxSpanColumn { get; set; }
        public int MaxSpanRow { get; set; }

        //Style values
        public bool GridLinesOn { get; set; }
        public bool xAxisOn { get; set; }
        public bool yAxisOn { get; set; }
        public string title { get; set; }
        public int colourValue { get; set; }

        //Information for saving
        public int GraphType { get; set; }

        public int ColumnSpan { get; set; }
        public int RowSpan { get; set; }

        public int Device { get; set; }
        public int Datasource { get; set; }
        public bool SingleData { get; set; }

        public int XLocation { get; set; }
        public int YLocation { get; set; }

        #endregion

        #region Declaring buttons
        private float buttonSize = 15f;
        private int radius = 25;
        private bool AlreadyGenerated = false;

        public Button myButton = new Button();

        public Button north = new Button();
        public Button west = new Button();
        public Button east = new Button();
        public Button south = new Button();
        #endregion
        Random rand = new Random();

        //Compare method
        public int CompareTo(Cell o)
        {

            return this.Pos.CompareTo(o.Pos);
        }

        public Cell()
        {
            Pos = rand.Next(100);
            buttonState = DashboardButtonState.Add;

            //Initial values
            xAxisOn = false;
            yAxisOn = false;
            GridLinesOn = true;
            title = "";
            colourValue = 0;

            RowSpan = 1;
            ColumnSpan = 1;
            Device = 0;
            Datasource = 0;
            GraphType = 0;

            myButton = new Button();
            myButton.Text = "";
            myButton.FontSize = 25;
            myButton.VerticalOptions = LayoutOptions.Center;
            myButton.HorizontalOptions = LayoutOptions.Center;
            myButton.BorderColor = Color.Transparent;
            myButton.BorderWidth = .000001;
            myButton.WidthRequest = 2000;
            myButton.HeightRequest = 2000;
            Children.Add(myButton);
        }

        public void DisableButton()
        {
            myButton.IsVisible = false;
            myButton.InputTransparent = true;
        }
        public void EnableButton()
        {
            myButton.IsVisible = true;
            myButton.InputTransparent = false;
        }

        public void RemoveMovementButtons()
        {
            north.IsVisible = false;
            south.IsVisible = false;
            east.IsVisible = false;
            west.IsVisible = false;
        }

        public void GenerateMovementButtons()
        {
            if (!AlreadyGenerated)
            {
                north.Text = "";
                north.FontSize = 25;
                north.VerticalOptions = LayoutOptions.Start;
                north.HorizontalOptions = LayoutOptions.Center;
                north.BorderColor = Color.Transparent;
                north.BackgroundColor = Color.Black;
                north.BorderWidth = .000001;
                north.WidthRequest = buttonSize;
                north.HeightRequest = buttonSize;
                north.BorderRadius = radius;

                east.Text = "";
                east.FontSize = 25;
                east.VerticalOptions = LayoutOptions.Center;
                east.HorizontalOptions = LayoutOptions.End;
                east.BorderColor = Color.Transparent;
                east.BackgroundColor = Color.Black;
                east.BorderWidth = .000001;
                east.WidthRequest = buttonSize;
                east.HeightRequest = buttonSize;
                east.BorderRadius = radius;

                west.Text = "";
                west.FontSize = 25;
                west.VerticalOptions = LayoutOptions.Center;
                west.HorizontalOptions = LayoutOptions.Start;
                west.BorderColor = Color.Transparent;
                west.BackgroundColor = Color.Black;
                west.BorderWidth = .000001;
                west.WidthRequest = buttonSize;
                west.HeightRequest = buttonSize;
                west.BorderRadius = radius;

                south.Text = "";
                south.FontSize = 25;
                south.VerticalOptions = LayoutOptions.End;
                south.HorizontalOptions = LayoutOptions.Center;
                south.BorderColor = Color.Transparent;
                south.BackgroundColor = Color.Black;
                south.BorderWidth = .000001;
                south.WidthRequest = buttonSize;
                south.HeightRequest = buttonSize;
                south.BorderRadius = radius;

                Children.Add(south);
                Children.Add(west);
                Children.Add(east);
                Children.Add(north);

                //Pushing buttons above graph
                RaiseChild(south);
                RaiseChild(west);
                RaiseChild(east);
                RaiseChild(north);
                LowerChild(myChart);
                AlreadyGenerated = true;

                //If there is a graph, show buttons
                if (hasGraph)
                {
                    south.IsVisible = true;
                    west.IsVisible = true;
                    east.IsVisible = true;
                    north.IsVisible = true;
                }
            }
            else
            {
                if (hasGraph)
                {
                    south.IsVisible = true;
                    west.IsVisible = true;
                    east.IsVisible = true;
                    north.IsVisible = true;
                }
            }
        }

        public void SetLocation(int x, int y)
        {
            XLocation = x;
            YLocation = y;
        }

        #region Generate graphs
      
        public void AreaChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new AreaSeries());

            GraphType = 0;
            Common(a, b, false);
        }

        public void BarChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new BarSeries());
            GraphType = 1;
            Common(a, b, false);
        }

        public void ColumnChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new ColumnSeries());
            Common(a, b, false);
            GraphType = 2;
            Children.Add(myChart);
        }

        public void LineChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new LineSeries());
            Common(a, b, false);
            GraphType = 3;
            Children.Add(myChart);
        }

        public void StepArea(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new StepLineSeries());
            Common(a, b, false);
            GraphType = 4;
            Children.Add(myChart);
        }

        public void PyramidChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new PyramidSeries());
            Common(a, b, false);
            GraphType = 5;
            Children.Add(myChart);
        }

        public void ScatterChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new ScatterSeries());
            Common(a, b, false);
            GraphType = 6;
            Children.Add(myChart);
        }

        public void SplineSeriesChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new SplineSeries());
            Common(a, b, false);
            GraphType = 7;
            Children.Add(myChart);
        }

        public void SplineAreaChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new SplineAreaSeries());
            Common(a, b, false);
            GraphType = 8;
            Children.Add(myChart);
        }


        public void StepLineSeries(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new StepLineSeries());
            Common(a, b, false);
            GraphType = 9;
            Children.Add(myChart);
        }

        public void PieChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new PieSeries());
            Common(a, b, true);
            GraphType = 10;
            Children.Add(myChart);
        }

        public void DoughnutChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new DoughnutSeries());
            Common(a, b, true);
            GraphType = 11;
            Children.Add(myChart);
        }

        public void Common(int a, int b, bool singleData)
        {
            Device = a;
            Datasource = b;
            SingleData = singleData;

            hasGraph = true;

            RowSpan = 1;
            ColumnSpan = 1;

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            if (b == 0)
            {
                (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
                (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            }
            else if (b == 1)
            {
                //(myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
                (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            }

            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;
            myChart.Series[0].AnimationDuration = .7;
            myChart.Series[0].EnableAnimation = true;

            myChart.PrimaryAxis.IsVisible = false;
            myChart.SecondaryAxis.IsVisible = false;
            myChart.InputTransparent = true;

            BindingContext = viewModel;
            viewModel = new DashboardViewModel();
            myChart.Series[0].ItemsSource = viewModel.Data;

            //If you only want single values for pie/donut charts
            if (singleData)
            {
                viewModel.LoadSingleValues(a, b);
            }
            else
            {
                viewModel.LoadMultipleValues(a, b);
            }
            Children.Add(myChart);
        }
        #endregion

        public void ApplyChanges(bool a, bool b, bool c, int d, string e)
        {
            //When clicking the save button on editscreen

            //Getting values
            xAxisOn = a;
            yAxisOn = b;
            GridLinesOn = c;
            colourValue = d;
            title = e;

            //Setting title
            myChart.PrimaryAxis.Title = new ChartAxisTitle() { Text = title };

            //Setting grid lines
            myChart.PrimaryAxis.ShowMajorGridLines = GridLinesOn;
            myChart.SecondaryAxis.ShowMinorGridLines = GridLinesOn;

            //Setting axis lines
            myChart.PrimaryAxis.IsVisible = xAxisOn;
            myChart.SecondaryAxis.IsVisible = yAxisOn;

            //Setting colour
            if (colourValue == 0)
            {
                myChart.ColorModel.Palette = ChartColorPalette.Metro;
            } else if (colourValue == 1)
            {
                myChart.ColorModel.Palette = ChartColorPalette.Pineapple;
            }
            else if (colourValue == 2)
            {
                myChart.ColorModel.Palette = ChartColorPalette.TomatoSpectrum;
            }
        }

        public void CleanCell()
        {
            hasGraph = false;

            //Resetting cell when graph is deleted
            if (myChart != null)
            {
                viewModel.GC();
                BindingContext = null;
                viewModel = null;
                myChart.Series[0].ItemsSource = null;
                Children.Remove(myChart);
                myChart = null;
                SetColumnSpan(this, 1);
                SetRowSpan(this, 1);
                hasGraph = false;
            }
            //Remove data source
        }
    }
}
