using System.Collections.Generic;

namespace Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate;

internal sealed record OrderDocumentModel(
    string Id,
    string BuyerId,
    Address ShippingAddress,
    IReadOnlyCollection<OrderItem> OrderedItems,
    decimal FinalPrice);
