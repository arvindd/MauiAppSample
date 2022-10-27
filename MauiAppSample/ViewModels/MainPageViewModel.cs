using DynamicData;
using MauiAppSample.Services.Base;
using MauiAppSample.Services.Mock;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppSample.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    public MainPageViewModel() : base("Home") 
    {
        TemperatureSensor = AppConfig.TemperatureSensor;
        StartReadingCommand = ReactiveCommand.CreateFromObservable(TemperatureSensor.ReadValue, TemperatureSensor.IsEnabled());

        StartReadingCommand
            .ObserveOn(RxApp.MainThreadScheduler)
            .Bind(out _temperaturevalues)
            .Subscribe();

        StartReadingCommand
            .ThrownExceptions
            .Subscribe(x => this.Log().Warn($"Exception thrown: {x.Message}"));
    }

    public string Greeting { get; set; }
    public string Welcome { get; set; }

    private ReadOnlyObservableCollection<int> _temperaturevalues;
    public ReadOnlyObservableCollection<int> TemperatureValues => _temperaturevalues;

    private TemperatureSensor TemperatureSensor { get; }

    public ReactiveCommand<Unit, IChangeSet<int>> StartReadingCommand { get; }
}
