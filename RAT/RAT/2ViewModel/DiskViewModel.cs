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
    class DiskViewModel : ViewModelBase
    {
        private ObservableCollection<ChartDataPoint> data;
        private ObservableCollection<ChartDataPoint> piedata;
        private int y;
        private bool killThread = false;
        private int deviceNum = 9;

        public DiskViewModel(int deviceNum)
        {
            this.deviceNum = deviceNum;
            y = 0;
            Data = new ObservableCollection<ChartDataPoint>();
            PieData = new ObservableCollection<ChartDataPoint>();
            LoadData();
        }

        private static int deviceNo = DashboardFromDatabase.deviceChosen;

        private string diskReadTime = GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskReadTime;
        private string diskWriteTime = GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskWriteTime;
        private string diskRead = GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskReadBytes;
        private string diskWrite = GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskWriteBytes;
        private string freeMb = GetTelemetry.lastTelemetryDatapoints[deviceNo].FreeMB;
        private string freeSpace = GetTelemetry.lastTelemetryDatapoints[deviceNo].FreeSpace;
        private string idleTime = GetTelemetry.lastTelemetryDatapoints[deviceNo].IdleTime;
        private string activeTime = GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskTime;

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
            y = 0;
            //Adding data to piechart
            double freeSpacePieChart = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNum].FreeSpace);
            double aaa = 100 - freeSpacePieChart;
            PieData.Add(new ChartDataPoint("Free Space", freeSpacePieChart));
            PieData.Add(new ChartDataPoint("Free Space", aaa));

            //Iterating over the queue of telemetry obects, adding to the chart databound collection
            foreach (var telemetry in GetTelemetry.listOfDevices[deviceNum])
            {
                data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.DiskTime)));
                y++;
            }
            await Task.Delay(1000);

            //Updates the information onece a second
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
            {
                if (killThread)
                {
                    return false;
                }
                y++;
                double diskTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNum].DiskTime);
                ActiveTime = GetTelemetry.lastTelemetryDatapoints[deviceNum].DiskTime;
                IdleTime = GetTelemetry.lastTelemetryDatapoints[deviceNum].IdleTime;
                FreeSpace = GetTelemetry.lastTelemetryDatapoints[deviceNum].FreeSpace;
                FreeMb = GetTelemetry.lastTelemetryDatapoints[deviceNum].FreeMB;
                DiskWrite = GetTelemetry.lastTelemetryDatapoints[deviceNum].DiskWriteBytes;
                DiskRead = GetTelemetry.lastTelemetryDatapoints[deviceNum].DiskReadBytes;
                DiskReadTime = GetTelemetry.lastTelemetryDatapoints[deviceNum].DiskReadTime;
                DiskWriteTime = GetTelemetry.lastTelemetryDatapoints[deviceNum].DiskWriteTime;
                Data.RemoveAt(0);
                Data.Add(new ChartDataPoint(y, diskTime));
                return true;
            });
        }

        public void StopUpdate()
        {
            killThread = true;
        }
    }
}