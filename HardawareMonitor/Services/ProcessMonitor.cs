using HardawareMonitor.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardawareMonitor.Services
{
    public class ProcessMonitor
    {
        public List<ProcessInfoModel> GetProcesses()
        {
            List<ProcessInfoModel> processes = new List<ProcessInfoModel>();
            try
            {
                Process[] allProcesses = Process.GetProcesses();

                foreach (var proc in allProcesses)
                {
                    ProcessInfoModel p = new ProcessInfoModel();
                    try
                    {
                        p.Name = proc.ProcessName;
                        p.Status = proc.Responding ? "Запущен" : "Не отвечает";
                        p.MemoryBytes = proc.WorkingSet64;

                        // CPU Usage приблизительно
                        TimeSpan totalCpuTime = proc.TotalProcessorTime;
                        p.CpuUsage = totalCpuTime.TotalMilliseconds / Environment.ProcessorCount; // упрощённо
                    }
                    catch
                    {
                        // Если доступ запрещён, пропускаем
                        continue;
                    }

                    processes.Add(p);
                }
            }
            catch
            {
                // Игнорируем ошибки
            }

            return processes;
        }
    }
}
