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
    public class BadDateReportsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: BadDateReports
        public ActionResult Index()
        {
            return View(db.BadDateReport.ToList());
        }

        // GET: BadDateReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BadDateReport badDateReport = db.BadDateReport.Find(id);
            if (badDateReport == null)
            {
                return HttpNotFound();
            }
            return View(badDateReport);
        }

        // GET: BadDateReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BadDateReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BadDateReportId,BadDateReportName")] BadDateReport badDateReport)
        {
            if (ModelState.IsValid)
            {
                db.BadDateReport.Add(badDateReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(badDateReport);
        }

        // GET: BadDateReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BadDateReport badDateReport = db.BadDateReport.Find(id);
            if (badDateReport == null)
            {
                return HttpNotFound();
            }
            return View(badDateReport);
        }

        // POST: BadDateReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BadDateReportId,BadDateReportName")] BadDateReport badDateReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(badDateReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(badDateReport);
        }

        // GET: BadDateReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BadDateReport badDateReport = db.BadDateReport.Find(id);
            if (badDateReport == null)
            {
                return HttpNotFound();
            }
            return View(badDateReport);
        }

        // POST: BadDateReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BadDateReport badDateReport = db.BadDateReport.Find(id);
            db.BadDateReport.Remove(badDateReport);
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
