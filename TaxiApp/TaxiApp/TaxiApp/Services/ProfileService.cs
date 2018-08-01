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

        public Task GetProfile(Guid id, string token)
        {
            throw new NotImplementedException();
        }
    }
}
