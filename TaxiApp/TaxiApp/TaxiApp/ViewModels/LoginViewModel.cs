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
    public class LoginViewModel : ViewModelBase
    {
        public Command LoginCommand { get; }
        public Command CancelCommand { get; }

        private readonly IAuthenticationService _authenticationService;
        private readonly IProfileService _profileService;

        public LoginViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IProfileService profileService)
            : this(navigationService, authenticationService, profileService, new RuntimeContext())
        { }

        public LoginViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IProfileService profileService, IRuntimeContext runtimeContext)
            : base(navigationService, runtimeContext)
        {
            _authenticationService = authenticationService;
            _profileService = profileService;

            LoginCommand = new Command(async () => await Login(), () => !IsBusy && !String.IsNullOrWhiteSpace(UserName) && !String.IsNullOrWhiteSpace(Password));
            CancelCommand = new Command(async () => await CancelLogin());
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }

        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
                LoginCommand.ChangeCanExecute();
            }
        }

        private async Task Login()
        {
            try
            {
                IsBusy = true;

                await _authenticationService.Login(UserName, Password);
                //await _profileService.GetProfile(_runtimeContext.Token);
                _navigationService.SetRootPage(typeof(DrivesViewModel));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task CancelLogin()
        {
            try
            {
                await _navigationService.NavigateAsync<StartViewModel>();
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
