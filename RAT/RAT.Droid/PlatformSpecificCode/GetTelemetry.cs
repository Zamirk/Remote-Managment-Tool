using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IoTHubAmqp;
using Newtonsoft.Json;

namespace ConsoleApplication1.Folder
{
    public class GetTelemetry
    {
        static string ConnectionString = "Endpoint=sb://iothub-ns-manageiot-119210-43e7bcdbe5.servicebus.windows.net/;" +
                             "SharedAccessKeyName=iothubowner;" +
                             "SharedAccessKey=XnRSB9kO1Knhq6sL7QMhWhxqshHsGV34NBw+HnDj5oU=";

        static string eventHubEntity = "ManageIoT";
        static string partitionId = "1";

        static DateTime startingDateTimeUtc;

        List<string> devices = new List<string>(){"Device_1","Device_2"};
        public static bool go = true;
        public static string aaaaa = "";
        public static List<Queue<TelemetryDatapoint>> listOfDevices;
        public static TelemetryDatapoint lastReceivedValue = new TelemetryDatapoint("");
        public static void ReceiveTelemetry()
        {
            lastReceivedValue = new TelemetryDatapoint("Device_1");
            Console.WriteLine("Receiving Data");

            listOfDevices = new List<Queue<TelemetryDatapoint>>();

            Queue<TelemetryDatapoint> myDevice = new Queue<TelemetryDatapoint>();
            for (int i = 0; i < 60; i++)
            {
                myDevice.Enqueue(new TelemetryDatapoint(""));
            }
            listOfDevices.Add(myDevice);
        }

        public static void StopReceive()
        {
            go = false;
        }
    }
}
