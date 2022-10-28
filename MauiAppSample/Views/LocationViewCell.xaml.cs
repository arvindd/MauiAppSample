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
            this.OneWayBind(ViewModel, x => x.Latitude, x => x.LatitudeDisplay.Text)
                .DisposeWith(disposables);
            this.OneWayBind(ViewModel, x => x.Longitude, x => x.LongitudeDisplay.Text)
                .DisposeWith(disposables);
        });
    }
}