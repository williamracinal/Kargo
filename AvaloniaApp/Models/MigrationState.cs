using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApp.Models;

public enum DesktopParadigm
{
    Windows,
    MacOS
}

public enum PrimaryRole
{
    Gaming,
    DailyUse,
    Productivity,
    Enthusiast
}

public enum UpdateStance
{
    LTS,
    BleedingEdge
}

public enum GpuManufacturer
{
    Unknown,
    Nvidia,
    AMD,
    Intel
}

public partial class MigrationState : ObservableObject
{
    [ObservableProperty]
    private DesktopParadigm _selectedParadigm = DesktopParadigm.Windows;

    [ObservableProperty]
    private PrimaryRole _selectedRole = PrimaryRole.DailyUse;

    [ObservableProperty]
    private UpdateStance _selectedStance = UpdateStance.LTS;

    [ObservableProperty]
    private GpuManufacturer _detectedGpu = GpuManufacturer.Unknown;

    [ObservableProperty]
    private string _gpuDetails = string.Empty;

    [ObservableProperty]
    private string? _gpuDetectionError;

    [ObservableProperty]
    private bool _isDiagnosticsComplete;

    [ObservableProperty]
    private bool _backupViaRclone = true;

    [ObservableProperty]
    private string _targetUsbDrive = string.Empty;
}
