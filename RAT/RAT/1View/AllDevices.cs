using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using ConsoleApplication1.Folder;
using IoTHubAmqpService;
using RAT.Syncfusion;
using RAT.ZTry;
using RAT._1View.Desktop.Screens.SubScreens;
using RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen;
using RAT._2ViewModel;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;
using Label = Xamarin.Forms.Label;

namespace RAT._1View.Desktop.Manage
{
	public class AllDevices : Grid
	{
        private AllDevicesViewModel viewModel;
	    private SfDataGrid sDataGrid;

        public AllDevices()
        {
            viewModel = new AllDevicesViewModel();
            BindingContext = viewModel;
           
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;

            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            sDataGrid = new SfDataGrid();
            sDataGrid.HorizontalOptions = LayoutOptions.FillAndExpand;

            sDataGrid.VerticalOverScrollMode = VerticalOverScrollMode.Bounce;
            sDataGrid.AutoGenerateColumns = false;
            sDataGrid.HeaderRowHeight = 35;
            sDataGrid.RowHeight = 25;
            sDataGrid.ColumnSizer = ColumnSizer.Star;
            sDataGrid.AllowSorting = true;
            sDataGrid.Margin = new Thickness(20, 20, 20, 20);

            //Column creation
            GridTextColumn column_1 = new GridTextColumn { MappingName = "Name", HeaderText = "Name" };
            GridTextColumn column_2 = new GridTextColumn { MappingName = "Cpu", HeaderText = "Cpu" };
            GridTextColumn column_3 = new GridTextColumn { MappingName = "Memory", HeaderText = "Memory" };
            GridTextColumn column_4 = new GridTextColumn { MappingName = "Disk", HeaderText = "Disk" };
            GridTextColumn column_5 = new GridTextColumn { MappingName = "Wifi", HeaderText = "Wifi" };
            GridTemplateColumn column_6 = new GridTemplateColumn { MappingName = "UserName", HeaderText = "UserName" };
            
            //Template for buttons
            DataTemplate template = new DataTemplate(() =>
            {
                StackLayout stack = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Vertical
                };
                //Button template
                Button myButton = new Button()
                {
                    TextColor = Color.Red,
                    FontSize = 12,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    BorderColor = Color.Transparent,
                    BorderWidth = .000001,
                    WidthRequest = 100,
                    Text = "View"
                };
                //Temp label for databinding the name of the device
                Label temp = new Label();
                temp.SetBinding(Label.TextProperty, "Name");

                myButton.Clicked += delegate (object sender, EventArgs args)
                {
                    //Setting device id
                    UserData.deviceId = temp.Text;

                    int deviceNum = 9;
                    bool found = false;
                    for (int i = 0; i < GetTelemetry.devices.Count; i++)
                    {
                        if (GetTelemetry.devices[i] == temp.Text)
                        {
                            deviceNum = i;
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        deviceNum = 9;
                    }
                    //Sending an asyncranous command
                    Button s = sender as Button;
                        ParentScreen d = (ParentScreen)s.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent;
                       d.EnterDevice(temp.Text, deviceNum);
                    BindingContext = null;
                    viewModel = null;
                };

                stack.Children.Add(myButton);
                stack.Children.Add(temp);
                temp.IsVisible = false;

                return stack;
            });
            //Setting the template
            column_6.CellTemplate = template;

            //Collumn sizes
            //column_1.Width = 200;
            //column_2.Width = 100;
            //column_3.Width = 100;
            column_6.Width = 40;

            sDataGrid.Columns.Add(column_1);
            sDataGrid.Columns.Add(column_2);
            sDataGrid.Columns.Add(column_3);
            sDataGrid.Columns.Add(column_4);
            sDataGrid.Columns.Add(column_5);
            sDataGrid.Columns.Add(column_6);

            //Data binding
            sDataGrid.ItemsSource = viewModel.Data;

            Children.Add(sDataGrid, 1, 1);
        }

        public void GC()
        {
            sDataGrid.ItemsSource = null;
            viewModel.GC();
            BindingContext = null;
            sDataGrid = null;
        }
    }
}