namespace MauiProductApp;

using MauiProductApp.Services;
using MauiProductApp.ViewModels;
using MauiProductApp.Views;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IProductsService, ProductsService>();
		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

		builder.Services.AddSingleton<ProductListViewModel>();
		builder.Services.AddSingleton<ProductListView>();

        builder.Services.AddSingleton<ProductDetailViewModel>();
        builder.Services.AddSingleton<ProductDetailView>();

        return builder.Build();
	}
}
