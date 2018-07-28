using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Services.Interfaces;

namespace TaxiApp.Services
{
    public class RequestService : IRequestService
    {
        public Task<TResult> DeleteAsync<TRequest, TResult>(Uri uri, TRequest data, string token = "")
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetAsync<TResult>(Uri uri, string token = "")
        {
            throw new NotImplementedException();
        }

        public Task<TResult> PostAsync<TRequest, TResult>(Uri uri, TRequest data, string token = "")
        {
            throw new NotImplementedException();
        }

        public Task<TResult> PutAsync<TRequest, TResult>(Uri uri, TRequest data, string token = "")
        {
            throw new NotImplementedException();
        }
    }
}
