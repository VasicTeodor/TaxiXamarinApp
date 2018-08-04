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
    public class EditDriveViewModel : ViewModelBase
    {
        private readonly IDriveServices _driveServices;

        public Command BackCommand { get; }
        public Command NewDriveCommand { get; }
        public Command QuitDriveCommand { get; }

        public EditDriveViewModel(INavigationService navigationService, IDriveServices driveService)
            : this(navigationService, driveService, new RuntimeContext())
        { }

        public EditDriveViewModel(INavigationService navigationService, IDriveServices driveService, IRuntimeContext runtimeContext)
            : base(navigationService, runtimeContext)
        {
            _driveServices = driveService;

            BackCommand = new Command(async () => await Back(), () => !IsBusy);
            NewDriveCommand = new Command(async () => await EditDrive(), () => !IsBusy);
            QuitDriveCommand = new Command(async () => await QuitDrive(), () => !IsBusy);

            CarTypes = new List<string> { "Bez_Naznake, Car, Kombi" };
            CarType = "Bez_Naznake";
        }

        private Guid _driveId;
        private Drive _selectedDrive;
        public override void Initialize(object navigationData)
        {
            try
            {
                IsBusy = true;

                var drive = navigationData as Drive;

                _selectedDrive = drive;

                Address = drive.Address.Address;
                XAxis = drive.Address.X.ToString();
                YAxis = drive.Address.Y.ToString();
                CarType = drive.CarType.ToString();

                _driveId = drive.DriveId;
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
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

        private async Task EditDrive()
        {
            try
            {
                IsBusy = true;

                Drive newDrive = new Drive
                {
                    Address =
                    {
                        Address = Address,
                        X = Double.Parse(XAxis),
                        Y = Double.Parse(YAxis)
                    },
                    DriveId = _selectedDrive.DriveId,
                    CarType =  (Enums.CarTypes)Enum.Parse(typeof(Enums.CarTypes), this.CarType)
                };

                await _driveServices.QuitDrive(_runtimeContext.Token, newDrive);

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

        private async Task QuitDrive()
        {
            try
            {
                IsBusy = true;
                
                await _driveServices.EditDrive(_runtimeContext.UserId, _runtimeContext.Token, _selectedDrive);

                await _navigationService.NavigateAsync<CommentViewModel>(_selectedDrive);
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
