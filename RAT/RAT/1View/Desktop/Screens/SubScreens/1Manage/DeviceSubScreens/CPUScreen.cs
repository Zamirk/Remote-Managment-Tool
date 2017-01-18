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
	public class CPUScreen : Grid
	{
        public CPUScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            RowDefinitions.Add(new RowDefinition { Height = 200 });
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            //Chart
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

            int col2 = 145;
            int col3 = 285;

            //Part 1
            Label utilizationLabel;
            utilizationLabel = new Label();
            utilizationLabel.Text = "Utilization";
            utilizationLabel.Margin = new Thickness(25, 20, 0, 0);

            Label uLive;
            uLive = new Label();
            uLive.Text = "38%";
            uLive.FontSize = 22;
            uLive.Margin = new Thickness(25, 35, 0, 0);

            //Part 2
            Label speedLabel;
            speedLabel = new Label();
            speedLabel.Text = "Speed";
            speedLabel.Margin = new Thickness(25, 75, 0, 0);

            Label sLive;
            sLive = new Label();
            sLive.Text = "2.5Ghz";
            sLive.FontSize = 22;
            sLive.Margin = new Thickness(25, 90, 0, 0);

            //Second Column
            Label processesLabel;
            processesLabel = new Label();
            processesLabel.Text = "Processes";
            processesLabel.Margin = new Thickness(col2, 20, 0, 0);

            Label pLive;
            pLive = new Label();
            pLive.Text = "120";
            pLive.FontSize = 22;
            pLive.Margin = new Thickness(col2, 35, 0, 0);

            //Part 4
            Label threadsLabel;
            threadsLabel = new Label();
            threadsLabel.Text = "Threads";
            Children.Add(threadsLabel, 0, 1);
            threadsLabel.Margin = new Thickness(col2, 75, 0, 0);

            Label tLabel;
            tLabel = new Label();
            tLabel.Text = "2400";
            tLabel.FontSize = 22;
            Children.Add(tLabel, 0, 1);
            tLabel.Margin = new Thickness(col2, 90, 0, 0);

            //Third Column
            Label maxSpeedLabel;
            maxSpeedLabel = new Label();
            maxSpeedLabel.Text = "Maximum Speed:";
            Children.Add(maxSpeedLabel, 0, 1);
            maxSpeedLabel.Margin = new Thickness(col3, 20, 0, 0);

            Label socketsLabel;
            socketsLabel = new Label();
            socketsLabel.Text = "Sockets:";
            Children.Add(socketsLabel, 0, 1);
            socketsLabel.Margin = new Thickness(col3, 40, 0, 0);

            Label coresLabel;
            coresLabel = new Label();
            coresLabel.Text = "Cores:";
            Children.Add(coresLabel, 0, 1);
            coresLabel.Margin = new Thickness(col3, 60, 0, 0);

            Label logicalCoresLabel;
            logicalCoresLabel = new Label();
            logicalCoresLabel.Text = "Logical Cores:";
            Children.Add(logicalCoresLabel, 0, 1);
            logicalCoresLabel.Margin = new Thickness(col3, 80, 0, 0);

            Label l1;
            l1 = new Label();
            l1.Text = "L1 Cache:\t100";
            Children.Add(l1, 0, 1);
            l1.Margin = new Thickness(col3, 100, 0, 0);

            Label l2;
            l2 = new Label();
            l2.Text = "L2 Cache:\t100";
            Children.Add(l2, 0, 1);
            l2.Margin = new Thickness(col3, 120, 0, 0);

            Label l3;
            l3 = new Label();
            l3.Text = "L3 Cache:\t100";
            Children.Add(l3, 0, 1);
            l3.Margin = new Thickness(col3, 140, 0, 0);

            //CPU Type
            Label cpuLabel;
            cpuLabel = new Label();
            cpuLabel.Text = "intel(r) core(tm) i5-2400 cpu @ 1.70ghz";
            cpuLabel.HorizontalOptions = LayoutOptions.End;

            Children.Add(cpuLabel, 0, 1);
            Children.Add(pLive, 0, 1);
            Children.Add(processesLabel, 0, 1);
            Children.Add(sLive, 0, 1);
            Children.Add(utilizationLabel, 0, 1);
            Children.Add(uLive, 0, 1);
            Children.Add(speedLabel, 0, 1);
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
