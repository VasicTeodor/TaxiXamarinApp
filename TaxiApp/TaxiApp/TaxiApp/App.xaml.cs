using System;
using TaxiApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace TaxiApp
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var boot = new AppBootstrapper();
            boot.Initialize();

			MainPage = new StartView();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
