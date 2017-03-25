using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SampleBrowser;
using RAT.Model;
using ConsoleApplication1.Folder;
using Xamarin.Forms;
using Tools;

namespace RAT._1View.Desktop.Screens.SubScreens
{
    class AllDevicesViewModel : ViewModelBase
    {
        public bool collectGarbage = false;
        ObservableCollection<DeviceSummary> data;

        public AllDevicesViewModel()
        {
            data = new ObservableCollection<DeviceSummary>();
            LoadData();
        }

        public ObservableCollection<DeviceSummary> Data
        {
            set { SetProperty(ref data, value); }
            get { return data; }
        }

        private async void LoadData()
        {
            //Initial data
            //int processesCount = GetTelemetry.lastReceivedValue.ListTest.Count;
            int devicesCount = GetTelemetry.listOfDevices.Count;

            //Initial collection of empty objects displayed
            //TODO Hardcoding empty values for now
            for (int i = 0; i < 5; i++)
            {
                data.Add(new DeviceSummary());
            }

            //Updating the empty objects with data
            for (int i = 0; i < devicesCount; i++)
            {
                Data[i].Name = GetTelemetry.lastTelemetryDatapoints[i].Device_id;
                Data[i].Cpu = GetTelemetry.lastTelemetryDatapoints[i].Cpu;
                Data[i].Memory = GetTelemetry.lastTelemetryDatapoints[i].Ram;
                Data[i].Disk = GetTelemetry.lastTelemetryDatapoints[i].DiskTime;
                Data[i].Wifi = GetTelemetry.lastTelemetryDatapoints[i].Bandwidth;
            }

            //Updating the data in the grid once a second
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                //If it is time to end the loop
                if (collectGarbage)
                {
                    return false;
                }

                //Getting current number of processes
                //processesCount = GetTelemetry.lastReceivedValue.ListTest.Count;

                //Resizing the size of the grid relative to the size of the processes
              /*  if (data.Count < processesCount)
                {
                    while (data.Count < processesCount)
                    {
                        data.Add(new ProcessTest());
                    }
                }
                else if (processesCount < data.Count)
                {
                    while (processesCount < data.Count)
                    {
                        data.RemoveAt(data.Count - 1);
                    }
                }
                */

                //Updating the grid with data
                for (int i = 0; i < devicesCount; i++)
                {
                    Data[i].Name = GetTelemetry.lastTelemetryDatapoints[i].Device_id;
                    Data[i].Cpu = GetTelemetry.lastTelemetryDatapoints[i].Cpu;
                    Data[i].Memory = GetTelemetry.lastTelemetryDatapoints[i].Ram;
                    Data[i].Disk = GetTelemetry.lastTelemetryDatapoints[i].DiskTime;
                    Data[i].Wifi = GetTelemetry.lastTelemetryDatapoints[i].Bandwidth;
                }
                return true;
            });
        }
        public void GC()
        {
            collectGarbage = true;
        }
    }
}
