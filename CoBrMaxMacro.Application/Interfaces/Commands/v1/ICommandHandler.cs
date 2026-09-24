namespace CoBrMaxMacro.Application.Interfaces.Commands.v1;

public interface ICommandHandler<TCommand>
{
    Task HandleAsync (
        TCommand command, 
        CancellationToken cancellationToken
    );
}