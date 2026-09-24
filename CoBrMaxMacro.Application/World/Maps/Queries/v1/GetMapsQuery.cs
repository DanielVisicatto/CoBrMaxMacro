using CoBrMaxMacro.Application.Interfaces.Queries.v1;

namespace CoBrMaxMacro.Application.World.Maps.Queries.v1;

public sealed class GetMapsQuery : IQuery
{
    public Guid CorrelationId { get; init; } = Guid.NewGuid();
}