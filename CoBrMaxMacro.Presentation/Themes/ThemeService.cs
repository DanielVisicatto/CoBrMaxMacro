using System.Windows;
using WpfApplication = System.Windows.Application;

namespace CoBrMaxMacro.Presentation.Themes;

public sealed class ThemeService
{
    public void ApplyTheme(AppThemeType theme)
    {
        var effectiveTheme = theme switch
        {
            AppThemeType.System => WindowsThemeHelper.IsLightTheme()
                ? AppThemeType.Light
                : AppThemeType.Dark,

            _ => theme
        };

        var themeUri = effectiveTheme switch
        {
            AppThemeType.Light =>
                "Themes/LightTheme.xaml",

            AppThemeType.Dark =>
                "Themes/DarkTheme.xaml",

            _ => throw new ArgumentOutOfRangeException(
                nameof(theme)
            )
        };

        var dictionary = new ResourceDictionary
        {
            Source = new Uri(
                themeUri,
                UriKind.Relative
            )
        };

        var dictionaries =
            WpfApplication.Current.Resources.MergedDictionaries;

        var currentTheme = dictionaries
            .FirstOrDefault(field =>
                field.Source?.OriginalString
                    .EndsWith("Theme.xaml") == true
            );

        if (currentTheme is not null)
            dictionaries.Remove(currentTheme);

        dictionaries.Insert(0, dictionary);
    }
}