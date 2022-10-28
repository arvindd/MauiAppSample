using MauiAppSample.ViewModels;
using MauiAppSample.Pages;
using ReactiveUI.Maui;
using ReactiveUI;
using Serilog;
using Splat;
using Splat.Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiAppSample.Views;

namespace MauiAppSample
{
    /// <summary>
    /// This bootstraps the application, registering all services, 
    /// views and viewmodels of the application with the Service Locator.
    /// </summary>
    /// 
    // Got this from: https://github.com/reactiveui/ReactiveUI.Samples/blob/main/Xamarin/Cinephile/Cinephile/AppBootstrapper.cs
    internal class AppBootstrapper : ReactiveObject, IScreen
    {
        public AppBootstrapper Bootstrap()
        {
            Router = new RoutingState();
            Locator.CurrentMutable.RegisterConstant(this, typeof(IScreen));

            // Initialise logging framework
            // We are using Serilog logger, and configuring it to write to the 
            // Visual Studio Debug Window
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Debug()
                .CreateLogger();

            // Register the logger to our locator so that we can use it anywhere in the application
            Locator.CurrentMutable.UseSerilogFullLogger();

            // Configure all services
            AppConfig.ConfigureServices();

            // Register all views with their view models
            Locator.CurrentMutable.Register(() => new MainPage(), typeof(IViewFor<MainPageViewModel>));
            Locator.CurrentMutable.Register(() => new LocationViewCell(), typeof(IViewFor<LocationViewModel>));

            // Navigates to the main page, and resets the navigation stack
            Router
               .NavigateAndReset
               .Execute(new MainPageViewModel())
               .Subscribe();

            return this;
        }

        /// <summary>
        /// Gets or sets the router which is used to navigate between views.
        /// </summary>
        public RoutingState Router { get; protected set; }

        /// <summary>
        /// Creates the first main page used within the application.
        /// </summary>
        /// <returns>The page generated.</returns>
        [SuppressMessage("Performance", "CA1822:Mark members as static",
            Justification = "Called in App.App() like an instance method, not as a static method")]
        public Page CreateMainPage()
        {
            // NB: This returns the opening page that the platform-specific
            // boilerplate code will look for. It will know to find us because
            // we've registered our AppBootstrappScreen.
            return new RoutedViewHost();
        }
    }
}
