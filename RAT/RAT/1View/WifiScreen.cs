using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using RAT._2ViewModel;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfDataGrid.XForms;
using Xamarin.Forms;
using ChartDataPoint = Syncfusion.SfChart.XForms.ChartDataPoint;
using FastLineSeries = Syncfusion.SfChart.XForms.FastLineSeries;
using NumericalAxis = Syncfusion.SfChart.XForms.NumericalAxis;
using SfChart = Syncfusion.SfChart.XForms.SfChart;

namespace RAT._1View.Desktop.Screens.SubScreens._1Manage.DeviceSubScreens
{
    public class WifiScreen : Grid
    {
        private WifiViewModel myViewModel;
        private SfChart myChart;
        private SfChart myChart2;
        Label myLabel;
        Label myLabel2;
        private string deviceId = "";

        public WifiScreen(int deviceNum)
        {
            myViewModel = new WifiViewModel(deviceNum);
            BindingContext = myViewModel;

            VerticalOptions = LayoutOptions.FillAndExpand;
            ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});
            ColumnDefinitions.Add(new ColumnDefinition {Width = 85});

            RowDefinitions.Add(new RowDefinition {Height = 100});
            RowDefinitions.Add(new RowDefinition {Height = 100});
            RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});

            //Chart One
            myChart = new SfChart();
            myChart.Series.Add(new ColumnSeries());

            myChart.VerticalOptions = LayoutOptions.Start;
            myChart.HorizontalOptions = LayoutOptions.Start;

            myChart.PrimaryAxis = new NumericalAxis();
            myChart.SecondaryAxis = new NumericalAxis();
            //myChart.BackgroundColor = Color.Black;
            //(myChart.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart.SecondaryAxis as NumericalAxis).Minimum = 0;
            //myChart.Series[0].Color = Color.Black;

            //Chart Two
            myChart2 = new SfChart();
            myChart2.Series.Add(new ColumnSeries());

            myChart2.VerticalOptions = LayoutOptions.Start;
            myChart2.HorizontalOptions = LayoutOptions.Start;

            myChart2.PrimaryAxis = new NumericalAxis();
            myChart2.SecondaryAxis = new NumericalAxis();

            //(myChart2.SecondaryAxis as NumericalAxis).Maximum = 100;
            (myChart2.SecondaryAxis as NumericalAxis).Minimum = 0;
            //myChart2.Series[0].Color = Color.Black;

            Children.Add(myChart, 0, 0);
            Children.Add(myChart2, 0, 1);

            myLabel = new Label();
            myLabel.FontSize = 20;
            myLabel.VerticalOptions = LayoutOptions.CenterAndExpand;
            myLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;

            FormattedString fs = new FormattedString();
            fs.Spans.Add(new Span {Text = "11.4", FontSize = 20});
            fs.Spans.Add(new Span {Text = " mb/s", FontSize = 16, FontAttributes = FontAttributes.Italic});
            myLabel.FormattedText = fs;

            myLabel2 = new Label();
            myLabel2.FontSize = 20;
            myLabel2.VerticalOptions = LayoutOptions.CenterAndExpand;
            myLabel2.HorizontalOptions = LayoutOptions.CenterAndExpand;

            FormattedString fs2 = new FormattedString();
            fs2.Spans.Add(new Span {Text = "8.4", FontSize = 20});
            fs2.Spans.Add(new Span {Text = " mb/s", FontSize = 16, FontAttributes = FontAttributes.Italic});
            myLabel2.FormattedText = fs2;

            myChart.Series[0].AnimationDuration = .5;
            myChart.Series[0].EnableAnimation = true;

            myChart2.Series[0].AnimationDuration = .5;
            myChart2.Series[0].EnableAnimation = true;

            Children.Add(myLabel, 1, 0);
            Children.Add(myLabel2, 1, 1);

            int col1 = 25;
            int col3 = 180;
            int col4 = 325;
            int col2 = 450;

            Label packetsReceived;
            packetsReceived = new Label();
            packetsReceived.Text = "Packets received";
            packetsReceived.Margin = new Thickness(col3, 20, 0, 0);

            Label prLive;
            prLive = new Label();
            prLive.Text = "";
            prLive.FontSize = 22;
            prLive.Margin = new Thickness(col3, 35, 0, 0);
            prLive.SetBinding(Label.TextProperty, "PacketsReceived");

            Label packetsSent;
            packetsSent = new Label();
            packetsSent.Text = "Packets sent";
            packetsSent.Margin = new Thickness(col3, 75, 0, 0);

            Label psLive;
            psLive = new Label();
            psLive.Text = "";
            psLive.FontSize = 22;
            psLive.Margin = new Thickness(col3, 90, 0, 0);
            psLive.SetBinding(Label.TextProperty, "PacketsSent");

            Label packets;
            packets = new Label();
            packets.Text = "Packets /s";
            packets.Margin = new Thickness(col3, 130, 0, 0);

            Label pLive;
            pLive = new Label();
            pLive.Text = "0KB/s";
            pLive.FontSize = 22;
            pLive.Margin = new Thickness(col3, 145, 0, 0);
            pLive.SetBinding(Label.TextProperty, "Packets");

            //Column One
            //Part 1
            Label downloadRate;
            downloadRate = new Label();
            downloadRate.Text = "Download Rate";
            downloadRate.Margin = new Thickness(col1, 20, 0, 0);

            Label dLive;
            dLive = new Label();
            dLive.Text = "0 KB/s";
            dLive.FontSize = 22;
            dLive.Margin = new Thickness(col1, 35, 0, 0);
            dLive.SetBinding(Label.TextProperty, "DownloadRate");

            //Part 2
            Label uploadRate;
            uploadRate = new Label();
            uploadRate.Text = "Upload Rate";
            uploadRate.Margin = new Thickness(col1, 75, 0, 0);

            Label uLive;
            uLive = new Label();
            uLive.Text = "0KB/s";
            uLive.FontSize = 22;
            uLive.Margin = new Thickness(col1, 90, 0, 0);
            uLive.SetBinding(Label.TextProperty, "UploadRate");

            //Column One
            //Part 1
            Label bandwidth;
            bandwidth = new Label();
            bandwidth.Text = "Bandwidth";
            bandwidth.Margin = new Thickness(col4, 20, 0, 0);

            Label bLive;
            bLive = new Label();
            bLive.Text = "";
            bLive.FontSize = 22;
            bLive.Margin = new Thickness(col4, 35, 0, 0);
            bLive.SetBinding(Label.TextProperty, "Bandwidth");

            //Column 2
            Label adapterName;
            adapterName = new Label();
            adapterName.Text = "Adapter name:";
            adapterName.Margin = new Thickness(col2, 20, 0, 0);

            Label ssid;
            ssid = new Label();
            ssid.Text = "SSID:";
            ssid.Margin = new Thickness(col2, 40, 0, 0);

            Label connectionType;
            connectionType = new Label();
            connectionType.Text = "SSID:";
            connectionType.Margin = new Thickness(col2, 60, 0, 0);

            Label ipv4;
            ipv4 = new Label();
            ipv4.Text = "IPv4 address:";
            ipv4.Margin = new Thickness(col2, 80, 0, 0);

            Label ipv6;
            ipv6 = new Label();
            ipv6.Text = "IPv6 address:";
            ipv6.Margin = new Thickness(col2, 100, 0, 0);

            Label signalStrenght;
            signalStrenght = new Label();
            signalStrenght.Text = "IPv6 address:";
            signalStrenght.Margin = new Thickness(col2, 120, 0, 0);

            Children.Add(bandwidth, 0, 2);
            Children.Add(bLive, 0, 2);
            Children.Add(packetsReceived, 0, 2);
            Children.Add(prLive, 0, 2);
            Children.Add(packetsSent, 0, 2);
            Children.Add(psLive, 0, 2);
            Children.Add(packets, 0, 2);
            Children.Add(pLive, 0, 2);
            Children.Add(downloadRate, 0, 2);
            Children.Add(dLive, 0, 2);
            Children.Add(uploadRate, 0, 2);
            Children.Add(uLive, 0, 2);
            Children.Add(adapterName, 0, 2);
            Children.Add(ssid, 0, 2);
            Children.Add(connectionType, 0, 2);
            Children.Add(ipv4, 0, 2);
            Children.Add(ipv6, 0, 2);
            Children.Add(signalStrenght, 0, 2);

            myChart.Series[0].ItemsSource = myViewModel.DownloadData;
            myChart2.Series[0].ItemsSource = myViewModel.UploadData;
        }

        public void GC()
        {
            myViewModel.StopUpdate();
            myChart.Series[0].ItemsSource = null;
            myChart2.Series[0].ItemsSource = null;
            myChart = null;
            myChart2 = null;
            myViewModel = null;
        }
    }
}