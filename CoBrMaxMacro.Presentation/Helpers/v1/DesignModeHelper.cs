using System.ComponentModel;
using System.Windows;

namespace CoBrMaxMacro.Presentation.Helpers.v1;

public static class DesignModeHelper
{
    public static bool IsInDesignMode(DependencyObject dependencyObject)
    {
        return DesignerProperties.GetIsInDesignMode(dependencyObject);
    }
}