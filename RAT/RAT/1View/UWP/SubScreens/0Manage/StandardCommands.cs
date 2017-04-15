using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using IoTHubAmqpService;
using RAT.ZTry;
using RAT._2ViewModel;
using RAT._2ViewModel.Test;
using Xamarin.Forms;

namespace RAT._1View.Desktop
{
    public class StandardCommands : Grid
    {
        //private CommandViewModel viewModel;
        private Editor myEditor;
        private string deviceId = "";

        public StandardCommands(string a)
        {
            deviceId = a;

            BackgroundColor = Color.FromRgb(29, 29, 29);
            List<Image> myImages = new List<Image>();

            //Image locations
            string[] imgUri = new string[]
            {
                "Assets\\Hibernate.png",
                "Assets\\Shut Down.png",
                "Assets\\Restart.png",
                "Assets\\Sleep.png",
                "Assets\\Logoff.png",
                "Assets\\Lock.png",
            };

            int y = 10;
            int x = 125;
            //Generating the images
            for (int i = 0; i < imgUri.Length; i++)
            {
                myImages.Add(new Image());
                myImages[i].VerticalOptions = LayoutOptions.Start;
                myImages[i].HorizontalOptions = LayoutOptions.Start;
                myImages[i].WidthRequest = 300;
                myImages[i].HeightRequest = 45;
                myImages[i].Aspect = Aspect.AspectFit;
                myImages[i].Source = imgUri[i];

                if (i == 4)
                {
                    y = 10;
                    x = 425;
                }
                    myImages[i].Margin = new Thickness(x, y, 0, 0);
                    y += 60;
                Children.Add(myImages[i]);

            }
            //Sleep, Logoff, Lock
            myImages[0].GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Task t = Task.Factory.StartNew(() => {
                        SendCommand myCommand = new SendCommand(deviceId);
                        myCommand.Command = new CommandDatapoint() { CommandType = CommandType.Hibernate, ExpireTime = DateTime.Now };
                        myCommand.SendCommandToDevice();
                    });
                })
            });

            myImages[1].GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Task t = Task.Factory.StartNew(() => {
                        SendCommand myCommand = new SendCommand(deviceId);
                        myCommand.Command = new CommandDatapoint() { CommandType = CommandType.ShutDown, ExpireTime = DateTime.Now };
                        myCommand.SendCommandToDevice();
                    });
                })
            });

            myImages[2].GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Task t = Task.Factory.StartNew(() => {
                        SendCommand myCommand = new SendCommand(deviceId);
                        myCommand.Command = new CommandDatapoint() { CommandType = CommandType.Restart, ExpireTime = DateTime.Now };
                        myCommand.SendCommandToDevice();
                    });
                })
            });

            myImages[3].GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Task t = Task.Factory.StartNew(() => {
                        SendCommand myCommand = new SendCommand(deviceId);
                        myCommand.Command = new CommandDatapoint() { CommandType = CommandType.Sleep, ExpireTime = DateTime.Now };
                        myCommand.SendCommandToDevice();
                    });
                })
            });

            myImages[4].GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Task t = Task.Factory.StartNew(() => {
                        SendCommand myCommand = new SendCommand(deviceId);
                        myCommand.Command = new CommandDatapoint() { CommandType = CommandType.Logoff, ExpireTime = DateTime.Now };
                        myCommand.SendCommandToDevice();
                    });
                })
            });

            myImages[5].GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Task t = Task.Factory.StartNew(() => {
                        SendCommand myCommand = new SendCommand(deviceId);
                        myCommand.Command = new CommandDatapoint() { CommandType = CommandType.Lock, ExpireTime = DateTime.Now };
                        myCommand.SendCommandToDevice();
                    });
                })
            });

        }

        public void GC()
        {
            //RemoveScreen();
        }
    }
}