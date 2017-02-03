using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Azure.Devices.Client;

namespace a
{
    class RecieveMessages
    {
        private DeviceClient deviceClient;
        static string connectionString = "{iot hub connection string}";
        private static IotHubConnectionStringBuilder myConnectionStringBuilder;

        public RecieveMessages()
        {
            string connectionString = "HostName=ManageIoT.azure-devices.net;" +
                                       "SharedAccessKeyName=iothubowner;" +
                                       "SharedAccessKey=1QnPUGMCx86KJRaOsIg5BvhJtww13EU6kzprCPSr/qs=";
            string iotHubD2cEndpoint = "messages/events";

            myConnectionStringBuilder.HostName = "";
            IotHubConnectionStringBuilder.Create("HostName=ManageIoT.azure-devices.net");
        }
    }
}