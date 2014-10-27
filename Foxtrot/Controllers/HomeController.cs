using Foxtrot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foxtrot.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db;

        public HomeController()
        {
            db = ApplicationDbContext.Create();
        }

        public ActionResult Index()
        {
            
            if (Request.IsAuthenticated)
            {
                var user = db.Profiles.SingleOrDefault(u => u.Email == HttpContext.User.Identity.Name);
                
                ViewData["ViewerIsManager"] = (user.Class == Core.EmployeeClass.Management);

                if (user.Class == Core.EmployeeClass.Management)
                    return View();
                else
                    return RedirectToAction("Details", "Profile", new { id = user.Id });
            }

            return RedirectToAction("Login", "Account");
        }
    }
}