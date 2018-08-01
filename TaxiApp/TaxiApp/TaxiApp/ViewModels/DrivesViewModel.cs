using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;
using TaxiApp.Services.Interfaces;
using TaxiApp.Settings;
using TaxiApp.Settings.Interfaces;
using Xamarin.Forms;

namespace TaxiApp.ViewModels
{
    public class DrivesViewModel : ViewModelBase
    {
        private readonly IDriveServices _driveServices;
        private readonly IAuthenticationService _authenticationService;
        
        public Command CreateDriveCommand { get; }
        public Command LogOutCommand { get; }
        public Command<Guid> ViewProfileCommand { get; }
        public Command<Guid> EditCommand { get; }
        public Command RefreshCommand { get; }

        public DrivesViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IDriveServices driveServices)
            : this(navigationService, authenticationService, driveServices, new RuntimeContext())
        { }

        public DrivesViewModel(INavigationService navigationService, IAuthenticationService authenticationService, IDriveServices driveServices, IRuntimeContext runtimeContext)
            : base(navigationService, runtimeContext)
        {
            DriveList = new ObservableCollection<Drive>();

            _driveServices = driveServices;
            _authenticationService = authenticationService;
            
            CreateDriveCommand = new Command(async () => await CreateDrive(), () => !IsBusy);
            LogOutCommand = new Command(async () => await LogOut(), () => !IsBusy);
            RefreshCommand = new Command(async () => await Refresh(), () => !IsBusy);
            //ViewProfileCommand = new Command<Guid>(async (id) => await ViewProfile(id), (id) => !IsBusy);
            EditCommand = new Command<Guid>(async (id) => await Edit(id), (id) => !IsBusy);
            //SearchCommand = new Command(async () => await Search(), () => !IsBusy);

            GetAllDrives();
        }

        private ObservableCollection<Drive> _driveList;
        public ObservableCollection<Drive> DriveList
        {
            get { return _driveList; }
            set
            {
                _driveList = value;
                OnPropertyChanged();
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
                CreateDriveCommand.ChangeCanExecute();
                EditCommand.ChangeCanExecute();
                //ViewProfileCommand.ChangeCanExecute();
            }
        }

        private async Task LogOut()
        {
            try
            {
                IsBusy = true;
                await _authenticationService.Logout();
                _navigationService.SetRootPage(typeof(LoginViewModel));
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

        private async Task Refresh()
        {
            try
            {
                IsBusy = true;

                var result = await _driveServices.GetAllDrives(_runtimeContext.UserId, _runtimeContext.Token);

                DriveList = new ObservableCollection<Drive>(result);
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

        private async Task CreateDrive()
        {
            try
            {
                IsBusy = true;
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

        private async Task Edit(Guid id)
        {
            try
            {
                IsBusy = true;
                var selectedPost = DriveList.Single(x => x.DriveId == id);
                await _navigationService.NavigateAsync<DrivesViewModel>(selectedPost);
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

        private async void GetAllDrives()
        {
            var drives = await _driveServices.GetAllDrives(_runtimeContext.UserId, _runtimeContext.Token);

            DriveList = new ObservableCollection<Drive>(drives);
        }
    }
}
