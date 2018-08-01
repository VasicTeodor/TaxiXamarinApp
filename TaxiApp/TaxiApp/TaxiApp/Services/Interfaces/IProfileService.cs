using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;

namespace TaxiApp.Services.Interfaces
{
    public interface IProfileService
    {
        Task GetProfile(Guid id, string token);
        Task<bool> CreateProfile(Customer profile);
    }
}
