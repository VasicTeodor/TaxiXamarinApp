using System;
using System.Collections.Generic;
using System.Text;
using TaxiApp.Settings.Interfaces;

namespace TaxiApp.Settings
{
    public class RuntimeContext : IRuntimeContext
    {
        public string BaseEndpoint
        {
            get => AppSettings.BaseEndpoint;

            set => AppSettings.BaseEndpoint = value;
        }

        public string Token
        {
            get => AppSettings.Token;

            set => AppSettings.Token = value;
        }

        public Guid UserId
        {
            get => AppSettings.UserId;

            set => AppSettings.UserId = value;
        }

        public void RemoveUserId()
        {
            AppSettings.RemoveUserId();
        }

        public void RemoveToken()
        {
            AppSettings.RemoveToken();
        }
    }
}
