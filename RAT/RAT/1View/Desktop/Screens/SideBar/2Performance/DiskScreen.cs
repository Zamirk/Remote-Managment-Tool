using System;
using System.Collections.ObjectModel;
using SampleBrowser;
using ServerMonitor;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class DiskScreen : Grid
    {
        public DiskScreen()
        {
            //Chart 1
            //VerticalOptions = LayoutOptions.FillAndExpand;
            //RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});
            //ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto});
            //ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            //ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            //ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            int size = 150;

            ContentView myV1 = new ContentView()
            {
            BackgroundColor = Color.Red,
            VerticalOptions = LayoutOptions.StartAndExpand,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            WidthRequest = size,
            HeightRequest = size
            };

            ContentView myV2 = new ContentView()
            {
                BackgroundColor = Color.Green,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = size,
                HeightRequest = size
            };

            ContentView myV3 = new ContentView()
            {
                BackgroundColor = Color.Black,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = size,
                HeightRequest = size
            };

            ContentView myV4 = new ContentView()
            {
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = size,
                HeightRequest = size
            };

            ContentView myV5 = new ContentView()
            {
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = size,
                HeightRequest = size
            };

            ContentView myV6 = new ContentView()
            {
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = size,
                HeightRequest = size
            };

            ContentView myV7 = new ContentView()
            {
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = size,
                HeightRequest = size
            };


            ContentView myV8 = new ContentView()
            {
                BackgroundColor = Color.Blue,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = size,
                HeightRequest = size
            };

            Children.Add(myV1, 0, 0);
            Children.Add(myV2, 1, 0);
            Children.Add(myV3, 2, 0);
            Children.Add(myV4, 3, 0);

            Children.Add(myV5, 0, 1);
            Children.Add(myV6, 1, 1);
            Children.Add(myV7, 2, 1);
            Children.Add(myV8, 3, 1);

            myV1.BackgroundColor = Color.Transparent;
            myV2.BackgroundColor = Color.Transparent;
            myV3.BackgroundColor = Color.Transparent;
            myV4.BackgroundColor = Color.Transparent;
            myV5.BackgroundColor = Color.Transparent;
            myV6.BackgroundColor = Color.Transparent;
            myV7.BackgroundColor = Color.Transparent;
            myV8.BackgroundColor = Color.Transparent;

            myV1.Content = GetChart();
            myV2.Content = GetChart();
            myV3.Content = GetChart();
            myV4.Content = GetChart();
            myV5.Content = GetChart();
            myV6.Content = GetChart();
            myV7.Content = GetChart();
            myV8.Content = GetChart();

            //Charts
            /*
            SfChart chart = new SfChart();
            chart.VerticalOptions = LayoutOptions.CenterAndExpand;
            chart.HorizontalOptions = LayoutOptions.CenterAndExpand;
            PieSeries pieSeries = new PieSeries();

            pieSeries.ItemsSource = PieSeriesData;
            chart.Series.Add(pieSeries);
            Children.Add(chart);

            SfChart chart2 = new SfChart();
            chart2.VerticalOptions = LayoutOptions.CenterAndExpand;
            chart2.HorizontalOptions = LayoutOptions.CenterAndExpand;
            PieSeries pieSeries2 = new PieSeries();

            pieSeries2.ItemsSource = PieSeriesData;
            chart2.Series.Add(pieSeries2);
            Children.Add(new ContentView()
            {
                BackgroundColor = Color.Red,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            }, 1, 1);
           // Children.Add(chart2,1,1);

    */
        }
        Random rand = new Random();
        public SfChart GetChart()
        {
            SfChart chart = new SfChart();
            chart.VerticalOptions = LayoutOptions.CenterAndExpand;
            chart.HorizontalOptions = LayoutOptions.CenterAndExpand;
            PieSeries pieSeries = new PieSeries();

            pieSeries.ItemsSource = PieSeriesData;
            chart.Series.Add(pieSeries);
            return chart;
        }

        public ObservableCollection<ChartDataPoint> PieSeriesData
        {
            get
            {
                //Data temp
                ObservableCollection<ChartDataPoint> pieDatas = new ObservableCollection<ChartDataPoint>();
                pieDatas.Add(new ChartDataPoint("54% Used", rand.Next(1, 100)));
                pieDatas.Add(new ChartDataPoint("46% Free", rand.Next(1, 100)));

                return pieDatas;
            }
        }
    }
}
