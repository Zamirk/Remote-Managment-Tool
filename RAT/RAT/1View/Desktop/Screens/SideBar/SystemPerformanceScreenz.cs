﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;
using Label = Xamarin.Forms.Label;

namespace RAT._1View.Desktop.Manage
{
	public class SystemPerformanceScreenz : Grid
    {
        public SystemPerformanceScreenz()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            Label myLabel;
            myLabel = new Label();
            myLabel.Text = "SystemPerformanceScreenz";
            Children.Add(myLabel, 1, 1);
        }
    }
}
