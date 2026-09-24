using CoBrMaxMacro.Application.Characters.Selection.Queries.v1;
using CoBrMaxMacro.Application.Interfaces.Queries.v1;
using CoBrMaxMacro.Application.Interfaces.Repositories.v1;
using CoBrMaxMacro.Application.World.Maps.Models.v1;
using CoBrMaxMacro.Application.World.Maps.Queries.v1;
using CoBrMaxMacro.Domain.Characters.Enums;
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

        services.AddSingleton<MainWindow>();

        return services;
    }
}