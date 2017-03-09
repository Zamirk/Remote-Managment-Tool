using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAT.ZTry;
using RAT._2ViewModel;
using RAT._2ViewModel.Test;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class Processes : Grid
    {
        int fontSize = 13;
        ProcessesViewModel viewModel;

        public Processes()
        {
            Children.Add(new Label() { Text = "Processes" });
            viewModel = new ProcessesViewModel();
            BindingContext = viewModel;

            VerticalOptions = LayoutOptions.FillAndExpand;
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            SfDataGrid sDataGrid;
            sDataGrid = new SfDataGrid();

            //sfGrid.DefaultColumnWidth = 200;
            sDataGrid.AllowDraggingColumn = true;
            sDataGrid.AutoExpandGroups = true;
            sDataGrid.ColumnSizer = ColumnSizer.Star;
            sDataGrid.VerticalOverScrollMode = VerticalOverScrollMode.Bounce;

            //sDataGrid.GridStyle = new DataGridStyle() { AlternatingRowColor = Color.Gray };
            sDataGrid.HeaderRowHeight = 15;
            sDataGrid.RowHeight = 20;
            

            //Binding
            sDataGrid.ItemsSource = viewModel.Data;
            Children.Add(sDataGrid, 1, 1);
        }

        public void GC()
        {
            viewModel.GC();
        }
    }
}