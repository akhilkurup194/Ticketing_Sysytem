using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Project1.Models
{
    public class Loginclass
    {
        [Required(ErrorMessage = " Username is required")]

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = " Password is required")]

        [Display(Name = "Password")]
        public string Password { get; set; }
        public string CustomerId { get; set; }
    }
}