using CoBrMaxMacro.Application.Interfaces.Repositories.v1;
using CoBrMaxMacro.Application.World.Spots.Models.v1;
using System.Text.Json;

namespace CoBrMaxMacro.Infrastructure.World.Spots.Repositories;

public sealed class SpotRepository(
    JsonSerializerOptions jsonOptions
) : ISpotRepository
{
    private readonly string _filePath = Path.Combine(
        AppContext.BaseDirectory,
        "World",
        "Spots",
        "Data",
        "spots.json"
    );

    public async Task<IReadOnlyCollection<SpotModel>> GetByMapIdAsync(
        string mapId,
        CancellationToken cancellationToken = default
    )
    {
        if (!File.Exists(_filePath))
            return [];

        await using var stream = File.OpenRead(_filePath);

        var spots = await JsonSerializer.DeserializeAsync<List<SpotModel>>(
            stream,
            jsonOptions,
            cancellationToken
        );

        if (spots is null)
            return [];

        return [.. spots
            .Where(spot =>
                string.Equals(
                    spot.MapId,
                    mapId,
                    StringComparison.OrdinalIgnoreCase
                )
            )
        ];
    }
}