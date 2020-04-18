using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CusjoTestProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        Helper.UserHelper _helper = null;
        public LoginController()
        {
            _helper = new Helper.UserHelper();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Models.Login login)
        {
            Models.User user = await _helper.GetUserByEmail(login.UserEmail);

            if (user != null)
            {
                if (user.Password.Trim().Equals(login.Passward))
                {
                    Session["UserAccessLevel"] = user.AccessLevel.ToString().Trim();
                    Session["UserName"] = $"{user.UserFirstName.Trim()} {user.UserLastName.Trim()}";
                    Session["LoggedIn"] = 1;
                    return RedirectToAction("Details", user);
                }
                else
                {
                    return View("InValidPassword");
                }
            }
            else
            {
                return View("Error");
            }
        }

        // GET: Login/Details/5
        public ActionResult Details(Models.User user)
        {
            return View(user);
        }

        public async Task<ActionResult> VerifyEmail(int Id)
        {
            if (await _helper.VerifyUserById(Id))
            {
                return View("ThankYou");
            }
            return View("Error");
        }

        public ActionResult Logout()
        {
            Session["UserAccessLevel"] = 2;
            Session["LoggedIn"] = 0;
            Session["UserName"] = String.Empty;
            return View("Login");
        }
    }
}
