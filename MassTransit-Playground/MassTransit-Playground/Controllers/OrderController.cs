using MassTransit;
using MassTransit_Playground.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit_Playground.Api.Controllers;
[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IRequestClient<ISubmitOrder> _submitOrderRequestClient;

    public OrderController(
        ILogger<OrderController> logger,
        IRequestClient<ISubmitOrder> submitOrderRequestClient)
    {
        _logger = logger;
        this._submitOrderRequestClient = submitOrderRequestClient;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Guid id, string customerNumber)
    {
        var (accepted, rejected) = await _submitOrderRequestClient.GetResponse<IOrderSubmitionAccepted, IOrderSubmitionRejected>(new
        {
            OrderId = id,
            Timestamp = InVar.Timestamp,
            CustomerNumber = customerNumber
        });

        if(accepted.IsCompletedSuccessfully)
        {
            var response = await accepted;

            return Accepted(response);
        }

        else
        {
            var response = await rejected;

            return BadRequest(response.Message);
        }

        
    }
}
