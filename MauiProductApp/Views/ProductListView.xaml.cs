namespace MauiProductApp.Views;

using MauiProductApp.ViewModels;
public partial class ProductListView : ContentPage
{
	public ProductListView(ProductListViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}