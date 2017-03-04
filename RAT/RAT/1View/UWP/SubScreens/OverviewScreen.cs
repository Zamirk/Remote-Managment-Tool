using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Folder;
using RAT.Services;
using RAT._1View.Desktop.Screens.SubScreens._1Manage;
using SampleBrowser;
using ServerMonitor;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.SfKanban.XForms;
using Xamarin.Forms;
using ChartDataPoint = Syncfusion.SfChart.XForms.ChartDataPoint;
using FastLineSeries = Syncfusion.SfChart.XForms.FastLineSeries;
using NumericalAxis = Syncfusion.SfChart.XForms.NumericalAxis;
using SfChart = Syncfusion.SfChart.XForms.SfChart;

namespace RAT._1View.Desktop
{
    public partial class OverviewScreen : Grid
    {
        bool succeeded = false;
        private Editor myEditor;
        public OverviewScreen()
        {
            string myString = "";
            myEditor = new Editor();
            Children.Add(myEditor);
            myEditor.Text = "Receiving Data!";
            myEditor.Text = GetTelemetry.aaaaa;


            WaitForItToWork();

        }
        public void GC()
        {
            succeeded = true;
        }

        async Task<bool> WaitForItToWork()
        {
            while (!succeeded)
            {
                myEditor.Text = GetTelemetry.aaaaa;
                await Task.Delay(1000); // arbitrary delay
            }
            return succeeded;
        }
    }
}
