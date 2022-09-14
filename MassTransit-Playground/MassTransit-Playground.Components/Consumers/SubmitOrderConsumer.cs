using MassTransit;
using MassTransit_Playground.Contracts;
using Microsoft.Extensions.Logging;

namespace MassTransit_Playground.Components.Consumers;
public class SubmitOrderConsumer :
    IConsumer<ISubmitOrder>
{
    private readonly ILogger<SubmitOrderConsumer> _logger;

    public SubmitOrderConsumer(ILogger<SubmitOrderConsumer> logger)
    {
        this._logger = logger;
    }
    
    public async Task Consume(ConsumeContext<ISubmitOrder> context)
    {
        _logger.Log(LogLevel.Information, "SubmitOrderConsumer: {CustomerNumber}", context.Message.CustomerNumber);

        if(context.Message.CustomerNumber.Contains("Test"))
        {
            await context.RespondAsync<IOrderSubmitionRejected>(new
            {

                OrderId = context.Message.OrderId,
                Timestamp = InVar.Timestamp,
                CustomerNumber = context.Message.CustomerNumber,
                Reason = "Test customer cannot submit order"
            });

            return;
        }

        await context.RespondAsync<IOrderSubmitionAccepted>(new
        {
            InVar.Timestamp,
            OrderId = context.Message.OrderId,
            CustomerNumber = context.Message.CustomerNumber
        });
    }
}
