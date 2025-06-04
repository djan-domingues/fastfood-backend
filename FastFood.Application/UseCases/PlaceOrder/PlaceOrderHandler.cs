using FastFood.Domain.Entities;
using FastFood.Domain.Repositories;

namespace FastFood.Application.UseCases.PlaceOrder;

public class PlaceOrderHandler
{
    private readonly IOrderRepository _orders;
    private readonly IProductRepository _products;

    public PlaceOrderHandler(IOrderRepository orders, IProductRepository products)
    {
        _orders = orders;
        _products = products;
    }

    public async Task<Guid> HandleAsync(PlaceOrderCommand command)
    {
        var items = new List<OrderItem>();

        foreach (var item in command.Items)
        {
            var product = await _products.GetByIdAsync(item.ProductId)
                ?? throw new Exception($"Product not found: {item.ProductId}");

            items.Add(new OrderItem(
                productId: product.Id,
                productName: product.Name,
                unitPrice: product.Price,
                quantity: item.Quantity
            ));
        }

        var order = new Order(command.CustomerId, items);
        await _orders.AddAsync(order);

        return order.Id;
    }
}
