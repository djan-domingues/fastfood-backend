using FastFood.Application.UseCases.PlaceOrder;
using FastFood.Application.UseCases.UpdateOrderStatus;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly PlaceOrderHandler _placeOrder;
    private readonly UpdateOrderStatusHandler _updateStatus;

    public OrdersController(PlaceOrderHandler placeOrder, UpdateOrderStatusHandler updateStatus)
    {
        _placeOrder = placeOrder;
        _updateStatus = updateStatus;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PlaceOrderRequest request)
    {
        var command = new PlaceOrderCommand(request.CustomerId, request.Items);
        var id = await _placeOrder.HandleAsync(command);
        return CreatedAtAction(nameof(Create), new { id }, new { id });
    }


    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateOrderStatusRequest request)
    {
        await _updateStatus.HandleAsync(id, request.Status);
        return NoContent();
    }

    [HttpGet("{id}/status")]
    public async Task<IActionResult> GetStatus(Guid id)
    {
        var status = await _updateStatus.GetStatusAsync(id);
        return Ok(new { status });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _updateStatus.GetAllAsync();
        return Ok(orders);
    }
}
