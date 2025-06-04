using FastFood.Application.UseCases.RegisterCustomer;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly RegisterCustomerHandler _handler;

    public CustomersController(RegisterCustomerHandler handler)
    {
        _handler = handler;
    }

    /// <summary>
    /// Cadastra um novo cliente (CPF ou anônimo)
    /// </summary>
    /// <param name="request">Dados do cliente</param>
    /// <returns>Id do cliente</returns>
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterCustomerRequest request)
    {
        var customerId = await _handler.HandleAsync(request);
        return CreatedAtAction(nameof(Register), new { id = customerId }, new { id = customerId });
    }
}
