namespace FastFood.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string? Name { get; private set; }
    public string? Cpf { get; private set; }
    public bool IsAnonymous => string.IsNullOrWhiteSpace(Cpf);

    public Customer(string? name, string? cpf)
    {
        Name = name;
        Cpf = cpf;
    }
}
