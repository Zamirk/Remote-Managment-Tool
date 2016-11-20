using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
	public class OverviewScreen : Grid
    {
        public OverviewScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});

            SfDataGrid sDataGrid;
            sDataGrid = new SfDataGrid();
            sDataGrid.ItemsSource = new OrderInfoRepository().OrderInfoCollection;

            //sfGrid.DefaultColumnWidth = 200;
            sDataGrid.AllowDraggingColumn = true;
            sDataGrid.AutoExpandGroups = true;
            sDataGrid.GridStyle = new DataGridStyle() { AlternatingRowColor = Color.Gray };

            sDataGrid.ColumnSizer = ColumnSizer.Star;
            //sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.Bounce;
            Children.Add(sDataGrid, 1, 1);

        }
    }
}
