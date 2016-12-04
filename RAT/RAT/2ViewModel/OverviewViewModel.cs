using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using SampleBrowser;
using Xamarin.Forms;

namespace RAT._2ViewModel.Test
{
    public class OverviewViewModel
    {
        private bool temp = true;
        private int a = 0;
        ObservableCollection<DeviceInfo> data;
        Random r = new Random();
        List<int> myList = new List<int>();
        public ObservableCollection<DeviceInfo> Stocks
        {
            get { return data; }
        }

        public OverviewViewModel()
        {
            if (temp)
            {
                temp = false;
                a = r.Next(1, 100);
                System.Diagnostics.Debug.WriteLine("\n-----Overview Start: " + a + " ");
            }
            data = new ObservableCollection<DeviceInfo>();
            for (int i = 0; i < 5; ++i)
            {
                DeviceInfo myStock = new DeviceInfo();
                data.Add(myStock);
            }

            for (int z = 0; z < 100000000; z++)
            {
                myList.Add(123456789);
            }

            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                if (collectGarbage)
                {
                    return false;
                }
                for (int i = 0; i < data.Count; i++)
                {
                    data[i].LastTrade = r.Next();
                    data[i].Open = r.Next();
                    data[i].PreviousClose = r.Next();
                    data[i].Volume = r.Next();
                    data[i].StockChange = r.Next();
                }
                System.Diagnostics.Debug.WriteLine("\n-----Overview Page: "+ a  + " is still going");
                return true;
            });
        }

        public bool collectGarbage = false;
    }
}
