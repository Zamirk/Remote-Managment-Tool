﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT._1View
{
	public class CPU : Grid
	{
		public CPU ()
		{
		    VerticalOptions = LayoutOptions.FillAndExpand;

            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
		    RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute)});

            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) });

            SfDataGrid sDataGrid;
            sDataGrid = new SfDataGrid();
            sDataGrid.ItemsSource = new OrderInfoRepository().OrderInfoCollection;

            sDataGrid.AllowDraggingColumn = true;
            sDataGrid.AutoExpandGroups = true;
            sDataGrid.GridStyle = new DataGridStyle() { AlternatingRowColor = Color.Gray };

            //Layout
            StackLayout myLayout = new StackLayout();
            myLayout.HorizontalOptions = LayoutOptions.CenterAndExpand;
            myLayout.VerticalOptions = LayoutOptions.CenterAndExpand;

            sDataGrid.ColumnSizer = ColumnSizer.Auto;


            Children.Add(new Label
            {
                Text = "Grid",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            }, 0, 3, 0, 1);

            Children.Add(new Label
                {
                    Text = "Autosized cell",
                    TextColor = Color.White,
                    BackgroundColor = Color.Blue
                }, 0, 1);

             Children.Add(new BoxView
                {
                    Color = Color.Silver,
                    HeightRequest = 0
                }, 1, 1);

               Children.Add(new BoxView
                {
                    Color = Color.Teal
                }, 0, 2);

                Children.Add(new Label
                {
                    Text = "Leftover space",
                    TextColor = Color.Purple,
                    BackgroundColor = Color.Aqua,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                }, 1, 2);

                Children.Add(new Label
                {
                    Text = "Span two rows (or more if you want)",
                    TextColor = Color.Yellow,
                    BackgroundColor = Color.Navy,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 2, 3, 1, 3);

                Children.Add(new Label
                {
                    Text = "Span 2 columns",
                    TextColor = Color.Blue,
                    BackgroundColor = Color.Yellow,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 0, 2, 3, 4);

                Children.Add(new Label
                {
                    Text = "Fixed 100x100",
                    TextColor = Color.Aqua,
                    BackgroundColor = Color.Red,
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center
                }, 2, 3);

            Children.Add(sDataGrid, 1, 2);

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

        }
	}
}