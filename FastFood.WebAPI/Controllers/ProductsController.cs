using FastFood.Application.UseCases.GetProducts;
using FastFood.Application.UseCases.ManageProduct;
using Microsoft.AspNetCore.Mvc;
using FastFood.Domain.Enums; 

namespace FastFood.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly GetProductsByCategoryHandler _getHandler;
    private readonly ManageProductHandler _manageHandler;

    public ProductsController(GetProductsByCategoryHandler getHandler, ManageProductHandler manageHandler)
    {
        _getHandler = getHandler;
        _manageHandler = manageHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetByCategory([FromQuery] string? category)
    {
        ProductCategory? parsedCategory = null;

        if (!string.IsNullOrWhiteSpace(category) &&
            Enum.TryParse(category, true, out ProductCategory parsed))
        {
            parsedCategory = parsed;
        }

        var result = await _getHandler.HandleAsync(parsedCategory);
        return Ok(result);
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductRequest request)
    {
        var id = await _manageHandler.CreateAsync(request);
        return CreatedAtAction(nameof(Create), new { id }, new { id });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductRequest request)
    {
        await _manageHandler.UpdateAsync(id, request);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _manageHandler.DeleteAsync(id);
        return NoContent();
    }
}
