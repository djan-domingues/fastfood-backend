using FastFood.Domain.Entities;
using FastFood.Domain.Enums;
using FastFood.Domain.Repositories;

namespace FastFood.Application.UseCases.GetProducts;

public class GetProductsByCategoryHandler
{
    private readonly IProductRepository _products;

    public GetProductsByCategoryHandler(IProductRepository products)
    {
        _products = products;
    }

    public async Task<IEnumerable<Product>> HandleAsync(ProductCategory? category)
    {
        if (category is null)
            return await _products.GetAllAsync();

        return await _products.GetByCategoryAsync(category.Value);
    }
}
