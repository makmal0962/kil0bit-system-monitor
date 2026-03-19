using Windows.UI;
using Microsoft.UI;
using System.Linq;

namespace Kil0bitSystemMonitor.Models
{
    public class SystemMetrics
    {
        public float CpuUsage { get; set; }
        public float RamPercent { get; set; }
        public string RamUsageText { get; set; } = "0/0 GB";
        public float GpuUsage { get; set; }
        public float GpuTemperature { get; set; }
        public float NetUpKbps { get; set; }
        public float NetDownKbps { get; set; }
        public string NetUpText { get; set; } = "0 KB/s";
        public string NetDownText { get; set; } = "0 KB/s";
        public float DiskUsage { get; set; }
        public string DiskSpaceText { get; set; } = "0%";
    }

    public class AppConfig : System.ComponentModel.INotifyPropertyChanged
    {
        private bool _showOverlay = true;
        private bool _lockPosition = false;
        private bool _launchOnStartup = false;
        private bool _showCpu = true;
        private bool _showRam = true;
        private bool _showGpu = true;
        private bool _showTemp = true;
        private bool _showDisk = true;
        private bool _showNetUp = true;
        private bool _showNetDown = true;
        private string _networkAdapter = "Default";
        private string _gpuAdapter = "Default";
        private string _diskDrive = "All";
        private string _displayStyle = "Icon";
        private string _fontFamily = "Segoe UI";
        private string _accentColorHex = "#FFFFFF";
        private string _iconColorHex = "#00CCFF";
        private double _x = 100;
        private double _y = 100;
        private bool _hideOnFullscreen = true;
        private bool _stickToTaskbar = true;
        private bool _showBackground = false;
        private string _backgroundColorHex = "#B4141414";
        private double _scaleFactor = 1.0;
        private bool _isTextBold = true;
        private bool _isIconBold = false;
        private string _theme = "Default";

        public bool ShowOverlay { get => _showOverlay; set { _showOverlay = value; OnPropertyChanged(); } }
        public bool LockPosition { get => _lockPosition; set { _lockPosition = value; OnPropertyChanged(); } }
        public bool LaunchOnStartup { get => _launchOnStartup; set { _launchOnStartup = value; OnPropertyChanged(); } }

        public bool ShowCpu { get => _showCpu; set { _showCpu = value; OnPropertyChanged(); } }
        public bool ShowRam { get => _showRam; set { _showRam = value; OnPropertyChanged(); } }
        public bool ShowGpu { get => _showGpu; set { _showGpu = value; OnPropertyChanged(); } }
        public bool ShowTemp { get => _showTemp; set { _showTemp = value; OnPropertyChanged(); } }
        public bool ShowDisk { get => _showDisk; set { _showDisk = value; OnPropertyChanged(); } }
        public bool ShowNetUp { get => _showNetUp; set { _showNetUp = value; OnPropertyChanged(); } }
        public bool ShowNetDown { get => _showNetDown; set { _showNetDown = value; OnPropertyChanged(); } }

        public string NetworkAdapter { get => _networkAdapter; set { _networkAdapter = value; OnPropertyChanged(); } }
        public string GpuAdapter { get => _gpuAdapter; set { _gpuAdapter = value; OnPropertyChanged(); } }
        public string DiskDrive { get => _diskDrive; set { _diskDrive = value; OnPropertyChanged(); } }
        public string DisplayStyle { get => _displayStyle; set { _displayStyle = value; OnPropertyChanged(); } }
        public string FontFamily { get => _fontFamily; set { _fontFamily = value; OnPropertyChanged(); } }

        public string AccentColorHex { get => _accentColorHex; set { _accentColorHex = value; OnPropertyChanged(); OnPropertyChanged(nameof(AccentColor)); } }
        public string IconColorHex { get => _iconColorHex; set { _iconColorHex = value; OnPropertyChanged(); OnPropertyChanged(nameof(IconColor)); } }
        public string BackgroundColorHex { get => _backgroundColorHex; set { _backgroundColorHex = value; OnPropertyChanged(); OnPropertyChanged(nameof(BackgroundColor)); } }

        public double ScaleFactor { get => _scaleFactor; set { _scaleFactor = value; OnPropertyChanged(); } }
        public bool IsTextBold { get => _isTextBold; set { _isTextBold = value; OnPropertyChanged(); } }
        public bool IsIconBold { get => _isIconBold; set { _isIconBold = value; OnPropertyChanged(); } }
        public string Theme { get => _theme; set { _theme = value; OnPropertyChanged(); } }

        public double X { get => _x; set { _x = value; OnPropertyChanged(); } }
        public double Y { get => _y; set { _y = value; OnPropertyChanged(); } }
        public bool HideOnFullscreen { get => _hideOnFullscreen; set { _hideOnFullscreen = value; OnPropertyChanged(); } }
        public bool StickToTaskbar { get => _stickToTaskbar; set { _stickToTaskbar = value; OnPropertyChanged(); } }
        public bool ShowBackground { get => _showBackground; set { _showBackground = value; OnPropertyChanged(); } }

        [System.Text.Json.Serialization.JsonIgnore]
        public Color AccentColor { get => HexToColor(AccentColorHex); set => AccentColorHex = ColorToHex(value); }

        [System.Text.Json.Serialization.JsonIgnore]
        public Color IconColor { get => HexToColor(IconColorHex); set => IconColorHex = ColorToHex(value); }

        [System.Text.Json.Serialization.JsonIgnore]
        public Color BackgroundColor { get => HexToColor(BackgroundColorHex); set => BackgroundColorHex = ColorToHex(value); }

        private Color HexToColor(string hex)
        {
            try
            {
                hex = hex.TrimStart('#');
                if (hex.Length == 8) // ARGB
                {
                    return Color.FromArgb(
                        byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber));
                }
                if (hex.Length == 6) // RGB
                {
                    return Color.FromArgb(255,
                        byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
                }
            }
            catch { }
            return Microsoft.UI.Colors.White;
        }

        private string ColorToHex(Color c) => $"#{c.A:X2}{c.R:X2}{c.G:X2}{c.B:X2}";

        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }
    }
}
