using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApplication1.Folder;
using Syncfusion.SfChart.XForms;
using Tools;
using Xamarin.Forms;

namespace RAT._2ViewModel
{
    public class CpuViewModel : ViewModelBase
    {
        private ObservableCollection<ChartDataPoint> data;
        private bool killThread = false;
        private int y;
        private int deviceNum = 9;

        public CpuViewModel(int deviceNum)
        {
            this.deviceNum = deviceNum;
            y = 0;
            Data = new ObservableCollection<ChartDataPoint>();
            LoadData();
        }

        private static int deviceNo = 0;

        private string pom = GetTelemetry.lastTelemetryDatapoints[deviceNo].Percent;
        private string percent = GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu;
        private string speed = GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu2;
        private string processes = GetTelemetry.lastTelemetryDatapoints[deviceNo].Processes;
        private string threads = GetTelemetry.lastTelemetryDatapoints[deviceNo].Thread;
        private string temperature = GetTelemetry.lastTelemetryDatapoints[deviceNo].CpuTem;

        public ObservableCollection<ChartDataPoint> Data
        {
            set { SetProperty(ref data, value); }
            get { return data; }
        }

        public string Percent
        {
            set { SetProperty(ref percent, value + "%"); }
            get { return percent; }
        }

        public string Speed
        {
            set { SetProperty(ref speed, value + "Mhz"); }
            get { return speed; }
        }

        public string Processes
        {
            set { SetProperty(ref processes, value); }
            get { return processes; }
        }

        public string Threads
        {
            set { SetProperty(ref threads, value); }
            get { return threads; }
        }

        public string Temperature
        {
            set { SetProperty(ref temperature, value + "°C"); }
            get { return temperature; }
        }

        public string PoM
        {
            set { SetProperty(ref pom, value + "%"); }
            get { return pom; }
        }

        public void StopUpdate()
        {
            killThread = true;
        }

        private async void LoadData()
        {
            y = 0;
            //Iterating the queue of telemetry objects, adding to the chart collection
            foreach (var telemetry in GetTelemetry.listOfDevices[deviceNum])
            {
                data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Cpu)));
                y++;
            }
            await Task.Delay(1000);

            //Updates the information onece a second
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
            {
                y++;
                System.Diagnostics.Debug.WriteLine("cpu" + y);

                double cpuValue = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNum].Cpu);
                Processes = GetTelemetry.lastTelemetryDatapoints[deviceNum].Processes;
                Threads = GetTelemetry.lastTelemetryDatapoints[deviceNum].Thread;
                Temperature = GetTelemetry.lastTelemetryDatapoints[deviceNum].CpuTem;
                Percent = GetTelemetry.lastTelemetryDatapoints[deviceNum].Cpu;
                Speed = GetTelemetry.lastTelemetryDatapoints[deviceNum].Cpu2;
                PoM = GetTelemetry.lastTelemetryDatapoints[deviceNum].Percent;
                Data.RemoveAt(0);
                Data.Add(new ChartDataPoint(y, cpuValue));
                if (killThread)
                {
                    return false;
                }
                return true;
            });
        }
    }
}