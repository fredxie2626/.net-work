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
    public class EthnicitiesController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Ethnicities
        public ActionResult Index()
        {
            return View(db.Ethnicity.ToList());
        }

        // GET: Ethnicities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ethnicity ethnicity = db.Ethnicity.Find(id);
            if (ethnicity == null)
            {
                return HttpNotFound();
            }
            return View(ethnicity);
        }

        // GET: Ethnicities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ethnicities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EthnicityId,EthnicityName")] Ethnicity ethnicity)
        {
            if (ModelState.IsValid)
            {
                db.Ethnicity.Add(ethnicity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ethnicity);
        }

        // GET: Ethnicities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ethnicity ethnicity = db.Ethnicity.Find(id);
            if (ethnicity == null)
            {
                return HttpNotFound();
            }
            return View(ethnicity);
        }

        // POST: Ethnicities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EthnicityId,EthnicityName")] Ethnicity ethnicity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ethnicity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ethnicity);
        }

        // GET: Ethnicities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ethnicity ethnicity = db.Ethnicity.Find(id);
            if (ethnicity == null)
            {
                return HttpNotFound();
            }
            return View(ethnicity);
        }

        // POST: Ethnicities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ethnicity ethnicity = db.Ethnicity.Find(id);
            db.Ethnicity.Remove(ethnicity);
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
