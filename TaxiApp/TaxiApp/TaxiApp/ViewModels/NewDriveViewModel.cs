using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;
using TaxiApp.Services.Interfaces;
using TaxiApp.Settings;
using TaxiApp.Settings.Interfaces;
using Xamarin.Forms;

namespace TaxiApp.ViewModels
{
    public class NewDriveViewModel : ViewModelBase
    {
        //https://www.c-sharpcorner.com/article/xamarin-forms-google-maps-api/
        //https://www.bingmapsportal.com/

        private readonly IDriveServices _driveServices;
        private readonly IProfileService _profileService;

        public Command BackCommand { get; }
        public Command NewDriveCommand { get; }

        public NewDriveViewModel(INavigationService navigationService, IDriveServices driveService, IProfileService profileService)
            : this(navigationService, driveService, profileService, new RuntimeContext())
        { }

        public NewDriveViewModel(INavigationService navigationService, IDriveServices driveService, IProfileService  profileService, IRuntimeContext runtimeContext)
            : base(navigationService, runtimeContext)
        {
            _driveServices = driveService;
            _profileService = profileService;

            BackCommand = new Command(async () => await Back(), () => !IsBusy);
            NewDriveCommand = new Command(async () => await NewDrive(), () => !IsBusy);

            CarTypes = new List<string> { "Bez_Naznake, Car, Kombi" };
            CarType = "Bez_Naznake";

        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
                BackCommand.ChangeCanExecute();
                NewDriveCommand.ChangeCanExecute();
            }
        }

        private List<string> _carTypes;

        public List<string> CarTypes
        {
            get { return _carTypes; }
            set { _carTypes = value; }
        }


        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
                NewDriveCommand.ChangeCanExecute();
            }
        }

        private string _yAxis;

        public string YAxis
        {
            get { return _yAxis; }
            set
            {
                _yAxis = value;
                OnPropertyChanged();
                NewDriveCommand.ChangeCanExecute();
            }
        }

        private string _xAxis;

        public string XAxis
        {
            get { return _xAxis; }
            set
            {
                _xAxis = value;
                OnPropertyChanged();
                NewDriveCommand.ChangeCanExecute();
            }
        }

        private string _carType;

        public string CarType
        {
            get { return _carType; }
            set
            {
                _carType = value;
                OnPropertyChanged();
                NewDriveCommand.ChangeCanExecute();
            }
        }

        private async Task Back()
        {
            try
            {
                await _navigationService.NavigateAsync<DrivesViewModel>();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
            }
        }

        private async Task NewDrive()
        {
            try
            {
                IsBusy = true;

                var profile = await _profileService.GetProfile(_runtimeContext.UserId, _runtimeContext.Token);

                Drive newDrive = new Drive
                {
                    Address =
                    {
                        Address = Address,
                        X = Double.Parse(XAxis),
                        Y = Double.Parse(YAxis)
                    },
                    CarType = (Enums.CarTypes)Enum.Parse(typeof(Enums.CarTypes), this.CarType),
                    OrderedBy = profile
                };

                await _driveServices.CreateDrive(_runtimeContext.Token, newDrive);
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
    }
}
