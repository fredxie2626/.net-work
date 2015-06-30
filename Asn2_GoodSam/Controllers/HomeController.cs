using Asn2_GoodSam.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asn2_GoodSam.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            var allusers = db.Users.OrderBy(r => r.UserName).ToList().Select(rr => new SelectListItem { Value = rr.UserName.ToString(), Text = rr.UserName }).ToList();
            //var workers = allusers.Where(x => x.Equals("a720143e-25b2-47fc-a642-5487304d173a")).ToList();
            var workers = db.Users.ToList().Where(x => UserManager.IsInRole(x.Id, "Worker")).ToList(); 
            ViewBag.Workers = workers;

            return View();
        }


        public ActionResult ReportPage()
        {
            return Redirect("~/Report.html");
        }

    }
}