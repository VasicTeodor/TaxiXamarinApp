using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;
using TaxiApp.Services.Interfaces;
using TaxiApp.Settings;
using TaxiApp.Settings.Interfaces;

namespace TaxiApp.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRequestService _requestService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IRuntimeContext _runtimeContext;

        public ProfileService(IRequestService requestService, IAuthenticationService authenticationService)
            : this(requestService, authenticationService, new RuntimeContext())
        { }

        public ProfileService(IRequestService requestService, IAuthenticationService authenticationService, IRuntimeContext runtimeContext)
        {
            _requestService = requestService;
            _authenticationService = authenticationService;
            _runtimeContext = runtimeContext;
        }

        public async Task<bool> CreateProfile(Customer profile)
        {
            UriBuilder builder = new UriBuilder(_runtimeContext.BaseEndpoint)
            {
                Path = "api/Register/RegisterAccount"
            };

            var message = await _requestService.PostAsync<Customer, LoginDto>(builder.Uri, profile);

            _runtimeContext.Token = message.AccessToken.ToString();
            _runtimeContext.UserId = message.User.Id;

            return await Task.FromResult(true);
        }

        public async Task<Customer> GetProfile(Guid id, string token)
        {
            UriBuilder builder = new UriBuilder(_runtimeContext.BaseEndpoint)
            {
                Path = "api/Customer/GetCustomer",
                Query = $"id={id}"
            };

             var message = await _requestService.GetAsync<Customer>(builder.Uri, token);

            return message;
        }

        public async Task<Customer> UpdateProfile(Guid id, Customer profile, string token)
        {
            UriBuilder builder = new UriBuilder(_runtimeContext.BaseEndpoint)
            {
                Path = "api/Customer/UpdateCustomer"
            };

            var message = await _requestService.PutAsync<Customer, Customer>(builder.Uri, profile, token);

            return message as Customer;
        }
    }
}
