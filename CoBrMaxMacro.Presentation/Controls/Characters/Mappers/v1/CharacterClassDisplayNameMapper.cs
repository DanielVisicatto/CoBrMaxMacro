using CoBrMaxMacro.Domain.Characters.Enums;

namespace CoBrMaxMacro.Presentation.Characters.Mappers.v1;

public static class CharacterClassDisplayNameMapper
{
    public static string ToDisplayName(
        CharacterClassType characterClass)
    {
        return characterClass switch
        {
            CharacterClassType.Warrior => "Guerreiro",
            CharacterClassType.Blader => "Duelista",
            CharacterClassType.Wizard => "Mago",
            CharacterClassType.ForceArcher => "Arqueiro Arcano",
            CharacterClassType.ForceShielder => "Guardião Arcano",
            CharacterClassType.ForceBlader => "Espadachim Arcano",
            CharacterClassType.Gladiator => "Gladiador",
            CharacterClassType.ForceGunner => "Atirador Arcano",
            CharacterClassType.DarkMage => "Mago Negro",
            _ => characterClass.ToString()
        };
    }
}