using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Play.Inventory.Service.Dtos;

namespace Play.Inventory.Service.Clients
{
    // CatalogClient class that uses the HttpClient to make requests to the catalog service
    public class CatalogClient
    {
        // HttpClient instance
        private readonly HttpClient httpClient;

        // Constructor that takes an HttpClient instance
        public CatalogClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // GetCatalogItemsAsync method that returns a collection of CatalogItemDto objects
        public async Task<IReadOnlyCollection<CatalogItemDto>> GetCatalogItemsAsync()
        {
            var items = await httpClient.GetFromJsonAsync<IReadOnlyCollection<CatalogItemDto>>("/items");
            return items;
        }
    }
}