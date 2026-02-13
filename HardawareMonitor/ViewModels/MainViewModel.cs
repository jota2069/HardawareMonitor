using HardawareMonitor.Models;
using HardawareMonitor.Services;
using HardawareMonitor.ViewModels;
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
        private readonly CpuMonitor _cpuMonitor;
        private readonly MemoryMonitor _memoryMonitor;
        private readonly DiskMonitor _diskMonitor;

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

        public ICommand RefreshCommand { get; }

        public MainViewModel()
        {
            _cpuMonitor = new CpuMonitor();
            _memoryMonitor = new MemoryMonitor();
            _diskMonitor = new DiskMonitor();

            RefreshCommand = new RelayCommand(async () => await RefreshDataAsync());

            // Используем асинхронное обновление при старте
            _ = RefreshDataAsync();
        }

        public async Task RefreshDataAsync()
        {
            CpuInfo = await Task.Run(() => _cpuMonitor.GetCpuInfo());
            MemoryInfo = await Task.Run(() => _memoryMonitor.GetMemoryInfo());
            DiskInfo = await Task.Run(() => _diskMonitor.GetDiskInfo());
        }
    }
}
