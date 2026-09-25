using CoBrMaxMacro.Domain.Characters.Enums;

namespace CoBrMaxMacro.Presentation.Characters.Models.v1;

public sealed class CharacterClassItem
{
    public CharacterClassType Value { get; init; }

    public string DisplayName { get; init; } = string.Empty;
}