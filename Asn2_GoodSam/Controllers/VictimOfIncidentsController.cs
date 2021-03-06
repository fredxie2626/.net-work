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
    public class VictimOfIncidentsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: VictimOfIncidents
        public ActionResult Index()
        {
            return View(db.VictimOfIncident.ToList());
        }

        // GET: VictimOfIncidents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimOfIncident victimOfIncident = db.VictimOfIncident.Find(id);
            if (victimOfIncident == null)
            {
                return HttpNotFound();
            }
            return View(victimOfIncident);
        }

        // GET: VictimOfIncidents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VictimOfIncidents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VictimOfIncidentId,VictimOfIncidentName")] VictimOfIncident victimOfIncident)
        {
            if (ModelState.IsValid)
            {
                db.VictimOfIncident.Add(victimOfIncident);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(victimOfIncident);
        }

        // GET: VictimOfIncidents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimOfIncident victimOfIncident = db.VictimOfIncident.Find(id);
            if (victimOfIncident == null)
            {
                return HttpNotFound();
            }
            return View(victimOfIncident);
        }

        // POST: VictimOfIncidents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VictimOfIncidentId,VictimOfIncidentName")] VictimOfIncident victimOfIncident)
        {
            if (ModelState.IsValid)
            {
                db.Entry(victimOfIncident).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(victimOfIncident);
        }

        // GET: VictimOfIncidents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VictimOfIncident victimOfIncident = db.VictimOfIncident.Find(id);
            if (victimOfIncident == null)
            {
                return HttpNotFound();
            }
            return View(victimOfIncident);
        }

        // POST: VictimOfIncidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VictimOfIncident victimOfIncident = db.VictimOfIncident.Find(id);
            db.VictimOfIncident.Remove(victimOfIncident);
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
