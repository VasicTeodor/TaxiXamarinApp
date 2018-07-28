using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Services.Interfaces;
using TaxiApp.Settings.Interfaces;
using Xamarin.Forms;

namespace TaxiApp.ViewModels
{
    public abstract class ViewModelBase : BindableObject
    {
        protected readonly INavigationService _navigationService;
        protected readonly IRuntimeContext _runtimeContext;

        public ViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ViewModelBase(INavigationService navigationService, IRuntimeContext runtimeContext)
        {
            _navigationService = navigationService;
            _runtimeContext = runtimeContext;
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public virtual void Initialize(object navigationData)
        {
        }
    }
}
