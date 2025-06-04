using FastFood.Domain.Entities;
using FastFood.Domain.Enums;
using FastFood.Domain.Repositories;
using FastFood.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _db;

    public OrderRepository(AppDbContext db) => _db = db;

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _db.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await _db.Orders
            .Include(o => o.Items)
            .OrderBy(o => o.Status)
            .ThenBy(o => o.CreatedAt)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateStatusAsync(Guid orderId, string newStatus)
    {
        var order = await _db.Orders.FindAsync(orderId);
        if (order is not null &&
            Enum.TryParse<OrderStatus>(newStatus, ignoreCase: true, out var status))
        {
            order.UpdateStatus(status);
            await _db.SaveChangesAsync();
        }
    }
}
