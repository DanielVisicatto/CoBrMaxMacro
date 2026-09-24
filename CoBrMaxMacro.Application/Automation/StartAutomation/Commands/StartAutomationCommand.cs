using CoBrMaxMacro.Application.Interfaces.Commands.v1;

namespace CoBrMaxMacro.Application.Automation.StartAutomation.Commands;

public class StartAutomationCommand : ICommand
{
    public Guid CorrelationId { get; init; } = Guid.NewGuid(); 
}