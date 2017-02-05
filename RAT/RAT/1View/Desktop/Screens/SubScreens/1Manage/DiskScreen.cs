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
        public DiskScreen()
        {
            DiskViewModel myViewModel = new DiskViewModel();
            BindingContext = myViewModel;

            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = 150 });

            RowDefinitions.Add(new RowDefinition { Height = 200 });
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            //LineChart
            SfChart myChart = new SfChart();
            myChart.Series.Add(new LineSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].ItemsSource = myViewModel.Data;
            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;
            myChart.Series[0].EnableTooltip = true;
            myChart.Series[0].EnableDataPointSelection = true;
            myChart.Series[0].Label = "Time";

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;

            myChart.Series[0].Color = Color.Black;
            myChart.Series[0].ItemsSource = myViewModel.Data;

            //PieChart
            SfChart pieChart = new SfChart();
            pieChart.VerticalOptions = LayoutOptions.CenterAndExpand;
            pieChart.HorizontalOptions = LayoutOptions.CenterAndExpand;

            //pieSeries.ItemsSource = PieSeriesData;
            pieChart.Series.Add(new PieSeries());
            pieChart.Series[0].ItemsSource = myViewModel.PieData;
            pieChart.Series[0].EnableAnimation = true;
            pieChart.Series[0].AnimationDuration = 1;
            pieChart.Series[0].ListenPropertyChange = true;
            pieChart.Series[0].ColorModel.Palette = ChartColorPalette.TomatoSpectrum;

            Children.Add(pieChart, 1, 0);
            Children.Add(myChart, 0, 0);

            int col1 = 25;
            int col2 = 145;
            int col3 = 285;

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

            //Second Column
            //Part 1
            Label responceTime;
            responceTime = new Label();
            responceTime.Text = "Av.responce time";
            responceTime.Margin = new Thickness(col2, 20, 0, 0);

            Label responceTimeLive;
            responceTimeLive = new Label();
            responceTimeLive.Text = "0.2 ms";
            responceTimeLive.FontSize = 22;
            responceTimeLive.Margin = new Thickness(col2, 35, 0, 0);

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
            Children.Add(responceTimeLive, 0, 1);
            Children.Add(responceTime, 0, 1);
            Children.Add(readSpeedLive, 0, 1);
            Children.Add(readspeed, 0, 1);
            Children.Add(diskType, 0, 1);
            Children.Add(pageFile, 0, 1);
            Children.Add(systemDisk, 0, 1);
            Children.Add(formatted, 0, 1);
            Children.Add(capacity, 0, 1);
            Children.Add(diskHardware, 0, 1);
        }
    }
}
