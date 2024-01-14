using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Functions
{
    public class DeliveryOrderProcessor
    {
        private readonly ILogger _logger;

        public DeliveryOrderProcessor(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<DeliveryOrderProcessor>();
        }

        [Function("DeliveryOrderProcessor")]
        [CosmosDBOutput("Eshoponweb", "Orders", Connection = "COSMOSDB_CONNECTION_STRING", PartitionKey ="buyerId")]
        public async Task<object> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req)
        {
            var document = await JsonSerializer.DeserializeAsync<dynamic>(req.Body);

            if ((object?)document == null)
            {
                _logger.LogError("Document deserializing error");
                return null;
            }

            return document;
        }
    }
}
