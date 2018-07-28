using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaxiApp.Services.Interfaces
{
    public interface IDriveServices
    {
        Task<IEnumerable<Type>> GetAllDrives(Guid id, string token);
        Task GetDrive(Guid id, string token);
        Task<bool> CreateDrive(string token);
        Task<bool> EditPost(Guid id, string token);
        Task<bool> LikePost(Guid id, string token);
        Task<bool> DeletePost(Guid id, string token);
    }
}
