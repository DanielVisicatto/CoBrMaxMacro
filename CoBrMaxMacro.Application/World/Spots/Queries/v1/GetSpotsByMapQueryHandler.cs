using CoBrMaxMacro.Application.Interfaces.Queries.v1;
using CoBrMaxMacro.Application.Interfaces.Repositories.v1;
using CoBrMaxMacro.Application.World.Spots.Models.v1;

namespace CoBrMaxMacro.Application.World.Spots.Queries.v1;

public sealed class GetSpotsByMapQueryHandler(
    ISpotRepository spotRepository
) : IQueryHandler<
    GetSpotsByMapQuery,
    IReadOnlyCollection<SpotModel>
>
{
    public async Task<IReadOnlyCollection<SpotModel>> HandleAsync(
        GetSpotsByMapQuery query,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(query);

        return await spotRepository.GetByMapIdAsync(
            query.MapId,
            cancellationToken
        );
    }
}