using DynamicData;
using MauiAppSample.Services.Base;
using MauiAppSample.Services.Mock;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
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
using Location = MauiAppSample.Models.Location;

namespace MauiAppSample.ViewModels;

public class MainPageViewModel : BaseViewModel
{
    public MainPageViewModel() : base("Home") 
    {
        LocationSensor = AppConfig.LocationSensor;
        StartReadingCommand = ReactiveCommand.CreateFromObservable(LocationSensor.Connect, LocationSensor.IsEnabled());

        // Note the SubscribeOn() and ObserveOn() used here:
        // SubscribeOn() makes the whole of the execution to run in a specific thread (so that the actual Subscribe()
        //    call happens in that thread)
        // ObserveOn() makes the lines after ObserveOn() execute on a specific thread.
        //
        // Since we want to Sensors to work independent of the GUI (main) thread, we subscribe on a TaskpoolScheduler
        // first, so that the StartReadingCommand (which in-turn is reading from the sensor) happens on that thread. 
        // We also want to make sure that we transform the generated Locations into a LocationViewModel on a TaskViewScheduler
        // so that we will no hog the GUI thread. The first two SubscribeOn() and ObserveOn() below achieves these objectives.
        // The _locationList has to be updated on the GUI (main) thread because we want the generated locations to be
        // displayed on the GUI. The last ObserveOn() is for that.
        StartReadingCommand                             // <-- Running on a TaskpoolScheduler
            .SubscribeOn(RxApp.TaskpoolScheduler)       // <-- Running on a TaskpoolScheduler
            .ObserveOn(RxApp.TaskpoolScheduler)         // <-- Running on a TaskpoolScheduler 
            .Transform(x => new LocationViewCellVM(x))   // <-- Running on a TaskpoolScheduler
            .DisposeMany()                              // <-- Running on a TaskpoolScheduler
            .ObserveOn(RxApp.MainThreadScheduler)       // <-- Running on a TaskpoolScheduler
            .Bind(out _locationList)                    // <-- Running on the main (GUI) thread
            .Subscribe();                               // <-- Running on the main (GUI) thread

        // Catch any exceptions thrown by the command above and display a log message
        StartReadingCommand
            .ThrownExceptions
            .Subscribe(x => this.Log().Warn($"Exception thrown: {x.Message}"));
    }

    private readonly ReadOnlyObservableCollection<LocationViewCellVM> _locationList;
    public ReadOnlyObservableCollection<LocationViewCellVM> LocationList => _locationList;

    private LocationSensor LocationSensor { get; }

    public ReactiveCommand<Unit, IChangeSet<Location>> StartReadingCommand { get; }
}
