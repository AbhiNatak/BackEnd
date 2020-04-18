using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CusjoInterface
{
    public interface IUser
    {
        string UserId { get; set; }
        string UserFirstName { get; set; }
        string UserLastName { get; set; }
        string UserEmail { get; set; }
        string Password { get; set; }
        int AccessLevel { get; set; }
        bool IsVerifiedUser { get; set; }
    }
}
