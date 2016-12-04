using System;
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
	public class MainManagmentScreen : Grid
	{
	    public Button pcOne;
        public MainManagmentScreen()
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            pcOne = new Button();
            pcOne.Text = "Computer 1";
            pcOne.FontSize = 20;
            pcOne.VerticalOptions = LayoutOptions.Center;
            pcOne.HorizontalOptions = LayoutOptions.CenterAndExpand;
            pcOne.BorderColor = Color.Transparent;
            pcOne.BorderWidth = .000001;
            pcOne.WidthRequest = 200;
            pcOne.HeightRequest = 200;
            pcOne.Margin = new Thickness(50, 50, 0, 0);
            pcOne.BackgroundColor = Color.Gray;

            Button pcTwo = new Button();
            pcTwo.Text = "Computer 2";
            pcTwo.FontSize = 20;
            pcTwo.VerticalOptions = LayoutOptions.Center;
            pcTwo.HorizontalOptions = LayoutOptions.CenterAndExpand;
            pcTwo.BorderColor = Color.Transparent;
            pcTwo.BorderWidth = .000001;
            pcTwo.WidthRequest = 200;
            pcTwo.HeightRequest = 200;
            pcTwo.Margin = new Thickness(50, 50, 0, 0);
            pcTwo.BackgroundColor = Color.Gray;

            Button pcThree = new Button();
            pcThree.Text = "Computer 3";
            pcThree.FontSize = 20;
            pcThree.VerticalOptions = LayoutOptions.Center;
            pcThree.HorizontalOptions = LayoutOptions.CenterAndExpand;
            pcThree.BorderColor = Color.Transparent;
            pcThree.BorderWidth = .000001;
            pcThree.WidthRequest = 200;
            pcThree.HeightRequest = 200;
            pcThree.Margin = new Thickness(50, 50, 0, 0);
            pcThree.BackgroundColor = Color.Gray;

            Button pcFour = new Button();
            pcFour.Text = "Computer 4";
            pcFour.FontSize = 20;
            pcFour.VerticalOptions = LayoutOptions.Center;
            pcFour.HorizontalOptions = LayoutOptions.CenterAndExpand;
            pcFour.BorderColor = Color.Transparent;
            pcFour.BorderWidth = .000001;
            pcFour.WidthRequest = 200;
            pcFour.HeightRequest = 200;
            pcFour.Margin = new Thickness(50, 50, 50, 0);
            pcFour.BackgroundColor = Color.Gray;

            Label myLabel;
            myLabel = new Label();
            myLabel.Text = "MainManagmentScreen";
            Children.Add(myLabel, 1, 1);
            Children.Add(pcOne, 1, 0);
            Children.Add(pcTwo, 2, 0);
            Children.Add(pcThree, 3, 0);
            Children.Add(pcFour, 4, 0);
        }
    }
}
