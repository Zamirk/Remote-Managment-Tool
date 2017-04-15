using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleApplication1;
using IoTHubAmqpService;
using RAT.ZTry;
using RAT._2ViewModel;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class Processes : Grid
    {
        private readonly ProcessesViewModel viewModel;

        public Processes(int deviceNum)
        {
            viewModel = new ProcessesViewModel(deviceNum);
            BindingContext = viewModel;

            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;

            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });

            SfDataGrid sDataGrid = new SfDataGrid();
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
            GridTextColumn column_2 = new GridTextColumn { MappingName = "Memory", HeaderText = "Memory" };
            GridTextColumn column_3 = new GridTextColumn { MappingName = "Cpu", HeaderText = "Cpu" };
            GridTextColumn column_4 = new GridTextColumn { MappingName = "Time", HeaderText = "Time" };
            GridTemplateColumn column_5 = new GridTemplateColumn { MappingName = "UserName", HeaderText = "UserName" };

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
                    Text = "✘"
                };
                //Temp label for databinding the name of the process
                Label temp = new Label();
                temp.SetBinding(Label.TextProperty, "Name");

                myButton.Clicked += delegate (object sender, EventArgs args)
                {
                    System.Diagnostics.Debug.WriteLine("[Processes]::Sending command to kill process::" + temp.Text);

                    //Sending an asyncranous command
                    Task t = Task.Factory.StartNew(() => {
                        SendCommand myCommand = new SendCommand(temp.Text);
                        myCommand.Command = new CommandDatapoint()
                        {
                            CommandType = CommandType.CloseProcess,
                            ProcessName = temp.Text,
                            ExpireTime = DateTime.Now
                        };
                        myCommand.SendCommandToDevice();

                    });
                };
                stack.Children.Add(myButton);
                stack.Children.Add(temp);
                temp.IsVisible = false;

                return stack;
            });
            //Setting the template
            column_5.CellTemplate = template;

            //Collumn sizes
            column_1.Width = 200;
            column_2.Width = 100;
            column_3.Width = 100;
            column_5.Width = 40;

            sDataGrid.Columns.Add(column_1);
            sDataGrid.Columns.Add(column_2);
            sDataGrid.Columns.Add(column_3);
            sDataGrid.Columns.Add(column_4);
            sDataGrid.Columns.Add(column_5);

            //Data binding
            sDataGrid.ItemsSource = viewModel.Data;

            /*Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                for (int i = 0; i < sDataGrid.Children.Count; i++)
                {
                    if (()sDataGrid.Children[i] == null)
                    {
                        sDataGrid.Children[i].IsVisible = false;
                    }
                }

                return true;
            });
            */
            Children.Add(sDataGrid, 1, 1);
        }

        public void GC()
        {
            viewModel.GC();
        }
    }
}