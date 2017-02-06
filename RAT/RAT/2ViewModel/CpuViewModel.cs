using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Syncfusion.SfChart.XForms;
using Tools;
using Xamarin.Forms;

namespace RAT._2ViewModel
{
    public class CpuViewModel : ViewModelBase
    {
        public CpuViewModel()
        {
            Data = new ObservableCollection<ChartDataPoint>();
            LoadData();
        }

        private ObservableCollection<ChartDataPoint> data;
        private double value = 50;
        private bool killThread = false;

        public void StopUpdate()
        {
            killThread = true;
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
                if (killThread)
                {
                    return false;
                }
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
