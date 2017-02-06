using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

namespace RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens
{
    public class SelectItem : Grid
    {
        private WifiViewModel myViewModel;
        private SfChart myChart;
        private SfChart myChart2;
        Label myLabel;
        Label myLabel2;
        private Button myButton;
        public SelectItem()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition {Width = 85});

            RowDefinitions.Add(new RowDefinition {Height = 50});

            myButton = new Button();
            myButton.WidthRequest = 200;
            myButton.HeightRequest = 50;
            myButton.Text = "FastLine Chart";

            Children.Add(myButton);
        }

        public Button aaa()
        {
            return myButton;
        }

    }
}
