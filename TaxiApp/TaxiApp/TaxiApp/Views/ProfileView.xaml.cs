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
	public partial class ProfileView : ContentPage
	{
        ProfilViewModel _profilViewModel;

		public ProfileView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            _profilViewModel = new ProfilViewModel(AppBootstrapper.NavigationService, AppBootstrapper.ProfileService);
            BindingContext = _profilViewModel;
        }

        protected override async void OnAppearing()
        {
            await _profilViewModel.InitializeAsync(null);
        }
    }
}