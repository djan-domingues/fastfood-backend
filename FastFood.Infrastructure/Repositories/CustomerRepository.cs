using FastFood.Domain.Entities;
using FastFood.Domain.Repositories;
using FastFood.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _db;

    public CustomerRepository(AppDbContext db) => _db = db;

    public async Task<Customer?> GetByCpfAsync(string cpf)
    {
        return await _db.Customers.FirstOrDefaultAsync(c => c.Cpf == cpf);
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _db.Customers.FindAsync(id);
    }

    public async Task AddAsync(Customer customer)
    {
        _db.Customers.Add(customer);
        await _db.SaveChangesAsync();
    }
}
