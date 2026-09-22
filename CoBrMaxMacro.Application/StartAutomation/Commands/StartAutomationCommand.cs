using CoBrMaxMacro.Application.Interfaces.Commands;

namespace CoBrMaxMacro.Application.StartAutomation.Commands;

public class StartAutomationCommand : ICommand
{
    public Guid CorrelationId { get; init; } = Guid.NewGuid(); 
}