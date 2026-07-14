using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AvaloniaApp.Models;
using Material.Icons;

namespace AvaloniaApp.ViewModels;

public class Slide2ViewModel : ViewModelBase
{
    private readonly MigrationState _state;

    public SlideHeaderViewModel Header { get; } = new(
        MaterialIconKind.AccountCircle,
        "What will you use this PC for?",
        "Select the best match for your daily workflow.");

    public ObservableCollection<ISelectableOption> Options { get; }
    public IReadOnlyList<OptionRow> OptionRows { get; }

    public Slide2ViewModel(MigrationState state)
    {
        _state = state;

        Options = new ObservableCollection<ISelectableOption>
        {
            new SelectableOption<PrimaryRole>(Select)
            {
                Value = PrimaryRole.Gaming,
                Title = "Pure Gaming",
                Description = "Optimized for a console-like experience, with smooth performance and vivid visuals.",
                Caption = "(Bazzite)",
                IconKind = MaterialIconKind.Linux,
            },
            new SelectableOption<PrimaryRole>(Select)
            {
                Value = PrimaryRole.DailyUse,
                Title = "Balanced Daily Use",
                Description = "Web, media, everyday productivity, and casual gaming.",
                Caption = "(Kubuntu)",
                IconKind = MaterialIconKind.Ubuntu,
            },
            new SelectableOption<PrimaryRole>(Select)
            {
                Value = PrimaryRole.Productivity,
                Title = "Productivity & Dev",
                Description = "Coding, design, illustration, and photo editing.",
                Caption = "(Debian)",
                IconKind = MaterialIconKind.Debian,
            },
            new SelectableOption<PrimaryRole>(Select)
            {
                Value = PrimaryRole.Enthusiast,
                Title = "Enthusiast",
                Description = "Bleeding-edge software and full control over your system. Requires hands-on maintenance.",
                Caption = "(Arch)",
                IconKind = MaterialIconKind.Arch,
            },
        };
        OptionRows = OptionRow.Chunk(Options);

        SyncSelection();
    }

    private void Select(PrimaryRole value)
    {
        _state.SelectedRole = value;
        // Update cadence is implied by role rather than asked separately.
        // Enthusiast wants bleeding-edge, everyone else gets the rock-solid default.
        _state.SelectedStance = value == PrimaryRole.Enthusiast ? UpdateStance.BleedingEdge : UpdateStance.LTS;
        SyncSelection();
    }

    private void SyncSelection()
    {
        foreach (var option in Options.Cast<SelectableOption<PrimaryRole>>())
            option.IsSelected = option.Value == _state.SelectedRole;
    }
}
