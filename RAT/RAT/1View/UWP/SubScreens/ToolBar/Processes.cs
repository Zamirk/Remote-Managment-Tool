using RAT._2ViewModel;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class Processes : Grid
    {
        private readonly ProcessesViewModel viewModel;

        public Processes()
        {
            viewModel = new ProcessesViewModel();
            BindingContext = viewModel;

            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;

            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            SfDataGrid sDataGrid = new SfDataGrid();
            sDataGrid.HorizontalOptions = LayoutOptions.FillAndExpand;

            sDataGrid.AllowSorting = true;
            sDataGrid.VerticalOverScrollMode = VerticalOverScrollMode.Bounce;
            sDataGrid.AutoGenerateColumns = false;
            sDataGrid.HeaderRowHeight = 15;
            sDataGrid.RowHeight = 20;
            sDataGrid.AutoGenerateColumns = false;
            sDataGrid.ColumnSizer = ColumnSizer.Star;

            //Column creation
            GridTextColumn column_1 = new GridTextColumn { MappingName = "Name", HeaderText = "Name" };
            GridTextColumn column_2 = new GridTextColumn { MappingName = "Memory", HeaderText = "Memory" };
            GridTextColumn column_3 = new GridTextColumn { MappingName = "Cpu", HeaderText = "Cpu" };
            GridTextColumn column_4 = new GridTextColumn { MappingName = "Time", HeaderText = "Time" };
            GridTemplateColumn column_5 = new GridTemplateColumn { MappingName = "Close", HeaderText = "Close" };

            column_5.CellTemplate = new DataTemplate(() =>
            {
                Button close = new Button();
                var myGrid = new Grid();
                close.FontSize = 10;
                close.VerticalOptions = LayoutOptions.Center;
                close.HorizontalOptions = LayoutOptions.CenterAndExpand;
                close.BorderColor = Color.Transparent;
                close.BorderWidth = .000001;
                close.WidthRequest = 200;
                close.HeightRequest = 200;
                //close.BackgroundColor = Color.Gray;
                close.TextColor = Color.Red;
                close.Text = "✘";
                myGrid.Children.Add(close);

                return myGrid;
            });

            column_1.Width = 200;
            column_2.Width = 100;
            column_3.Width = 100;
            column_5.Width = 40;

            sDataGrid.Columns.Add(column_1);
            sDataGrid.Columns.Add(column_2);
            sDataGrid.Columns.Add(column_3);
            sDataGrid.Columns.Add(column_4);
            sDataGrid.Columns.Add(column_5);

            sDataGrid.ItemsSource = viewModel.Data;
            sDataGrid.Margin = new Thickness(20, 20, 20, 20);
            Children.Add(sDataGrid, 1, 1);
        }
        Button aaaa = new Button();
        public void GC()
        {
            viewModel.GC();
        }
    }
}