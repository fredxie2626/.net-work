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
    public class CrisesController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Crises
        public ActionResult Index()
        {
            return View(db.Crisis.ToList());
        }

        // GET: Crises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crisis crisis = db.Crisis.Find(id);
            if (crisis == null)
            {
                return HttpNotFound();
            }
            return View(crisis);
        }

        // GET: Crises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CrisisId,CrisisName")] Crisis crisis)
        {
            if (ModelState.IsValid)
            {
                db.Crisis.Add(crisis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crisis);
        }

        // GET: Crises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crisis crisis = db.Crisis.Find(id);
            if (crisis == null)
            {
                return HttpNotFound();
            }
            return View(crisis);
        }

        // POST: Crises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CrisisId,CrisisName")] Crisis crisis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crisis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crisis);
        }

        // GET: Crises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crisis crisis = db.Crisis.Find(id);
            if (crisis == null)
            {
                return HttpNotFound();
            }
            return View(crisis);
        }

        // POST: Crises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crisis crisis = db.Crisis.Find(id);
            db.Crisis.Remove(crisis);
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
