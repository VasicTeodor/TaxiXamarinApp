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
    public class DriveServices : IDriveServices
    {
        private readonly IRequestService _requestService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IRuntimeContext _runtimeContext;

        public DriveServices(IRequestService requestService, IAuthenticationService authenticationService)
            : this(requestService, authenticationService, new RuntimeContext())
        { }

        public DriveServices(IRequestService requestService, IAuthenticationService authenticationService, IRuntimeContext runtimeContext)
        {
            _requestService = requestService;
            _authenticationService = authenticationService;
            _runtimeContext = runtimeContext;
        }

        public Task<bool> CreateDrive(string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditDrive(Guid id, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Drive>> GetAllDrives(Guid id, string token)
        {
            UriBuilder builder = new UriBuilder(_runtimeContext.BaseEndpoint)
            {
                Path = $"api/Drive/GetAllDrivesForId",
                Query = $"id={id}&role=Customer"
            };

            return await _requestService.GetAsync<IEnumerable<Drive>>(builder.Uri, token);
        }

        public async Task<Drive> GetDrive(Guid id, string token)
        {
            UriBuilder builder = new UriBuilder(_runtimeContext.BaseEndpoint)
            {
                Path = $"api/Drive/GetDrive?id={id}"
            };

            return await _requestService.GetAsync<Drive>(builder.Uri, token);
        }
    }
}
