using CoBrMaxMacro.Presentation.Themes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;

namespace CoBrMaxMacro.Presentation.Controls;

public partial class TitleBar : UserControl
{
    private readonly ThemeService _themeService = new();

    public TitleBar()
    {
        InitializeComponent();
    }

    private Window? ParentWindow =>
        Window.GetWindow(this);

    private void TitleBar_MouseLeftButtonDown(
    object sender,
    MouseButtonEventArgs e
)
    {
        if (e.OriginalSource is DependencyObject source)
        {
            if (FindParent<Button>(source) is not null ||
                FindParent<ComboBox>(source) is not null)
                return;
        }

        if (e.ClickCount == 2)
        {
            ToggleMaximize();
            return;
        }

        ParentWindow?.DragMove();
    }

    private void MinimizeButton_Click(
        object sender,
        RoutedEventArgs e
    ) => ParentWindow?.WindowState = WindowState.Minimized;
    

    private void MaximizeButton_Click(
        object sender,
        RoutedEventArgs e
    ) => ToggleMaximize();
    

    private void CloseButton_Click(
        object sender,
        RoutedEventArgs e
    ) => ParentWindow?.Close();    

    private void ToggleMaximize()
    {
        if (ParentWindow is null)
            return;

        ParentWindow.WindowState =
            ParentWindow.WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
    }

    private void ThemeSelector_SelectionChanged(
    object sender,
    SelectionChangedEventArgs selectionEvent
)
    {
        if (DesignerProperties.GetIsInDesignMode(this))
            return;

        if (ThemeSelector.SelectedItem is not ComboBoxItem selectedItem)
            return;

        var theme = selectedItem.Content?.ToString() switch
        {
            "Light" => AppThemeType.Light,
            "Dark" => AppThemeType.Dark,
            _ => AppThemeType.System
        };

        _themeService.ApplyTheme(theme);
    }

    private static T? FindParent<T>(
        DependencyObject child
    )
        where T : DependencyObject
    {
        var parent = child;

        while (parent is not null)
        {
            if (parent is T target)
                return target;

            parent = System.Windows.Media.VisualTreeHelper
                .GetParent(parent);
        }

        return null;
    }
}