using HardawareMonitor.Models;
using HardawareMonitor.Services;
using HardwareMonitor.ViewModels;
using HardаwareMonitor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HardawareMonitor.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        // Поля сервисовв
        private CpuMonitor _cpuMonitor;
        private MemoryMonitor _memoryMonitor;
        private DiskMonitor _diskMonitor;


        // Свойства для хранения данных
        private CpuInfo _cpuInfo;
        public CpuInfo CpuInfo
        {
            get => _cpuInfo;
            set => SetProperty(ref _cpuInfo, value);
        }

        private MemoryInfo _memoryInfo;
        public MemoryInfo MemoryInfo
        {
            get => _memoryInfo;
            set => SetProperty(ref _memoryInfo, value);
        }

        private DiskInfo _diskInfo;
        public DiskInfo DiskInfo
        {
            get => _diskInfo;
            set => SetProperty(ref _diskInfo, value);
        }

        // Командда (нужно для MVVM)
        public ICommand RefreshCommand { get; }

        // конструктор класса
        public MainViewModel()
        {
            _cpuMonitor = new CpuMonitor();
            _memoryMonitor = new MemoryMonitor();
            _diskMonitor = new DiskMonitor();


            RefreshCommand = new RelayCommand(async () => await RefreshDataAsync());
        }

        private async Task RefreshDataAsync()
        {
            CpuInfo = await Task.Run(() => _cpuMonitor.GetCpuInfo());
            MemoryInfo = await Task.Run(() => _memoryMonitor.GetMemoryInfo());
            DiskInfo = await Task.Run(() => _diskMonitor.GetDiskInfo());
        }


        //Метод обновления данных
        public void RefreshData()
        {
            CpuInfo = _cpuMonitor.GetCpuInfo();
            MemoryInfo = _memoryMonitor.GetMemoryInfo();
            DiskInfo = _diskMonitor.GetDiskInfo();
        }
    }
}
