using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen
{
    class DashboardCell: Grid
    {
        private Button myButton;
        private SfChart myChart;
        ObservableCollection<ChartDataPoint> data = new ObservableCollection<ChartDataPoint>();

        public DashboardCell()
        {
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
            Button myButton = new Button();
            myButton.Text = "+";
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
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void CloumnChart()
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
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        // Button Click
        private async void OnOpenPupup(object sender, EventArgs e)
        {
            SelectItemPopup pickChart = new SelectItemPopup();
            await Navigation.PushPopupAsync(pickChart);
            pickChart.AreaChart().Clicked += linechart;
        }

        public Button GetButton()
        {
            return myButton;
        }

        private void linechart(object sender, EventArgs e)
        {
            //LineChart();
            //StepLineArea();
        }
    }
}
