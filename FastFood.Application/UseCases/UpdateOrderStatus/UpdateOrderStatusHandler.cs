using FastFood.Domain.Repositories;
using FastFood.Domain.Enums;


namespace FastFood.Application.UseCases.UpdateOrderStatus;

public class UpdateOrderStatusHandler
{
    private readonly IOrderRepository _orders;

    public UpdateOrderStatusHandler(IOrderRepository orders)
    {
        _orders = orders;
    }

    public async Task HandleAsync(Guid orderId, string newStatus)
    {
        await _orders.UpdateStatusAsync(orderId, newStatus);
    }

    public async Task<OrderStatus> GetStatusAsync(Guid orderId)
    {
        var order = await _orders.GetByIdAsync(orderId)
            ?? throw new Exception("Order not found");

        return order.Status;
    }

    public async Task<IEnumerable<object>> GetAllAsync()
    {
        var orders = await _orders.GetAllAsync();

        // Você pode definir um DTO específico no futuro
        return orders.Select(o => new {
            o.Id,
            o.CustomerId,
            o.Status,
            o.CreatedAt
        });
    }

}
