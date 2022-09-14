namespace MassTransit_Playground.Contracts;

public interface IOrderSubmitionAccepted
{
    Guid OrderId { get; }

    DateTime Timestamp { get; }

    string CustomerNumber { get; }
}
