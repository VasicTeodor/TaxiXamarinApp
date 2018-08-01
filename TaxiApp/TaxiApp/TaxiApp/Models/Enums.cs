using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiApp.Models
{
    public class Enums
    {
        public enum Roles : int
        {
            Driver = 0,
            Customer,
            Dispatcher
        }

        public enum CarTypes : int
        {
            Bez_Naznake = 0,
            Car = 1,
            Kombi = 2
        }

        public enum Status : int
        {
            Created = 0,
            Canceled,
            Formated,
            Processed,
            Accepted,
            Successful,
            Unsuccessful
        }

        public enum Genders : int
        {
            Male = 0,
            Female
        }
    }
}