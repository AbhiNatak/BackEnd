using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CusjoTestProject.Models
{
    public class Registration
    {
        [Required]
        [Display(Name = "First Name")]
        public string UserFirstName { get; set; }

        [Display(Name = "Last Name")]
        public string UserLastName { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}