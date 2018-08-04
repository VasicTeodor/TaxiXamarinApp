using Newtonsoft.Json.Linq;
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

        public async Task<bool> CreateDrive(string token, Drive drive)
        {
            UriBuilder builder = new UriBuilder(_runtimeContext.BaseEndpoint)
            {
                Path = "api/Customer/CreateNewDrive"
            };

            var message = await _requestService.PostAsync<Drive, Drive>(builder.Uri, drive, token);

            return await Task.FromResult(true);
        }

        public async Task<bool> QuitDrive(string token, Drive drive)
        {
            UriBuilder builder = new UriBuilder(_runtimeContext.BaseEndpoint)
            {
                Path = "api/Customer/CreateNewDrive"
            };

            QuitDrive quitDrive = new QuitDrive
            {
                quitId = drive.DriveId
            };

            var message = await _requestService.PostAsync<QuitDrive, Drive>(builder.Uri, quitDrive, token);

            return await Task.FromResult(true);
        }

        public async Task<bool> EditDrive(Guid id, string token, Drive drive)
        {
            UriBuilder builder = new UriBuilder(_runtimeContext.BaseEndpoint)
            {
                Path = "api/Customer/UpdateDrive"
            };

            var message = await _requestService.PutAsync<Drive, Drive>(builder.Uri, drive, token);

            return await Task.FromResult(true);
        }

        public async Task<bool> CommentDrive(Guid id, string token, CommentDto jObject)
        {
            UriBuilder builder = new UriBuilder(_runtimeContext.BaseEndpoint)
            {
                Path = "api/Customer/AddComment"
            };

            var message = await _requestService.PutAsync<CommentDto, Drive>(builder.Uri, jObject, token);

            return await Task.FromResult(true);
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
                Path = $"api/Drive/GetDrive",
                Query = $"id={id}"
            };

            return await _requestService.GetAsync<Drive>(builder.Uri, token);
        }
    }
}
