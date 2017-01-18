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

namespace RAT._1View.Desktop
{
	public class DiskScreen : Grid
	{
        Random rand = new Random();
        public DiskScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = 150});

            RowDefinitions.Add(new RowDefinition { Height = 200 });
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            //PieChart
            SfChart pieChart = new SfChart();
            pieChart.VerticalOptions = LayoutOptions.CenterAndExpand;
            pieChart.HorizontalOptions = LayoutOptions.CenterAndExpand;
            PieSeries pieSeries = new PieSeries();

            pieSeries.ItemsSource = PieSeriesData;
            pieChart.Series.Add(pieSeries);

            Children.Add(pieChart, 1, 0);

            //LineChart
            SfChart myChart = new SfChart();

            myChart.Series.Add(new FastLineSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].ItemsSource = getData();

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;

            Children.Add(myChart, 0, 0);

            int col1 = 25;
            int col2 = 145;
            int col3 = 285;

            //Column One
            //Part 1
            Label activeTime;
            activeTime = new Label();
            activeTime.Text = "Active time";
            activeTime.Margin = new Thickness(col1, 20, 0, 0);

            Label activeTimeLive;
            activeTimeLive = new Label();
            activeTimeLive.Text = "1%";
            activeTimeLive.FontSize = 22;
            activeTimeLive.Margin = new Thickness(col1, 35, 0, 0);

            //Part 2
            Label readspeed;
            readspeed = new Label();
            readspeed.Text = "Read Speed";
            readspeed.Margin = new Thickness(col1, 75, 0, 0);

            Label readSpeedLive;
            readSpeedLive = new Label();
            readSpeedLive.Text = "0KB/s";
            readSpeedLive.FontSize = 22;
            readSpeedLive.Margin = new Thickness(col1, 90, 0, 0);

            //Second Column
            //Part 1
            Label responceTime;
            responceTime = new Label();
            responceTime.Text = "Av.responce time";
            responceTime.Margin = new Thickness(col2, 20, 0, 0);

            Label responceTimeLive;
            responceTimeLive = new Label();
            responceTimeLive.Text = "0.2 ms";
            responceTimeLive.FontSize = 22;
            responceTimeLive.Margin = new Thickness(col2, 35, 0, 0);

            //Part 2
            Label writeSpeed;
            writeSpeed = new Label();
            writeSpeed.Text = "Write speed";
            writeSpeed.Margin = new Thickness(col2, 75, 0, 0);

            Label writeSpeedLive;
            writeSpeedLive = new Label();
            writeSpeedLive.Text = "0 KB/s";
            writeSpeedLive.FontSize = 22;
            writeSpeedLive.Margin = new Thickness(col2, 90, 0, 0);

            //Third Column
            Label capacity;
            capacity = new Label();
            capacity.Text = "Capacity: 556 GB";
            capacity.Margin = new Thickness(col3, 20, 0, 0);

            Label diskHardware;
            diskHardware = new Label();
            diskHardware.Text = "Type: SSD";
            diskHardware.Margin = new Thickness(col3, 40, 0, 0);

            Label formatted;
            formatted = new Label();
            formatted.Text = "Formatted: 466 GB";
            formatted.Margin = new Thickness(col3, 60, 0, 0);

            Label systemDisk;
            systemDisk = new Label();
            systemDisk.Text = "System disk: 466 GB";
            systemDisk.Margin = new Thickness(col3, 80, 0, 0);

            Label pageFile;
            pageFile = new Label();
            pageFile.Text = "Page File: Yes";
            pageFile.Margin = new Thickness(col3, 100, 0, 0);

            //DISK Type
            Label diskType;
            diskType = new Label();
            diskType.Text = "Samsung SSD 850 EVO 500GB";
            diskType.HorizontalOptions = LayoutOptions.End;

            Children.Add(activeTime, 0, 1);
            Children.Add(activeTimeLive, 0, 1);
            Children.Add(writeSpeedLive, 0, 1);
            Children.Add(writeSpeed, 0, 1);
            Children.Add(responceTimeLive, 0, 1);
            Children.Add(responceTime, 0, 1);
            Children.Add(readSpeedLive, 0, 1);
            Children.Add(readspeed, 0, 1);
            Children.Add(diskType, 0, 1);
            Children.Add(pageFile, 0, 1);
            Children.Add(systemDisk, 0, 1);
            Children.Add(formatted, 0, 1);
            Children.Add(capacity, 0, 1);
            Children.Add(diskHardware, 0, 1);

        }

        //TODO Should be replaced with ViewModel/DataBinding 13/12/16
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

        //TODO Should be replaced with ViewModel/DataBinding 13/12/16
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
