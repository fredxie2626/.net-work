﻿using System;
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
    public class PoliceAttendancesController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: PoliceAttendances
        public ActionResult Index()
        {
            return View(db.PoliceAttendance.ToList());
        }

        // GET: PoliceAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceAttendance policeAttendance = db.PoliceAttendance.Find(id);
            if (policeAttendance == null)
            {
                return HttpNotFound();
            }
            return View(policeAttendance);
        }

        // GET: PoliceAttendances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoliceAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PoliceAttendanceId,PoliceAttendanceName")] PoliceAttendance policeAttendance)
        {
            if (ModelState.IsValid)
            {
                db.PoliceAttendance.Add(policeAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(policeAttendance);
        }

        // GET: PoliceAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceAttendance policeAttendance = db.PoliceAttendance.Find(id);
            if (policeAttendance == null)
            {
                return HttpNotFound();
            }
            return View(policeAttendance);
        }

        // POST: PoliceAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PoliceAttendanceId,PoliceAttendanceName")] PoliceAttendance policeAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policeAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(policeAttendance);
        }

        // GET: PoliceAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoliceAttendance policeAttendance = db.PoliceAttendance.Find(id);
            if (policeAttendance == null)
            {
                return HttpNotFound();
            }
            return View(policeAttendance);
        }

        // POST: PoliceAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PoliceAttendance policeAttendance = db.PoliceAttendance.Find(id);
            db.PoliceAttendance.Remove(policeAttendance);
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
