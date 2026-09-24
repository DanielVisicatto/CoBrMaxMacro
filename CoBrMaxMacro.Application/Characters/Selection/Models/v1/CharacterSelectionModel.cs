using CoBrMaxMacro.Domain.Characters.Enums;

namespace CoBrMaxMacro.Application.Characters.Selection.Models.v1;

public sealed class CharacterSelectionModel
{
    public string CharacterName { get; init; } = string.Empty;

    public CharacterClassType Class { get; init; }

    public string? MapId { get; init; }

    public string? SpotId { get; init; }
}