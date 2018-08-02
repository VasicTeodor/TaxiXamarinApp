using System;
using System.Collections.Generic;
using System.Text;
using TaxiApp.Services.Interfaces;
using TaxiApp.Services;
using TaxiApp.ViewModels;
using TaxiApp.Views;

namespace TaxiApp
{
    public class AppBootstrapper
    {
        public static INavigationService NavigationService => new NavigationService();
        public static IRequestService RequestService => new RequestService();
        public static IAuthenticationService AuthenticationService => new AuthenticationService(RequestService);
        public static IProfileService ProfileService => new ProfileService(RequestService, AuthenticationService);
        public static IDriveServices DriveServices => new DriveServices(RequestService, AuthenticationService);

        public void Initialize()
        {
            NavigationService.Register<StartView, StartViewModel>();
            NavigationService.Register<LoginView, LoginViewModel>();
            NavigationService.Register<RegisterView, RegisterViewModel>();
            NavigationService.Register<DrivesView, DrivesViewModel>();
            NavigationService.Register<DriveView, DriveViewModel>();
            NavigationService.Register<ProfileView, ProfilViewModel>();
        }

    }
}
