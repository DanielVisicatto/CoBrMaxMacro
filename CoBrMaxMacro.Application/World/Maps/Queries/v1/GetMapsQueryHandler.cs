using CoBrMaxMacro.Application.Interfaces.Queries.v1;
using CoBrMaxMacro.Application.Interfaces.Repositories.v1;
using CoBrMaxMacro.Application.World.Maps.Models.v1;

namespace CoBrMaxMacro.Application.World.Maps.Queries.v1;

public sealed class GetMapsQueryHandler(
    IMapRepository mapRepository
) : IQueryHandler<
    GetMapsQuery,
    IReadOnlyCollection<MapModel>
>
{
    public async Task<IReadOnlyCollection<MapModel>> HandleAsync(
        GetMapsQuery query,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(query);

        return await mapRepository.GetAllAsync(
            cancellationToken
        );
    }
}