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
	public partial class RegisterView : ContentPage
	{
		public RegisterView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new RegisterViewModel(AppBootstrapper.NavigationService, AppBootstrapper.ProfileService);
        }
    }
}