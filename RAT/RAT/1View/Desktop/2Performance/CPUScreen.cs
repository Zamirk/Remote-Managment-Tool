using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ServerMonitor;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
	public class CPUScreen : Grid
	{
	    private int i = 40;
	    private SfChart chart;
	    private List<SfChart> myCharts;
        public CPUScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Label myLabel;
            myLabel = new Label();
            myLabel.Text = "CPU Screen";
            Children.Add(myLabel, 1, 1);
            myCharts = new List<SfChart>();
            for (int i = 0; i <1; i++)
            {
                aaa = getData();
                RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                myCharts.Add(new SfChart());

                myCharts[i].Series.Add(new FastLineSeries());
                myCharts[i].Series.Add(new FastLineSeries());

                myCharts[i].VerticalOptions = LayoutOptions.Start;
                myCharts[i].HorizontalOptions = LayoutOptions.Start;
                
                Children.Add(myCharts[i], 0,i);
                myCharts[i].Series[0].ItemsSource = aaa;
                //myCharts[i].Series[1].ItemsSource = getData();
                myCharts[i].Series[1].EnableTooltip = true;
               // myCharts[i].Series[1].Label = "Test Label"
                //column.ItemsSource = viewModel.ColumnData;
                //column.XBindingPath = "Name";
                //column.YBindingPath = "Value";
                myCharts[i].Series[0].EnableAnimation = true;
                myCharts[i].Series[0].AnimationDuration = 2;
                //myCharts[i].Series[0].
            }
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                AddData();

                return true;
            });
        }

	    public ObservableCollection<ChartDataPoint> aaa { get; set; }
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

        private bool AddData()
        {
            i += 10;
            int a = r.Next(10, 90);
            int b = r.Next(10, 90);
            int c = r.Next(10, 90);
            if (a < 10)
            {
                a = 1;
            }

            aaa.RemoveAt(0);
            aaa[0].YValue++;
            //(myCharts[0].Series[1].ItemsSource as ObservableCollection<ChartDataPoint>).RemoveAt(0);
            //(myCharts[0].Series[1].ItemsSource as ObservableCollection<ChartDataPoint>).Add(new ChartDataPoint(i, a*.5));

            return true;
        }
        Random r = new Random();
    }
}
