using System.Collections.ObjectModel;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class DiskScreen : Grid
    {
        public DiskScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
            ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});

            var chart = new SfChart();

            var pieSeries = new PieSeries
            {
                XBindingPath = "Expense",
                YBindingPath = "Value"
            };
            chart.Series[0].ItemsSource = getData();

            chart.Series.Add(pieSeries);
            Children.Add(chart);
        }

        private ObservableCollection<int> getData()
        {
            ObservableCollection<int> datas = new ObservableCollection<int>();
            datas.Add(10);

            return datas;
        }
    }
}
