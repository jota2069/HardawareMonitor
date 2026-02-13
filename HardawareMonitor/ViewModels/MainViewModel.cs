using HardawareMonitor.Models;
using HardawareMonitor.Services;
using HardawareMonitor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


using HardawareMonitor.Models;
using HardawareMonitor.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HardawareMonitor.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        // Сервисы
        private readonly CpuMonitor _cpuMonitor;
        private readonly MemoryMonitor _memoryMonitor;
        private readonly DiskMonitor _diskMonitor;
        private readonly ProcessMonitor _processMonitor;

        // Свойства данных
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

        private List<ProcessInfoModel> _processes;
        public List<ProcessInfoModel> Processes
        {
            get => _processes;
            set => SetProperty(ref _processes, value);
        }

        // Команда обновления
        public ICommand RefreshCommand { get; }

        // Конструктор
        public MainViewModel()
        {
            _cpuMonitor = new CpuMonitor();
            _memoryMonitor = new MemoryMonitor();
            _diskMonitor = new DiskMonitor();
            _processMonitor = new ProcessMonitor();

            RefreshCommand = new RelayCommand(async () => await RefreshDataAsync());

            // Асинхронное обновление при старте
            _ = RefreshDataAsync();
        }

        // Метод обновления всех данных
        public async Task RefreshDataAsync()
        {
            CpuInfo = await Task.Run(() => _cpuMonitor.GetCpuInfo());
            MemoryInfo = await Task.Run(() => _memoryMonitor.GetMemoryInfo());
            DiskInfo = await Task.Run(() => _diskMonitor.GetDiskInfo());
            Processes = await Task.Run(() => _processMonitor.GetProcesses());
        }
    }
}

