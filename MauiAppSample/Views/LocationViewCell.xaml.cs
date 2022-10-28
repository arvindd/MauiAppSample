namespace MauiAppSample.Views;

using MauiAppSample.ViewModels;
using ReactiveUI;
using ReactiveUI.Maui;
using System.Reactive.Disposables;

public partial class LocationViewCell : BaseViewCell<LocationViewModel>
{
	public LocationViewCell()
	{
		InitializeComponent();

        this.WhenActivated(disposables =>
        {
            this.OneWayBind(ViewModel, vm => vm.Latitude, v => v.LatitudeDisplay.Text)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, vm => vm.Longitude, v => v.LongitudeDisplay.Text)
                .DisposeWith(disposables);
        });
    }
}