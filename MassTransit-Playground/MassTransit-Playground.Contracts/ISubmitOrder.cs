namespace MassTransit_Playground.Contracts;
public interface ISubmitOrder
{
    Guid OrderId { get; }

    DateTime Timestamp { get; }

    string CustomerNumber { get; }
}
