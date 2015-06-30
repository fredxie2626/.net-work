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
    public class VictimServicesAttendancesController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: VictimServicesAttendances
        public ActionResult Index()
        {
            return View(db.VictimServicesAttendance.ToList());
        }

        // GET: VictimServicesAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimServicesAttendance victimServicesAttendance = db.VictimServicesAttendance.Find(id);
            if (victimServicesAttendance == null)
            {
                return HttpNotFound();
            }
            return View(victimServicesAttendance);
        }

        // GET: VictimServicesAttendances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VictimServicesAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VictimServicesAttendanceId,VictimServicesAttendanceName")] VictimServicesAttendance victimServicesAttendance)
        {
            if (ModelState.IsValid)
            {
                db.VictimServicesAttendance.Add(victimServicesAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(victimServicesAttendance);
        }

        // GET: VictimServicesAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimServicesAttendance victimServicesAttendance = db.VictimServicesAttendance.Find(id);
            if (victimServicesAttendance == null)
            {
                return HttpNotFound();
            }
            return View(victimServicesAttendance);
        }

        // POST: VictimServicesAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VictimServicesAttendanceId,VictimServicesAttendanceName")] VictimServicesAttendance victimServicesAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victimServicesAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(victimServicesAttendance);
        }

        // GET: VictimServicesAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimServicesAttendance victimServicesAttendance = db.VictimServicesAttendance.Find(id);
            if (victimServicesAttendance == null)
            {
                return HttpNotFound();
            }
            return View(victimServicesAttendance);
        }

        // POST: VictimServicesAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VictimServicesAttendance victimServicesAttendance = db.VictimServicesAttendance.Find(id);
            db.VictimServicesAttendance.Remove(victimServicesAttendance);
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
