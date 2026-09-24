using Microsoft.Win32;

namespace CoBrMaxMacro.Presentation.Themes.Helpers;

public static class WindowsThemeHelper
{
    public static bool IsLightTheme()
    {
        const string keyPath =
            @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

        using var key = Registry
            .CurrentUser
            .OpenSubKey(
                keyPath
            );

        var value = key?.GetValue(
            "AppsUseLightTheme"
        );

        return value is null || 
            Convert.ToInt32(
                value
            ) != 0;
    }
}