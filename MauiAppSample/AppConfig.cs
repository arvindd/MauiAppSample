using MauiAppSample.Services.Base;
using MauiAppSample.Services.Mock;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample
{
    internal static class AppConfig
    {
        public static void ConfigureServices()
        {
            // Register all services
            Locator.CurrentMutable.RegisterConstant<TemperatureSensor>(new MockTemperatureSensor());

            // Make these services available to all other classes
            TemperatureSensor = Locator.Current.GetService<TemperatureSensor>();
        }

        public static TemperatureSensor TemperatureSensor { get; private set; }
    }
}
