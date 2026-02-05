using System.Collections.Generic;

namespace HardawareMonitor.Models
{
    /// <summary>
    /// Класс для хранения информации об оперативной памяти
    /// </summary>
    public class MemoryInfo
    {
        // Общий объем оперативной памяти в байтах
        public long TotalMemoryBytes { get; set; }

        // Доступный объем памяти в байтах
        public long AvailableMemoryBytes { get; set; }

        // Список установленных модулей памяти
        public List<MemoryModule> Modules { get; set; }

        /// <summary>
        /// Вычисляемое свойство - процент использования памяти
        /// </summary>
        public double UsagePercentage
        {
            get
            {
                if (TotalMemoryBytes <= 0)
                {
                    return 0.0;
                }
                return (double)(TotalMemoryBytes - AvailableMemoryBytes) / TotalMemoryBytes * 100.0;
            }
        }

        public MemoryInfo()
        {
            Modules = new List<MemoryModule>();
        }
    }

    /// <summary>
    /// Класс для хранения информации об отдельном модуле памяти
    /// </summary>
    public class MemoryModule
    {
        // Производитель модуля памяти
        public string Manufacturer { get; set; }

        // Объем модуля в байтах
        public long CapacityBytes { get; set; }

        // Частота модуля в МГц
        public int SpeedMHz { get; set; }

        public MemoryModule()
        {
            Manufacturer = "Неизвестно";
        }
    }
}