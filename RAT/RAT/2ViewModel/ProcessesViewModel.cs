using System;
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

        private async void LoadData()
        {
            for (int i = 0; i < 200; i++){ data.Add(new ProcessTest()); }

            //Initial data
            int processesCount = GetTelemetry.lastReceivedValue.ListTest.Count;
            for (int i = 0; i < processesCount; i++)
            {
                Data[i].Name = GetTelemetry.lastReceivedValue.ListTest[i].N;
                Data[i].Memory = GetTelemetry.lastReceivedValue.ListTest[i].M;
            }
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                //If it is time to end the loop
                if (collectGarbage)
                {
                    return false;
                }
                processesCount = GetTelemetry.lastReceivedValue.ListTest.Count;


                //Updating the grid
                for (int i = 0; i < processesCount; i++)
                {
                    Data[i].Name = GetTelemetry.lastReceivedValue.ListTest[i].N;
                    Data[i].Cpu = GetTelemetry.lastReceivedValue.ListTest[i].C;
                    Data[i].Memory = GetTelemetry.lastReceivedValue.ListTest[i].M;
                    Data[i].Time = GetTelemetry.lastReceivedValue.ListTest[i].T;
                    Data[i].CustomerID = GetTelemetry.lastReceivedValue.ListTest[i].N;

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
