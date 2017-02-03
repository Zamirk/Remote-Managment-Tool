using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
	public class OverviewScreen : Grid
	{
	    private Editor aaaa;

        public OverviewScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            aaaa = new Editor();
            aaaa.HorizontalOptions = LayoutOptions.CenterAndExpand;
            aaaa.VerticalOptions = LayoutOptions.CenterAndExpand;
            aaaa.HeightRequest = 2000;
            aaaa.WidthRequest = 1000;

            Children.Add(aaaa);
            Button send = new Button();
            send.Text = "Command Test";
            Children.Add(send);
            
            send.VerticalOptions = LayoutOptions.Center;
            send.HorizontalOptions = LayoutOptions.Center;
            send.Clicked += clicked;

            //Label myLabel;
            //myLabel = new Label();
            //myLabel.Text = "Single Device: Overview Screen";
            //Children.Add(myLabel, 1, 1);

            //SfKanban kanban = new SfKanban();
            //KanbanViewModel aaa = new KanbanViewModel();
            // kanban.ItemsSource = aaa.Cards;
            // Children.Add(kanban);
            //  Image beachImage = new Image { Aspect = Aspect.AspectFit };
            //beachImage.Source = "Assets/PC.png";
            //Children.Add(beachImage);

            // Button buttonTest = new Button();
            //buttonTest.Text = "Test Button";
            // buttonTest.BorderRadius = 10;
            //buttonTest.BackgroundColor = Color.Green;
            //buttonTest.BorderColor = Color.Red;
            //buttonTest.Image = new FileImageSource() {File = "Assets/PC.png"};

            //Children.Add(buttonTest);
            //buttonTest.Image.File = "Assets/PC.png";
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
                aaaa.Text = "Receiving Data";
            worker.RunWorkerAsync(10000);

        }
        //static string ConnectionString =
        //   "Endpoint=sb://ihsuproddbres040dednamespace.servicebus.windows.net/;" +
        //   "SharedAccessKeyName=iothubowner;" +
        //   "SharedAccessKey=KHMmYzPNmQ4I9b3RWXXAwz/8Tz3tg+8tOpC64BW/uKs=";

        // static string eventHubEntity = "iothub-ehub-qwertytest-109555-608ad40157";
        //static string partitionId = "1";

        static string ConnectionString = "Endpoint=sb://iothub-ns-manageiot-107893-aab55f8a1a.servicebus.windows.net/;" +
                             "SharedAccessKeyName=iothubowner;" +
                             "SharedAccessKey=1QnPUGMCx86KJRaOsIg5BvhJtww13EU6kzprCPSr/qs=";

        static string eventHubEntity = "ManageIoT";
        static string partitionId = "1";

        static DateTime startingDateTimeUtc;


        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //TODO Login
            //LoginValidate();
        }

	    private string b = "";

        private void clicked(object sender, EventArgs eventArgs)
    {

    }
}
}
