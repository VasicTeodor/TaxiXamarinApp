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
	public partial class StartView : ContentPage
	{
		public StartView ()
		{
			InitializeComponent ();
            image.Source = ImageSource.FromResource("TaxiApp.Images.taxi2.jpg");

            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = new StartViewModel(AppBootstrapper.NavigationService);
		}
	}
}