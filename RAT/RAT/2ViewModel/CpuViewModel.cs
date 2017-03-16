﻿using System;
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
        public CpuViewModel()
        {
            y = 0;
            Data = new ObservableCollection<ChartDataPoint>();
            LoadData();
        }
        private string pom = GetTelemetry.lastReceivedValue.Percent;
        private string percent = GetTelemetry.lastReceivedValue.Cpu;
        private string speed = GetTelemetry.lastReceivedValue.Cpu2;
        private string processes = GetTelemetry.lastReceivedValue.Processes;
        private string threads = GetTelemetry.lastReceivedValue.Thread;
        private string temperature = GetTelemetry.lastReceivedValue.CpuTem;

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
            foreach (var telemetry in GetTelemetry.listOfDevices[0])
            {
                    data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Cpu)));
                y++;
            }
            await Task.Delay(1000);

            //Updates the information onece a second
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
            {
                y++; System.Diagnostics.Debug.WriteLine("cpu" + y);

                double cpuValue = Convert.ToDouble(GetTelemetry.lastReceivedValue.Cpu);
                Processes = GetTelemetry.lastReceivedValue.Processes;
                Threads = GetTelemetry.lastReceivedValue.Thread;
                Temperature = GetTelemetry.lastReceivedValue.CpuTem;
                Percent = GetTelemetry.lastReceivedValue.Cpu;
                Speed = GetTelemetry.lastReceivedValue.Cpu2;
                PoM = GetTelemetry.lastReceivedValue.Percent;
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
