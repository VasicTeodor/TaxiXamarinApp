using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Services.Interfaces;
using Xamarin.Forms;

namespace TaxiApp.Services
{
    class NavigationService : INavigationService
    {
        private static Dictionary<Type, Type> _pagesByType = new Dictionary<Type, Type>();

        public Task NavigateAsync<TViewModel>(bool animated = true)
        {
            return NavigateToAsync(typeof(TViewModel), null, animated);
        }

        public Task NavigateAsync<TViewModel>(object parameter, bool animated = true)
        {
            return NavigateToAsync(typeof(TViewModel), parameter, animated);
        }

        public void Register<TView, TViewModel>()
        {
            if(!_pagesByType.Keys.Contains(typeof(TView)))
                _pagesByType.Add(typeof(TView), typeof(TViewModel));
        }

        public void SetRootPage(Type viewModelType)
        {
            Page page = CreatePage(viewModelType);
            Application.Current.MainPage = new NavigationPage(page);
        }

        private async Task NavigateToAsync(Type viewModelType, object parameter, bool animated)
        {
            Page page = CreatePage(viewModelType, parameter);

            var navigationPage = Application.Current.MainPage as NavigationPage;
            if(navigationPage != null)
            {
                await navigationPage.PushAsync(page, animated);
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(page);
            }
        }

        private Page CreatePage(Type viewModelType, object parameter = null)
        {
            Type pageType = _pagesByType.FirstOrDefault(x => x.Value == viewModelType).Key;
            if(pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType.Name}");
            }

            Page page = parameter != null ? Activator.CreateInstance(pageType, parameter) as Page : Activator.CreateInstance(pageType) as Page;
            return page;
        }
    }
}
