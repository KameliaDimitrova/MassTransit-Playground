namespace MassTransit_Playground.Contracts;
public interface IOrderSubmitionRejected
{
    Guid OrderId { get; }

    DateTime Timestamp { get; }

    string CustomerNumber { get; }

    string Reason { get; }
}
