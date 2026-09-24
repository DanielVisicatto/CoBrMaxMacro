namespace CoBrMaxMacro.Application.Interfaces.Commands.v1;

public interface ICommand
{
    public Guid CorrelationId { get; }
}