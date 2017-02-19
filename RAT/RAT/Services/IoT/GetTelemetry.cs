﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using Amqp.Framing;
using IoTHubAmqp;
using Newtonsoft.Json;
using ppatierno.AzureSBLite;
using ppatierno.AzureSBLite.Messaging;

namespace ConsoleApplication1.Folder
{
    public class GetTelemetry
    {
        static string ConnectionString = "Endpoint=sb://iothub-ns-manageiot-107893-aab55f8a1a.servicebus.windows.net/;" +
                             "SharedAccessKeyName=iothubowner;" +
                             "SharedAccessKey=1QnPUGMCx86KJRaOsIg5BvhJtww13EU6kzprCPSr/qs=";

        static string eventHubEntity = "ManageIoT";
        static string partitionId = "1";

        static DateTime startingDateTimeUtc;

        List<string> devices = new List<string>(){"Device_1","Device_2"};
        public static bool go = true;
        public static string aaaaa = "";
        public static List<Queue<TelemetryDatapoint>> listOfDevices;
        public static TelemetryDatapoint lastReceivedValue;
        public static void ReceiveTelemetry()
        {
            lastReceivedValue = new TelemetryDatapoint("");
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(ConnectionString);
            builder.TransportType = TransportType.Amqp;

            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(ConnectionString);

            EventHubClient client = factory.CreateEventHubClient(eventHubEntity);
            EventHubConsumerGroup group = client.GetDefaultConsumerGroup();

            startingDateTimeUtc = DateTime.Now;

            EventHubReceiver receiver = group.CreateReceiver(partitionId, startingDateTimeUtc);

            Console.WriteLine("Receiving Data");

            listOfDevices = new List<Queue<TelemetryDatapoint>>();

            Queue<TelemetryDatapoint> myDevice = new Queue<TelemetryDatapoint>();
            for (int i = 0; i < 60; i++)
            {
                myDevice.Enqueue(new TelemetryDatapoint(""));
            }
            listOfDevices.Add(myDevice);
            EventData data;
            while (go)
            {
                System.Diagnostics.Debug.WriteLine("Level 1: Looping");
                data = receiver.Receive();
                System.Diagnostics.Debug.WriteLine("Level 2: Data received");
               // if (data.GetBytes() != null)
               // {
                    string JsonString = Encoding.UTF8.GetString(data.GetBytes());
                    System.Diagnostics.Debug.WriteLine("Level 3: JSon");

                    TelemetryDatapoint telemetry = JsonConvert.DeserializeObject<TelemetryDatapoint>(JsonString);
                    if (telemetry.Device_id.Equals("Device_1"))
                    {
                        System.Diagnostics.Debug.WriteLine(JsonString);

                        listOfDevices[0].Dequeue();
                        listOfDevices[0].Enqueue(telemetry);
                        lastReceivedValue = telemetry;
                        aaaaa = JsonString;
                        System.Diagnostics.Debug.WriteLine("Level 4: Device ID" +
                                                           listOfDevices[0].ElementAt(0).Device_id);
                    }
               // }
               // else
                //{
                //    System.Diagnostics.Debug.WriteLine("----------------------------Avoided Error"+DateTime.Now);
                //}
            }
            
            receiver.Close();
            client.Close();
            factory.Close();
        }

        public static void StopReceive()
        {
            go = false;
        }
    }
}
