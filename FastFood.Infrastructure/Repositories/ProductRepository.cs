using FastFood.Domain.Entities;
using FastFood.Domain.Enums;
using FastFood.Domain.Repositories;
using FastFood.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _db;

    public ProductRepository(AppDbContext db) => _db = db;

    public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _db.Products.ToListAsync();

    public async Task<IEnumerable<Product>> GetByCategoryAsync(ProductCategory category) =>
        await _db.Products.Where(p => p.Category == category).ToListAsync();

    public async Task<Product?> GetByIdAsync(Guid id) =>
        await _db.Products.FindAsync(id);

    public async Task AddAsync(Product product)
    {
        _db.Products.Add(product);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _db.Products.Update(product);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var product = await _db.Products.FindAsync(id);
        if (product != null)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }
    }
}
