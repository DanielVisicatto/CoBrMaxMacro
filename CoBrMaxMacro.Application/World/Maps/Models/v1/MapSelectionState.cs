namespace CoBrMaxMacro.Application.World.Maps.Models.v1;

public sealed class MapSelectionState
{
    private MapModel? _selectedMap;

    public event EventHandler? SelectedMapChanged;

    public MapModel? SelectedMap
    {
        get => _selectedMap;

        set
        {
            if (_selectedMap == value)
                return;

            _selectedMap = value;

            SelectedMapChanged?.Invoke(
                this, 
                EventArgs.Empty
            );
        }
    }
}