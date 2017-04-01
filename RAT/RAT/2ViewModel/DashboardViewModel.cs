using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApplication1;
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

        public ObservableCollection<ChartDataPoint> Data
        {
            set { SetProperty(ref data, value); }
            get { return data; }
        }

        public void GC()
        {
            killThread = true;
        }

        //Passing in device and data selection from graph selection screen
        public async void LoadMultipleValues(int deviceNo, int dataSelection)
        {
            y = 0;
            if (dataSelection == 0)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
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

                    var cpuValue = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu);
                    Data.Add(new ChartDataPoint(y, cpuValue));
                    if (killThread)
                        return false;
                    return true;
                });
            }
            else if (dataSelection == 1)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Cpu2)));
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var cpuValue = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu2);
                    Data.Add(new ChartDataPoint(y, cpuValue));
                    if (killThread)
                        return false;
                    return true;
                });
            }
        }

        public async void LoadSingleValues(int deviceNo, int dataSelection)
        {
            //Initial value
            //TODO CHANGE
            double cpuUsage = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu);
            double restOfSpace = 100 - cpuUsage;

            Data.Add(new ChartDataPoint("CPU %", cpuUsage));
            Data.Add(new ChartDataPoint("Empty Space", restOfSpace));
            await Task.Delay(1000);

            //Updates the information onece a second
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
            {
                Data.RemoveAt(0);
                Data.RemoveAt(0);
                Data.Add(new ChartDataPoint("CPU %", Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu)));
                restOfSpace = 100 - cpuUsage;
                Data.Add(new ChartDataPoint("Empty Space", restOfSpace));
                if (killThread)
                {
                    return false;
                }
                return true;
            });
        }
        
    }
}
