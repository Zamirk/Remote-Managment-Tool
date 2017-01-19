using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using SampleBrowser;
using ServerMonitor;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;
using ChartDataPoint = Syncfusion.SfChart.XForms.ChartDataPoint;
using FastLineSeries = Syncfusion.SfChart.XForms.FastLineSeries;
using NumericalAxis = Syncfusion.SfChart.XForms.NumericalAxis;
using SfChart = Syncfusion.SfChart.XForms.SfChart;

namespace RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens
{
	public class WifiScreen : Grid
	{
	    private SfChart myChart;
	    private SfChart myChart2;
        Label myLabel;
        Label myLabel2;
        public WifiScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = 85 });

            RowDefinitions.Add(new RowDefinition { Height = 100 });
            RowDefinitions.Add(new RowDefinition { Height = 100 });
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            //Chart One
            myChart = new SfChart();
            myChart.Series.Add(new SplineAreaSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].ItemsSource = getData();

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            myChart.Series[0].Color = Color.Black;

            //Chart Two
            myChart2 = new SfChart();
            myChart2.Series.Add(new ColumnSeries());

            myChart2.VerticalOptions = LayoutOptions.Start;
            myChart2.HorizontalOptions = LayoutOptions.Start;

            myChart2.Series[0].ItemsSource = getData();

            myChart2.PrimaryAxis = new NumericalAxis();
            myChart2.SecondaryAxis = new NumericalAxis();

            (myChart2.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart2.SecondaryAxis as NumericalAxis).Minimum = 0;
            myChart2.Series[0].Color = Color.Black;

            Children.Add(myChart, 0, 0);
            Children.Add(myChart2, 0, 1);

            myLabel = new Label();
            myLabel.FontSize = 20;
            myLabel.VerticalOptions = LayoutOptions.CenterAndExpand;
            myLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;

            FormattedString fs = new FormattedString();
            fs.Spans.Add(new Span { Text = "11.4", FontSize = 20 });
            fs.Spans.Add(new Span { Text = " mb/s", FontSize = 16, FontAttributes = FontAttributes.Italic });
            myLabel.FormattedText = fs;

            myLabel2 = new Label();
            myLabel2.FontSize = 20;
            myLabel2.VerticalOptions = LayoutOptions.CenterAndExpand;
            myLabel2.HorizontalOptions = LayoutOptions.CenterAndExpand;

            FormattedString fs2 = new FormattedString();
            fs2.Spans.Add(new Span { Text = "8.4", FontSize = 20 });
            fs2.Spans.Add(new Span { Text = " mb/s", FontSize = 16, FontAttributes = FontAttributes.Italic });
            myLabel2.FormattedText = fs2;

            Children.Add(myLabel, 1, 0);
            Children.Add(myLabel2, 1, 1);

            int col1 = 25;
            int col2 = 180;
            int col3 = 285;

            //Column One
            //Part 1
            Label downloadRate;
            downloadRate = new Label();
            downloadRate.Text = "Download Rate";
            downloadRate.Margin = new Thickness(col1, 20, 0, 0);

            Label dLive;
            dLive = new Label();
            dLive.Text = "0 KB/s";
            dLive.FontSize = 22;
            dLive.Margin = new Thickness(col1, 35, 0, 0);

            //Part 2
            Label uploadRate;
            uploadRate = new Label();
            uploadRate.Text = "Upload Rate";
            uploadRate.Margin = new Thickness(col1, 75, 0, 0);

            Label uLive;
            uLive = new Label();
            uLive.Text = "0KB/s";
            uLive.FontSize = 22;
            uLive.Margin = new Thickness(col1, 90, 0, 0);

            //Column 2
            Label adapterName;
            adapterName = new Label();
            adapterName.Text = "Adapter name:";
            adapterName.Margin = new Thickness(col2, 20, 0, 0);

            Label ssid;
            ssid = new Label();
            ssid.Text = "SSID:";
            ssid.Margin = new Thickness(col2, 40, 0, 0);

            Label connectionType;
            connectionType = new Label();
            connectionType.Text = "SSID:";
            connectionType.Margin = new Thickness(col2, 60, 0, 0);

            Label ipv4;
            ipv4 = new Label();
            ipv4.Text = "IPv4 address:";
            ipv4.Margin = new Thickness(col2, 80, 0, 0);

            Label ipv6;
            ipv6 = new Label();
            ipv6.Text = "IPv6 address:";
            ipv6.Margin = new Thickness(col2, 100, 0, 0);

            Label signalStrenght;
            signalStrenght = new Label();
            signalStrenght.Text = "IPv6 address:";
            signalStrenght.Margin = new Thickness(col2, 120, 0, 0);

            Children.Add(downloadRate, 0, 2);
            Children.Add(dLive, 0, 2);
            Children.Add(uploadRate, 0, 2);
            Children.Add(uLive, 0, 2);
            Children.Add(adapterName, 0, 2);
            Children.Add(ssid, 0, 2);
            Children.Add(connectionType, 0, 2);
            Children.Add(ipv4, 0, 2);
            Children.Add(ipv6, 0, 2);
            Children.Add(signalStrenght, 0, 2);

            //TODO This should go in a viewModel/Connected to IoT
            SimulateLiveData();
        }

	    public void SimulateLiveData()
	    {
            Random r = new Random();
            int i = 40;
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                i += 1;
                int a = r.Next(10, 90);
                if (a < 10)
                {
                    a = 1;
                }

                (myChart.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).RemoveAt(0);
                (myChart.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).Add(new ChartDataPoint(i, a));

                (myChart2.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).RemoveAt(0);
                (myChart2.Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).Add(new ChartDataPoint(i, a/2));

                return true;
            });
        }

        //TODO Should be databound instead in ViewModel 13/12/16
        private ObservableCollection<ChartDataPoint> getData2()
        {
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            for(int i = 0; i< 4; i++) 
            {
                datas.Add(new ChartDataPoint(1, 3));
                datas.Add(new ChartDataPoint(2, 4));
                datas.Add(new ChartDataPoint(3, 92));
                datas.Add(new ChartDataPoint(4, 13));
                datas.Add(new ChartDataPoint(5, 5));
                datas.Add(new ChartDataPoint(6, 55));
                datas.Add(new ChartDataPoint(7, 4));
                datas.Add(new ChartDataPoint(8, 24));
                datas.Add(new ChartDataPoint(9, 15));
                datas.Add(new ChartDataPoint(10, 31));
                datas.Add(new ChartDataPoint(11, 75));
                datas.Add(new ChartDataPoint(12, 36));
                datas.Add(new ChartDataPoint(13, 64));
                datas.Add(new ChartDataPoint(14, 74));
                datas.Add(new ChartDataPoint(15, 69));
                datas.Add(new ChartDataPoint(16, 21));
                datas.Add(new ChartDataPoint(17, 45));
                datas.Add(new ChartDataPoint(18, 52));
                datas.Add(new ChartDataPoint(19, 65));
                datas.Add(new ChartDataPoint(20, 22));
                datas.Add(new ChartDataPoint(21, 45));
                datas.Add(new ChartDataPoint(22, 35));
                datas.Add(new ChartDataPoint(23, 32));
                datas.Add(new ChartDataPoint(24, 21));
                datas.Add(new ChartDataPoint(25, 9));
                datas.Add(new ChartDataPoint(26, 1));
                datas.Add(new ChartDataPoint(27, 35));
                datas.Add(new ChartDataPoint(28, 12));
                datas.Add(new ChartDataPoint(29, 45));
                datas.Add(new ChartDataPoint(30, 82));
                datas.Add(new ChartDataPoint(31, 24));
                datas.Add(new ChartDataPoint(32, 42));
                datas.Add(new ChartDataPoint(33, 32));
                datas.Add(new ChartDataPoint(34, 24));
                datas.Add(new ChartDataPoint(35, 15));
                datas.Add(new ChartDataPoint(36, 26));
                datas.Add(new ChartDataPoint(37, 27));
                datas.Add(new ChartDataPoint(38, 38));
                datas.Add(new ChartDataPoint(39, 95));
                datas.Add(new ChartDataPoint(40, 92));
            }
            return datas;
        }

        private ObservableCollection<ChartDataPoint> getData()
        {
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            datas.Add(new ChartDataPoint(1, 34));
            datas.Add(new ChartDataPoint(2, 24));
            datas.Add(new ChartDataPoint(3, 19));
            datas.Add(new ChartDataPoint(4, 21));
            datas.Add(new ChartDataPoint(5, 25));
            datas.Add(new ChartDataPoint(6, 15));
            datas.Add(new ChartDataPoint(7, 34));
            datas.Add(new ChartDataPoint(8, 24));
            datas.Add(new ChartDataPoint(9, 19));
            datas.Add(new ChartDataPoint(10, 21));
            datas.Add(new ChartDataPoint(11, 25));
            datas.Add(new ChartDataPoint(12, 76));
            datas.Add(new ChartDataPoint(13, 34));
            datas.Add(new ChartDataPoint(14, 24));
            datas.Add(new ChartDataPoint(15, 19));
            datas.Add(new ChartDataPoint(16, 21));
            datas.Add(new ChartDataPoint(17, 25));
            datas.Add(new ChartDataPoint(18, 32));
            datas.Add(new ChartDataPoint(19, 15));
            datas.Add(new ChartDataPoint(20, 32));
            datas.Add(new ChartDataPoint(21, 25));
            datas.Add(new ChartDataPoint(22, 32));
            datas.Add(new ChartDataPoint(23, 34));
            datas.Add(new ChartDataPoint(24, 24));
            datas.Add(new ChartDataPoint(25, 19));
            datas.Add(new ChartDataPoint(26, 21));
            datas.Add(new ChartDataPoint(27, 25));
            datas.Add(new ChartDataPoint(28, 32));
            datas.Add(new ChartDataPoint(29, 25));
            datas.Add(new ChartDataPoint(30, 32));
            datas.Add(new ChartDataPoint(31, 74));
            datas.Add(new ChartDataPoint(32, 32));
            datas.Add(new ChartDataPoint(33, 34));
            datas.Add(new ChartDataPoint(34, 24));
            datas.Add(new ChartDataPoint(35, 19));
            datas.Add(new ChartDataPoint(36, 21));
            datas.Add(new ChartDataPoint(37, 25));
            datas.Add(new ChartDataPoint(38, 32));
            datas.Add(new ChartDataPoint(39, 25));
            datas.Add(new ChartDataPoint(40, 32));
            return datas;
        }
    }
}
