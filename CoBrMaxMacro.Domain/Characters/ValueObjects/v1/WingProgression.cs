namespace CoBrMaxMacro.Domain.Characters.ValueObjects.v1;

public sealed class WingProgression
{
    public int Level { get; init; }

    public bool CanLevelUp { get; init; }

    public string? RequiredItemId { get; init; }
}