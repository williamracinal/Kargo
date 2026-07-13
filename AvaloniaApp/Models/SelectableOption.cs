using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Material.Icons;

namespace AvaloniaApp.Models;

// Non-generic surface so a single DataTemplate can render option cards
// for any SelectableOption<T> (T differs per wizard slide).
public interface ISelectableOption
{
    string Title { get; }
    string Description { get; }
    MaterialIconKind IconKind { get; }
    bool IsSelected { get; set; }
    IRelayCommand SelectCommand { get; }
}

public partial class SelectableOption<T> : ObservableObject, ISelectableOption where T : notnull
{
    public required T Value { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required MaterialIconKind IconKind { get; init; }

    [ObservableProperty]
    private bool _isSelected;

    public IRelayCommand SelectCommand { get; }

    public SelectableOption(Action<T> onSelect)
    {
        SelectCommand = new RelayCommand(() => onSelect(Value!));
    }
}
