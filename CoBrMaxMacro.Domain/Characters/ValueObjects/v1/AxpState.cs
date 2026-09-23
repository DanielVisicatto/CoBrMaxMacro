namespace CoBrMaxMacro.Domain.Characters.ValueObjects.v1;

public sealed class AxpState
{
    public int Current { get; init; }

    public int Maximum { get; init; } = 700;
}