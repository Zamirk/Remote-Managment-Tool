using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IoTHubAmqp;
using Newtonsoft.Json;
using RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen;

namespace ConsoleApplication1.Folder
{
    public class GetTelemetry
    {
        public static bool go = true;

        static string partitionId = "0";
        static string partitionId1 = "1";

        //Todays date and time
        static DateTime startingDateTimeUtc;

        //List of devices
        public static List<string> devices = new List<string>() { "Device_1", "Device_2", "Device_3", "Device_4", "Device_5", "Device_6", "Device_7", "Device_8", "Device_9", "Device_10" };

        //Last received values
        public static List<TelemetryDatapoint> lastTelemetryDatapoints = new List<TelemetryDatapoint>()
        {
            new TelemetryDatapoint(""),new TelemetryDatapoint(""),new TelemetryDatapoint(""),new TelemetryDatapoint(""),
            new TelemetryDatapoint(""),new TelemetryDatapoint(""),new TelemetryDatapoint(""),new TelemetryDatapoint(""),
            new TelemetryDatapoint(""),new TelemetryDatapoint("")
        };

        //Storing data of all devices
        public static List<Queue<TelemetryDatapoint>> listOfDevices = new List<Queue<TelemetryDatapoint>>()
        {
            //TODO TEMP HARDCODING 2 DEVICES
            new Queue<TelemetryDatapoint>(),new Queue<TelemetryDatapoint>(),new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>(),new Queue<TelemetryDatapoint>(),new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>(),new Queue<TelemetryDatapoint>(),new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>()
        };

        //Receive data partition 0
        public static void ReceiveTelemetry()
        {
            System.Diagnostics.Debug.WriteLine("AAAAAAAAAAAAAAAAAA" + UserData.connectionString);

            startingDateTimeUtc = DateTime.Now.AddSeconds(-30);
            Console.WriteLine("Receiving Data");

            //Filling default values
            for (int i = 0; i < 60; i++)
            {
                listOfDevices[0].Enqueue(new TelemetryDatapoint(""));
                listOfDevices[1].Enqueue(new TelemetryDatapoint(""));
                listOfDevices[2].Enqueue(new TelemetryDatapoint(""));
                listOfDevices[3].Enqueue(new TelemetryDatapoint(""));
                listOfDevices[4].Enqueue(new TelemetryDatapoint(""));
                listOfDevices[5].Enqueue(new TelemetryDatapoint(""));
                listOfDevices[6].Enqueue(new TelemetryDatapoint(""));
                listOfDevices[7].Enqueue(new TelemetryDatapoint(""));
                listOfDevices[8].Enqueue(new TelemetryDatapoint(""));
                listOfDevices[9].Enqueue(new TelemetryDatapoint(""));
            }
            try
            {







                //while (go)
                {
                    //System.Diagnostics.Debug.WriteLine("Level 1: Looping");
                   // data = receiver.Receive();
                    //System.Diagnostics.Debug.WriteLine("Level 2: Data received"+data);
                    // if (data.GetBytes() != null)
                    // {
                    //string JsonString = Encoding.UTF8.GetString(data.GetBytes());
                    //System.Diagnostics.Debug.WriteLine("Level 3: JSon"+JsonString);

                    //TelemetryDatapoint telemetry = JsonConvert.DeserializeObject<TelemetryDatapoint>(JsonString);
                    //System.Diagnostics.Debug.WriteLine(JsonString);

                    //for (int i = 0; i < devices.Count; i++)
                    {
                       // if (telemetry.Device_id.Equals(devices[i]))
                        {
                         //   listOfDevices[i].Dequeue();
                         //   listOfDevices[i].Enqueue(telemetry);
                         //   lastTelemetryDatapoints[i] = telemetry;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("[GetTelemetry] Error IOT, you should probably check this" + e);
            }



        }
        private static async Task ReceiveMessagesFromDeviceAsync(string partition, CancellationToken ct)
        {
            var eventHubReceiver = Microsoft.ServiceBus.Messaging.EventDataeventHubClient.GetDefaultConsumerGroup().CreateReceiver(partition, DateTime.UtcNow);
            while (true)
            {
                Microsoft.Azure.Devices.Client.DeviceClient.Create().ReceiveAsync()
                if (ct.IsCancellationRequested) break;
                EventData eventData = await eventHubReceiver.ReceiveAsync();
                if (eventData == null) continue;

                string data = Encoding.UTF8.GetString(eventData.GetBytes());
                Console.WriteLine("Message received. Partition: {0} Data: '{1}'", partition, data);
            }
        }

        public static void StopReceive()
        {
            go = false;
        }
    }
}
