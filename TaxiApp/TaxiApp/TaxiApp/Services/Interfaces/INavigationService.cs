using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Services.Interfaces
{
    public interface INavigationService
    {
        void Register<TView, TViewModel>();
        Task NavigateAsync<TViewModel>(bool animated = true);
        Task NavigateAsync<TViewModel>(object parameter, bool animated = true);
        void SetRootPage(Type viewModelType);
    }
}
