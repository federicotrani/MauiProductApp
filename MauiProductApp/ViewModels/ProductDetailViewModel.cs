using MauiProductApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiProductApp.ViewModels
{
    [QueryProperty(nameof(Product), "Product")]
    public partial class ProductDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        Product product;

        public ProductDetailViewModel()
        {
           
        }
    }
}
