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
	public class AllCPUScreen : Grid
	{
        public AllCPUScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Label myLabel;
            myLabel = new Label();
            myLabel.Text = "CPU Screen";
            Children.Add(myLabel, 1, 1);
            List<SfChart>  myCharts = new List<SfChart>();
            for (int i = 0; i <1; i++)
            {
                RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                myCharts.Add(new SfChart());

                myCharts[i].Series.Add(new FastLineSeries());

                myCharts[i].VerticalOptions = LayoutOptions.Start;
                myCharts[i].HorizontalOptions = LayoutOptions.Start;
                
                Children.Add(myCharts[i], 0,i);

                //myCharts[i].Series[0].ItemsSource = aaa;

                myCharts[0].PrimaryAxis = new NumericalAxis();
                myCharts[0].SecondaryAxis = new NumericalAxis();

                (myCharts[i].SecondaryAxis as NumericalAxis).Maximum = 100;
                (myCharts[i].SecondaryAxis as NumericalAxis).Minimum = 0;
            }
        }
        }
}
