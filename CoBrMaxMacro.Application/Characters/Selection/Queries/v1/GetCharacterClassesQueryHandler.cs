using CoBrMaxMacro.Application.Interfaces.Queries.v1;
using CoBrMaxMacro.Domain.Characters.Enums;

namespace CoBrMaxMacro.Application.Characters.Selection.Queries.v1;

public sealed class GetCharacterClassesQueryHandler
: IQueryHandler<
    GetCharacterClassesQuery,
    IReadOnlyCollection<CharacterClassType>
>
{
    public Task<IReadOnlyCollection<CharacterClassType>> HandleAsync(
        GetCharacterClassesQuery query,
        CancellationToken cancellationToken = default
    )
    {
        ArgumentNullException.ThrowIfNull(query);

        IReadOnlyCollection<CharacterClassType> classes =
            Enum.GetValues<CharacterClassType>();

        return Task.FromResult(classes);
    }
}