using CoBrMaxMacro.Application.Interfaces.Queries.v1;
using CoBrMaxMacro.Application.World.Maps.Models.v1;
using CoBrMaxMacro.Application.World.Spots.Models.v1;
using CoBrMaxMacro.Application.World.Spots.Queries.v1;
using CoBrMaxMacro.Presentation.Helpers.v1;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace CoBrMaxMacro.Presentation.Controls.World.Spots;

public partial class SpotSelectionView : UserControl
{
    private IQueryHandler<
        GetSpotsByMapQuery,
        IReadOnlyCollection<SpotModel>>
        GetSpotsByMapHandler =>
            App.Services.GetRequiredService<
                IQueryHandler<
                    GetSpotsByMapQuery,
                    IReadOnlyCollection<SpotModel>>>();

    private MapSelectionState MapSelectionState =>
        App.Services.GetRequiredService<MapSelectionState>();

    private SpotSelectionState SpotSelectionState =>
        App.Services.GetRequiredService<SpotSelectionState>();

    public SpotSelectionView()
    {
        InitializeComponent();

        Loaded += SpotSelectionView_Loaded;
        Unloaded += SpotSelectionView_Unloaded;
    }

    private async void SpotSelectionView_Loaded(
        object sender,
        RoutedEventArgs e
    )
    {
        if (DesignModeHelper.IsInDesignMode(this))
            return;

        MapSelectionState.SelectedMapChanged -=
            MapSelectionState_SelectedMapChanged;

        MapSelectionState.SelectedMapChanged +=
            MapSelectionState_SelectedMapChanged;

        await LoadSpotsAsync();
    }

    private async void MapSelectionState_SelectedMapChanged(
        object? sender,
        EventArgs e
    )
    {
        await LoadSpotsAsync();
    }

    private void SpotSelector_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e
    )
    {
        SpotSelectionState.SelectedSpot =
            SpotSelector.SelectedItem as SpotModel;

        if (SpotSelectionState.SelectedSpot is null)
            return;

        System.Diagnostics.Debug.WriteLine(
            $"Spot selected: {SpotSelectionState.SelectedSpot.Name} " +
            $"({SpotSelectionState.SelectedSpot.X}, " +
            $"{SpotSelectionState.SelectedSpot.Y})"
        );
    }

    private async Task LoadSpotsAsync()
    {
        var selectedMap = MapSelectionState.SelectedMap;

        SpotSelectionState.SelectedSpot = null;
        SpotSelector.ItemsSource = null;
        SpotSelector.IsEnabled = false;

        if (selectedMap is null)
            return;

        var spots = await GetSpotsByMapHandler.HandleAsync(
            new GetSpotsByMapQuery
            {
                MapId = selectedMap.Id
            }
        );

        SpotSelector.ItemsSource = spots;
        SpotSelector.IsEnabled = spots.Count > 0;

        System.Diagnostics.Debug.WriteLine(
            $"Spots loaded: {spots.Count} for map {selectedMap.Name}");
    }

    private void SpotSelectionView_Unloaded(
        object sender,
        RoutedEventArgs e
    )
    {
        MapSelectionState.SelectedMapChanged -=
            MapSelectionState_SelectedMapChanged;
    }
}