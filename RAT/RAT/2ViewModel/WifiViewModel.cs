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
            DownloadData = new ObservableCollection<ChartDataPoint>();
            UploadData = new ObservableCollection<ChartDataPoint>();
            LoadData();
        }

        private ObservableCollection<ChartDataPoint> downloadData;
        private ObservableCollection<ChartDataPoint> uploadData;
        private double value = 50;
        private bool killThread = false;

        public void StopUpdate()
        {
            killThread = true;
        }

        //Data binding
        public ObservableCollection<ChartDataPoint> DownloadData
        {
            set
            {
                if (SetProperty(ref downloadData, value))
                {
                    //UpdateProduct();
                }
            }
            get { return downloadData; }
        }

        //Data binding
        public ObservableCollection<ChartDataPoint> UploadData
        {
            set
            {
                if (SetProperty(ref uploadData, value))
                {
                    //UpdateProduct();
                }
            }
            get { return uploadData; }
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
                    downloadData.Add(new ChartDataPoint(z, rand.Next(100)));
                    uploadData.Add(new ChartDataPoint(z, rand.Next(100)));

                    a = false;
                }
                else
                {
                    downloadData.Add(new ChartDataPoint(z, rand.Next(100)));
                    uploadData.Add(new ChartDataPoint(z, rand.Next(100)));

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
                DownloadData.RemoveAt(0);
                if (a)
                {
                    DownloadData.Add(new ChartDataPoint(z, value++));
                    a = false;
                }
                else
                {
                    DownloadData.Add(new ChartDataPoint(z, value--));
                    a = true;
                }
                return true;
            });
        }
    }
}
