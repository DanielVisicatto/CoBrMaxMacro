using CoBrMaxMacro.Application.Interfaces.Queries.v1;

namespace CoBrMaxMacro.Application.Characters.Selection.Queries.v1;

public sealed class GetCharacterClassesQuery : IQuery
{
    public Guid CorrelationId { get; init; } = Guid.NewGuid();
}