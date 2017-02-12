using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.SfChart.XForms;
using Tools;
using Xamarin.Forms;

namespace RAT._2ViewModel
{
    class DiskViewModel : ViewModelBase
    {
        public DiskViewModel()
        {
            Data = new ObservableCollection<ChartDataPoint>();
            PieData = new ObservableCollection<ChartDataPoint>();
            LoadData();
        }
        private bool killThread = false;

        public void StopUpdate()
        {
            killThread = true;
        }
        private double value = 50;
        Random rand = new Random();
        private ObservableCollection<ChartDataPoint> data;
        private ObservableCollection<ChartDataPoint> piedata;

        //Data binding
        public ObservableCollection<ChartDataPoint> PieData
        {
            set
            {
                if (SetProperty(ref piedata, value))
                {
                    //UpdateProduct();
                }
            }
            get { return piedata; }
        }

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
            PieData.Add(new ChartDataPoint("54% Used", rand.Next(1, 100)));
            PieData.Add(new ChartDataPoint("46% Free", rand.Next(1, 100)));

            bool a = true;
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

            await Task.Delay(3000);

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 500), () =>
            {
                if (killThread)
                {
                    return false;
                }
                z++;
                piedata.RemoveAt(0);
                Data.RemoveAt(0);
                if (a)
                {
                    Data.Add(new ChartDataPoint(z, value+30));
                    a = false;
                    piedata.Add(new ChartDataPoint(""+ (value+30) + " Used", value + 30));
                }
                else
                {
                    Data.Add(new ChartDataPoint(z, value-20));
                    a = true;
                    piedata.Add(new ChartDataPoint("" + (value + 20) + " Used", value - 20));
                }

                return true;
            });
        }
    }
}