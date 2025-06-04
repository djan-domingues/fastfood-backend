namespace FastFood.Application.UseCases.PlaceOrder;

public record PlaceOrderRequest(Guid CustomerId, List<PlaceOrderItemDto> Items);
