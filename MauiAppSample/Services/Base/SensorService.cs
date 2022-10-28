using DynamicData;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Services.Base;
internal abstract class SensorService<T> : BaseService
    //where T : unmanaged
    // Uncomment ^^ above line if you want to make sure that T is one of the basic 
    // .NET types such as int, float, etc.
{
    /// <summary>
    /// A function that returns an observable that says if the sensor service is enabled.
    /// The read commands are executed only when a specific sensor is enabled. 
    /// This is made as an observable to enable notification when a sensor suddenly becomes
    /// available for use.
    /// </summary>
    /// <returns>True if enabled; false otherwise (wrapped in an observable)</returns>
    /// <remarks>
    /// NOTE: This function can be overridden in the derived classes. If not overridden, 
    /// the sensor is assumed to be always enabled (and hence available for use).
    /// </remarks>
    public virtual IObservable<bool> IsEnabled() => new List<bool> { true }.ToObservable();

    /// <summary>
    /// Connects to the sensor, and streams the sensor values as Observables of ChangeSets.
    /// </summary>
    /// <returns></returns>
    public abstract IObservable<IChangeSet<T>> Connect();

    /// <summary>
    /// Writes an individual value into the sensor control.
    /// </summary>
    /// <param name="value">Value to be written</param>
    public abstract void WriteValue(T value);
}
