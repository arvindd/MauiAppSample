using MauiAppSample.Pages;

namespace MauiAppSample;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new AppBootstrapper().Bootstrap().CreateMainPage();
	}
}
