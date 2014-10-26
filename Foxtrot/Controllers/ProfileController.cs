using Foxtrot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foxtrot.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext db;

        public ProfileController()
        {
            this.db = ApplicationDbContext.Create();
        }
        public ActionResult Details(Guid id)
        {
            var profile = db.Profiles.SingleOrDefault(p => p.Id == id);

            return View(profile);
        }

        public ActionResult Edit(Guid id)
        {
            //var profile = db.Profiles.SingleOrDefault(p => p.Id == id);

            throw new NotImplementedException();

        }

        public ActionResult Search(string filter)
        {
            var users = db.Profiles
                          .Where(p => p.FirstName.Contains(filter))
                          .Select(p => new EmployeeViewModel
                                           {
                                               Id = p.Id,
                                               FullName = p.FirstName + " " + p.LastName,
                                               Email = p.Email
                                           });

            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}