using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using RAT.Syncfusion;
using RAT._1View.Desktop.Screens.SubScreens;
using RAT._2ViewModel.Test;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;
using Label = Xamarin.Forms.Label;

namespace RAT._1View.Desktop.Manage
{
	public class ViewDevicesScreen : Grid
	{
	    public Button pcOne;
        public ViewDevicesScreen()
        {
            ViewDevicesViewModel viewModel = new ViewDevicesViewModel();
            BindingContext = viewModel;

            VerticalOptions = LayoutOptions.FillAndExpand;
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            SfDataGrid sDataGrid = new SfDataGrid();
            
            sDataGrid.AutoGenerateColumns = false;
            sDataGrid.ColumnSizer = ColumnSizer.Star;
            //sDataGrid.SelectionMode = SelectionMode.Single;

            sDataGrid.HeaderRowHeight = 55;
            sDataGrid.AllowDraggingColumn = true;
            sDataGrid.AutoExpandGroups = true;
            sDataGrid.VerticalOverScrollMode = VerticalOverScrollMode.Bounce;
            sDataGrid.GridStyle = new DataGridStyle() { AlternatingRowColor = Color.Gray };

            GridTextColumn column_1 = new GridTextColumn() { MappingName = "A", HeaderText = "Device Id"};
            GridTextColumn column_2 = new GridTextColumn() { MappingName = "A", HeaderText = "CPU" };
            GridTextColumn column_3 = new GridTextColumn() { MappingName = "A", HeaderText = "Ram" };
            GridTextColumn column_4 = new GridTextColumn() { MappingName = "A", HeaderText = "Disk" };
            GridTextColumn column_5 = new GridTextColumn() { MappingName = "A", HeaderText = "Network" };
            GridTextColumn testColumn = new GridTextColumn() { MappingName = "A", HeaderText = "" };
            GridTemplateColumn custColumn = new GridTemplateColumn() { MappingName = "A", HeaderText = "B"};

            custColumn.CellTemplate = new DataTemplate(() =>
            {
                Grid myGrid = new Grid();
                Button aaaa = new Button();
                aaaa.BackgroundColor = Color.Black;
                aaaa.TextColor = Color.White;
                aaaa.Text = "View";
                myGrid.Children.Add(aaaa);
                
                return myGrid;
            });

            sDataGrid.Columns.Add(column_1);
            sDataGrid.Columns.Add(column_2);
            sDataGrid.Columns.Add(column_3);
            sDataGrid.Columns.Add(column_4);
            sDataGrid.Columns.Add(column_5);
            sDataGrid.Columns.Add(custColumn);
            sDataGrid.ItemsSource = viewModel.data;

            Children.Add(sDataGrid, 1, 1);

            pcOne = new Button();
            pcOne.Text = "Computer 1";
            pcOne.FontSize = 20;
            pcOne.VerticalOptions = LayoutOptions.Center;
            pcOne.HorizontalOptions = LayoutOptions.CenterAndExpand;
            pcOne.BorderColor = Color.Transparent;
            pcOne.BorderWidth = .000001;
            pcOne.WidthRequest = 200;
            pcOne.HeightRequest = 200;
            pcOne.Margin = new Thickness(50, 50, 0, 0);
            pcOne.BackgroundColor = Color.Gray;

            //Children.Add(pcOne, 1, 0);
        }
    }
}
