﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApplication1;
using ConsoleApplication1.Folder;
using RAT.Model;
using SampleBrowser;
using Syncfusion.SfChart.XForms;
using Tools;
using Xamarin.Forms;

namespace RAT._2ViewModel
{
    public class ProcessesViewModel : ViewModelBase
    {
        public bool collectGarbage = false;
        ObservableCollection<ProcessTest> data;

        public ProcessesViewModel()
        {
            data = new ObservableCollection<ProcessTest>();
            LoadData();
        }

        public ObservableCollection<ProcessTest> Data
        {
            set { SetProperty(ref data, value); }
            get { return data; }
        }

        private static int deviceNo = 0;

        private async void LoadData()
        {
            //Initial data
            int processesCount = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest.Count;

            //Initial collection of empty objects displayed
            for (int i = 0; i < processesCount; i++)
            {
                data.Add(new ProcessTest());
            }

            //Updating the empty objects with data
            for (int i = 0; i < processesCount; i++)
            {
                Data[i].Name = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest[i].N;
                Data[i].Cpu = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest[i].C;
                Data[i].Memory = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest[i].M;
                Data[i].Time = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest[i].T;
                Data[i].CustomerID = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest[i].N;
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
                processesCount = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest.Count;

                //Resizing the size of the grid relative to the size of the processes
                if (data.Count < processesCount)
                {
                    while (data.Count < processesCount)
                    {
                        data.Add(new ProcessTest());
                    }
                } else if (processesCount < data.Count)
                {
                    while (processesCount < data.Count)
                    {
                        data.RemoveAt(data.Count -1);
                    }
                }
                    
                //Updating the grid with data
                for (int i = 0; i < processesCount; i++)
                {
                    Data[i].Name = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest[i].N;
                    Data[i].Cpu = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest[i].C;
                    Data[i].Memory = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest[i].M;
                    Data[i].Time = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest[i].T;
                    Data[i].CustomerID = GetTelemetry.lastTelemetryDatapoints[deviceNo].ListTest[i].N;
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
