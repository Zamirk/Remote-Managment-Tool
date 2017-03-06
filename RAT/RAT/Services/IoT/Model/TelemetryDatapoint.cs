using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    public class TelemetryDatapoint
    {
        public TelemetryDatapoint(string device_id)
        {
            Device_id = device_id;
            Cpu = "50";
            RamInUse = "50";
        }
            public string Device_id { get; set; }
        //CPU
            public string Cpu { get; set; }
            public string Cpu2 { get; set; }
            public string Thread { get; set; }
            public string CpuTem { get; set; }
            public string Processes { get; set; }
            public string Percent { get; set; }
        //Ram
            public string Ram { get; set; }
            public string RamInUse { get; set; }
            public string RamCache { get; set; }
            public string RamCommitted { get; set; }
            public string PagedPool { get; set; }
            public string NonPagedPool { get; set; }
            public string DiskReadTime { get; set; }
            public string DiskWriteTime { get; set; }
            public string DiskReadBytes { get; set; }
            public string DiskWriteBytes { get; set; }
            public string FreeMB { get; set; }
            public string FreeSpace { get; set; }
            public string IdleTime { get; set; }
            public string DiskTime { get; set; }
            public string DownloadRate { get; set; }
            public string UploadRate { get; set; }
            public string Bandwidth { get; set; }
            public string PacketsReceived { get; set; }
            public string PacketsSent { get; set; }
            public string Packets { get; set; }
        public List<ProcessData> ListTest { get; set; }
    }
    }
