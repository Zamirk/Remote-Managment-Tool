using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens;
using RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Label = Xamarin.Forms.Label;

namespace RAT._1View.Desktop.Manage
{
	public class DashboardScreen : Grid
    {
        private Grid mainGrid;

        public DashboardScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;

            mainGrid = new Grid();
            mainGrid.ColumnSpacing = 0;
            mainGrid.RowSpacing = 0;
            int pos = 0;

            mainGrid.RowDefinitions.Add(new RowDefinition { Height = 25 });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

            //Addings cells
            for (int i = 0; i < 7; i++)
            {
                for (int z = 0; z < 6; z++)
                {
                    mainGrid.Children.Add(new DashboardCell(),i,z);
                    pos++;
                }
            }
            Children.Add(mainGrid);
       }
    }
}
