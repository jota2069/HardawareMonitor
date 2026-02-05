using HardawareMonitor.Models;

namespace HardawareMonitor.Models
{
    /// <summary>
    /// Класс для хранения системной информации
    /// </summary>
    public class SystemInfo
    {
        // Название операционной системы
        public string OsName { get; set; }

        // Версия ОС
        public string OsVersion { get; set; }

        // Архитектура системы
        public string Architecture { get; set; }

        // Имя компьютера в сети
        public string ComputerName { get; set; }

        // Имя текущего пользователя
        public string UserName { get; set; }

        public SystemInfo()
        {
            OsName = "Неизвестно";
            OsVersion = "Неизвестно";
            Architecture = "Неизвестно";
            ComputerName = "Неизвестно";
            UserName = "Неизвестно";
        }
    }
}