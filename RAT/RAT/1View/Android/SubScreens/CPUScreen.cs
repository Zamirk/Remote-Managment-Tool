using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using RAT.Services.IoT;
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

namespace Mobile
{
	public class CPUScreen : Grid
	{
	    private CpuViewModel myViewModel;
	    private SfChart myChart;
        public CPUScreen()
        {
            myViewModel = new CpuViewModel();
            BindingContext = myViewModel;

            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            RowDefinitions.Add(new RowDefinition { Height = 200 });
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            //Chart
            myChart = new SfChart();

            myChart.Series.Add(new SplineSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;
            myChart.Series[0].ItemsSource = myViewModel.Data;

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();

            (myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;
            Children.Add(myChart, 0, 0);

            int col1 = 25;
            int col2 = 145;
            int col22 = 255;
            int col3 = 400;

            //Part 1
            Label utilizationLabel;
            utilizationLabel = new Label();
            utilizationLabel.Text = "Utilization";
            utilizationLabel.Margin = new Thickness(col1, 20, 0, 0);

            Label uLive;
            uLive = new Label();
            uLive.Text = "38%";
            uLive.FontSize = 22;
            uLive.Margin = new Thickness(col1, 35, 0, 0);
            uLive.SetBinding(Label.TextProperty, "Percent");

            //Part 2
            Label speedLabel;
            speedLabel = new Label();
            speedLabel.Text = "Speed";
            speedLabel.Margin = new Thickness(col2, 20, 0, 0);

            Label sLive;
            sLive = new Label();
            sLive.Text = "2.5Ghz";
            sLive.FontSize = 22;
            sLive.Margin = new Thickness(col2, 35, 0, 0);
            sLive.SetBinding(Label.TextProperty, "Speed");

            //Second Column
            Label processesLabel;
            processesLabel = new Label();
            processesLabel.Text = "Processes";
            processesLabel.Margin = new Thickness(col1, 75, 0, 0);

            Label pLive;
            pLive = new Label();
            pLive.Text = "120";
            pLive.FontSize = 22;
            pLive.Margin = new Thickness(col1, 90, 0, 0);
            pLive.SetBinding(Label.TextProperty, "Processes");

            //Part 4
            Label threadsLabel;
            threadsLabel = new Label();
            threadsLabel.Text = "Threads";
            Children.Add(threadsLabel, 0, 1);
            threadsLabel.Margin = new Thickness(col2, 75, 0, 0);

            Label tlive;
            tlive = new Label();
            tlive.Text = "2400";
            tlive.FontSize = 22;
            Children.Add(tlive, 0, 1);
            tlive.Margin = new Thickness(col2, 90, 0, 0);
            tlive.SetBinding(Label.TextProperty, "Threads");

            //Part 5
            Label temperatureLabel;
            temperatureLabel = new Label();
            temperatureLabel.Text = "Temperature";
            Children.Add(temperatureLabel, 0, 1);
            temperatureLabel.Margin = new Thickness(col1, 130, 0, 0);

            Label tmplive;
            tmplive = new Label();
            tmplive.Text = "0";
            tmplive.FontSize = 22;
            Children.Add(tmplive, 0, 1);
            tmplive.Margin = new Thickness(col1, 145, 0, 0);
            tmplive.SetBinding(Label.TextProperty, "Temperature");

            Label percentOfMaxLabel;
            percentOfMaxLabel = new Label();
            percentOfMaxLabel.Text = "Percent of Max";
            Children.Add(percentOfMaxLabel, 0, 1);
            percentOfMaxLabel.Margin = new Thickness(col22, 20, 0, 0);

            Label pomlive;
            pomlive = new Label();
            pomlive.Text = "0";
            pomlive.FontSize = 22;
            Children.Add(pomlive, 0, 1);
            pomlive.Margin = new Thickness(col22, 35, 0, 0);
            pomlive.SetBinding(Label.TextProperty, "PoM");

            //Third Column
            Label maxSpeedLabel;
            maxSpeedLabel = new Label();
            maxSpeedLabel.Text = "Maximum Speed:";
            Children.Add(maxSpeedLabel, 0, 1);
            maxSpeedLabel.Margin = new Thickness(col3, 20, 0, 0);

            Label socketsLabel;
            socketsLabel = new Label();
            socketsLabel.Text = "Sockets:";
            Children.Add(socketsLabel, 0, 1);
            socketsLabel.Margin = new Thickness(col3, 40, 0, 0);

            Label coresLabel;
            coresLabel = new Label();
            coresLabel.Text = "Cores:";
            Children.Add(coresLabel, 0, 1);
            coresLabel.Margin = new Thickness(col3, 60, 0, 0);

            Label logicalCoresLabel;
            logicalCoresLabel = new Label();
            logicalCoresLabel.Text = "Logical Cores:";
            Children.Add(logicalCoresLabel, 0, 1);
            logicalCoresLabel.Margin = new Thickness(col3, 80, 0, 0);

            Label l1;
            l1 = new Label();
            l1.Text = "L1 Cache:\t100";
            Children.Add(l1, 0, 1);
            l1.Margin = new Thickness(col3, 100, 0, 0);

            Label l2;
            l2 = new Label();
            l2.Text = "L2 Cache:\t100";
            Children.Add(l2, 0, 1);
            l2.Margin = new Thickness(col3, 120, 0, 0);

            Label l3;
            l3 = new Label();
            l3.Text = "L3 Cache:\t100";
            Children.Add(l3, 0, 1);
            l3.Margin = new Thickness(col3, 140, 0, 0);

            //CPU Type
            Label cpuLabel;
            cpuLabel = new Label();
            cpuLabel.Text = "intel(r) core(tm) i5-2400 cpu @ 1.70ghz";
            cpuLabel.HorizontalOptions = LayoutOptions.End;

            Children.Add(cpuLabel, 0, 1);
            Children.Add(pLive, 0, 1);
            Children.Add(processesLabel, 0, 1);
            Children.Add(sLive, 0, 1);
            Children.Add(utilizationLabel, 0, 1);
            Children.Add(uLive, 0, 1);
            Children.Add(speedLabel, 0, 1);
        }
	    public void GC()
	    {
	        myViewModel.StopUpdate();
	        myChart.Series[0].ItemsSource = null;
	    }
    }
}
