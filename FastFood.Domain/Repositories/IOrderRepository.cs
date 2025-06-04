using FastFood.Domain.Entities;

namespace FastFood.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(Guid id);
    Task<IEnumerable<Order>> GetAllAsync();
    Task AddAsync(Order order);
    Task UpdateStatusAsync(Guid orderId, string newStatus);
}
