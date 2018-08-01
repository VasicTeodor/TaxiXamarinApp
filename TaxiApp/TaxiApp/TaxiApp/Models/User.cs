using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiApp.Models
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Jmbg { get; set; }
        public string Phone { get; set; }
        public bool IsBanned { get; set; }
        public string Email { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Genders Gender { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Enums.Roles Role { get; set; }
        public List<Drive> Drives { get; set; }
    }
}