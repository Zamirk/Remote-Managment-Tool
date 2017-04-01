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

namespace ConsoleApplication1.Folder
{
    public class GetTelemetry
    {
        public static bool go = true;
        public static string aaaaa = "";

        static string ConnectionString = "Endpoint=sb://iothub-ns-manageiot-119210-43e7bcdbe5.servicebus.windows.net/;" +
                             "SharedAccessKeyName=iothubowner;" +
                             "SharedAccessKey=9MVDBFa+gjD8C1awDRPW8oGVraiJm6XV72ui4fm8UIA=";

        static string eventHubEntity = "ManageIoT";
        static string partitionId = "1";

        //Todays date and time
        static DateTime startingDateTimeUtc;

        //List of devices
        public static List<string> devices = new List<string>() { "Device_1", "Device_2" };

        //Last received values
        public static List<TelemetryDatapoint> lastTelemetryDatapoints = new List<TelemetryDatapoint>()
        {
            new TelemetryDatapoint(""),
            new TelemetryDatapoint(""),
            new TelemetryDatapoint("")
        };

        //Storing data of all devices
        public static List<Queue<TelemetryDatapoint>> listOfDevices = new List<Queue<TelemetryDatapoint>>()
        {
            //TODO TEMP HARDCODING 2 DEVICES
            new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>()

        };

        //Receive data method
        public static void ReceiveTelemetry()
        {
            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(ConnectionString);
            builder.TransportType = TransportType.Amqp;

            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(ConnectionString);

            EventHubClient client = factory.CreateEventHubClient(eventHubEntity);
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
            }

            EventData data;
            try
            {
                while (go)
                {
                    System.Diagnostics.Debug.WriteLine("Level 1: Looping");
                    data = receiver.Receive();
                    System.Diagnostics.Debug.WriteLine("Level 2: Data received"+data);
                    // if (data.GetBytes() != null)
                    // {
                    string JsonString = Encoding.UTF8.GetString(data.GetBytes());
                    System.Diagnostics.Debug.WriteLine("Level 3: JSon"+JsonString);

                    TelemetryDatapoint telemetry = JsonConvert.DeserializeObject<TelemetryDatapoint>(JsonString);
                    System.Diagnostics.Debug.WriteLine(JsonString);

                    if (telemetry.Device_id.Equals("Device_1"))
                    {
                        System.Diagnostics.Debug.WriteLine(JsonString);

                        listOfDevices[0].Dequeue();
                        listOfDevices[0].Enqueue(telemetry);
                        lastTelemetryDatapoints[0] = telemetry;
                        aaaaa = JsonString;
                    }
                    else if (telemetry.Device_id.Equals("Device_2"))
                    {
                        System.Diagnostics.Debug.WriteLine(JsonString);
                        System.Diagnostics.Debug.WriteLine(JsonString);

                        listOfDevices[1].Dequeue();
                        listOfDevices[1].Enqueue(telemetry);
                        lastTelemetryDatapoints[1] = telemetry;
                    }
                    // }
                    // else
                    //{
                    //    System.Diagnostics.Debug.WriteLine("----------------------------Avoided Error"+DateTime.Now);
                    //}
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("[GetTelemetry] Error IOT, you should probably check this" +e);
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
