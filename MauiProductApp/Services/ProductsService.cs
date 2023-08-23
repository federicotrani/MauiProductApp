using System.Text.Json;
using System.Net.Http.Json;
using MauiProductApp.Models;

namespace MauiProductApp.Services
{
    public class ProductsService : IProductsService
    {
        HttpClient httpClient;

        public ProductsService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetOnlineProductAsync()
        {
            // var response = await httpClient.GetAsync("https://jsonkeeper.com/b/Q81Q");

            var response = await httpClient.GetAsync("https://api.npoint.io/834fc459c24e32a8981d");

            if (response.IsSuccessStatusCode)
            {
                var products = await response.Content.ReadFromJsonAsync<List<Product>>();
                return products;
            }

            return default;
        }

        public async Task<List<Product>> GetOfflineProductAsync()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("product.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();

            var products = JsonSerializer.Deserialize<List<Product>>(contents);
            return products;
        }
    }
}
