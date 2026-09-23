using CoBrMaxMacro.Application.Interfaces.Queries;

namespace CoBrMaxMacro.Application.CharacterSelection.Queries.V1;

public sealed class GetCharacterClassesQuery : IQuery
{
    public Guid CorrelationId { get; init; } = Guid.NewGuid();
}