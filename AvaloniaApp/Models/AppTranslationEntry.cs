using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApp.Models;

public partial class AppTranslationEntry : ObservableObject
{
    public required string SourceApp { get; init; }
    public required string SourceLogoGlyph { get; init; }
    public required IBrush SourceLogoColor { get; init; }

    public required string TargetApp { get; init; }
    public required string TargetLogoGlyph { get; init; }
    public required IBrush TargetLogoColor { get; init; }
    public required string TargetPackageManager { get; init; }
    public string? Explanation { get; init; }

    [ObservableProperty]
    private bool _isIncluded = true;
}
