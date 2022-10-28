using MauiAppSample.ViewModels;
using ReactiveUI;
using ReactiveUI.Maui;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MauiAppSample.Pages;

public partial class MainPage : BasePage<MainPageViewModel>
{
	public MainPage()
	{
		InitializeComponent();

		this.WhenActivated(disposable =>
		{
			this.OneWayBind(ViewModel, x => x.LocationList, x => x.LstLocations.ItemsSource)
				.DisposeWith(disposable);

			this.BindCommand(ViewModel, x => x.StartReadingCommand, x => x.BtnStart)
                .DisposeWith(disposable);

			this.WhenAnyValue(x => x.ViewModel.StartReadingCommand)
				.Subscribe();
        });
	}
}