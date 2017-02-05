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
    class WifiViewModel: ViewModelBase
    {
        public WifiViewModel()
        {
            Data = new ObservableCollection<ChartDataPoint>();
            LoadData();
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
            for (var i = 0; i < 120; i++)
            {
                z++;
                if (a)
                {
                    Data.Add(new ChartDataPoint(z, value));
                    a = false;
                }
                else
                {
                    Data.Add(new ChartDataPoint(z, value));
                    a = true;
                }
            }

            await Task.Delay(1000);

            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 500), () =>
            {
                z++;
                Data.RemoveAt(0);
                if (a)
                {
                    Data.Add(new ChartDataPoint(z, value++));
                    a = false;
                }
                else
                {
                    Data.Add(new ChartDataPoint(z, value--));
                    a = true;
                }
                return true;
            });
        }
    }
}
