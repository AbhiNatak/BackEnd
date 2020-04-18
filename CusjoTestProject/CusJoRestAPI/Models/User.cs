using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CusJoRestAPI.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public int AccessLevel { get; set; }
        public int IsVerifiedUser { get; set; }
    }
}