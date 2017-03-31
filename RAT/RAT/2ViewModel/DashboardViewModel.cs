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
    public class DashboardViewModel : ViewModelBase
    {
        private ObservableCollection<ChartDataPoint> data;
        private bool killThread = false;
        private int y;
        public DashboardViewModel()
        {
            y = 0;
            Data = new ObservableCollection<ChartDataPoint>();
        }

        private static int deviceNo = 0;

        public ObservableCollection<ChartDataPoint> Data
        {
            set { SetProperty(ref data, value); }
            get { return data; }
        }

        public void GC()
        {
            killThread = true;
        }

        public async void Load1()
        {
            y = 0;
            //Iterating over the queue of telemetry obects, adding to the chart databound collection
            foreach (var telemetry in GetTelemetry.listOfDevices[0])
            {
                    data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Cpu)));
                y++;
            }
            await Task.Delay(1000);

            //Updates the information onece a second
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
            {
                Data.RemoveAt(0);
                y++;
                System.Diagnostics.Debug.WriteLine("cpu" + y);

                double cpuValue = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu);
                Data.Add(new ChartDataPoint(y, cpuValue));
                if (killThread)
                {
                    return false;
                }
                return true;
            });
        }

        public async void Load2()
        {
            //Initial value
            data.Add(new ChartDataPoint(0, Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo])));

            await Task.Delay(1000);

            //Updates the information onece a second
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
            {
                Data.RemoveAt(0);
                Data.Add(new ChartDataPoint(0, Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo])));
                if (killThread)
                {
                    return false;
                }
                return true;
            });
        }
    }
}
