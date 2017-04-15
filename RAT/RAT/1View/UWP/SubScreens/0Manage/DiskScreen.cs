using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using RAT._2ViewModel;
using SampleBrowser;
using ServerMonitor;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;
using ChartDataPoint = Syncfusion.SfChart.XForms.ChartDataPoint;
using FastLineSeries = Syncfusion.SfChart.XForms.FastLineSeries;
using NumericalAxis = Syncfusion.SfChart.XForms.NumericalAxis;
using SfChart = Syncfusion.SfChart.XForms.SfChart;

namespace RAT._1View.Desktop
{
	public class DiskScreen : Grid
	{
	    private DiskViewModel myViewModel;
	    private SfChart myChart;
	    private SfChart pieChart;
        private string deviceId = "";

        public DiskScreen(int deviceNum)
        {
            myViewModel = new DiskViewModel(deviceNum);
            BindingContext = myViewModel;

            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = 150 });

            RowDefinitions.Add(new RowDefinition { Height = 200 });
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            //LineChart
            myChart = new SfChart();
            myChart.Series.Add(new LineSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].ItemsSource = myViewModel.Data;

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            //(myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;

            //myChart.Series[0].Color = Color.Black;
            myChart.Series[0].ItemsSource = myViewModel.Data;

            //PieChart
            pieChart = new SfChart();
            pieChart.VerticalOptions = LayoutOptions.CenterAndExpand;
            pieChart.HorizontalOptions = LayoutOptions.CenterAndExpand;

            //pieSeries.ItemsSource = PieSeriesData;
            pieChart.Series.Add(new PieSeries());
            pieChart.Series[0].ItemsSource = myViewModel.PieData;
            pieChart.Series[0].ListenPropertyChange = true;
            pieChart.Series[0].ColorModel.Palette = ChartColorPalette.TomatoSpectrum;

            pieChart.Series[0].EnableAnimation = true;
            pieChart.Series[0].AnimationDuration = 1;
            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;
            Children.Add(pieChart, 1, 0);
            Children.Add(myChart, 0, 0);

            int col1 = 25;
            int col2 = 145;
            int col22 = 255;
            int col3 = 400;

            //Column One
            //Part 1
            Label activeTime;
            activeTime = new Label();
            activeTime.Text = "Active time";
            activeTime.Margin = new Thickness(col1, 20, 0, 0);

            Label activeTimeLive;
            activeTimeLive = new Label();
            activeTimeLive.Text = "1%";
            activeTimeLive.FontSize = 22;
            activeTimeLive.Margin = new Thickness(col1, 35, 0, 0);
            activeTimeLive.SetBinding(Label.TextProperty, "ActiveTime");

            Label freeMb;
            freeMb = new Label();
            freeMb.Text = "Free Mb";
            freeMb.Margin = new Thickness(col22, 20, 0, 0);

            Label fLive;
            fLive = new Label();
            fLive.Text = "";
            fLive.FontSize = 22;
            fLive.Margin = new Thickness(col22, 35, 0, 0);
            fLive.SetBinding(Label.TextProperty, "FreeMb");

            //Part 2
            Label freePercent;
            freePercent = new Label();
            freePercent.Text = "Free percent";
            freePercent.Margin = new Thickness(col22, 75, 0, 0);

            Label fpLive;
            fpLive = new Label();
            fpLive.Text = "";
            fpLive.FontSize = 22;
            fpLive.Margin = new Thickness(col22, 90, 0, 0);
            fpLive.SetBinding(Label.TextProperty, "FreeSpace");

            //Part 2
            Label readspeed;
            readspeed = new Label();
            readspeed.Text = "Read Speed";
            readspeed.Margin = new Thickness(col1, 75, 0, 0);

            Label readSpeedLive;
            readSpeedLive = new Label();
            readSpeedLive.Text = "0KB/s";
            readSpeedLive.FontSize = 22;
            readSpeedLive.Margin = new Thickness(col1, 90, 0, 0);
            readSpeedLive.SetBinding(Label.TextProperty, "DiskRead");

            //Part 2
            Label idleTime;
            idleTime = new Label();
            idleTime.Text = "Idle time";
            idleTime.Margin = new Thickness(col1, 130, 0, 0);
            Children.Add(idleTime, 0, 1);

            Label iLive;
            iLive = new Label();
            iLive.Text = "";
            iLive.FontSize = 22;
            iLive.Margin = new Thickness(col1, 145, 0, 0);
            iLive.SetBinding(Label.TextProperty, "IdleTime");
            Children.Add(iLive, 0, 1);

            //Second Column
            //Part 1
            Label readPercent;
            readPercent = new Label();
            readPercent.Text = "R: ";
            readPercent.Margin = new Thickness(col2, 20, 0, 0);
            Children.Add(readPercent, 0, 1);

            Label writePercent;
            writePercent = new Label();
            writePercent.Text = "W: ";
            writePercent.Margin = new Thickness(col2, 40, 0, 0);
            Children.Add(writePercent, 0, 1);

            Label rLive;
            rLive = new Label();
            rLive.Text = "";
            rLive.Margin = new Thickness(col2 + 20, 20, 0, 0);
            Children.Add(rLive, 0, 1);
            rLive.SetBinding(Label.TextProperty, "DiskReadTime");

            Label wLive;
            wLive = new Label();
            wLive.Text = "";
            wLive.Margin = new Thickness(col2 + 20, 40, 0, 0);
            Children.Add(wLive, 0, 1);
            wLive.SetBinding(Label.TextProperty, "DiskWriteTime");

            //Part 2
            Label writeSpeed;
            writeSpeed = new Label();
            writeSpeed.Text = "Write speed";
            writeSpeed.Margin = new Thickness(col2, 75, 0, 0);

            Label writeSpeedLive;
            writeSpeedLive = new Label();
            writeSpeedLive.Text = "0 KB/s";
            writeSpeedLive.FontSize = 22;
            writeSpeedLive.Margin = new Thickness(col2, 90, 0, 0);
            writeSpeedLive.SetBinding(Label.TextProperty, "DiskWrite");

            //Third Column
            Label capacity;
            capacity = new Label();
            capacity.Text = "Capacity: 556 GB";
            capacity.Margin = new Thickness(col3, 20, 0, 0);

            Label diskHardware;
            diskHardware = new Label();
            diskHardware.Text = "Type: SSD";
            diskHardware.Margin = new Thickness(col3, 40, 0, 0);

            Label formatted;
            formatted = new Label();
            formatted.Text = "Formatted: 466 GB";
            formatted.Margin = new Thickness(col3, 60, 0, 0);

            Label systemDisk;
            systemDisk = new Label();
            systemDisk.Text = "System disk: 466 GB";
            systemDisk.Margin = new Thickness(col3, 80, 0, 0);

            Label pageFile;
            pageFile = new Label();
            pageFile.Text = "Page File: Yes";
            pageFile.Margin = new Thickness(col3, 100, 0, 0);

            //DISK Type
            Label diskType;
            diskType = new Label();
            diskType.Text = "Samsung SSD 850 EVO 500GB";
            diskType.HorizontalOptions = LayoutOptions.End;

            Children.Add(activeTime, 0, 1);
            Children.Add(activeTimeLive, 0, 1);
            Children.Add(writeSpeedLive, 0, 1);
            Children.Add(writeSpeed, 0, 1);
            Children.Add(readSpeedLive, 0, 1);
            Children.Add(readspeed, 0, 1);
            Children.Add(freeMb, 0, 1);
            Children.Add(fLive, 0, 1);
            Children.Add(fpLive, 0, 1);
            Children.Add(freePercent, 0, 1);
            Children.Add(readSpeedLive, 0, 1);
            Children.Add(readspeed, 0, 1);
            Children.Add(diskType, 0, 1);
            Children.Add(pageFile, 0, 1);
            Children.Add(systemDisk, 0, 1);
            Children.Add(formatted, 0, 1);
            Children.Add(capacity, 0, 1);
            Children.Add(diskHardware, 0, 1);
        }
        public void GC()
        {
            myChart.Series[0].ItemsSource = null;
            pieChart.Series[0].ItemsSource = null;
            myViewModel.StopUpdate();
        }
    }
}
