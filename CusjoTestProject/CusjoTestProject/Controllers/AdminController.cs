using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using CusjoTestProject.Models;
using System.Threading.Tasks;

namespace CusjoTestProject.Controllers
{
    public class AdminController : Controller
    {
        Helper.UserHelper _helper = null;
        public AdminController()
        {
            _helper = new Helper.UserHelper();
        }
       
        public async Task<ActionResult> List()
        {
            return View(await _helper.GetAllUsers());
        }

        // GET: Admin/UpdateAccess/5
        public async Task<ActionResult> UpdateAccess(int Id)
        {
            return View(await _helper.GetUserById(Id));
        }

        [HttpPost]
        public async Task<ActionResult> UpdateAccess(Models.User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            if (await _helper.UpdateUser(user))
            {
                return View("Success");
            }

            return View("Error");  
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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
