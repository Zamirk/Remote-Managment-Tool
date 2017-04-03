using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApplication1;
using ConsoleApplication1.Folder;
using Syncfusion.SfChart.XForms;
using Tools;
using Xamarin.Forms;

namespace RAT._2ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        private ObservableCollection<ChartDataPoint> data;
        private bool killThread = false;
        private int y;

        public DashboardViewModel()
        {
            y = 0;
            Data = new ObservableCollection<ChartDataPoint>();
        }

        public ObservableCollection<ChartDataPoint> Data
        {
            set { SetProperty(ref data, value); }
            get { return data; }
        }

        public void GC()
        {
            killThread = true;
        }

        //Passing in device and data selection from graph selection screen
        public async void LoadMultipleValues(int deviceNo, int dataSelection)
        {
            y = 0;
            if (dataSelection == 0)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Cpu)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    if (killThread)
                    {
                        return false;
                    }
                    Data.RemoveAt(0);
                    y++;

                    var cpuValue = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu);
                    Data.Add(new ChartDataPoint(y, cpuValue));
                    return true;
                });
            } //CPU
            else if (dataSelection == 1)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Cpu2)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var cpuValue = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu2);
                    Data.Add(new ChartDataPoint(y, cpuValue));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //CPU Frequency
            else if (dataSelection == 2)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Thread)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var thread = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Thread);
                    Data.Add(new ChartDataPoint(y, thread));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Thread Count
            else if (dataSelection == 3)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.CpuTem)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var cpuTemp = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].CpuTem);
                    Data.Add(new ChartDataPoint(y, cpuTemp));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //CPU Temperature
            else if (dataSelection == 4)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Processes)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var processes = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Processes);
                    Data.Add(new ChartDataPoint(y, processes));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Number of processes
            else if (dataSelection == 5)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Percent)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var percent = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Percent);
                    Data.Add(new ChartDataPoint(y, percent));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Percent of CPU Frequency of Max
            else if (dataSelection == 6)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Ram)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var percent = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Ram);
                    Data.Add(new ChartDataPoint(y, percent));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Ram left
            else if (dataSelection == 7)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.RamInUse)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var ramInUse = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamInUse);
                    Data.Add(new ChartDataPoint(y, ramInUse));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Ram in use %
            else if (dataSelection == 8)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.RamCache)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var ramInUse = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamCache);
                    Data.Add(new ChartDataPoint(y, ramInUse));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Ram cahce
            else if (dataSelection == 9)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.RamCommitted)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var ramCommitted = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamCommitted);
                    Data.Add(new ChartDataPoint(y, ramCommitted));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Ram committed
            else if (dataSelection == 10)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.PagedPool)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var pagedPool = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].PagedPool);
                    Data.Add(new ChartDataPoint(y, pagedPool));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Ram paged pool
            else if (dataSelection == 11)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.NonPagedPool)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var nonPagedPool = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].NonPagedPool);
                    Data.Add(new ChartDataPoint(y, nonPagedPool));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Ram non paged pool
            else if (dataSelection == 12)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.DiskReadTime)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var diskReadTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskReadTime);
                    Data.Add(new ChartDataPoint(y, diskReadTime));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Disk read time
            else if (dataSelection == 13)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.DiskWriteTime)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var diskWriteTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskWriteTime);
                    Data.Add(new ChartDataPoint(y, diskWriteTime));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Disk write time
            else if (dataSelection == 14)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.DiskReadBytes)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var diskreadBytes = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskReadBytes);
                    Data.Add(new ChartDataPoint(y, diskreadBytes));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Disk read bytes
            else if (dataSelection == 15)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.DiskWriteBytes)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var diskwriteBytes = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskWriteBytes);
                    Data.Add(new ChartDataPoint(y, diskwriteBytes));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Disk write bytes
            else if (dataSelection == 16)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.FreeMB)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var freemb = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].FreeMB);
                    Data.Add(new ChartDataPoint(y, freemb));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Free mb
            else if (dataSelection == 17)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.FreeSpace)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var freespace = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].FreeSpace);
                    Data.Add(new ChartDataPoint(y, freespace));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Free disk space
            else if (dataSelection == 18)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.IdleTime)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var idleTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].IdleTime);
                    Data.Add(new ChartDataPoint(y, idleTime));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Idle time
            else if (dataSelection == 19)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.DiskTime)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var diskTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskTime);
                    Data.Add(new ChartDataPoint(y, diskTime));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Disk time
              //Network
            else if (dataSelection == 20)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.DownloadRate)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var downloadRate = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DownloadRate);
                    Data.Add(new ChartDataPoint(y, downloadRate));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Download rate
            else if (dataSelection == 21)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.UploadRate)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var uploadRate = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].UploadRate);
                    Data.Add(new ChartDataPoint(y, uploadRate));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Upload rate
            else if (dataSelection == 22)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Bandwidth)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var bandwidth = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Bandwidth);
                    Data.Add(new ChartDataPoint(y, bandwidth));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Bandwidth
            else if (dataSelection == 23)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.PacketsReceived)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var packetsReceived = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].PacketsReceived);
                    Data.Add(new ChartDataPoint(y, packetsReceived));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Packets received
            else if (dataSelection == 24)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.PacketsSent)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var packetsSent = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].PacketsSent);
                    Data.Add(new ChartDataPoint(y, packetsSent));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Packets sent
            else if (dataSelection == 25)
            {
                //Iterating over the queue of telemetry obects, adding to the chart databound collection
                Queue<TelemetryDatapoint> telemetryTemp = GetTelemetry.listOfDevices[deviceNo];
                foreach (var telemetry in telemetryTemp)
                {
                    //Only 30 values
                    if (y > 29)
                    {
                        data.Add(new ChartDataPoint(y, Convert.ToDouble(telemetry.Packets)));
                    }
                    y++;
                }
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    y++;

                    var packets = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Packets);
                    Data.Add(new ChartDataPoint(y, packets));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Packets
        }

        public async void LoadSingleValues(int deviceNo, int dataSelection)
        {
            if (dataSelection == 0)
            {
                //Initial value
                double cpuUsage = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu);
                double restOfSpace = 100 - cpuUsage;

                Data.Add(new ChartDataPoint("CPU %", cpuUsage));
                Data.Add(new ChartDataPoint("Empty Space", restOfSpace));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    Data.Add(new ChartDataPoint("CPU %",
                        Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu)));
                    restOfSpace = 100 - cpuUsage;
                    Data.Add(new ChartDataPoint("Empty Space", restOfSpace));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //CPU
            else if (dataSelection == 1)
            {
                //Initial value
                double frequency = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu2);
                double restOfFrequency = 2400 - frequency;

                Data.Add(new ChartDataPoint("Frequency", frequency));
                Data.Add(new ChartDataPoint("", restOfFrequency));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    frequency = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Cpu2);
                    restOfFrequency = 2450 - frequency;

                    Data.Add(new ChartDataPoint("Frequency", frequency));
                    Data.Add(new ChartDataPoint(".", restOfFrequency));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //CPU Frequency
            else if (dataSelection == 2)
            {
                //Initial value
                double threadcount = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Thread);
                double restOfFrequency = 3000 - threadcount;

                Data.Add(new ChartDataPoint("Threads", threadcount));
                Data.Add(new ChartDataPoint("", restOfFrequency));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    threadcount = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Thread);
                    restOfFrequency = 3000 - threadcount;

                    Data.Add(new ChartDataPoint("Threads", threadcount));
                    Data.Add(new ChartDataPoint("", restOfFrequency));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Thread Count
            else if (dataSelection == 3)
            {
                //Initial value
                double cpuTemp = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].CpuTem);
                double remainingTemp = 85 - cpuTemp;

                Data.Add(new ChartDataPoint("C*", cpuTemp));
                Data.Add(new ChartDataPoint("", remainingTemp));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    cpuTemp = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].CpuTem);
                    remainingTemp = 85 - cpuTemp;

                    Data.Add(new ChartDataPoint("CPU Temp", cpuTemp));
                    Data.Add(new ChartDataPoint("", remainingTemp));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //CPU Temperature
            else if (dataSelection == 4)
            {
                //Initial value
                double processes = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].CpuTem);
                double remainingProcesses = 150 - processes;

                Data.Add(new ChartDataPoint("No. Processes", processes));
                Data.Add(new ChartDataPoint("", remainingProcesses));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    processes = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].CpuTem);
                    remainingProcesses = 150 - processes;

                    Data.Add(new ChartDataPoint("No. Processes", processes));
                    Data.Add(new ChartDataPoint("", remainingProcesses));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Number of processes
            else if (dataSelection == 5)
            {
                //Initial value
                double percent = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Percent);
                double remaining = 100 - percent;

                Data.Add(new ChartDataPoint("CPU % of Max", percent));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    percent = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Percent);
                    remaining = 100 - percent;

                    Data.Add(new ChartDataPoint("CPU % of Max", percent));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Percent of CPU Frequency of Max
            else if (dataSelection == 6)
            {
                //Initial value
                double ram = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Ram);
                double remaining = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamInUse);

                Data.Add(new ChartDataPoint("Ram left", ram));
                Data.Add(new ChartDataPoint("Ram InUse", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    ram = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Ram);
                    remaining = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamInUse);

                    Data.Add(new ChartDataPoint("Ram left", ram));
                    Data.Add(new ChartDataPoint("Ram InUse", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Ram left
            else if (dataSelection == 7)
            {
                //Initial value
                double ram = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Ram);
                double remaining = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamInUse);

                Data.Add(new ChartDataPoint("Ram InUse", remaining));
                Data.Add(new ChartDataPoint("Ram left", ram));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    ram = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Ram);
                    remaining = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamInUse);

                    Data.Add(new ChartDataPoint("Ram InUse", remaining));
                    Data.Add(new ChartDataPoint("Ram left", ram));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Ram in use %
            else if (dataSelection == 8)
            {
                //Initial value
                double ramCache = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamCache);
                double remaining = 8500 - ramCache;

                Data.Add(new ChartDataPoint("Ram cached", ramCache));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    ramCache = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamCache);
                    remaining = 8500 - ramCache;

                    Data.Add(new ChartDataPoint("Ram cached", ramCache));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Ram cache
            else if (dataSelection == 9)
            {
                //Initial value
                double ramCommitted = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamCommitted);
                double remaining = 8500 - ramCommitted;

                Data.Add(new ChartDataPoint("Ram committed", ramCommitted));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    ramCommitted = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].RamCommitted);
                    remaining = 8500 - ramCommitted;

                    Data.Add(new ChartDataPoint("Ram committed", ramCommitted));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Ram committed
            else if (dataSelection == 10)
            {
                //Initial value
                double pagedPool = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].PagedPool);
                double remaining = 8500 - pagedPool;

                Data.Add(new ChartDataPoint("Paged Pool", pagedPool));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    pagedPool = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].PagedPool);
                    remaining = 8500 - pagedPool;

                    Data.Add(new ChartDataPoint("Paged Pool", pagedPool));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Paged pool
            else if (dataSelection == 11)
            {
                //Initial value
                double nonpagedPool = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].NonPagedPool);
                double remaining = 8500 - nonpagedPool;

                Data.Add(new ChartDataPoint("Non paged Pool", nonpagedPool));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    nonpagedPool = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].PagedPool);
                    remaining = 8500 - nonpagedPool;

                    Data.Add(new ChartDataPoint("Non Paged Pool", nonpagedPool));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Non Paged pool
            else if (dataSelection == 12)
            {
                //Initial value
                double diskReadTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskReadTime);
                double remaining = 100 - diskReadTime;

                Data.Add(new ChartDataPoint("Disk read time", diskReadTime));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    diskReadTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskReadTime);
                    remaining = 100 - diskReadTime;

                    Data.Add(new ChartDataPoint("Disk read time", diskReadTime));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Disk read 
            else if (dataSelection == 13)
            {
                //Initial value
                double diskWriteTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskWriteTime);
                double remaining = 100 - diskWriteTime;

                Data.Add(new ChartDataPoint("Disk write time", diskWriteTime));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    diskWriteTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskWriteTime);
                    remaining = 100 - diskWriteTime;

                    Data.Add(new ChartDataPoint("Disk write time", diskWriteTime));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Disk write 
            else if (dataSelection == 14)
            {
                //Initial value
                double diskReadBytes = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskReadBytes);
                double remaining = 1000 - diskReadBytes;

                Data.Add(new ChartDataPoint("Disk read bytes", diskReadBytes));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    diskReadBytes = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskReadBytes);
                    remaining = 1000 - diskReadBytes;

                    Data.Add(new ChartDataPoint("Disk read bytes", diskReadBytes));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Disk read bytes
            else if (dataSelection == 15)
            {
                //Initial value
                double diskWriteBytes = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskWriteBytes);
                double remaining = 1000 - diskWriteBytes;

                Data.Add(new ChartDataPoint("Disk write bytes", diskWriteBytes));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    diskWriteBytes = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskWriteBytes);
                    remaining = 1000 - diskWriteBytes;

                    Data.Add(new ChartDataPoint("Disk write bytes", diskWriteBytes));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Disk write bytes
            else if (dataSelection == 16)
            {
                //Initial value
                double freemb = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].FreeMB);
                double remaining = 100 - freemb;

                Data.Add(new ChartDataPoint("Free mb", freemb));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    freemb = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].FreeMB);
                    remaining = 100 - freemb;

                    Data.Add(new ChartDataPoint("Free mb", freemb));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Free mb
            else if (dataSelection == 17)
            {
                //Initial value
                double freespace = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].FreeSpace);
                double remaining = 100 - freespace;

                Data.Add(new ChartDataPoint("Free space", freespace));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    freespace = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].FreeSpace);
                    remaining = 100 - freespace;

                    Data.Add(new ChartDataPoint("Free space", freespace));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Free disk space
            else if (dataSelection == 18)
            {
                //Initial value
                double idleTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].IdleTime);
                double remaining = 100 - idleTime;

                Data.Add(new ChartDataPoint("Idle time", idleTime));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    idleTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].IdleTime);
                    remaining = 100 - idleTime;

                    Data.Add(new ChartDataPoint("Idle time", idleTime));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Idle time
            else if (dataSelection == 19)
            {
                //Initial value
                double diskTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskTime);
                double remaining = 100 - diskTime;

                Data.Add(new ChartDataPoint("Disk time", diskTime));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    diskTime = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DiskTime);
                    remaining = 100 - diskTime;

                    Data.Add(new ChartDataPoint("Disk time", diskTime));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Disk time
              //Network
            else if (dataSelection == 20)
            {
                //Initial value
                double downloadRate = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DownloadRate);
                double remaining = 1000 - downloadRate;

                Data.Add(new ChartDataPoint("Download Rate", downloadRate));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    downloadRate = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].DownloadRate);
                    remaining = 1000 - downloadRate;

                    Data.Add(new ChartDataPoint("Download Rate", downloadRate));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Download rate
            else if (dataSelection == 21)
            {
                //Initial value
                double uploadRate = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].UploadRate);
                double remaining = 1000 - uploadRate;

                Data.Add(new ChartDataPoint("Upload Rate", uploadRate));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    uploadRate = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].UploadRate);
                    remaining = 1000 - uploadRate;

                    Data.Add(new ChartDataPoint("Upload Rate", uploadRate));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Upload rate
            else if (dataSelection == 22)
            {
                //Initial value
                double bandwidth = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Bandwidth);
                double remaining = 1000 - bandwidth;

                Data.Add(new ChartDataPoint("Bandwidth", bandwidth));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    bandwidth = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Bandwidth);
                    remaining = 1000 - bandwidth;

                    Data.Add(new ChartDataPoint("Bandwidth", bandwidth));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Bandwidth
            else if (dataSelection == 23)
            {
                //Initial value
                double packetsReceived = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].PacketsReceived);
                double remaining = 1000 - packetsReceived;

                Data.Add(new ChartDataPoint("Packets Received", packetsReceived));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    packetsReceived = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].PacketsReceived);
                    remaining = 1000 - packetsReceived;

                    Data.Add(new ChartDataPoint("Packets Received", packetsReceived));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Packets received
            else if (dataSelection == 24)
            {
                //Initial value
                double packetsReceived = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].PacketsReceived);
                double remaining = 1000 - packetsReceived;

                Data.Add(new ChartDataPoint("Packets Received", packetsReceived));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    packetsReceived = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].PacketsReceived);
                    remaining = 1000 - packetsReceived;

                    Data.Add(new ChartDataPoint("Packets Received", packetsReceived));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Packets sent
            else if (dataSelection == 25)
            {
                //Initial value
                double packets = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Packets);
                double remaining = 1000 - packets;

                Data.Add(new ChartDataPoint("Packets", packets));
                Data.Add(new ChartDataPoint("", remaining));
                await Task.Delay(1000);

                //Updates the information onece a second
                Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), () =>
                {
                    Data.RemoveAt(0);
                    Data.RemoveAt(0);
                    packets = Convert.ToDouble(GetTelemetry.lastTelemetryDatapoints[deviceNo].Packets);
                    remaining = 1000 - packets;

                    Data.Add(new ChartDataPoint("Packets", packets));
                    Data.Add(new ChartDataPoint("", remaining));
                    if (killThread)
                    {
                        return false;
                    }
                    return true;
                });
            } //Packets
        }
    }
}
