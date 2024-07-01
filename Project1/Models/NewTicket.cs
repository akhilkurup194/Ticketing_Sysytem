using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project1.Models
{
    public class NewTicket
    {
        [Key]
        [DisplayName("Ticket ID")]
        public string TicketId { get; set; }

        [DisplayName("Customer ID")]

        public string CustomerId { get; set; }

        [DisplayName("Create Date")]
        public string CreateDate { get; set; }

        [DisplayName("Ticket Type")]
        [Required(ErrorMessage = "Field is required...!!")]
        public string TicketType { get; set; }
        
        [DisplayName("Team")]
        [Required(ErrorMessage = "Field is required...!!")]
        public string Team { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage = "Field is required...!!")]
        public string Category { get; set; }

        [DisplayName("Priority")]
        [Required(ErrorMessage = "Field is required...!!")]
        public string Priority { get; set; }

        [DisplayName("Short Description")]
        [Required(ErrorMessage = "Field is required...!!")]
        public string StDescr{ get; set; }

        [DisplayName("Describe Your Issue")]
        [Required(ErrorMessage = "Field is required...!!")]
        public string Description { get; set; }

        [DisplayName("Assigned To")]

        public string AssignedTo { get; set; }

        public string Status { get; set; }
        public string SearchString { get; set; }
    }
}