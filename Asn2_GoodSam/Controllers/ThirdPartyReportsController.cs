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
    public class ThirdPartyReportsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: ThirdPartyReports
        public ActionResult Index()
        {
            return View(db.ThirdPartyReport.ToList());
        }

        // GET: ThirdPartyReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThirdPartyReport thirdPartyReport = db.ThirdPartyReport.Find(id);
            if (thirdPartyReport == null)
            {
                return HttpNotFound();
            }
            return View(thirdPartyReport);
        }

        // GET: ThirdPartyReports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ThirdPartyReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ThirdPartyReportId,ThirdPartyReportName")] ThirdPartyReport thirdPartyReport)
        {
            if (ModelState.IsValid)
            {
                db.ThirdPartyReport.Add(thirdPartyReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thirdPartyReport);
        }

        // GET: ThirdPartyReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThirdPartyReport thirdPartyReport = db.ThirdPartyReport.Find(id);
            if (thirdPartyReport == null)
            {
                return HttpNotFound();
            }
            return View(thirdPartyReport);
        }

        // POST: ThirdPartyReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ThirdPartyReportId,ThirdPartyReportName")] ThirdPartyReport thirdPartyReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thirdPartyReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thirdPartyReport);
        }

        // GET: ThirdPartyReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThirdPartyReport thirdPartyReport = db.ThirdPartyReport.Find(id);
            if (thirdPartyReport == null)
            {
                return HttpNotFound();
            }
            return View(thirdPartyReport);
        }

        // POST: ThirdPartyReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThirdPartyReport thirdPartyReport = db.ThirdPartyReport.Find(id);
            db.ThirdPartyReport.Remove(thirdPartyReport);
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
