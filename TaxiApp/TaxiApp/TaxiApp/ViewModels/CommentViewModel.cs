using Newtonsoft.Json.Linq;
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
    public class CommentViewModel : ViewModelBase
    {
        private readonly IDriveServices _driveServices;

        public Command BackCommand { get; }
        public Command CommentCommand { get; }

        public CommentViewModel(INavigationService navigationService, IDriveServices driveService)
            : this(navigationService, driveService, new RuntimeContext())
        { }

        public CommentViewModel(INavigationService navigationService, IDriveServices driveService, IRuntimeContext runtimeContext)
            : base(navigationService, runtimeContext)
        {
            _driveServices = driveService;

            BackCommand = new Command(async () => await Back(), () => !IsBusy);
            CommentCommand = new Command(async () => await CommentDrive(), () => !IsBusy);

            Grades = new List<string> { "0", "1", "2", "3", "4", "5" };
            Grade = "0";
        }

        private Guid _driveId;
        private Drive _selectedDrive;
        public override void Initialize(object navigationData)
        {
            try
            {
                IsBusy = true;

                var drive = navigationData as Drive;

                _driveId = drive.DriveId;
                _selectedDrive = drive;
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

        private List<string> _grades;
        public List<string> Grades
        {
            get { return _grades; }
            set
            {
                _grades = value;
            }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
                CommentCommand.ChangeCanExecute();
            }
        }

        private string _grade;

        public string Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                OnPropertyChanged();
            }
        }


        private async Task Back()
        {
            try
            {
                await _navigationService.NavigateAsync<DriveViewModel>(_selectedDrive);
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
                IsBusy = true;

                if(_selectedDrive.State == Enums.Status.Canceled)
                {

                }
                else
                {
                    CommentDto comment = new CommentDto
                    {
                        driveId = _selectedDrive.DriveId,
                        grade = Int32.Parse(Grade),
                        orderedBy = _selectedDrive.OrderedBy.Id,
                        text = Text
                    };
                    

                    _selectedDrive.Comments = new Comment
                    {
                        CreatedBy = _selectedDrive.OrderedBy,
                        Description = Text,
                        CreatedOn = DateTime.Now,
                        Grade = Int32.Parse(Grade)
                    };

                    await _driveServices.CommentDrive(_runtimeContext.UserId,_runtimeContext.Token, comment);
                    await _navigationService.NavigateAsync<DriveViewModel>(_selectedDrive);
                }
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
