using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asn2_GoodSam.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Asn2_GoodSam.Models.TempPwd;

namespace Asn2_GoodSam.Controllers
{
    [Authorize(Roles="Administrator")]  
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private TempPwdContext dbTemp = new TempPwdContext();

        // GET: ApplicationUsers
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,PasswordHash,PhoneNumber,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(applicationUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(applicationUser);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(applicationUser);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Disable user by removing the password of him/her.
        public ActionResult DisableUser(string id, Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            var thisUser = context.Users.Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            Asn2_GoodSam.Models.TempPwd.TempPwdContext cxt = new Models.TempPwd.TempPwdContext();
            cxt.TempPwd.Add(
                  new TempPwd
                  {
                      Id = thisUser.Id,
                      Password = thisUser.PasswordHash
                  }
          );
            cxt.SaveChanges();

            thisUser.PasswordHash = null;
            thisUser.LockoutEnabled = true;
            //context.Users.Remove(thisUser);
            thisUser.PhoneNumberConfirmed = true;
            context.Entry(thisUser).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Enable user by adding the hashed password of him/her(P@$$w0rd).
        public ActionResult EnableUser(string id, Asn2_GoodSam.Models.ApplicationDbContext context)
        {
            var thisUser = context.Users.Where(r => r.Id.Equals(id, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            Asn2_GoodSam.Models.TempPwd.TempPwdContext cxt = new Models.TempPwd.TempPwdContext();
            var tempPwd = cxt.TempPwd.Where(r => r.Id.Equals(thisUser.Id, StringComparison.CurrentCulture)).FirstOrDefault();

            thisUser.PasswordHash = tempPwd.Password;
            thisUser.LockoutEnabled = false;
            //context.Users.Remove(thisUser);
            thisUser.PhoneNumberConfirmed = false;
            context.Entry(thisUser).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            TempPwd pwd = dbTemp.TempPwd.Find(tempPwd.Id);
            dbTemp.TempPwd.Remove(pwd);
            dbTemp.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
