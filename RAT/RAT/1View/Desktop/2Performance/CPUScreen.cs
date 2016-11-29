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
                myCharts[i].Series[1].EnableTooltip = true;
                aaa = getData();
                myCharts[i].Series[0].ItemsSource = aaa;
                myCharts[i].Series[1].ItemsSource = aaa;

                //myCharts[i].Series[0].ItemsSource = aaa;
                //myCharts[i].Series[1].ItemsSource = getData();



                // myCharts[i].Series[1].Label = "Test Label"

                //column.ItemsSource = viewModel.ColumnData;
                //column.XBindingPath = "Name";
                //column.YBindingPath = "Value";
                //myCharts[i].Series[0].EnableAnimation = true;
                // myCharts[i].Series[0].AnimationDuration = 2;
                ////myCharts[i].Series[0].
                /// 
                /// 
                /// 
                //myCharts[0].PrimaryAxis = new NumericalAxis();
                //myCharts[0].SecondaryAxis = new NumericalAxis();

                //ViewModel viewModel = myCharts[i].BindingContext as ViewModel;
                ////viewModel.LoadData1();
                //myCharts[0].Series[0].SetBinding(FastLineSeries.XAxisProperty, "Value");
                //myCharts[0].Series[0].ItemsSource = viewModel.liveData1;

                //// (myCharts[i].SecondaryAxis as NumericalAxis).Maximum = 100;
                ////     (myCharts[i].SecondaryAxis as NumericalAxis).Minimum = 0;

                //           (myCharts[i].PrimaryAxis as NumericalAxis).Maximum = 100;
                //      (myCharts[i].PrimaryAxis as NumericalAxis).Minimum = 0;
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
            for (int i = 0; i < 40; i++)
            {
            datas.Add(new ChartDataPoint(i+1, 34));

            }
            return datas;
        }

        private bool AddData()
        {
            i += 1;
            int a = r.Next(10, 90);
            int b = r.Next(10, 90);
            int c = r.Next(10, 90);
            if (a < 10)
            {
                a = 1;
            }

            aaa.RemoveAt(0);
            aaa.Add(new ChartDataPoint(i, a * .5));
            (myCharts[0].Series[0].ItemsSource as ObservableCollection<ChartDataPoint>).RemoveAt(0);
            (myCharts[0].Series[1].ItemsSource as ObservableCollection<ChartDataPoint>).Add(new ChartDataPoint(i, a*.5));

            return true;
        }
        Random r = new Random();
    }
}
