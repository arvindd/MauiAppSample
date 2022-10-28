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
using Location = MauiAppSample.Models.Location;

namespace MauiAppSample.Services.Mock;

/// <summary>
/// Service that reads values from the temperature sensor
/// </summary>
internal class MockLocationSensor : LocationSensor
{
    private readonly Random random = new();

    /// <summary>
    /// Generates a random sequence of 3 locations every 1 or 2 seconds.
    /// 
    /// <para>
    /// The locations are generated as (integral pseudo) latitudes ranging from -90 (for 90S) to +90 (for 90N) and
    /// (integral pseudo) longitudes ranging from -180 (for 180W) to +180 (for 180 E).
    /// </para>
    /// </summary>
    /// <returns></returns>
    public override IObservable<IChangeSet<Location>> Connect()
    {
        return Observable.Generate(0,
                 x => x < 3,
                 x => x + 1,
                 _ => new Location(random.Next(-90, 90),random.Next(-180, 180)),
                 _ => TimeSpan.FromSeconds(random.Next(1, 2)))
            .Log(this, "Location", x => $"Lat: {x.Latitude}, Long: {x.Longitude}")
            .ToObservableChangeSet();
    }

    public override void WriteValue(Location loc) {  }
}
