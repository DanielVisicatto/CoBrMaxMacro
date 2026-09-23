namespace CoBrMaxMacro.Application.Interfaces.Queries;

public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQuery
{
    Task<TResult> HandleAsync(
        TQuery query,
        CancellationToken cancellationToken = default
    );
}