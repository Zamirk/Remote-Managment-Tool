﻿using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;
using RAT._2ViewModel.Test;

namespace RAT._1View.Desktop
{
	public class OverviewScreen : Grid
    {
        public OverviewScreen()
        {
            OverviewViewModel viewModel = new OverviewViewModel();
            BindingContext = viewModel;

            VerticalOptions = LayoutOptions.FillAndExpand;
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});

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