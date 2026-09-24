namespace CoBrMaxMacro.Application.World.Maps.Models.v1;

public sealed class MapModel
{
    public string Id { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public int? MinimumLevel { get; init; }

    public int? MaximumLevel { get; init; }
}