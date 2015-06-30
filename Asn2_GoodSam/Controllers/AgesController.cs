using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Asn2_GoodSam.Models.Client;

namespace Asn2_GoodSam.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AgesController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Ages
        public ActionResult Index()
        {
            return View(db.Age.ToList());
        }

        // GET: Ages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Age age = db.Age.Find(id);
            if (age == null)
            {
                return HttpNotFound();
            }
            return View(age);
        }

        // GET: Ages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgeId,AgeName")] Age age)
        {
            if (ModelState.IsValid)
            {
                db.Age.Add(age);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(age);
        }

        // GET: Ages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Age age = db.Age.Find(id);
            if (age == null)
            {
                return HttpNotFound();
            }
            return View(age);
        }

        // POST: Ages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgeId,AgeName")] Age age)
        {
            if (ModelState.IsValid)
            {
                db.Entry(age).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(age);
        }

        // GET: Ages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Age age = db.Age.Find(id);
            if (age == null)
            {
                return HttpNotFound();
            }
            return View(age);
        }

        // POST: Ages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Age age = db.Age.Find(id);
            db.Age.Remove(age);
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
    }
}
