namespace FastFood.Application.UseCases.ManageProduct;

public record ProductRequest(string Name, string Description, decimal Price, string Category);
