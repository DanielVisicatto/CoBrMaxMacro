using CoBrMaxMacro.Application.Interfaces.Commands.v1;

namespace CoBrMaxMacro.Application.Automation.StartAutomation.Commands;

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