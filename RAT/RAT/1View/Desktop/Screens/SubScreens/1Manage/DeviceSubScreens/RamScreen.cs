using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
	public class RamScreen : Grid
	{
        public RamScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            RowDefinitions.Add(new RowDefinition { Height = 200 });
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            SfChart myChart = new SfChart();

            myChart.Series.Add(new StepAreaSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.Series[0].ItemsSource = getData();

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;

            Children.Add(myChart, 0, 0);

            int col1 = 25;
            int col2 = 145;
            int col3 = 285;

            //Column One
            //Part 1
            Label inUseLabel;
            inUseLabel = new Label();
            inUseLabel.Text = "In Use";
            inUseLabel.Margin = new Thickness(col1, 20, 0, 0);

            Label inUseLive;
            inUseLive = new Label();
            inUseLive.Text = "4.4GB";
            inUseLive.FontSize = 22;
            inUseLive.Margin = new Thickness(col1, 35, 0, 0);

            //Part 2
            Label committedLabel;
            committedLabel = new Label();
            committedLabel.Text = "Committed";
            committedLabel.Margin = new Thickness(col1, 75, 0, 0);

            Label cLive;
            cLive = new Label();
            cLive.Text = "3.5/5.8GB";
            cLive.FontSize = 22;
            cLive.Margin = new Thickness(col1, 90, 0, 0);

            //Part 3
            Label pagedLabel;
            pagedLabel = new Label();
            pagedLabel.Text = "Paged Pool";
            pagedLabel.Margin = new Thickness(col1, 130, 0, 0);

            Label paLive;
            paLive = new Label();
            paLive.Text = "100mb";
            paLive.FontSize = 22;
            paLive.Margin = new Thickness(col1, 145, 0, 0);

            //Second Column
            //Part 1
            Label availableLabel;
            availableLabel = new Label();
            availableLabel.Text = "Not in use";
            availableLabel.Margin = new Thickness(col2, 20, 0, 0);

            Label pLive;
            pLive = new Label();
            pLive.Text = "120";
            pLive.FontSize = 22;
            pLive.Margin = new Thickness(col2, 35, 0, 0);

            //Part 2
            Label cachedLabel;
            cachedLabel = new Label();
            cachedLabel.Text = "Cached";
            Children.Add(cachedLabel, 0, 1);
            cachedLabel.Margin = new Thickness(col2, 75, 0, 0);

            Label caLive;
            caLive = new Label();
            caLive.Text = "24GB";
            caLive.FontSize = 22;
            Children.Add(caLive, 0, 1);
            caLive.Margin = new Thickness(col2, 90, 0, 0);

            //Part 3
            Label nonPagedLabel;
            nonPagedLabel = new Label();
            nonPagedLabel.Text = "Non Paged Pool";
            Children.Add(nonPagedLabel, 0, 1);
            nonPagedLabel.Margin = new Thickness(col2, 130, 0, 0);

            Label npLive;
            npLive = new Label();
            npLive.Text = "24GB";
            npLive.FontSize = 22;
            Children.Add(npLive, 0, 1);
            npLive.Margin = new Thickness(col2, 145, 0, 0);

            //Third Column
            Label maxSpeedLabel;
            maxSpeedLabel = new Label();
            maxSpeedLabel.Text = "Max Speed:";
            Children.Add(maxSpeedLabel, 0, 1);
            maxSpeedLabel.Margin = new Thickness(col3, 20, 0, 0);

            Label currentSpeedLabel;
            currentSpeedLabel = new Label();
            currentSpeedLabel.Text = "Current Speed:";
            Children.Add(currentSpeedLabel, 0, 1);
            currentSpeedLabel.Margin = new Thickness(col3, 40, 0, 0);

            Label slotsLabel;
            slotsLabel = new Label();
            slotsLabel.Text = "Slots Used:";
            Children.Add(slotsLabel, 0, 1);
            slotsLabel.Margin = new Thickness(col3, 60, 0, 0);

            Label formFactor;
            formFactor = new Label();
            formFactor.Text = "Form Factor:";
            Children.Add(formFactor, 0, 1);
            formFactor.Margin = new Thickness(col3, 80, 0, 0);

            Label hardwarReserved;
            hardwarReserved = new Label();
            hardwarReserved.Text = "Hardware Reserved:";
            Children.Add(hardwarReserved, 0, 1);
            hardwarReserved.Margin = new Thickness(col3, 100, 0, 0);

            //CPU Type
            Label ramLabel;
            ramLabel = new Label();
            ramLabel.Text = "8.0GB DDR3 Ram";
            ramLabel.HorizontalOptions = LayoutOptions.End;

            Children.Add(ramLabel, 0, 1);
            Children.Add(pLive, 0, 1);
            Children.Add(inUseLabel, 0, 1);
            Children.Add(inUseLive, 0, 1);
            Children.Add(committedLabel, 0, 1);
            Children.Add(cLive, 0, 1);
            Children.Add(availableLabel, 0, 1);
            Children.Add(pagedLabel, 0, 1);
            Children.Add(paLive, 0, 1);
        }

        private ObservableCollection<ChartDataPoint> getData()
        {
            ObservableCollection<ChartDataPoint> datas = new ObservableCollection<ChartDataPoint>();
            datas.Add(new ChartDataPoint(1, 34));
            datas.Add(new ChartDataPoint(2, 24));
            datas.Add(new ChartDataPoint(3, 19));
            datas.Add(new ChartDataPoint(4, 21));
            datas.Add(new ChartDataPoint(5, 25));
            datas.Add(new ChartDataPoint(6, 15));
            datas.Add(new ChartDataPoint(7, 34));
            datas.Add(new ChartDataPoint(8, 24));
            datas.Add(new ChartDataPoint(9, 19));
            datas.Add(new ChartDataPoint(10, 21));
            datas.Add(new ChartDataPoint(11, 25));
            datas.Add(new ChartDataPoint(12, 76));
            datas.Add(new ChartDataPoint(13, 34));
            datas.Add(new ChartDataPoint(14, 24));
            datas.Add(new ChartDataPoint(15, 19));
            datas.Add(new ChartDataPoint(16, 21));
            datas.Add(new ChartDataPoint(17, 25));
            datas.Add(new ChartDataPoint(18, 32));
            datas.Add(new ChartDataPoint(19, 15));
            datas.Add(new ChartDataPoint(20, 32));
            datas.Add(new ChartDataPoint(21, 25));
            datas.Add(new ChartDataPoint(22, 32));
            datas.Add(new ChartDataPoint(23, 34));
            datas.Add(new ChartDataPoint(24, 24));
            datas.Add(new ChartDataPoint(25, 19));
            datas.Add(new ChartDataPoint(26, 21));
            datas.Add(new ChartDataPoint(27, 25));
            datas.Add(new ChartDataPoint(28, 32));
            datas.Add(new ChartDataPoint(29, 25));
            datas.Add(new ChartDataPoint(30, 32));
            datas.Add(new ChartDataPoint(31, 74));
            datas.Add(new ChartDataPoint(32, 32));
            datas.Add(new ChartDataPoint(33, 34));
            datas.Add(new ChartDataPoint(34, 24));
            datas.Add(new ChartDataPoint(35, 19));
            datas.Add(new ChartDataPoint(36, 21));
            datas.Add(new ChartDataPoint(37, 25));
            datas.Add(new ChartDataPoint(38, 32));
            datas.Add(new ChartDataPoint(39, 25));
            datas.Add(new ChartDataPoint(40, 32));
            return datas;
        }
    }
}

