using FastFood.Domain.Entities;

namespace FastFood.Domain.Repositories;

public interface ICustomerRepository
{
    Task<Customer?> GetByCpfAsync(string cpf);
    Task<Customer?> GetByIdAsync(Guid id);
    Task AddAsync(Customer customer);
}
