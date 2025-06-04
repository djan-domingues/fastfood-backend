using FastFood.Domain.Entities;
using FastFood.Domain.Repositories;

namespace FastFood.Application.UseCases.RegisterCustomer;

public class RegisterCustomerHandler
{
    private readonly ICustomerRepository _customers;

    public RegisterCustomerHandler(ICustomerRepository customers)
    {
        _customers = customers;
    }

    public async Task<Guid> HandleAsync(RegisterCustomerRequest request)
    {
        var name = request.Name;
        var cpf = request.CPF;

        if (!string.IsNullOrWhiteSpace(cpf))
        {
            var existing = await _customers.GetByCpfAsync(cpf);
            if (existing is not null)
                return existing.Id;
        }

        var customer = new Customer(name, cpf);
        await _customers.AddAsync(customer);
        return customer.Id;
    }

}
