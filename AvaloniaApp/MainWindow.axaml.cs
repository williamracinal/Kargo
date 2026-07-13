using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using AvaloniaApp.ViewModels;

namespace AvaloniaApp;

public partial class MainWindow : Window
{
    // Matches the app's baseline design size (1000x700) so proportional
    // content scaling (see WindowSizeToScaleConverter) stays uniform in
    // both directions instead of letterboxing.
    private const double AspectRatio = 1000.0 / 700.0;

    private bool _isSyncingSize;
    private double _lastWidth;
    private double _lastHeight;

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();

        _lastWidth = Width;
        _lastHeight = Height;
        Resized += OnResized;
    }

    private void OnResized(object? sender, WindowResizedEventArgs e)
    {
        if (_isSyncingSize) return;

        var size = e.ClientSize;
        if (size.Width <= 0 || size.Height <= 0) return;

        var currentRatio = size.Width / size.Height;
        if (Math.Abs(currentRatio - AspectRatio) > 0.005)
        {
            var widthDelta = Math.Abs(size.Width - _lastWidth);
            var heightDelta = Math.Abs(size.Height - _lastHeight);

            _isSyncingSize = true;
            try
            {
                if (widthDelta >= heightDelta)
                    Height = size.Width / AspectRatio;
                else
                    Width = size.Height * AspectRatio;
            }
            finally
            {
                _isSyncingSize = false;
            }
        }

        _lastWidth = ClientSize.Width;
        _lastHeight = ClientSize.Height;
    }

    private void TitleBar_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed)
            BeginMoveDrag(e);
    }

    private void MinimizeButton_Click(object? sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

    private void CloseButton_Click(object? sender, RoutedEventArgs e) => Close();
}
