using MauiAppSample.ViewModels;
using ReactiveUI;
using ReactiveUI.Maui;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MauiAppSample.Pages;

public partial class TemperaturePage : BasePage<TemperaturePageViewModel>
{
	public TemperaturePage()
	{
		InitializeComponent();
	}
}