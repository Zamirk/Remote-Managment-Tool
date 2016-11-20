using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
	public class RamScreen : Grid
    {
        public RamScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Label myLabel;
            myLabel = new Label();
            myLabel.Text = "RAM Screen";
            Children.Add(myLabel, 1, 1);
        }
    }
}
