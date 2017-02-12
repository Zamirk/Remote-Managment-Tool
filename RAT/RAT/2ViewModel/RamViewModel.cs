using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Amqp.Framing;
using Syncfusion.SfChart.XForms;
using Tools;
using Xamarin.Forms;

namespace RAT._2ViewModel
{
    class RamViewModel : ViewModelBase
    {
        public RamViewModel()
        {
            Data = new ObservableCollection<ChartDataPoint>();
            LoadData();
        }
        private bool killThread = false;

        public void StopUpdate()
        {
            killThread = true;
        }
        private ObservableCollection<ChartDataPoint> data;
        private double value = 50;

        //Data binding
        public ObservableCollection<ChartDataPoint> Data
        {
            set
            {
                if (SetProperty(ref data, value))
                {
                    //UpdateProduct();
                }
            }
            get { return data; }
        }

        private int z = 0;
        //TODO Replace with real data 05/02/17
        public async void LoadData()
        {
            bool a = true;
            Random rand = new Random();
            for (var i = 0; i < 60; i++)
            {
                z++;
                if (a)
                {
                    data.Add(new ChartDataPoint(z, rand.Next(100)));
                    a = false;
                }
                else
                {
                    data.Add(new ChartDataPoint(z, rand.Next(100)));
                    a = true;
                }
            }

            await Task.Delay(1000);

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 500), () =>
            {
                if (killThread)
                {
                    return false;
                }
                z++;

                if (a)
                {
                    Data.Add(new ChartDataPoint(z, value+20));
                    a = false;
                }
                else
                {
                    Data.Add(new ChartDataPoint(z, value-20));
                    a = true;
                }
                Data.RemoveAt(3);
                return true;
            });
        }
    }
}

