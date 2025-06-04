using FastFood.Domain.Entities;
using FastFood.Domain.Repositories;
using FastFood.Domain.Enums;


namespace FastFood.Application.UseCases.ManageProduct;

public class ManageProductHandler
{
    private readonly IProductRepository _products;

    public ManageProductHandler(IProductRepository products)
    {
        _products = products;
    }

    public async Task<Guid> CreateAsync(ProductRequest request)
    {
        var parsed = Enum.TryParse(request.Category, ignoreCase: true, out ProductCategory parsedCategory)
            ? parsedCategory
            : throw new Exception("Invalid category");

        var product = new Product(request.Name, request.Description, request.Price, parsedCategory);
        await _products.AddAsync(product);
        return product.Id;
    }

    public async Task UpdateAsync(Guid id, ProductRequest request)
    {
        var parsed = Enum.TryParse(request.Category, ignoreCase: true, out ProductCategory parsedCategory)
            ? parsedCategory
            : throw new Exception("Invalid product category");

        var product = new Product(request.Name, request.Description, request.Price, parsedCategory);

        // Atualizando o ID diretamente — depende de como EF está configurado
        typeof(Product).GetProperty("Id")?.SetValue(product, id);

        await _products.UpdateAsync(product);
    }


    public async Task DeleteAsync(Guid id)
    {
        await _products.DeleteAsync(id);
    }
}
