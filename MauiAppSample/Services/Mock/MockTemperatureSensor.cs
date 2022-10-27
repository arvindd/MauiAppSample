using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Linq;
using MauiAppSample.Services.Base;
using System.Reactive.Disposables;

namespace MauiAppSample.Services.Mock;

/// <summary>
/// Service that reads values from the temperature sensor
/// </summary>
internal class MockTemperatureSensor : TemperatureSensor
{
    private readonly Random random = new();

    /// <summary>
    /// Generates a random sequence of numbers in random time intervals.
    /// </summary>
    /// <returns></returns>
    public override IObservable<IChangeSet<int>> ReadValue()
    {
        return Observable.Generate(0,
                 x => x < 3,
                 x => x + 1,
                 _ => random.Next(0, 60),
                 _ => TimeSpan.FromSeconds(1))
            .ToObservableChangeSet();
    }

    public override void WriteValue(int value) {  }
}
