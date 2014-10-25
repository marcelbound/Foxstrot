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
        public ActionResult Details()
        {
            throw new NotImplementedException();   // return a razor with a view model that shows the details of the user
        }

        public ActionResult Search(string filter)
        {
            var users = db.Profiles
                          .Where(p => p.FirstName.Contains(filter))
                          .Select(p => new EmployeeViewModel
                                           {
                                               Id = p.Id,
                                               FullName = p.FullName,
                                               Email = p.Email
                                           });

            return Json(users);
        }
    }
}