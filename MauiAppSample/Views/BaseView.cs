using MauiAppSample.ViewModels;
using ReactiveUI.Maui;
using Splat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppSample.Views
{
    public class BaseView<TViewModel> : ReactiveContentView<TViewModel>, IEnableLogger
                       where TViewModel : BaseViewModel
    {
        public BaseView() { }
    }
}
