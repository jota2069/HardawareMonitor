using System.Collections.Generic;

namespace HardawareMonitor.Models
{
    /// <summary>
    /// Класс для хранения информации о дисках системы
    /// </summary>
    public class DiskInfo
    {
        // Список физических дисков
        public List<PhysicalDiskInfo> PhysicalDisks { get; set; }

        // Список логических дисков
        public List<LogicalDiskInfo> LogicalDisks { get; set; }

        /// <summary>
        /// Конструктор инициализирует коллекции
        /// </summary>
        public DiskInfo()
        {
            PhysicalDisks = new List<PhysicalDiskInfo>();
            LogicalDisks = new List<LogicalDiskInfo>();
        }
    }

    /// <summary>
    /// Класс для хранения информации о физическом диске
    /// </summary>
    public class PhysicalDiskInfo
    {
        // Модель диска
        public string Model { get; set; }

        // Размер диска в байтах
        public long Size { get; set; }

        // Тип носителя
        public string MediaType { get; set; }

        public PhysicalDiskInfo()
        {
            Model = "Неизвестно";
            MediaType = "Неизвестно";
        }
    }

    /// <summary>
    /// Класс для хранения информации о логическом диске (разделе)
    /// </summary>
    public class LogicalDiskInfo
    {
        // Буква диска
        public string DriveLetter { get; set; }

        // Общий размер раздела в байтах
        public long TotalSizeBytes { get; set; }

        // Свободное место на разделе в байтах
        public long FreeSizeBytes { get; set; }

        // Файловая система (NTFS, FAT32, exFAT)
        public string FileSystem { get; set; }

        /// <summary>
        /// Вычисляемое свойство: процент использования диска
        /// </summary>
        public double UsagePercent
        {
            get
            {
                if (TotalSizeBytes <= 0)
                {
                    return 0.0;
                }
                return (double)(TotalSizeBytes - FreeSizeBytes) / TotalSizeBytes * 100.0;
            }
        }

        public LogicalDiskInfo()
        {
            DriveLetter = "";
            FileSystem = "Неизвестно";
        }
    }
}