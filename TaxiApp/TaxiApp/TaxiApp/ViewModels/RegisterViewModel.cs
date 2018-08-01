using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;
using TaxiApp.Services.Interfaces;
using Xamarin.Forms;

namespace TaxiApp.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }

        private readonly IProfileService _profileService;

        public RegisterViewModel(INavigationService navigationService, IProfileService profileService)
            : base(navigationService)
        {
            _profileService = profileService;
            RegisterCommand = new Command(async () => await RegisterNewUser(),
                () => !IsBusy && !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email));
            CancelCommand = new Command(async () => await CancelLogin());

            Genders = new List<string> { "Male", "Female" };
        }

        private List<string> _genders;
        public List<string> Genders
        {
            get { return _genders; }
            set
            {
                _genders = value;
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
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
                RegisterCommand.ChangeCanExecute();
            }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
            }
        }

        private string _jmbg;

        public string Jmbg
        {
            get { return _jmbg; }
            set
            {
                _jmbg = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
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
                RegisterCommand.ChangeCanExecute();
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
                RegisterCommand.ChangeCanExecute();
            }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set {
                _gender = value;
                OnPropertyChanged();
            }
        }


        private async Task RegisterNewUser()
        {
            try
            {
                IsBusy = true;

                Enums.Genders cosenGender = (Enums.Genders)Enum.Parse(typeof(Enums.Genders), _gender);

                Customer newCustomer = new Customer
                {
                    Email = _email,
                    Id = new Guid(),
                    IsBanned = false,
                    Jmbg = _jmbg,
                    Name = _name,
                    Password = _password,
                    Phone = _phone,
                    Surname = _surname,
                    Username = _userName,
                    Gender = cosenGender,
                    Role = Enums.Roles.Customer
                };

                await _profileService.CreateProfile(newCustomer);
                await _navigationService.NavigateAsync<DrivesViewModel>();
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
