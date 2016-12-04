using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace RAT._2ViewModel
{
	public class Temp : ContentPage
	{
		public Temp ()
		{
            /*
             * 
             * 
             *         public ObservableCollection<ChartDataPoint> aaa { get; set; }
        private ObservableCollection<ChartDataPoint> getData()
        {
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            for (int i = 0; i < sizeOfGraph; i++)
            {
                if (test)
                {
                    datas.Add(new ChartDataPoint(i + 1, 60));
                    test = false;
                }
                else
                {
                    datas.Add(new ChartDataPoint(i + 1, 40));
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
             * 
             * 
             *             Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                if (killTimer)
                {
                    return false;
                }
                if (a)
                {
                    uniqueId = rand.Next(1, 100);
                    System.Diagnostics.Debug.WriteLine("\n-----First Time Start" + uniqueId);
                    a = false;
                }
                zz++;
                System.Diagnostics.Debug.WriteLine("\n" + "\tKey: "+ uniqueId+"-----" +zz);
                AddData();
                return true;
             });
             */
        }
    }
}
