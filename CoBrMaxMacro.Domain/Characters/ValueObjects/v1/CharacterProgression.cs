using CoBrMaxMacro.Domain.Characters.ValueObjects.v1;

namespace CoBrMaxMacro.Domain.Characters.ValueObjects.V1;

public sealed class CharacterProgression
{
    public int Level { get; init; }

    public AxpState Axp { get; init; } = new();

    public OxpState Oxp { get; init; } = new();

    public WingProgression Wing { get; init; } = new();
}