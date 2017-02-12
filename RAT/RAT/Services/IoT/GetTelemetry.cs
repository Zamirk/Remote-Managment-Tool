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
        static string ConnectionString = "Endpoint=sb://iothub-ns-manageiot-107893-aab55f8a1a.servicebus.windows.net/;" +
                             "SharedAccessKeyName=iothubowner;" +
                             "SharedAccessKey=1QnPUGMCx86KJRaOsIg5BvhJtww13EU6kzprCPSr/qs=";

        static string eventHubEntity = "ManageIoT";
        static string partitionId = "1";

        static DateTime startingDateTimeUtc;

        static void test()
        {
            System.Diagnostics.Debug.WriteLine("Text");

            while (true)
            {
                System.Diagnostics.Debug.WriteLine("etstsetsetest");
            }
        }
        public static string aaaaa = "";
        public static List<Stack<TelemetryDatapoint>> listOfDevices;
        public static void ReceiveTelemetry()
        {

            ServiceBusConnectionStringBuilder builder = new ServiceBusConnectionStringBuilder(ConnectionString);
            builder.TransportType = TransportType.Amqp;

            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(ConnectionString);

            EventHubClient client = factory.CreateEventHubClient(eventHubEntity);
            EventHubConsumerGroup group = client.GetDefaultConsumerGroup();

            startingDateTimeUtc = DateTime.Now;

            EventHubReceiver receiver = group.CreateReceiver(partitionId, startingDateTimeUtc);

            Console.WriteLine("Receiving Data");

            listOfDevices = new List<Stack<TelemetryDatapoint>>();

            Stack<TelemetryDatapoint> myDevice = new Stack<TelemetryDatapoint>();
           // for (int i = 0; i < 100; i++)
           // {
                myDevice.Push(new TelemetryDatapoint("Device_1",0,0,0));
           // }

            listOfDevices.Add(myDevice);

            Console.WriteLine(listOfDevices[0].ElementAt(0).device_id);
            Console.WriteLine("");

            //List<Stack<> myStacks = new List<Stack>();
            // myStacks.Add(new Stack<TelemetryDatapoint>());

            List<string> devices = new List<string>()
            {
                "Device_1",
                "Device_2"
            };

            while (true)
            {
                System.Diagnostics.Debug.WriteLine("Level 1: Looping");
                EventData data = receiver.Receive();
                System.Diagnostics.Debug.WriteLine("Level 2: Data received");

                string JsonString = ":"+Encoding.UTF8.GetString(data.GetBytes());

                //TelemetryDatapoint telemetry = JsonConvert.DeserializeObject<TelemetryDatapoint>(JsonString);
                //if (telemetry.device_id.Equals("Device_1"))
                //    {
                    Console.WriteLine(JsonString);

                //    listOfDevices[0].Pop();
                 //       listOfDevices[0].Push(telemetry);
                //    }
                System.Diagnostics.Debug.WriteLine("Level 3"+ JsonString);
                aaaaa = JsonString;
                System.Diagnostics.Debug.WriteLine("eeee"+listOfDevices[0].ElementAt(0).device_id);
                System.Diagnostics.Debug.WriteLine(listOfDevices[0].ElementAt(0).value_1);
                System.Diagnostics.Debug.WriteLine(listOfDevices[0].ElementAt(0).value_2);
                // myStack.
            }
            
            receiver.Close();
            client.Close();
            factory.Close();
        }

    }
}
