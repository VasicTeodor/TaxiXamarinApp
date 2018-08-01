using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiApp.Models
{
    public class DriveDto
    {
        public Guid DriveId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid DispatcherId { get; set; }
        public Guid DriverId { get; set; }
        public Guid CommentId { get; set; }
        public DateTime Date { get; set; }
        public Enums.CarTypes CarType { get; set; }
        public Location Destination { get; set; }
        public Location Address { get; set; }
        public double Price { get; set; }
        public Enums.Status State { get; set; }
    }
}