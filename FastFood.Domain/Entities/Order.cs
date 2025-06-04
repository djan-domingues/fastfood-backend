using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CustomerId { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public OrderStatus Status { get; private set; } = OrderStatus.Received;
    public List<OrderItem> Items { get; private set; } = new();

    protected Order() { }

    public Order(Guid customerId, List<OrderItem> items)
    {
        CustomerId = customerId;
        Items = items;
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        Status = newStatus;
    }

    public decimal TotalPrice => Items.Sum(i => i.Total);
}
