using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ARAT.Droid.PlatformSpecificCode;
using IoTHubAmqp;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using Newtonsoft.Json;
using RAT._1View.UWP.SubScreens._0Manage._1DashboardScreen;

namespace ConsoleApplication1.Folder
{
    public class GetTelemetry
    {
        //Storage account const
        private const string StorageAccountName = "mystorageaccountscus";

        private const string StorageAccountKey =
            "KgcTJAQNEgDMICrdzkwHsp43LoSBUrs1pdKu6uSy2AXz4ohFCZk07eWNiJ1sgUDfddttDXUAjfUvVFDUctIEqA==";

        public static bool go = true;

        static string partitionId = "0";
        static string partitionId1 = "1";

        //Todays date and time
        static DateTime startingDateTimeUtc;

        //List of devices
        public static List<string> devices = new List<string>()
        {
            "Device_1",
            "Device_2",
            "Device_3",
            "Device_4",
            "Device_5",
            "Device_6",
            "Device_7",
            "Device_8",
            "Device_9",
            "Device_10"
        };

        //Last received values
        public static List<TelemetryDatapoint> lastTelemetryDatapoints = new List<TelemetryDatapoint>()
        {
            new TelemetryDatapoint(""),
            new TelemetryDatapoint(""),
            new TelemetryDatapoint(""),
            new TelemetryDatapoint(""),
            new TelemetryDatapoint(""),
            new TelemetryDatapoint(""),
            new TelemetryDatapoint(""),
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
            new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>(),
            new Queue<TelemetryDatapoint>()
        };

        //Receive data partition 0
        public static void ReceiveTelemetry2()
        {
        }

        //Receive data all partitions
        public static async void ReceiveTelemetry()
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

            EhConnectionString = UserData.connectionString;
            EhEntityPath = UserData.eventHubEntity;

            string _guid = Guid.NewGuid().ToString();
            string eventProcessorHostName = _guid;

            string leaseName = eventProcessorHostName = _guid;
            Console.WriteLine("Registering EventProcessor...");

            var eventProcessorHost = new EventProcessorHost(
                eventProcessorHostName,
                EhEntityPath,
                PartitionReceiver.DefaultConsumerGroupName,
                EhConnectionString,
                StorageConnectionString,
                leaseName);

            // Registers the Event Processor Host and starts receiving messages
            await eventProcessorHost.RegisterEventProcessorAsync<SimpleEventProcessor>(new EventProcessorOptions()
            {
                InitialOffsetProvider = (partitionId) => DateTime.UtcNow,
            });
            //Console.WriteLine("Receiving. Press ENTER to stop worker.");
            //Console.ReadLine();

            // Disposes of the Event Processor Host
            // await eventProcessorHost.UnregisterEventProcessorAsync();
        }


        private static string EhConnectionString = UserData.connectionString;
        private static string EhEntityPath = UserData.eventHubEntity;

        private static readonly string StorageConnectionString =
            string.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", StorageAccountName,
                StorageAccountKey);
    }
}