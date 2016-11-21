using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT.Syncfusion
{
	public class Datagrid : ContentPage
	{
		public Datagrid ()
		{
            SfDataGrid dataGrid = new SfDataGrid();
            
            //Layout
            StackLayout myLayout = new StackLayout();
            myLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
            myLayout.VerticalOptions = LayoutOptions.CenterAndExpand;

            //sfGrid.DefaultColumnWidth = 200;
            dataGrid.AllowDraggingColumn = true;
            dataGrid.AutoExpandGroups = true;
            dataGrid.GridStyle = new DataGridStyle() { AlternatingRowColor = Color.Gray };

            dataGrid.ColumnSizer = ColumnSizer.Auto;
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

            Content = dataGrid;
        }
	}
}
