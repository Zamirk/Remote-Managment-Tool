using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.ServiceModel.Channels;
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
    class Cell: Grid
    {
        //Maxium span value
        public int MaxSpanColumn { get; set; }
        public int MaxSpanRow { get; set; }

        //Style values
        public bool GridLinesOn { get; set; }
        public bool xAxisOn { get; set; }
        public bool yAxisOn { get; set; }
        public string title { get; set; }
        public int colourValue { get; set; }

        private DashboardViewModel viewModel;
        public bool hasGraph = false;
        public Button myButton = new Button();
        private SfChart myChart;

        public DashboardButtonState buttonState;

        private float buttonSize = 15f;
        private int radius = 25;
        private bool AlreadyGenerated = false;

        public Button north = new Button();
        public Button west = new Button();
        public Button east = new Button();
        public Button south = new Button();

        int z = 0;
        bool a = true;

        public Cell()
        {
            buttonState = DashboardButtonState.Add;
            Opacity = 1.1;
            //TODO ONLY USE AS TESTING

            //Initial values
            xAxisOn = false;
            yAxisOn = false;
            GridLinesOn = true;
            title = "";
            colourValue = 0;

            Button();
        }

        private void Button()
        {
            myButton = new Button();
            myButton.Text = "";
            myButton.FontSize = 25;
            myButton.VerticalOptions = LayoutOptions.Center;
            myButton.HorizontalOptions = LayoutOptions.Center;
            myButton.BorderColor = Color.Transparent;
            myButton.BackgroundColor = Color.Transparent;
            myButton.BorderWidth = .000001;
            myButton.WidthRequest = 500;
            myButton.HeightRequest = 500;
            //myButton.Clicked += OnOpenPupup;
            Children.Add(myButton);
        }

        public int XLocation { get; set; }
        public int YLocation { get; set; }

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

        public void PositionalButtons()
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

                south.IsVisible = true;
                west.IsVisible = true;
                east.IsVisible = true;
                north.IsVisible = true;
            }
            else
            {
                south.IsVisible = true;
                west.IsVisible = true;
                east.IsVisible = true;
                north.IsVisible = true;
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
            Common(a, b, false);
        }

        public void BarChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new BarSeries());
            Common(a, b, false);
        }

        public void ColumnChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new ColumnSeries());
            Common(a, b, false);
            Children.Add(myChart);
        }

        public void LineChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new LineSeries());
            Common(a, b, false);
            Children.Add(myChart);
        }

        public void PyramidChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new PyramidSeries());
            Common(a, b, false);
            Children.Add(myChart);
        }

        public void ScatterChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new ScatterSeries());
            Common(a, b, false);
            Children.Add(myChart);
        }

        public void SplineAreaChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new SplineAreaSeries());
            Common(a, b, false);
            Children.Add(myChart);
        }

        public void SplineSeriesChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new SplineSeries());
            Common(a, b, false);
            Children.Add(myChart);
        }

        public void StepArea(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new StepLineSeries());
            Common(a, b, false);
            Children.Add(myChart);
        }

        public void StepLineSeries(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new StepLineSeries());
            Common(a, b, false);
            Children.Add(myChart);
        }

        public void DoughnutChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new DoughnutSeries());
            Common(a, b, true);
            Children.Add(myChart);
        }

        public void PieChart(int a, int b)
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new PieSeries());
            Common(a, b, true);
            Children.Add(myChart);
        }

        public void Common(int a, int b, bool singleData)
        {
            hasGraph = true;
            Opacity = 1;

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            if (a == 0)
            {
                (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
                (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            }
            else if (a == 1)
            {
                //(myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
                (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            }

            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;
            myChart.Series[0].AnimationDuration = .5;
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

        public void GCGraphSelect()
        {
            //Removing graph select screen
            //Navigation.RemovePopupPageAsync(_chart ,false);
            //_chart = null;
        }

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
            //Resetting cell when graph is deleted
            if (myChart != null)
            {
                Children.Remove(myChart);
                SetColumnSpan(this, 1);
                SetRowSpan(this, 1);
                hasGraph = false;
            }
            //Remove data source
        }
    }
}
