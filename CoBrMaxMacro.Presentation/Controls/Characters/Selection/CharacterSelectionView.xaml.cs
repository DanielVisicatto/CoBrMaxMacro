using CoBrMaxMacro.Application.Characters.Selection.Queries.v1;
using CoBrMaxMacro.Application.Interfaces.Queries.v1;
using CoBrMaxMacro.Domain.Characters.Enums;
using CoBrMaxMacro.Presentation.Characters.Mappers.v1;
using CoBrMaxMacro.Presentation.Characters.Models.v1;
using CoBrMaxMacro.Presentation.Helpers.v1;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace CoBrMaxMacro.Presentation.Controls.Characters.Selection;

public partial class CharacterSelectionView : UserControl
{
    private IQueryHandler<
        GetCharacterClassesQuery,
        IReadOnlyCollection<CharacterClassType>>
        GetCharacterClassesHandler =>
            App.Services.GetRequiredService<
                IQueryHandler<
                    GetCharacterClassesQuery,
                    IReadOnlyCollection<CharacterClassType>>>();

    public CharacterSelectionView()
    {
        InitializeComponent();
    }

    private async void CharacterSelectionView_Loaded(
        object sender,
        RoutedEventArgs e
    )
    {
        if (DesignModeHelper.IsInDesignMode(this))
            return;

        var classes = await GetCharacterClassesHandler.HandleAsync(
            new GetCharacterClassesQuery());

        CharacterClassSelector.ItemsSource = classes
            .Select(characterClass => new CharacterClassItem
            {
                Value = characterClass,
                DisplayName =
                    CharacterClassDisplayNameMapper.ToDisplayName(characterClass)
            })
            .ToList();
    }
}