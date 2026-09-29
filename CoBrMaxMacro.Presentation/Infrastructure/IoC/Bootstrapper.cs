using CoBrMaxMacro.Application.Characters.Selection.Queries.v1;
using CoBrMaxMacro.Application.Interfaces.Queries.v1;
using CoBrMaxMacro.Application.Interfaces.Repositories.v1;
using CoBrMaxMacro.Application.World.Maps.Models.v1;
using CoBrMaxMacro.Application.World.Maps.Queries.v1;
using CoBrMaxMacro.Application.World.Spots.Models.v1;
using CoBrMaxMacro.Application.World.Spots.Queries.v1;
using CoBrMaxMacro.Domain.Characters.Enums;
using CoBrMaxMacro.Infrastructure.World.Spots.Repositories;
using CoBrMaxMacro.Presentation.Themes.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace CoBrMaxMacro.Presentation.Infrastructure.IoC;

public static class Bootstrapper
{
    public static IServiceCollection AddApplicationDependencies(    
        this IServiceCollection services
    )
    {
        services.AddSingleton(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        services.AddSingleton<ThemeService>();

        services.AddSingleton<IMapRepository, MapRepository>();
        services.AddSingleton<ISpotRepository, SpotRepository>();

        services.AddTransient<
            IQueryHandler<
                GetCharacterClassesQuery, 
                IReadOnlyCollection<CharacterClassType>>,
            GetCharacterClassesQueryHandler>();

        services.AddTransient<
            IQueryHandler<
                GetMapsQuery, 
                IReadOnlyCollection<MapModel>>,
            GetMapsQueryHandler>();

        services.AddTransient<
            IQueryHandler<
                GetSpotsByMapQuery,
            IReadOnlyCollection<SpotModel>>,
                GetSpotsByMapQueryHandler>();

        services.AddSingleton<MapSelectionState>();
        services.AddSingleton<SpotSelectionState>();

        services.AddSingleton<MainWindow>();

        return services;
    }
}