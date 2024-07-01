using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class ChangeStatus
    {
        public string TicketId { get; set; }
        public string CustomerId { get; set; }

        public string StDescr { get; set; }
        public string Description { get; set; }

        public string AssignedTo { get; set; }

        public string Status { get; set; }
    }
}