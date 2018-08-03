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
    public class DriveViewModel : ViewModelBase
    {
        private readonly IDriveServices _driveServices;

        public Command BackCommand { get; }
        public Command CommentCommand { get; }

        public DriveViewModel(INavigationService navigationService, IDriveServices driveService)
            : this(navigationService, driveService, new RuntimeContext())
        { }

        public DriveViewModel(INavigationService navigationService, IDriveServices driveService, IRuntimeContext runtimeContext)
            : base(navigationService, runtimeContext)
        {
            _driveServices = driveService;

            BackCommand = new Command(async () => await Back(), () => !IsBusy);
            CommentCommand = new Command(async () => await CommentDrive(), () => !IsBusy);
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
                Destination = drive.Destination.Address;
                Price = drive.Price;
                CarType = drive.CarType.ToString();
                Date = drive.Date.ToLongDateString();

                if (drive.DrivedBy != null)
                {
                    Driver = drive.DrivedBy.Name + " " + drive.DrivedBy.Surname;
                }

                if(drive.Comments != null)
                {
                    CommentText = drive.Comments.Description;
                    CommentBy = drive.Comments.CreatedBy.Name + " " + drive.Comments.CreatedBy.Surname + " - " + drive.Comments.CreatedBy.Role.ToString();
                    CommentDate = drive.Comments.CreatedOn.ToLongDateString();
                }

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
                CommentCommand.ChangeCanExecute();
            }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged();
            }
        }

        private string _destination;

        public string Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
                OnPropertyChanged();
            }
        }

        private double _price;

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
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
            }
        }

        private string _driver;

        public string Driver
        {
            get { return _driver; }
            set
            {
                _driver = value;
                OnPropertyChanged();
            }
        }

        private string _date;

        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private string _commentText;

        public string CommentText
        {
            get { return _commentText; }
            set
            {
                _commentText = value;
                OnPropertyChanged();
            }
        }

        private string _commentBy;

        public string CommentBy
        {
            get { return _commentBy; }
            set
            {
                _commentBy = value;
                OnPropertyChanged();
            }
        }

        private string _commentDate;

        public string CommentDate
        {
            get { return _commentDate; }
            set
            {
                _commentDate = value;
                OnPropertyChanged();
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

        private async Task CommentDrive()
        {
            try
            {
                if(_selectedDrive != null)
                    await _navigationService.NavigateAsync<CommentViewModel>(_selectedDrive);
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
