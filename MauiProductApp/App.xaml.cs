using MauiProductApp.Models;

namespace MauiProductApp;

public partial class App : Application
{
	
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		
	}
}
