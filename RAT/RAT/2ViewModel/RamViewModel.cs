using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Folder;
using RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen;
using Syncfusion.SfChart.XForms;
using Tools;
using Xamarin.Forms;

namespace RAT._2ViewModel
{
    class RamViewModel : ViewModelBase
    {
        private ObservableCollection<ChartDataPoint> data;
        private bool killThread = false;
        private int y;
        private int deviceNum = 9;

        public RamViewModel(int deviceNum)
        {
            this.deviceNum = deviceNum;
            y = 0;
            Data = new ObservableCollection<ChartDataPoint>();
            LoadData();
        }

        private static int deviceNo = UserData.deviceChosen;

        private string inUse = GetTelemetry.lastTelemetryDatapoints[deviceNo].RamInUse;
        private string notInUse = GetTelemetry.lastTelemetryDatapoints[deviceNo].Ram;
        private string committed = GetTelemetry.lastTelemetryDatapoints[deviceNo].RamCommitted;
        private string cached = GetTelemetry.lastTelemetryDatapoints[deviceNo].RamCache;
        private string pagedPool = GetTelemetry.lastTelemetryDatapoints[deviceNo].PagedPool;
        private string nonPagedPool = GetTelemetry.lastTelemetryDatapoints[deviceNo].NonPagedPool;

        public string PagedPool
        {
            set { SetProperty(ref pagedPool, value + " GB"); }
            get { return pagedPool; }
        }

        public string NonPagedPool
        {
            set { SetProperty(ref nonPagedPool, value + " GB"); }
            get { return nonPagedPool; }
        }

        public string Cached
        {
            set { SetProperty(ref cached, value + " GB"); }
            get { return cached; }
        }

        public string NotInUse
        {
            set { SetProperty(ref notInUse, value + " Mb"); }
            get { return notInUse; }
        }

        public string InUse
        {
            set { SetProperty(ref inUse, value + " %"); }
            get { return inUse; }
        }

        public string Committed
        {
            set { SetProperty(ref committed, value + " GB"); }
            get { return committed; }
        }

        public void StopUpdate()
        {
            killThread = true;
        }

        public ObservableCollection<ChartDataPoint> Data
        {
            set { SetProperty(ref data, value); }
            get { return data; }
        }

        private async void LoadData()
        {
            y = 0;
            //Iterating over the queue of telemetry obects, adding to the chart databound collection
            foreach (var telemetry in GetTelemetry.listOfDevices[deviceNum])
            {
                data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.RamInUse)));
                y++;
            }
            await Task.Delay(1000);

            //Updates the information onece a second
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
            {
                System.Diagnostics.Debug.WriteLine("RAM" + y);
                y++;
                double ramUsage = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNum].RamInUse);
                PagedPool = GetTelemetry.lastTelemetryDatapoints[deviceNum].PagedPool;
                NonPagedPool = GetTelemetry.lastTelemetryDatapoints[deviceNum].NonPagedPool;
                InUse = GetTelemetry.lastTelemetryDatapoints[deviceNum].RamInUse;
                NotInUse = GetTelemetry.lastTelemetryDatapoints[deviceNum].Ram;
                Cached = GetTelemetry.lastTelemetryDatapoints[deviceNum].RamCache;
                Committed = GetTelemetry.lastTelemetryDatapoints[deviceNum].RamCommitted;
                data.RemoveAt(0);
                data.Add(new ChartDataPoint(y, ramUsage));
                if (killThread)
                {
                    return false;
                }
                return true;
            });
        }
    }
}