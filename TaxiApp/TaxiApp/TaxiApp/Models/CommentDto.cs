using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiApp.Models
{
    public class CommentDto
    {
        public Guid CommentId { get; set; }
        public Guid CreatedById { get; set; }
        public Guid DriveId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Grade { get; set; }
    }
}