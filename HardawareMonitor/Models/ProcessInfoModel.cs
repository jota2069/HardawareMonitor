using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardawareMonitor.Models
{
    public class ProcessInfoModel
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public double CpuUsage { get; set; } // %
        public long MemoryBytes { get; set; } // байты

        public ProcessInfoModel()
        {
            Name = "Неизвестно";
            Status = "Неизвестно";
            CpuUsage = 0;
            MemoryBytes = 0;
        }
    }
}
