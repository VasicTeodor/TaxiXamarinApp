using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Services.Interfaces
{
    public interface IRequestService
    {
        Task<TResult> GetAsync<TResult>(Uri uri, string token = "");
        Task<TResult> PostAsync<TRequest, TResult>(Uri uri, TRequest data, string token = "");
        Task<TResult> PutAsync<TRequest, TResult>(Uri uri, TRequest data, string token = "");
        Task<TResult> DeleteAsync<TRequest, TResult>(Uri uri, TRequest data, string token = "");
    }
}
