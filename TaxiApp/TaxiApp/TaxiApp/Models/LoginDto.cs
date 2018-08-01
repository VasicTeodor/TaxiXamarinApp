using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiApp.Models
{
    public class LoginDto
    {
        public string AccessToken { get; set; }
        public Customer User { get; set; }
    }
}