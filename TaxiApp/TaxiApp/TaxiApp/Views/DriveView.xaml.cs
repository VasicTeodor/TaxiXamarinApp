using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;
using TaxiApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxiApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DriveView : ContentPage
	{
        object _parameter;
        DriveViewModel _driveViewModel;
		public DriveView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            _driveViewModel = new DriveViewModel(AppBootstrapper.NavigationService, AppBootstrapper.DriveServices);
            BindingContext = _driveViewModel;
		}

        public DriveView(object parameter) : this()
        {
            _parameter = parameter;

            if (_parameter != null)
            {
                _driveViewModel.Initialize(_parameter);

                var drive = _parameter as Drive;
                if (drive.State == Enums.Status.Successful || drive.State == Enums.Status.Unsuccessful)
                {
                    btnComment.IsVisible = true;
                }
                else
                {
                    btnComment.IsVisible = false;
                }

                if(drive.DrivedBy == null)
                {
                    lblDriverX.IsVisible = false;
                    lblDriver.IsVisible = false;
                }

                if(drive.Comments == null)
                {
                    lblCommDateX.IsVisible = false;
                    lblComment.IsVisible = false;
                    lblCommentBy.IsVisible = false;
                    lblCommentByX.IsVisible = false;
                    lblCommentDate.IsVisible = false;
                    lblCommentText.IsVisible = false;
                    lblCommentTextX.IsVisible = false;
                }
            }
        }
    }
}