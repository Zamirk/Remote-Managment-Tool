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
        public  bool collectGarbage = false;
        ObservableCollection<ProcessTest> data;

        public AllDevicesViewModel()
        {
            data = new ObservableCollection<ProcessTest>();
            LoadData();
        }

        public ObservableCollection<ProcessTest> Data
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
            for (int i = 0; i < 5; i++)
            {
                data.Add(new ProcessTest());
            }

            //Updating the empty objects with data
            for (int i = 0; i < devicesCount; i++)
            {
                Data[i].Name = GetTelemetry.lastReceivedValue.Device_id;
                Data[i].Cpu = GetTelemetry.lastReceivedValue.Cpu;
                Data[i].Memory = GetTelemetry.lastReceivedValue.Ram;
                Data[i].Time = GetTelemetry.lastReceivedValue.DiskTime;
                Data[i].CustomerID = GetTelemetry.lastReceivedValue.Bandwidth;
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
                    Data[i].Name = GetTelemetry.lastReceivedValue.Device_id;
                    Data[i].Cpu = GetTelemetry.lastReceivedValue.Cpu;
                    Data[i].Memory = GetTelemetry.lastReceivedValue.Ram;
                    Data[i].Time = GetTelemetry.lastReceivedValue.DiskTime;
                    Data[i].CustomerID = GetTelemetry.lastReceivedValue.Bandwidth;
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
