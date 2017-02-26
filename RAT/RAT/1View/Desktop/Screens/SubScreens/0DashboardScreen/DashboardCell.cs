using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using RAT.zTest;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen
{
    class DashboardCell: Grid
    {
        public Button myButton = new Button();
        private SfChart myChart;
        ObservableCollection<ChartDataPoint> data = new ObservableCollection<ChartDataPoint>();

        public Button north = new Button();
        public Button west = new Button();
        public Button east = new Button();
        public Button south = new Button();

        public Button northwest;
        public Button northeast;
        public Button southeast;
        public Button southwest;

        public DashboardCell()
        {
            this.BackgroundColor = Color.White;
            //TODO ONLY USE AS TESTING
            int z = 0;
            bool a = true;
            double value = 50;
            Random rand = new Random();

            for (var i = 0; i < 25; i++)
            {
                z++;
                if (a)
                {
                    data.Add(new ChartDataPoint(z, rand.Next(100)));
                    a = false;
                }
                else
                {
                    data.Add(new ChartDataPoint(z, rand.Next(100)));
                    a = true;
                }
            }

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
        public int PosInLayout { get; set; }

        public void other()
        {
            northwest.Text = "";
            northwest.FontSize = 25;
            northwest.VerticalOptions = LayoutOptions.Start;
            northwest.HorizontalOptions = LayoutOptions.Start;
            northwest.BorderColor = Color.Transparent;
            northwest.BackgroundColor = Color.Black;
            northwest.BorderWidth = .000001;
            northwest.WidthRequest = 10f;
            northwest.HeightRequest = 10f;

            northeast.Text = "";
            northeast.FontSize = 25;
            northeast.VerticalOptions = LayoutOptions.Start;
            northeast.HorizontalOptions = LayoutOptions.End;
            northeast.BorderColor = Color.Transparent;
            northeast.BackgroundColor = Color.Black;
            northeast.BorderWidth = .000001;
            northeast.WidthRequest = 10f;
            northeast.HeightRequest = 10f;

            southwest.Text = "";
            southwest.FontSize = 25;
            southwest.VerticalOptions = LayoutOptions.End;
            southwest.HorizontalOptions = LayoutOptions.Start;
            southwest.BorderColor = Color.Transparent;
            southwest.BackgroundColor = Color.Black;
            southwest.BorderWidth = .000001;
            southwest.WidthRequest = 10f;
            southwest.HeightRequest = 10f;

            southeast.Text = "";
            southeast.FontSize = 25;
            southeast.VerticalOptions = LayoutOptions.End;
            southeast.HorizontalOptions = LayoutOptions.End;
            southeast.BorderColor = Color.Transparent;
            southeast.BackgroundColor = Color.Black;
            southeast.BorderWidth = .000001;
            southeast.WidthRequest = 10f;
            southeast.HeightRequest = 10f;
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

        private float buttonSize = 15f;
        private int radius = 25;
        private bool AlreadyGenerated = false;
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
                AlreadyGenerated = true;
            }
            else
            {
                south.IsVisible = true;
                west.IsVisible = true;
                east.IsVisible = true;
                north.IsVisible = true;
            }
            //Children.Add(northwest);
            //Children.Add(northeast);
            //Children.Add(southeast);
            //Children.Add(southwest);
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

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.SecondaryAxis.IsVisible = false;
            myChart.InputTransparent = true;

            Children.Add(myChart);
        }

        public void BarChart()
        {
               //Chart
               myChart = new SfChart();

            myChart.Series.Add(new BarSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void ColumnChart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new ColumnSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void Column100Chart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new StackingColumn100Series());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void LineChart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new LineSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void DoughnutChart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new DoughnutSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void FastLineChart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new FastLineSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void PieChart()
        {
            //Chart
            myChart = new SfChart();
            myChart.Series.Add(new PieSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void PyramidChart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new PyramidSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void ScatterChart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new ScatterSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void SplineAreaChart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new SplineAreaSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void SplineSeriesChart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new SplineSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void StackingArea100Chart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new StackingArea100Series());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void StackingArea100()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new StackingArea100Series());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void StackingArea()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new StackingAreaSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void StepLineSeries()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new StepLineSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void StepArea()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new StepLineSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void StackingColumnSeries()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new StackingColumnSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void StackingColumn100Chart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new StackingColumn100Series());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void StackingBar100Chart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new StackingBar100Series());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void StackingBarChart()
        {
            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new StackingBarSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].EnableTooltip = true;
            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            (myChart.PrimaryAxis as NumericalAxis).AutoScrollingDelta = 120;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        // Button Click
        private async void OnOpenPupup(object sender, EventArgs e)
        {
            SelectItemPopup pickChart = new SelectItemPopup();
            await Navigation.PushPopupAsync(pickChart);
            pickChart.LineChart().Clicked += (o, args) => { LineChart(); };
            pickChart.AreaChart().Clicked += (o, args) => { AreaChart(); };
            pickChart.BarChart().Clicked += (o, args) => { BarChart(); };
            pickChart.ColumnChart().Clicked += (o, args) => { ColumnChart(); };
            pickChart.DoughnutChart().Clicked += (o, args) => { DoughnutChart(); };
            pickChart.FastlineChart().Clicked += (o, args) => { FastLineChart(); };
            pickChart.PieChart().Clicked += (o, args) => { PieChart(); };
            pickChart.PyramidChart().Clicked += (o, args) => { PyramidChart(); };
            pickChart.ScatterplotChart().Clicked += (o, args) => { ScatterChart(); };
            pickChart.SplineChart().Clicked += (o, args) => { SplineSeriesChart(); };
            pickChart.SplineAreaChart().Clicked += (o, args) => { SplineAreaChart(); };
            pickChart.StackingBarChart().Clicked += (o, args) => { StackingArea(); };
            pickChart.StrackingArea100Chart().Clicked += (o, args) => { StackingArea100(); };
            pickChart.StepLineChart().Clicked += (o, args) => { StepLineSeries(); };
            pickChart.StepAreaChart().Clicked += (o, args) => { StepArea(); };
            pickChart.StackingColumnChart().Clicked += (o, args) => { StackingColumnSeries(); };
            pickChart.StackingColumn10Chart().Clicked += (o, args) => { StackingColumn100Chart(); };
            pickChart.StackingBarChart().Clicked += (o, args) => { StackingBarChart(); };
            pickChart.StackingBar100Chart().Clicked += (o, args) => { StackingBar100Chart(); };
        }

        public Button GetButton()
        {
            return myButton;
        }



    }
}
