using CoBrMaxMacro.Domain.Characters.Enums;
using CoBrMaxMacro.Domain.Characters.ValueObjects.V1;

namespace CoBrMaxMacro.Domain.Characters.Entities.V1;

public sealed class CharacterProfile
{
    public Guid Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public CharacterClassType Class { get; init; }

    public CharacterProgression Progression { get; init; } = new();

    public string? MapId { get; init; }

    public string? SpotId { get; init; }
}