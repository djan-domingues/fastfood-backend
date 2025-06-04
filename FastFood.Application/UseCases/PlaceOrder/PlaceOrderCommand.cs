namespace FastFood.Application.UseCases.PlaceOrder;

public record PlaceOrderCommand(
    Guid CustomerId,
    List<PlaceOrderItemDto> Items
);

public record PlaceOrderItemDto(
    Guid ProductId,
    int Quantity
);
