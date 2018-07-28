using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Services.Interfaces;
using TaxiApp.Settings;
using TaxiApp.Settings.Interfaces;
using Xamarin.Forms;

namespace TaxiApp.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public StartViewModel(INavigationService navigationService)
            : this(navigationService, new RuntimeContext())
        { }

        public StartViewModel(INavigationService navigationService, IRuntimeContext runtimeContext)
            : base(navigationService, runtimeContext)
        {
            LoginCommand = new Command(async () => await Login());

            RegisterCommand = new Command(async () => await RegisterNewUser());
        }

        private async Task Login()
        {
            try
            {
                _navigationService.SetRootPage(typeof(LoginViewModel));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
            }
        }

        private async Task RegisterNewUser()
        {
            try
            {
                await _navigationService.NavigateAsync<RegisterViewModel>();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
            }
        }
    }
}
