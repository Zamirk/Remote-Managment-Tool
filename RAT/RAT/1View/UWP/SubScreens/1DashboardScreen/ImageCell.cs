using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using IoTHubAmqpService;
using RAT.zTest;
using RAT.ZTry;
using RAT._2ViewModel;
using Rg.Plugins.Popup.Extensions;
using Syncfusion.SfChart.XForms;
using Xamarin.Forms;

namespace RAT._1View.Desktop.Screens.SubScreens._4DashboardScreen
{
    class ImageCell: Grid
    {
        private Image myImage;
        private string[] imgUri;

        public ImageCell()
        {
            if (Device.OS == TargetPlatform.Android)
            {
                //Image locations
                imgUri = new string[]
            {
                "Area.png",
                "Bar.png",
                "Column.png",
                "Line.png",
                "StepArea.png",
                "Pyramid.png",
                "Scatter.png",
                "Spline.png",
                "SplineArea.png",
                "Step.png",
                "Pie.png",
                "Doughnut.png",
            };
            }
            else
            {
                //Image locations
                imgUri = new string[]
            {
                "Assets\\Graphs\\Area.png",
                "Assets\\Graphs\\Bar.png",
                "Assets\\Graphs\\Column.png",
                "Assets\\Graphs\\Line.png",
                "Assets\\Graphs\\StepArea.png",
                "Assets\\Graphs\\Pyramid.png",
                "Assets\\Graphs\\Scatter.png",
                "Assets\\Graphs\\Spline.png",
                "Assets\\Graphs\\SplineArea.png",
                "Assets\\Graphs\\Step.png",
                "Assets\\Graphs\\Pie.png",
                "Assets\\Graphs\\Doughnut.png",
            };
            }

            //Generating the images
            myImage = new Image();
            myImage.VerticalOptions = LayoutOptions.Center;
            myImage.HorizontalOptions = LayoutOptions.Center;
            myImage.WidthRequest = 100;
            myImage.HeightRequest = 100;
            Children.Add(myImage);

        }

        public void SetImage(int a)
        {
            myImage.Source = imgUri[a];
        }
    }
}
