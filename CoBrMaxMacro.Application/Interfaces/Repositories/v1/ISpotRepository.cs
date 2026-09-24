using CoBrMaxMacro.Application.World.Spots.Models.v1;

namespace CoBrMaxMacro.Application.Interfaces.Repositories.v1;

public interface ISpotRepository
{
    Task<IReadOnlyCollection<SpotModel>> GetByMapIdAsync(
        string mapId,
        CancellationToken cancellationToken = default
    );
}