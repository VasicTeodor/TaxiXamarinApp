using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiApp.Models
{
    public class CommentDto
    {
        public Guid driveId { get; set; }
        public Guid orderedBy { get; set; }
        public string text { get; set; }
        public int grade { get; set; }
    }
}