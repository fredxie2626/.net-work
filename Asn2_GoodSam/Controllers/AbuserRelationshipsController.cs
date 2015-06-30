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
    public class AbuserRelationshipsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: AbuserRelationships
        public ActionResult Index()
        {
            return View(db.AbuserRelationship.ToList());
        }

        // GET: AbuserRelationships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbuserRelationship abuserRelationship = db.AbuserRelationship.Find(id);
            if (abuserRelationship == null)
            {
                return HttpNotFound();
            }
            return View(abuserRelationship);
        }

        // GET: AbuserRelationships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AbuserRelationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AbuserRelationshipId,AbuserRelationshipName")] AbuserRelationship abuserRelationship)
        {
            if (ModelState.IsValid)
            {
                db.AbuserRelationship.Add(abuserRelationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abuserRelationship);
        }

        // GET: AbuserRelationships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbuserRelationship abuserRelationship = db.AbuserRelationship.Find(id);
            if (abuserRelationship == null)
            {
                return HttpNotFound();
            }
            return View(abuserRelationship);
        }

        // POST: AbuserRelationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AbuserRelationshipId,AbuserRelationshipName")] AbuserRelationship abuserRelationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abuserRelationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abuserRelationship);
        }

        // GET: AbuserRelationships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AbuserRelationship abuserRelationship = db.AbuserRelationship.Find(id);
            if (abuserRelationship == null)
            {
                return HttpNotFound();
            }
            return View(abuserRelationship);
        }

        // POST: AbuserRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AbuserRelationship abuserRelationship = db.AbuserRelationship.Find(id);
            db.AbuserRelationship.Remove(abuserRelationship);
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
