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
            VerticalOptions = LayoutOptions.FillAndExpand;
            RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
            ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});

            ContentView myV = new ContentView()
            {
            BackgroundColor = Color.Red,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            WidthRequest = 200,
            HeightRequest = 200
        };

            ContentView myV2 = new ContentView()
            {
                BackgroundColor = Color.Green,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 200,
                HeightRequest = 200
            };

            Children.Add(myV2,0,1);

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

        public ObservableCollection<ChartDataPoint> PieSeriesData
        {
            get
            {
                //Data temp
                ObservableCollection<ChartDataPoint> pieDatas = new ObservableCollection<ChartDataPoint>();
                pieDatas.Add(new ChartDataPoint("54% Used", 54));
                pieDatas.Add(new ChartDataPoint("46% Free", 46));

                return pieDatas;
            }
        }
    }
}
