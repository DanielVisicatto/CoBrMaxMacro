namespace CoBrMaxMacro.Application.Interfaces.Queries.v1;

public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQuery
{
    Task<TResult> HandleAsync(
        TQuery query,
        CancellationToken cancellationToken = default
    );
}