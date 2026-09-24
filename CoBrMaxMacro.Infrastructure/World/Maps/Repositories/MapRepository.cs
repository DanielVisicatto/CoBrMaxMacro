using CoBrMaxMacro.Application.Interfaces.Repositories.v1;
using CoBrMaxMacro.Application.World.Maps.Models.v1;
using System.Text.Json;

public sealed class MapRepository(
    JsonSerializerOptions jsonOptions
) : IMapRepository
{
    private readonly string _filePath = Path.Combine(
        AppContext.BaseDirectory,
        "World",
        "Maps",
        "Data",
        "maps.json"
    );

    public async Task<IReadOnlyCollection<MapModel>> GetAllAsync(
        CancellationToken cancellationToken = default
    )
    {
        System.Diagnostics.Debug.WriteLine(
            $"Map file path: {_filePath}"
        );

        System.Diagnostics.Debug.WriteLine(
            $"Map file exists: {File.Exists(_filePath)}"
        );
        if (!File.Exists(_filePath))
            return [];

        await using var stream = File.OpenRead(_filePath);

        var maps = await JsonSerializer.DeserializeAsync<List<MapModel>>(
            stream,
            jsonOptions,
            cancellationToken
        );

        return maps ?? [];
    }
}