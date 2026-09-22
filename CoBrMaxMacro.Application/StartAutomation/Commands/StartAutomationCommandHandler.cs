using CoBrMaxMacro.Application.Interfaces.Commands;

namespace CoBrMaxMacro.Application.StartAutomation.Commands;

internal class StartAutomationCommandHandler : ICommandHandler<StartAutomationCommand>
{
    public Task HandleAsync(
        StartAutomationCommand command, 
        CancellationToken cancellationToken
    )
    {
        ArgumentNullException.ThrowIfNull(
            command
        );

        return Task.CompletedTask;
    }
}