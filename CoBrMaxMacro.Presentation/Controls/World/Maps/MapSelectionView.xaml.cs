using CoBrMaxMacro.Application.Interfaces.Queries.v1;
using CoBrMaxMacro.Application.World.Maps.Models.v1;
using CoBrMaxMacro.Application.World.Maps.Queries.v1;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace CoBrMaxMacro.Presentation.Controls.World.Maps;

public partial class MapSelectionView : UserControl
{
    private IQueryHandler<
        GetMapsQuery,
        IReadOnlyCollection<MapModel>>
        GetMapsHandler =>
            App.Services.GetRequiredService<
                IQueryHandler<
                    GetMapsQuery,
                    IReadOnlyCollection<MapModel>>>();
    private MapSelectionState MapSelectionState =>
    App.Services.GetRequiredService<MapSelectionState>();

    public MapSelectionView()
    {
        InitializeComponent();
    }

    private async void MapSelectionView_Loaded(
        object sender,
        RoutedEventArgs e
    )
    {
        if (DesignerProperties.GetIsInDesignMode(this))
            return;

        var maps = await GetMapsHandler.HandleAsync(
            new GetMapsQuery());

        MapSelector.ItemsSource = maps;
    }

    private void MapSelector_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e
    )
    {
        MapSelectionState.SelectedMap =
            MapSelector.SelectedItem as MapModel;
    }
}