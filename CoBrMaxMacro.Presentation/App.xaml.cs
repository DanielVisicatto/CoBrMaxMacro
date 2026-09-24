using CoBrMaxMacro.Application.Interfaces.Queries.v1;
using CoBrMaxMacro.Application.World.Maps.Models.v1;
using CoBrMaxMacro.Application.World.Maps.Queries.v1;
using CoBrMaxMacro.Presentation.Infrastructure.IoC;
using CoBrMaxMacro.Presentation.Themes.Enums;
using CoBrMaxMacro.Presentation.Themes.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfApplication = System.Windows.Application;

namespace CoBrMaxMacro.Presentation;

public partial class App : WpfApplication
{
    public static IServiceProvider Services { get; private set; } = null!;

    protected override async void OnStartup(StartupEventArgs e)
    {
        var services = new ServiceCollection();

        services.AddApplicationDependencies();

        Services = services.BuildServiceProvider();

        var themeService = Services.GetRequiredService<ThemeService>();
        themeService.ApplyTheme(AppThemeType.System);

        var getMapsHandler = Services.GetRequiredService<
            IQueryHandler<GetMapsQuery, IReadOnlyCollection<MapModel>>>();

        var maps = await getMapsHandler.HandleAsync(
            new GetMapsQuery()
        );

        System.Diagnostics.Debug.WriteLine(
            $"Maps loaded: {maps.Count}"
        );

        var mainWindow = Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }
}