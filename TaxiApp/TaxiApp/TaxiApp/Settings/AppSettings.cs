using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiApp.Settings
{
    public static class AppSettings
    {
        private const string DefaultBaseEndpoint = "http://localhost:3577";
        private static ISettings Settings => CrossSettings.Current;

        // API Endpoints
        public static string BaseEndpoint
        {
            get => Settings.GetValueOrDefault(nameof(BaseEndpoint), DefaultBaseEndpoint);

            set => Settings.AddOrUpdateValue(nameof(BaseEndpoint), value);
        }

        public static string Token
        {
            get => Settings.GetValueOrDefault(nameof(Token), default(string));

            set => Settings.AddOrUpdateValue(nameof(Token), value);
        }
        

        public static Guid UserId
        {
            get => Settings.GetValueOrDefault(nameof(UserId), default(Guid));

            set => Settings.AddOrUpdateValue(nameof(UserId), value);
        }

        public static void RemoveUserId()
        {
            Settings.Remove(nameof(UserId));
        }

        public static void RemoveToken()
        {
            Settings.Remove(nameof(Token));
        }
    }
}
