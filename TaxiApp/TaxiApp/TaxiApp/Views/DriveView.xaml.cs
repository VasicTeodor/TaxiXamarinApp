using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            }
        }
    }
}