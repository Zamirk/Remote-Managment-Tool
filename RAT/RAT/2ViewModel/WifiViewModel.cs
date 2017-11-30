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
    class WifiViewModel : ViewModelBase
    {
        private ObservableCollection<ChartDataPoint> downloadData;
        private ObservableCollection<ChartDataPoint> uploadData;
        private bool killThread = false;
        private int y;
        private int deviceNum = 9;

        public WifiViewModel(int deviceNum)
        {
            this.deviceNum = deviceNum;
            y = 0;
            DownloadData = new ObservableCollection<ChartDataPoint>();
            UploadData = new ObservableCollection<ChartDataPoint>();
            LoadData();
        }

        private static int deviceNo = UserData.deviceChosen;

        private string downloadRate = GetTelemetry.lastTelemetryDatapoints[deviceNo].DownloadRate;
        private string uploadRate = GetTelemetry.lastTelemetryDatapoints[deviceNo].UploadRate;
        private string bandwidth = GetTelemetry.lastTelemetryDatapoints[deviceNo].Bandwidth;
        private string packets = GetTelemetry.lastTelemetryDatapoints[deviceNo].Packets;
        private string packetsSent = GetTelemetry.lastTelemetryDatapoints[deviceNo].PacketsSent;
        private string packetsReceived = GetTelemetry.lastTelemetryDatapoints[deviceNo].PacketsReceived;

        public string Packets
        {
            set { SetProperty(ref packets, value + " p/s"); }
            get { return packets; }
        }

        public string PacketsSent
        {
            set { SetProperty(ref packetsSent, value + " p/s"); }
            get { return packetsSent; }
        }

        public string PacketsReceived
        {
            set { SetProperty(ref packetsReceived, value + " p/s"); }
            get { return packetsReceived; }
        }

        public string Bandwidth
        {
            set { SetProperty(ref bandwidth, value + " MB/S"); }
            get { return bandwidth; }
        }

        public string UploadRate
        {
            set { SetProperty(ref uploadRate, value + " MB/S"); }
            get { return uploadRate; }
        }

        public string DownloadRate
        {
            set { SetProperty(ref downloadRate, value + " MB/S"); }
            get { return downloadRate; }
        }

        public ObservableCollection<ChartDataPoint> DownloadData
        {
            set { SetProperty(ref downloadData, value); }
            get { return downloadData; }
        }

        public ObservableCollection<ChartDataPoint> UploadData
        {
            set { SetProperty(ref uploadData, value); }
            get { return uploadData; }
        }

        private async void LoadData()
        {
            y = 0;
            //Iterating over the queue of telemetry obects, adding to the chart databound collection
            foreach (var telemetry in GetTelemetry.listOfDevices[deviceNum])
            {
                DownloadData.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.DownloadRate)));
                UploadData.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.UploadRate)));
                y++;
            }
            await Task.Delay(1000);

            //Updates the information onece a second
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
            {
                System.Diagnostics.Debug.WriteLine("WIFI" + y);

                y++;
                double downloadRate = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNum].DownloadRate);
                double uploadRate = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNum].UploadRate);
                Packets = GetTelemetry.lastTelemetryDatapoints[deviceNum].Packets;
                PacketsReceived = GetTelemetry.lastTelemetryDatapoints[deviceNum].PacketsReceived;
                PacketsSent = GetTelemetry.lastTelemetryDatapoints[deviceNum].PacketsSent;
                Bandwidth = GetTelemetry.lastTelemetryDatapoints[deviceNum].Bandwidth;
                DownloadRate = GetTelemetry.lastTelemetryDatapoints[deviceNum].DownloadRate;
                UploadRate = GetTelemetry.lastTelemetryDatapoints[deviceNum].UploadRate;
                DownloadData.RemoveAt(0);
                UploadData.RemoveAt(0);
                DownloadData.Add(new ChartDataPoint(y, downloadRate));
                UploadData.Add(new ChartDataPoint(y, uploadRate));
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