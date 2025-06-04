using FastFood.Domain.Enums;

namespace FastFood.Domain.Entities;

public class Product
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public ProductCategory Category { get; private set; }

    public Product(string name, string description, decimal price, ProductCategory category)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
    }
}
