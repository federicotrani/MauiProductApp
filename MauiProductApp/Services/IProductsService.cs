using MauiProductApp.Models;

namespace MauiProductApp.Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetOnlineProductAsync();
        Task<List<Product>> GetOfflineProductAsync();
    }
}
