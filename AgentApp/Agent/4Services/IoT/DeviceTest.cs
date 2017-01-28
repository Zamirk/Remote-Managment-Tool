using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;

namespace MyDeviceTest
{
    class DeviceTest
    {
        static DeviceClient deviceClient;

        private static string iotHubUri = "ManageIoT.azure-devices.net";

        static string deviceKey = "1pTf0qxFt0Nq1PgJMmwPmHH7peY1t9yXUi2IlVfggkg=";

        private bool kill = false;
        //Sending messages to the IoT hub
        private async void SendDeviceToCloudMessagesAsync()
        {
            //Loop for sending messages
            while (!kill)
            {
                string cpuSpeed = "18";

                //Telemetry data point
                var telemetryDataPoint = new
                {
                    deviceId = "Device_1",
                    DATA_CPU = cpuSpeed,
                    DATA_RAM = "ram,",
                    DATA_network = "net",
                };
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                Message message = new Message(Encoding.ASCII.GetBytes(messageString));

                await deviceClient.SendEventAsync(message);

                //Printing out message
                Console.WriteLine(messageString);
                
                Task.Delay(1000).Wait();


            }
        }

        public void stop()
        {
            kill = true;
            deviceClient.CloseAsync();
        }

        public void Test()
        {
            kill = false;
            Console.WriteLine("Simulated device\n");
            deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey("Device_1", deviceKey));
            SendDeviceToCloudMessagesAsync();
            Console.ReadLine();
        }
    }
}
//Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, messageString);
