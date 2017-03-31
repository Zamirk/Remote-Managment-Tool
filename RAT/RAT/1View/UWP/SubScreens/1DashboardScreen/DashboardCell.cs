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
    class DashboardCell: Grid
    {
        //todo remove
        ObservableCollection<ChartDataPoint> data = new ObservableCollection<ChartDataPoint>();
        
        //Maxium span value
        public int MaxSpanColumn { get; set; }
        public int MaxSpanRow { get; set; }

        //Style values
        public bool GridLinesOn { get; set; }
        public bool xAxisOn { get; set; }
        public bool yAxisOn { get; set; }
        public string title { get; set; }
        public int colourValue { get; set; }

        private EditScreen editChart;
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

        public DashboardCell()
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

        double value = 50;

            data = new ObservableCollection<ChartDataPoint>();

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
            viewModel= new DashboardViewModel();
            BindingContext = viewModel;

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


            data = new ObservableCollection<ChartDataPoint>();
            viewModel.Load1();
            myChart.Series[0].ItemsSource = viewModel.Data;

            myChart.PrimaryAxis.IsVisible = false;
            myChart.SecondaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            Common();
            Children.Add(myChart);
        }

        public void Common()
        {
            hasGraph = true;
            Opacity = 1;

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
            Common();


            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 55; i++)
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
            data = new ObservableCollection<ChartDataPoint>();

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
            Common();


            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 55; i++)
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
            Common();

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
            Common();


            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 55; i++)
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
            Common();


            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 2; i++)
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
            Common();


            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 55; i++)
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
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        public void PieChart()
        {
            viewModel = new DashboardViewModel();

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
            Common();


            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 2; i++)
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
            Common();


            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 6; i++)
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
            Common();

            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 6; i++)
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
            Common();

            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 6; i++)
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
            Common();

            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 6; i++)
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
            Common();

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
            Common();

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
            Common();

            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 40; i++)
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
            Common();

            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 55; i++)
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
            Common();

            data = new ObservableCollection<ChartDataPoint>();
            myChart.Series[0].ItemsSource = data;
            for (var i = 0; i < 40; i++)
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
            Common();

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
            Common();

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
            Common();

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
            Common();

            myChart.Series[0].ItemsSource = data;
            myChart.PrimaryAxis.IsVisible = false;
            myChart.InputTransparent = true;
            myChart.SecondaryAxis.IsVisible = false;
            Children.Add(myChart);
        }

        // Button Click
        private async void OnOpenPupup(object sender, EventArgs e)
        {
            if (buttonState == DashboardButtonState.Neutral)
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

            } else if (buttonState == DashboardButtonState.Editing)
            {
                if (hasGraph)
                {
                    //Creating new edit popup screen, adding clickhandler
                    editChart = new EditScreen(xAxisOn, yAxisOn, GridLinesOn, title, colourValue);
                    editChart.CloseWhenBackgroundIsClicked = false;
                    editChart.saveButton.Clicked += SaveButtonOnClicked;
                    await Navigation.PushPopupAsync(editChart);
                }
            } else if (buttonState == DashboardButtonState.Delete)
            {
                CleanCell();
            }
        }


//When clickin the save button
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
