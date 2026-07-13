using System;
using System.Collections.ObjectModel;
using AvaloniaApp.Models;
using AvaloniaApp.Services;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApp.ViewModels;

public class AppTranslationModalViewModel : ViewModelBase
{
    public ObservableCollection<AppTranslationEntry> Entries { get; }
    public IRelayCommand CloseCommand { get; }

    public AppTranslationModalViewModel(AppTranslationCatalog catalog, Action onClose)
    {
        Entries = new ObservableCollection<AppTranslationEntry>(catalog.GetSuggestions());
        CloseCommand = new RelayCommand(onClose);
    }
}
