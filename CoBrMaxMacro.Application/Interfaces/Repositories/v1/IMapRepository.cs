using CoBrMaxMacro.Application.World.Maps.Models.v1;

namespace CoBrMaxMacro.Application.Interfaces.Repositories.v1;

public interface IMapRepository
{
    Task<IReadOnlyCollection<MapModel>> GetAllAsync(
        CancellationToken cancellationToken = default
    );
}