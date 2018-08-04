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
	public partial class EditDriveView : ContentPage
	{
        object _parameter;
        EditDriveViewModel _editDriveViewModel;

        public EditDriveView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            _editDriveViewModel = new EditDriveViewModel(AppBootstrapper.NavigationService, AppBootstrapper.DriveServices);

            BindingContext = _editDriveViewModel;
		}

        public EditDriveView(object parameter) : this()
        {
            _parameter = parameter;

            if (_parameter != null)
            {
                _editDriveViewModel.Initialize(_parameter);
            }
        }
    }
}