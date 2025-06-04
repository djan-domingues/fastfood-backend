using FastFood.Domain.Entities;
using FastFood.Domain.Enums;

namespace FastFood.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<IEnumerable<Product>> GetByCategoryAsync(ProductCategory category);
    Task<Product?> GetByIdAsync(Guid id);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid id);
}
