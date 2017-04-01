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
        //todo remove
        ObservableCollection<ChartDataPoint> data = new ObservableCollection<ChartDataPoint>();
        private GraphSelection _chart;

        //Maxium span value
        public int MaxSpanColumn { get; set; }
        public int MaxSpanRow { get; set; }

        //Style values
        public bool GridLinesOn { get; set; }
        public bool xAxisOn { get; set; }
        public bool yAxisOn { get; set; }
        public string title { get; set; }
        public int colourValue { get; set; }

        private EditGraph editChart;
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

        public Button northwest;
        public Button northeast;
        public Button southeast;
        public Button southwest;
        int z = 0;
        bool a = true;
        Random rand = new Random();

        public Cell()
        {
            buttonState = DashboardButtonState.Neutral;
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
            myButton.Clicked += OnOpenPupup;
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

        public void AreaChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new AreaSeries());
            Common(false);
        }

        public void BarChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new BarSeries());
            Common(false);
        }

        public void ColumnChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new ColumnSeries());
            Common(false);
            Children.Add(myChart);
        }


        public void LineChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new LineSeries());
            Common(false);
            Children.Add(myChart);
        }

        public void PyramidChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new PyramidSeries());
            Common(false);
            Children.Add(myChart);
        }

        public void ScatterChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new ScatterSeries());
            Common(false);
            Children.Add(myChart);
        }

        public void SplineAreaChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new SplineAreaSeries());
            Common(false);
            Children.Add(myChart);
        }


        public void SplineSeriesChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new SplineSeries());
            Common(false);
            Children.Add(myChart);
        }

        public void StepArea()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new StepLineSeries());
            Common(false);
            Children.Add(myChart);
        }

        public void StepLineSeries()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new StepLineSeries());
            Common(false);
            Children.Add(myChart);
        }

        public void DoughnutChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new DoughnutSeries());
            Common(true);
            Children.Add(myChart);
        }

        public void PieChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new PieSeries());
            Common(true);
            Children.Add(myChart);
        }

        public void Common(bool singleData)
        {
            hasGraph = true;
            Opacity = 1;

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            if (_chart.selectDataSource.SelectedIndex == 0)
            {
                (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
                (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            }
            else if (_chart.selectDataSource.SelectedIndex == 1)
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
                viewModel.LoadSingleValues(_chart.selectDevice.SelectedIndex, _chart.selectDataSource.SelectedIndex);
            }
            else
            {
                viewModel.LoadMultipleValues(_chart.selectDevice.SelectedIndex, _chart.selectDataSource.SelectedIndex);
            }
            Children.Add(myChart);
        }

        // Button Click
        private async void OnOpenPupup(object sender, EventArgs e)
        {
            if (buttonState == DashboardButtonState.Neutral)
            {
                _chart = new GraphSelection();
                await Navigation.PushPopupAsync(_chart);
                
                //Adding graph generating method to chart select buttons
                _chart.AreaChart().Clicked += (o, args) => { AreaChart(); GCGraphSelect(); };
                _chart.BarChart().Clicked += (o, args) => { BarChart(); GCGraphSelect(); };
                _chart.ColumnChart().Clicked += (o, args) => { ColumnChart(); GCGraphSelect(); };
                _chart.LineChart().Clicked += (o, args) => { LineChart(); GCGraphSelect(); };
                _chart.StepAreaChart().Clicked += (o, args) => { StepArea(); GCGraphSelect(); };
                _chart.PyramidChart().Clicked += (o, args) => { PyramidChart(); GCGraphSelect(); };
                _chart.ScatterplotChart().Clicked += (o, args) => { ScatterChart(); GCGraphSelect(); };
                _chart.SplineChart().Clicked += (o, args) => { SplineSeriesChart(); GCGraphSelect(); };
                _chart.SplineAreaChart().Clicked += (o, args) => { SplineAreaChart(); GCGraphSelect(); };
                _chart.StepLineChart().Clicked += (o, args) => { StepLineSeries(); GCGraphSelect(); };
                _chart.PieChart().Clicked += (o, args) => { PieChart(); GCGraphSelect(); };
                _chart.DoughnutChart().Clicked += (o, args) => { DoughnutChart(); GCGraphSelect(); };
            }
            else if (buttonState == DashboardButtonState.Editing)
            {
                if (hasGraph)
                {
                    //Creating new edit popup screen, adding clickhandler
                    editChart = new EditGraph(xAxisOn, yAxisOn, GridLinesOn, title, colourValue);
                    editChart.CloseWhenBackgroundIsClicked = false;
                    editChart.saveButton.Clicked += SaveButtonOnClicked;
                    await Navigation.PushPopupAsync(editChart);
                }
            } else if (buttonState == DashboardButtonState.Delete)
            {
                CleanCell();
            }
        }
        public void GCGraphSelect()
        {
            //Removing graph select screen
            Navigation.RemovePopupPageAsync(_chart ,false);
            _chart = null;
        }

//When clicking the save button
private void SaveButtonOnClicked(object sender, EventArgs eventArgs)
        {
            //Getting values
            GridLinesOn = editChart.GridLinesValues;
            xAxisOn = editChart.XAxisValue;
            yAxisOn = editChart.YXaxisValue;
            colourValue = editChart.ColourPicked;
            title = editChart.TitleTyped;

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
            //Removing click handler to allow garbage collection
            editChart.saveButton.Clicked -= SaveButtonOnClicked;

            //Removing popup screen after saving
            editChart.GC();
            Navigation.PopAllPopupAsync(true);
            editChart = null;
            GC.Collect();
        }

        //Resetting cell when graph is deleted
        public void CleanCell()
        {
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
