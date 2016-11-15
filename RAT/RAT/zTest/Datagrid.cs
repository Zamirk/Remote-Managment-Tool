using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT.Syncfusion
{
	public class Datagrid : ContentPage
	{
		public Datagrid ()
		{
            SfDataGrid sDataGrid;
            sDataGrid = new SfDataGrid();
            sDataGrid.ItemsSource = new OrderInfoRepository().OrderInfoCollection;
            
            //Layout
            StackLayout myLayout = new StackLayout();
            myLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
            myLayout.VerticalOptions = LayoutOptions.CenterAndExpand;

            //sfGrid.DefaultColumnWidth = 200;
            sDataGrid.AllowDraggingColumn = true;
            sDataGrid.AutoExpandGroups = true;
            sDataGrid.GridStyle = new DataGridStyle() { AlternatingRowColor = Color.Gray };

            sDataGrid.ColumnSizer = ColumnSizer.Auto;
            //sfGrid.AllowPullToRefresh = true;              #No Change
            //sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.Bounce;
            Button myButton = new Button();
            myButton.BorderColor = Color.Aqua;
		    //myButton.Text = "Barry Feenster";
            //ContentView myView = new ContentView();
		    //myView.Content = sDataGrid;

		    myLayout.Children.Add(myButton);
            //myLayout.Children.Add(myView);
		    //myView.AnchorX = 100;
		    //myView.Margin = 100;

            Content = sDataGrid;
        }
	}
}
