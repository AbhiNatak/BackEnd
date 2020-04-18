using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CusjoDataAccessLayer;
namespace CusJoRestAPI.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            IList<User> users = null;
            using (CusJoDBContext context = new CusJoDBContext())
            {
                context.Database.Connection.Open();
                users = context.Users.ToList();
            }
            if(users.Count == 0)
            {
                return NotFound();
            }
            return Ok(users);
        }


       [HttpGet]
        public IHttpActionResult GetUserByEmail(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            User user = null;
            using (CusJoDBContext context = new CusJoDBContext())
            {
                user = context.Users
                    .Where(u => u.UserEmail.ToString().Equals(id.ToString(), StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault<User>();    
            }

            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IHttpActionResult GetUserById(string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            User user = null;
            using (CusJoDBContext context = new CusJoDBContext())
            {
                user = context.Users
                    .Where(u => u.UserId.ToString().Equals(id.ToString(), StringComparison.OrdinalIgnoreCase))
                    .FirstOrDefault<User>();
            }

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/User/PostNewUser
        public IHttpActionResult PostNewUser(Models.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            try
            {
                using (CusJoDBContext context = new CusJoDBContext())
                {
                    context.Users.Add(new User()
                    {
                        UserFirstName = user.UserFirstName,
                        UserLastName = user.UserLastName,
                        UserEmail = user.UserEmail,
                        AccessLevel = 2,
                        IsVerified = 0,
                        Password = user.Password

                    });
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Ok();
        }

        // PUT: api/User/5
        public IHttpActionResult UpdateUser(Models.User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            using (CusJoDBContext context = new CusJoDBContext())
            {
                User existingUser = context.Users
                    .Where(u => u.UserId.ToString() == user.UserId)
                    .FirstOrDefault<User>();

                if (existingUser != null)
                {
                    existingUser.AccessLevel = user.AccessLevel;
                    context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();

        }

        [HttpPut]
        public IHttpActionResult VerifyUserById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }
            
            using (CusJoDBContext context = new CusJoDBContext())
            {
                User existingUser = context.Users
                    .Where(u => u.UserId == id)
                    .FirstOrDefault<User>();
                if (existingUser != null)
                {
                    existingUser.IsVerified = 1;
                    context.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }
    }
}
