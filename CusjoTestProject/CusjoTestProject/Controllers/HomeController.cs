using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CusjoTestProject.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            if(Session["UserAccessLevel"] == null)
            {
                Session["UserAccessLevel"] = 2;
            }
            if (Session["LoggedIn"] == null)
            {
                Session["LoggedIn"] = 0;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Notice()
        {
            ViewBag.Message = "Your Notice page.";

            return View();
        }
        public ActionResult Policy()
        {
            ViewBag.Message = "Your Policy page.";

            return View();
        }
        public ActionResult Legal()
        {
            ViewBag.Message = "Your Legal page.";

            return View();
        }
    }
}