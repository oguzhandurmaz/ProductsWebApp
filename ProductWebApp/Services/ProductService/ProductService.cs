using Polly;
using ProductWebApp.Models;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace ProductWebApp.Services.ProductService
{
    public class ProductService : IProductService
    {
        public const string ClientName = "ProductService";
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Category>?> GetCategories()
        {
            try
            {
                var client = _httpClientFactory.CreateClient(ClientName);
                var response = await client.GetAsync("Category");
                if (response.IsSuccessStatusCode)
                {

                    return await response.Content.ReadFromJsonAsync<IEnumerable<Category>>();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>?> GetProducts()
        {
            try
            {
                var client = _httpClientFactory.CreateClient(ClientName);
                var response = await client.GetAsync("Product");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();

                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>?> GetProductsByQuery(ProductQuery productQuery)
        {
            try
            {
                var client = _httpClientFactory.CreateClient(ClientName);
                HttpRequestMessage request = new()
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(client.BaseAddress.ToString() + "Product/ProductByQuery"),
                    Content = new StringContent(JsonSerializer.Serialize(productQuery), Encoding.UTF8, MediaTypeNames.Application.Json)
                };
                var responseMessage = await client.SendAsync(request);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return await responseMessage.Content.ReadFromJsonAsync<IEnumerable<Product>>();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
