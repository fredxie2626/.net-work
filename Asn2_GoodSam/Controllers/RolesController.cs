using Asn2_GoodSam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Asn2_GoodSam.Models.Client;

namespace Asn2_GoodSam.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RolesController : Controller
    {
        private ClientContext db = new ClientContext();
        // GET: Roles
        public ActionResult Index(Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            try
            {
                // TODO: Add insert logic here
                if (collection["RoleName"].Length > 0 && collection["RoleName"].Length < 20)
                {
                    context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                    {
                        Name = collection["RoleName"]
                    });
                    ViewBag.ResultMessage = "Role created successfully !";
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ResultMessage = "Role created failed. Role name length must between 1 and 20 !";
                    return View("Create");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(string roleName, Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role, Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            try
            {
                // TODO: Add update logic here
                context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(string RoleName, Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            var thisRole = context.Roles.Where(r => r.Name.Equals(RoleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            context.Roles.Remove(thisRole);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ManageUserRoles(Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            // prepopulat roles for the view dropdown
            var userList = context.Users.OrderBy(r => r.UserName).ToList().Select(rr => new SelectListItem { Value = rr.UserName.ToString(), Text = rr.UserName }).ToList();
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Users = userList;
            ViewBag.Roles = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string UserName, string RoleName, Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            if (RoleName == "Worker")
            {
                AssignedWorker assignedWorker = new AssignedWorker();
                assignedWorker.AssignedWorkerName = UserName;
                bool workerExists = db.AssignedWorker.Any(w => w.AssignedWorkerName.Equals(UserName));

                if (!workerExists)
                {
                    db.AssignedWorker.Add(assignedWorker);
                    db.SaveChanges();
                }

            }
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            um.AddToRole(user.Id, RoleName);

            ViewBag.ResultMessage = "Role created successfully !";

            // prepopulat roles for the view dropdown
            var userList = context.Users.OrderBy(r => r.UserName).ToList().Select(rr => new SelectListItem { Value = rr.UserName.ToString(), Text = rr.UserName }).ToList();
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Users = userList;
            ViewBag.Roles = list;

            return View("AssignRole");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName, Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            if (!string.IsNullOrWhiteSpace(UserName))
            {
                ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
                var account = new AccountController();

                ViewBag.RolesForThisUser = account.UserManager.GetRoles(user.Id);

                // prepopulat roles for the view dropdown
                var userList = context.Users.OrderBy(r => r.UserName).ToList().Select(rr => new SelectListItem { Value = rr.UserName.ToString(), Text = rr.UserName }).ToList();
                var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                ViewBag.Users = userList;
                ViewBag.Roles = list;
            }

            return View("ManageUserRoles");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string UserName, string RoleName, Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            var account = new AccountController();
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(UserName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (um.IsInRole(user.Id, RoleName))
            {
                um.RemoveFromRole(user.Id, RoleName);
                ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }

            if (RoleName == "Worker")
            {
                var assignedWorker = db.AssignedWorker.FirstOrDefault(s => s.AssignedWorkerName == UserName);
                if (assignedWorker != null)
                {
                    db.AssignedWorker.Remove(assignedWorker);
                    db.SaveChanges();
                }
            }

            // prepopulat roles for the view dropdown
            var userList = context.Users.OrderBy(r => r.UserName).ToList().Select(rr => new SelectListItem { Value = rr.UserName.ToString(), Text = rr.UserName }).ToList();
            var list = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Users = userList;
            ViewBag.Roles = list;

            return View("RemoveRole");
        }
    }
}
