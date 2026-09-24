using CoBrMaxMacro.Application.Interfaces.Queries.v1;

namespace CoBrMaxMacro.Application.World.Spots.Queries.v1;

public sealed class GetSpotsByMapQuery : IQuery
{
    public Guid CorrelationId { get; init; } = Guid.NewGuid();

    public string MapId { get; init; } = string.Empty;
}