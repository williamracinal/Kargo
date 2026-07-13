using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AvaloniaApp.Models;
using Material.Icons;

namespace AvaloniaApp.ViewModels;

public class Slide1ViewModel : ViewModelBase
{
    private readonly MigrationState _state;

    public SlideHeaderViewModel Header { get; } = new(
        MaterialIconKind.Monitor,
        "Choose your desktop layout",
        "How do you prefer to navigate your system?");

    public ObservableCollection<ISelectableOption> Options { get; }
    public IReadOnlyList<OptionRow> OptionRows { get; }

    public Slide1ViewModel(MigrationState state)
    {
        _state = state;

        Options = new ObservableCollection<ISelectableOption>
        {
            new SelectableOption<DesktopParadigm>(Select)
            {
                Value = DesktopParadigm.Windows,
                Title = "Bottom Taskbar",
                Description = "Windows-style layout",
                IconKind = MaterialIconKind.PageLayoutSidebarLeft,
            },
            new SelectableOption<DesktopParadigm>(Select)
            {
                Value = DesktopParadigm.MacOS,
                Title = "Centered Dock",
                Description = "macOS-style layout with bottom dock and top bar",
                IconKind = MaterialIconKind.DockBottom,
            },
        };
        OptionRows = OptionRow.Chunk(Options);

        SyncSelection();
    }

    private void Select(DesktopParadigm value)
    {
        _state.SelectedParadigm = value;
        SyncSelection();
    }

    private void SyncSelection()
    {
        foreach (var option in Options.Cast<SelectableOption<DesktopParadigm>>())
            option.IsSelected = option.Value == _state.SelectedParadigm;
    }
}
