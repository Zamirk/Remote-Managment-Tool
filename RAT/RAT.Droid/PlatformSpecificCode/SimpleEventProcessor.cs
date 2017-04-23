using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Renderscripts;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ConsoleApplication1;
using ConsoleApplication1.Folder;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using Newtonsoft.Json;

namespace ARAT.Droid.PlatformSpecificCode
{
    public class SimpleEventProcessor : IEventProcessor
    {
        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            Console.WriteLine($"Processor Shutting Down. Partition '{context.PartitionId}', Reason: '{reason}'.");
            return Task.CompletedTask;
        }

        public Task OpenAsync(PartitionContext context)
        {
            Console.WriteLine($"SimpleEventProcessor initialized. Partition: '{context.PartitionId}'");
            return Task.CompletedTask;
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            Console.WriteLine($"Error on Partition: {context.PartitionId}, Error: {error.Message}");
            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (var eventData in messages)
            {
                var data = Encoding.UTF8.GetString(eventData.Body.Array, eventData.Body.Offset, eventData.Body.Count);
                //System.Diagnostics.Debug.WriteLine("" + data);

                TelemetryDatapoint telemetry = JsonConvert.DeserializeObject<TelemetryDatapoint>(data);

                for (int i = 0; i < GetTelemetry.devices.Count; i++)
                {
                     if (telemetry.Device_id.Equals(GetTelemetry.devices[i]))
                    {
                        GetTelemetry.listOfDevices[i].Dequeue();
                        GetTelemetry.listOfDevices[i].Enqueue(telemetry);
                        GetTelemetry.lastTelemetryDatapoints[i] = telemetry;
                    }
                }

            }

            return context.CheckpointAsync();
        }
    }
}