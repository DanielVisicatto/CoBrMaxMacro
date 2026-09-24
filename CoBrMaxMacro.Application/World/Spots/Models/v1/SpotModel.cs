namespace CoBrMaxMacro.Application.World.Spots.Models.v1;

public sealed class SpotModel
{
    public string Id { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public string MapId { get; init; } = string.Empty;

    public int X { get; init; }

    public int Y { get; init; }
}