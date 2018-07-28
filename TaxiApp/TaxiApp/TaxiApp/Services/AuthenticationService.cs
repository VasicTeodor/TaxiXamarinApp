using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Services.Interfaces;
using TaxiApp.Settings;
using TaxiApp.Settings.Interfaces;

namespace TaxiApp.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRequestService _requestService;
        private readonly IRuntimeContext _runtimeContext;

        public AuthenticationService(IRequestService requestService)
            : this(requestService, new RuntimeContext())
        { }

        public AuthenticationService(IRequestService requestService, IRuntimeContext runtimeContext)
        {
            _requestService = requestService;
            _runtimeContext = runtimeContext;
        }
        public Task<bool> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Logout()
        {
            _runtimeContext.RemoveToken();
            _runtimeContext.RemoveUserId();
            return Task.FromResult(true);
        }
    }
}
