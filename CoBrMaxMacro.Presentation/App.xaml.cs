using CoBrMaxMacro.Presentation.Themes;
using WpfApplication = System.Windows.Application;

namespace CoBrMaxMacro.Presentation;

public partial class App : WpfApplication
{
    public App()
    {
        InitializeComponent();

        var themeService = new ThemeService();
        themeService.ApplyTheme(AppThemeType.System);
    }
}