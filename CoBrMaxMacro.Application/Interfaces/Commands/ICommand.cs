namespace CoBrMaxMacro.Application.Interfaces.Commands;

public interface ICommand
{
    public Guid CorrelationId { get; }
}