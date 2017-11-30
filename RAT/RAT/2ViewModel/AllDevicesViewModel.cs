using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using CoffeeCups.Helpers;
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
            try
            {
                //Initial data
                //int processesCount = GetTelemetry.lastReceivedValue.ListTest.Count;
                int devicesCount = GetTelemetry.listOfDevices.Count;

                //Initial collection of empty objects displayed
                for (int i = 0; i < 10; i++)
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
                              data.Add(new Processes());
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
            catch (Exception e)
            {
                await App.Current.MainPage.DisplayAlert("Connection Error", "Please restart the application", "OK");
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;
            }
        }

        public void GC()
        {
            collectGarbage = true;
        }
    }
}