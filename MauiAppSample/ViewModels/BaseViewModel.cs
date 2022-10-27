using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject, 
        IRoutableViewModel, IActivatableViewModel, IEnableLogger
    {
        protected BaseViewModel(string title, IScreen hostScreen = null)
        {
            UrlPathSegment = title;
            HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        }

        /// <summary>
        /// Gets the activator which contains context information for use in activation of the view model.
        /// </summary>
        public ViewModelActivator Activator { get; } = new ViewModelActivator();

        /// <summary>
        /// Gets the current page path.
        /// </summary>
        public string UrlPathSegment { get; }

        /// <summary>
        /// Gets the screen used for routing operations.
        /// </summary>
        public IScreen HostScreen { get; }
    }
}
