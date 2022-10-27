using MauiAppSample.ViewModels;
using ReactiveUI.Maui;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Pages
{
    public class BasePage<TViewModel> : ReactiveContentPage<TViewModel>, IEnableLogger
                           where TViewModel : BaseViewModel
    {
        public BasePage() { }
    }
}
