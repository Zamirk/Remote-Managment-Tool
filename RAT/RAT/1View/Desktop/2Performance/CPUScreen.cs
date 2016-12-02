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
        private bool test = true;
        Random r = new Random();
        private int sizeOfGraph = 100;
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

                myCharts[i].VerticalOptions = LayoutOptions.Start;
                myCharts[i].HorizontalOptions = LayoutOptions.Start;
                
                Children.Add(myCharts[i], 0,i);
                aaa = getData();

                myCharts[i].Series[0].ItemsSource = aaa;

                myCharts[0].PrimaryAxis = new NumericalAxis();
                myCharts[0].SecondaryAxis = new NumericalAxis();

                (myCharts[i].SecondaryAxis as NumericalAxis).Maximum = 100;
                (myCharts[i].SecondaryAxis as NumericalAxis).Minimum = 0;
                    //(myCharts[i].PrimaryAxis as NumericalAxis).Maximum = 100;
                    //(myCharts[i].PrimaryAxis as NumericalAxis).Minimum = 0;
            }


        
            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
             {
                AddData();
                return true;
             });
        }

	    public ObservableCollection<ChartDataPoint> aaa { get; set; }
        private ObservableCollection<ChartDataPoint> getData()
        {
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            for (int i = 0; i < sizeOfGraph; i++)
            {
                if (test)
                {
                    datas.Add(new ChartDataPoint(i + 1, 55));
                    test = false;
                }
                else
                {
                    datas.Add(new ChartDataPoint(i + 1, 45));
                    test = true;
                }

            }
            return datas;
        }

        private bool AddData()
        {
            sizeOfGraph += 1;
            aaa.RemoveAt(0);
            aaa.Add(new ChartDataPoint(sizeOfGraph, r.Next(10, 90)));

            return true;
        }
    }
}
//myCharts[i].Series[0].ItemsSource = aaa;
//myCharts[i].Series[1].ItemsSource = getData();

// myCharts[i].Series[1].Label = "Test Label"

//column.ItemsSource = viewModel.ColumnData;
//column.XBindingPath = "Name";
//column.YBindingPath = "Value";
//myCharts[i].Series[0].EnableAnimation = true;
// myCharts[i].Series[0].AnimationDuration = 2;
////myCharts[i].Series[0].
//ViewModel viewModel = myCharts[i].BindingContext as ViewModel;
////viewModel.LoadData1();
//myCharts[0].Series[0].SetBinding(FastLineSeries.XAxisProperty, "Value");
//myCharts[0].Series[0].ItemsSource = viewModel.liveData1;