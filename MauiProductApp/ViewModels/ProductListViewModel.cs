using System.Collections.ObjectModel;
using MauiProductApp.Models;
using MauiProductApp.Services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiProductApp.Views;

namespace MauiProductApp.ViewModels
{
    public partial class ProductListViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Products { get; } = new();

        [ObservableProperty]
        Product selectedProduct;

        [ObservableProperty]
        bool isRefreshing;

        private readonly IProductsService service;
        private readonly IConnectivity connectivity;

        public ProductListViewModel(IProductsService service, IConnectivity connectivity)
        {
            this.service = service;
            this.connectivity = connectivity;
        }

        [RelayCommand]
        async Task GetProductsAsync()
        {
            if(IsBusy) return;

            try
            {
                IsBusy = true;

                var products = (connectivity.NetworkAccess == NetworkAccess.Internet)
                    ? await service.GetOnlineProductAsync() 
                    : await service.GetOfflineProductAsync();

                if(products!=null)
                {
                    if (products.Any()) Products.Clear();

                    foreach(var product in products)
                    {
                        Products.Add(product);
                    }
                }

            }catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }finally { 
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GoToDetailAsync()
        {
            if (SelectedProduct == null) 
                return;

            var data = new Dictionary<string, object>()
            {
                {"Product", SelectedProduct }
            };

            await Shell.Current.GoToAsync(nameof(ProductDetailView), true, data);
        }

    }
}
