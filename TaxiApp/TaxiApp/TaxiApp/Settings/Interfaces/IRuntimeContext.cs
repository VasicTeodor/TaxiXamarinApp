using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiApp.Settings.Interfaces
{
    public interface IRuntimeContext
    {
        string BaseEndpoint { get; set; }
        string Token { get; set; }
        Guid UserId { get; set; }

        void RemoveToken();
        void RemoveUserId();
    }
}
