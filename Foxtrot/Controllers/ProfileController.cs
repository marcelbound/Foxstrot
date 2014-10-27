using Foxtrot.Core;
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
            var profile = db.Profiles
                                .SingleOrDefault(p => p.Id == id);

            var viewData = new EmployeeViewModel
                                {
                                    Id = profile.Id,
                                    Class = profile.Class,
                                    Email = profile.Email,
                                    FirstName = profile.FirstName,
                                    LastName = profile.LastName,
                                    Location = profile.Location,
                                    Title = profile.Title
                                };

            return View(viewData);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeViewModel model)
        {
            var profile = db.Profiles.SingleOrDefault(p => p.Id == model.Id);

            db.Profiles.Attach(profile);

            profile.FirstName = model.FirstName;
            profile.LastName = model.LastName;
            profile.Location = model.Location;
            profile.Title = model.Title;
            profile.Class = model.Class;
            profile.Email = model.Email;

            db.Entry<EmployeeProfile>(profile).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("details", new { id = model.Id });

        }

        public ActionResult Search(string filter)
        {
            var users = db.Profiles
                          .Where(p => p.FirstName.Contains(filter) || p.LastName.Contains(filter))
                          .Select(p => new EmployeeSelectViewModel
                                           {
                                               Id = p.Id,
                                               FullName = p.FirstName + " " + p.LastName,
                                               Email = p.Email
                                           });

            return Json(users, JsonRequestBehavior.AllowGet);
        }
    }
}