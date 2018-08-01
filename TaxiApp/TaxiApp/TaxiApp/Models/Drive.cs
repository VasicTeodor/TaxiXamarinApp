using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xamarin.Forms;

namespace TaxiApp.Models
{
    public class Drive : BindableObject
    {
        public Guid DriveId { get; set; }
        public DateTime Date { get; set; }
        public Enums.CarTypes CarType { get; set; }
        public Customer OrderedBy { get; set; }
        public Location Destination { get; set; }
        public Location Address { get; set; }
        public Dispatcher ApprovedBy { get; set; }
        public Driver DrivedBy { get; set; }
        public double Price { get; set; }
        public Comment Comments { get; set; }
        public Enums.Status State { get; set; }
    }
}