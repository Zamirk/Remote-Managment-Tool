using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using RAT._2ViewModel.Test;
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
	public class OverviewAllScreen : Grid
	{
        public OverviewAllScreen()
        {
            OverviewViewModel viewModel = new OverviewViewModel();
            BindingContext = viewModel;

            VerticalOptions = LayoutOptions.FillAndExpand;
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            SfDataGrid sDataGrid;
            sDataGrid = new SfDataGrid();

            //sfGrid.DefaultColumnWidth = 200;
            sDataGrid.AllowDraggingColumn = true;
            sDataGrid.AutoExpandGroups = true;
            sDataGrid.GridStyle = new DataGridStyle() { AlternatingRowColor = Color.Gray };
            sDataGrid.ColumnSizer = ColumnSizer.Star;
            //sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.Bounce;

            //Binding
            sDataGrid.ItemsSource = viewModel.Stocks;
            Children.Add(sDataGrid, 1, 1);

        }
        }
}
