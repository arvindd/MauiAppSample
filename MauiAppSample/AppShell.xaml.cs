using AndroidX.Lifecycle;
using MauiAppSample.ViewModels;
using ReactiveUI;
using ReactiveUI.Maui;
using Splat;

namespace MauiAppSample;

public partial class AppShell: ReactiveShell<AppShellViewModel>
{
	public AppShell() 
	{
		InitializeComponent();
	}
}
