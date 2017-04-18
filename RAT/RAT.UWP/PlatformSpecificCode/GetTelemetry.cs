using System;
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
using RAT;
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

        //Receive data partition 1
        public static void ReceiveTelemetry2()
        {
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(UserData.connectionString);
            builder.TransportType = TransportType.Amqp;

            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(UserData.connectionString);

            EventHubClient client = factory.CreateEventHubClient(UserData.eventHubEntity);
            EventHubConsumerGroup group = client.GetDefaultConsumerGroup();

            startingDateTimeUtc = DateTime.Now.AddSeconds(-30);

            EventHubReceiver receiver2 = group.CreateReceiver(partitionId1, startingDateTimeUtc);
            Console.WriteLine("Receiving Data");


            EventData data;
            try
            {
                while (go)
                {
                    //System.Diagnostics.Debug.WriteLine("Level 1: Looping");
                    data = receiver2.Receive();
                    //System.Diagnostics.Debug.WriteLine("Level 2: Data received" + data);
                    // if (data.GetBytes() != null)
                    // {
                    string JsonString = Encoding.UTF8.GetString(data.GetBytes());
                    //System.Diagnostics.Debug.WriteLine("Level 3: JSon" + JsonString);

                    TelemetryDatapoint telemetry = JsonConvert.DeserializeObject<TelemetryDatapoint>(JsonString);
                    //System.Diagnostics.Debug.WriteLine(JsonString);

                    for (int i = 0; i < devices.Count; i++)
                    {
                        if (telemetry.Device_id.Equals(devices[i]))
                        {
                            listOfDevices[i].Dequeue();
                            listOfDevices[i].Enqueue(telemetry);
                            lastTelemetryDatapoints[i] = telemetry;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("[GetTelemetry] Error IOT, you should probably check this" + e);
            }

            //receiver2.Close();
            //client.Close();
            //factory.Close();
        }

        //Receive data partition 0
        public static void ReceiveTelemetry()
        {
            System.Diagnostics.Debug.WriteLine("AAAAAAAAAAAAAAAAAA"+ UserData.connectionString);
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(UserData.connectionString);
            builder.TransportType = TransportType.Amqp;

            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(UserData.connectionString);

            EventHubClient client = factory.CreateEventHubClient(UserData.eventHubEntity);
            EventHubConsumerGroup group = client.GetDefaultConsumerGroup();

            startingDateTimeUtc = DateTime.Now.AddSeconds(-30);

            EventHubReceiver receiver = group.CreateReceiver(partitionId, startingDateTimeUtc);

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

            EventData data;
            try
            {
                while (go)
                {
                    //System.Diagnostics.Debug.WriteLine("Level 1: Looping");
                    data = receiver.Receive();
                    //System.Diagnostics.Debug.WriteLine("Level 2: Data received"+data);
                    // if (data.GetBytes() != null)
                    // {
                    string JsonString = Encoding.UTF8.GetString(data.GetBytes());
                    //System.Diagnostics.Debug.WriteLine("Level 3: JSon"+JsonString);

                    TelemetryDatapoint telemetry = JsonConvert.DeserializeObject<TelemetryDatapoint>(JsonString);
                    //System.Diagnostics.Debug.WriteLine(JsonString);

                    for (int i = 0; i < devices.Count; i++)
                    {
                        if (telemetry.Device_id.Equals(devices[i]))
                        {
                            listOfDevices[i].Dequeue();
                            listOfDevices[i].Enqueue(telemetry);
                            lastTelemetryDatapoints[i] = telemetry;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("[GetTelemetry] Error IOT, you should probably check this" +e);
            }


            //receiver.Close();
            //client.Close();
            //factory.Close();
        }

        public static void StopReceive()
        {
            go = false;
        }
    }
}
