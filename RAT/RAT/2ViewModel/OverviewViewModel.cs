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

        ObservableCollection<DeviceInfo> data;
        Random r = new Random(3);

        public ObservableCollection<DeviceInfo> Stocks
        {
            get { return data; }
        }

        public OverviewViewModel()
        {
            data = new ObservableCollection<DeviceInfo>();
            for (int i = 0; i < 5; ++i)
            {
                DeviceInfo myStock = new DeviceInfo();
                data.Add(myStock);
            }

            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                for (int i = 0; i < data.Count; i++)
                {
                    data[i].LastTrade = r.Next();
                    data[i].Open = r.Next();
                    data[i].PreviousClose = r.Next();
                    data[i].Volume = r.Next();
                    data[i].StockChange = r.Next();
                }
                return true;
            });
        }
    }
}
