using System.Collections.Generic;
using Avalonia.Media;
using AvaloniaApp.Models;

namespace AvaloniaApp.Services;

// TODO: replace with a real scan of the Windows registry / AppData installed-program
// list (Architecture.md §5). Until that's built, this is a small hardcoded placeholder
// so the App Translation modal is demoable with real data-binding plumbing.
public class AppTranslationCatalog
{
    public IReadOnlyList<AppTranslationEntry> GetSuggestions() => new List<AppTranslationEntry>
    {
        new()
        {
            SourceApp = "MS Office", SourceLogoGlyph = "W", SourceLogoColor = Brush.Parse("#0078D7"),
            TargetApp = "OnlyOffice", TargetLogoGlyph = "O", TargetLogoColor = Brush.Parse("#D83B01"),
            TargetPackageManager = "Flatpak",
            Explanation = "Highly compatible alternative that opens .docx/.xlsx/.pptx without conversion issues."
        },
        new()
        {
            SourceApp = "Spotify", SourceLogoGlyph = "S", SourceLogoColor = Brush.Parse("#1DB954"),
            TargetApp = "Spotify", TargetLogoGlyph = "S", TargetLogoColor = Brush.Parse("#1DB954"),
            TargetPackageManager = "Native Package",
            Explanation = "Spotify ships an official Linux client."
        },
        new()
        {
            SourceApp = "Adobe Photoshop", SourceLogoGlyph = "Ps", SourceLogoColor = Brush.Parse("#31A8FF"),
            TargetApp = "GIMP", TargetLogoGlyph = "G", TargetLogoColor = Brush.Parse("#5C5543"),
            TargetPackageManager = "Flatpak",
            Explanation = "Free, full-featured raster editor with a comparable layers/plugins workflow."
        },
        new()
        {
            SourceApp = "Adobe Acrobat", SourceLogoGlyph = "A", SourceLogoColor = Brush.Parse("#DC3E28"),
            TargetApp = "Okular", TargetLogoGlyph = "O", TargetLogoColor = Brush.Parse("#1D99F3"),
            TargetPackageManager = "APT/DNF",
            Explanation = "Handles PDF annotation and forms out of the box."
        },
        new()
        {
            SourceApp = "Notepad++", SourceLogoGlyph = "N", SourceLogoColor = Brush.Parse("#90E59A"),
            TargetApp = "VS Code", TargetLogoGlyph = "VS", TargetLogoColor = Brush.Parse("#007ACC"),
            TargetPackageManager = "Flatpak",
            Explanation = "Closest match for lightweight text/code editing."
        },
        new()
        {
            SourceApp = "WinRAR", SourceLogoGlyph = "R", SourceLogoColor = Brush.Parse("#8B0000"),
            TargetApp = "File Roller", TargetLogoGlyph = "FR", TargetLogoColor = Brush.Parse("#F6A429"),
            TargetPackageManager = "APT/DNF",
            Explanation = "Built-in archive manager, supports .rar/.zip/.7z."
        },
    };
}
