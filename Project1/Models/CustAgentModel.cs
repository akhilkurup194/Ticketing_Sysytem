using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Project1.Models
{
    public class CustAgentModel
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Customer ID")]
        public string CustomerId { get; set; }

        [DisplayName("Agent ID")]
        public string AgentId { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Field is required...!!")]

        public string Firstname { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Field is required...!!")]

        public string Lastname { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        [Required(ErrorMessage = "Enter the Date Of Birth")]
        [Project1.Models.Validation.ValidBirthDate(ErrorMessage = "Birth Date can not be greater than current date")]

        public DateTime DateOfBirth { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Field is required...!!")]

        public string Gender { get; set; }

        [DisplayName("Mobile Number")]
        [Required(ErrorMessage = "Field is required...!!")]

        public string Phonenumber { get; set; }

        [DisplayName("Email ID")]
        [Required(ErrorMessage = "Field is required...!!")]

        public string EmailID { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Field is required...!!")]

        public string Address { get; set; }
        
        [DisplayName("Username")]
        [Required(ErrorMessage = "Field is required...!!")]

        public string Username { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Field is required...!!")]

        public string Password { get; set; }

        public List<CustAgentModel> ShowallCustomer { get; set; }

    }
}