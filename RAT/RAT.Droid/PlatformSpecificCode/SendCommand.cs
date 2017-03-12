using IoTHubAmqp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ConsoleApplication1;
using Newtonsoft.Json;

namespace IoTHubAmqpService
{
    class SendCommand
    {
        public void SendCommandToDevice()
        {
        }
        public CommandDatapoint Command { get; set; }
    }
}