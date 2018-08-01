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
	public partial class DrivesView : ContentPage
	{
        DrivesViewModel drivesViewModel;

		public DrivesView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            drivesViewModel = new DrivesViewModel(AppBootstrapper.NavigationService, AppBootstrapper.AuthenticationService, AppBootstrapper.DriveServices);
            BindingContext = drivesViewModel;

            //DrivesList.ItemSelected += (sender, e) =>
            //{
            //    ((ListView)sender).SelectedItem = null;
            //};
		}

        //protected override async void OnAppearing()
        //{
        //    await drivesViewModel.InitializeAsync(null);
        //}
	}
}