using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CusjoTestProject.Models
{
    public class User
    {
        [Display(Name = "User Id")]
        public string UserId { get; set; }

        [Display(Name = "User's First Name")]
        public string UserFirstName { get; set; }

        [Display(Name = "User's Last Name")]
        public string UserLastName { get; set; }

        [Display(Name = "Email")]
        public string UserEmail { get; set; }
        public string Password { get; set; }

        [Display(Name = "Access Level")]
        public int  AccessLevel { get; set; }
        [Display(Name = "User Status")]
        public int IsVerifiedUser { get; set; }
    }
}