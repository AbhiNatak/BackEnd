using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CusjoTestProject.Controllers
{
    public class RegisterationController : Controller
    {
        Helper.UserHelper _helper = null;
        public RegisterationController()
        {
            _helper = new Helper.UserHelper();
        }
        // GET: Registeration
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Models.User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            if(await _helper.CreateUser(user))
            {
                return View("Success");
            }
            return View("Error");
        }

        // GET: Registeration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Registeration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registeration/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registeration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registeration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registeration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registeration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
