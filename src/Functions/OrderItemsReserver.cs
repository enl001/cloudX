using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public class OrderItemsReserver
    {
        private readonly ILogger<OrderItemsReserver> _logger;

        public OrderItemsReserver(ILogger<OrderItemsReserver> logger)
        {
            _logger = logger;
        }

        [Function(nameof(OrderItemsReserver))]
        [BlobOutput("orders/{messageId}.json", Connection = "BLOB_STORAGE_CONNECTION_STRING")]
        public string Run([ServiceBusTrigger("orders", Connection = "SERVICE_BUS_CONNECTION_STRING")] string message, string messageId)
        {
            _logger.LogInformation("Process message ID: {0}", messageId);

            return message;
        }
    }
}
