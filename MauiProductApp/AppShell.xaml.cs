namespace MauiProductApp;

using MauiProductApp.Views;
public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ProductDetailView), typeof(ProductDetailView));
	}
}
