using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RAT.ZTry;

namespace ConsoleApplication1
{
    public class CommandDatapoint
    {
        public DateTime ExpireTime { get; set; }
        public string Command { get; set; }
        public string ProcessName { get; set; }
        public CommandType CommandType { get; set; }
    }
}
