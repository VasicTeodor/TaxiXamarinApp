using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> Login(string userName, string password);
        Task<bool> Logout();
    }
}
