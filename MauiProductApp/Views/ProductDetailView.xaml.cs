namespace MauiProductApp.Views;

using MauiProductApp.ViewModels;

public partial class ProductDetailView : ContentPage
{
	public ProductDetailView(ProductDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}