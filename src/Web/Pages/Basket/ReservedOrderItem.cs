namespace Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

internal sealed record ReservedOrderItem(
    int ItemId,
    int Quantity);
