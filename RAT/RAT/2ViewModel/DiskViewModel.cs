using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Folder;
using Syncfusion.SfChart.XForms;
using Tools;
using Xamarin.Forms;

namespace RAT._2ViewModel
{
    class DiskViewModel : ViewModelBase
    {
        private ObservableCollection<ChartDataPoint> data;
        private ObservableCollection<ChartDataPoint> piedata;
        private int y;
        private bool killThread = false;

        public DiskViewModel()
        {
            y = 0;
            Data = new ObservableCollection<ChartDataPoint>();
            PieData = new ObservableCollection<ChartDataPoint>();
            LoadData();
        }

        private string diskReadTime = GetTelemetry.lastReceivedValue.DiskReadTime;
        private string diskWriteTime = GetTelemetry.lastReceivedValue.DiskWriteTime;
        private string diskRead = GetTelemetry.lastReceivedValue.DiskReadBytes;
        private string diskWrite = GetTelemetry.lastReceivedValue.DiskWriteBytes;
        private string freeMb = GetTelemetry.lastReceivedValue.FreeMB;
        private string freeSpace = GetTelemetry.lastReceivedValue.FreeSpace;
        private string idleTime = GetTelemetry.lastReceivedValue.IdleTime;
        private string activeTime = GetTelemetry.lastReceivedValue.DiskTime;

        public string ActiveTime
        {
            set { SetProperty(ref activeTime, value + " %"); }
            get { return activeTime; }
        }

        public string IdleTime
        {
            set { SetProperty(ref idleTime, value + " %"); }
            get { return idleTime; }
        }

        public string FreeSpace
        {
            set { SetProperty(ref freeSpace, value + " %"); }
            get { return freeSpace; }
        }

        public string FreeMb
        {
            set { SetProperty(ref freeMb, value + " GB"); }
            get { return freeMb; }
        }

        public string DiskWrite
        {
            set { SetProperty(ref diskWrite, value + " MB"); }
            get { return diskWrite; }
        }

        public string DiskRead
        {
            set { SetProperty(ref diskRead, value + " MB"); }
            get { return diskRead; }
        }

        public string DiskWriteTime
        {
            set { SetProperty(ref diskWriteTime, value + " %"); }
            get { return diskWriteTime; }
        }

        public string DiskReadTime
        {
            set { SetProperty(ref diskReadTime, value + " %"); }
            get { return diskReadTime; }
        }

        public ObservableCollection<ChartDataPoint> PieData
        {
            set { SetProperty(ref piedata, value); }
            get { return piedata; }
        }

        public ObservableCollection<ChartDataPoint> Data
        {
            set { SetProperty(ref data, value); }
            get { return data; }
        }

        private async void LoadData()
        {
            y = 0; System.Diagnostics.Debug.WriteLine("DISK" + y);


            //Adding data to piechart
            double freeSpacePieChart = Convert.ToDouble(GetTelemetry.lastReceivedValue.FreeSpace);
            double aaa = 100 - freeSpacePieChart;
            PieData.Add(new ChartDataPoint("Free Space", freeSpacePieChart));
            PieData.Add(new ChartDataPoint("Free Space", aaa));

            //Iterating over the queue of telemetry obects, adding to the chart databound collection
            foreach (var telemetry in GetTelemetry.listOfDevices[0])
            {
                data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.DiskTime)));
                y++;
            }
            await Task.Delay(1000);

            System.Diagnostics.Debug.WriteLine("Le" + Convert.ToDouble(GetTelemetry.lastReceivedValue.FreeSpace));
            //Updates the information onece a second
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
            {
                y++;
                double diskTime = Convert.ToDouble(GetTelemetry.lastReceivedValue.DiskTime);
                ActiveTime = GetTelemetry.lastReceivedValue.DiskTime;
                IdleTime = GetTelemetry.lastReceivedValue.IdleTime;
                FreeSpace = GetTelemetry.lastReceivedValue.FreeSpace;
                FreeMb = GetTelemetry.lastReceivedValue.FreeMB;
                DiskWrite = GetTelemetry.lastReceivedValue.DiskWriteBytes;
                DiskRead = GetTelemetry.lastReceivedValue.DiskReadBytes;
                DiskReadTime = GetTelemetry.lastReceivedValue.DiskReadTime;
                DiskWriteTime = GetTelemetry.lastReceivedValue.DiskWriteTime;
                Data.RemoveAt(0);
                Data.Add(new ChartDataPoint(y, diskTime));
                if (killThread)
                {
                    return false;
                }
                return true;
            });
        }

        public void StopUpdate()
        {
            killThread = true;
        }
    }
}