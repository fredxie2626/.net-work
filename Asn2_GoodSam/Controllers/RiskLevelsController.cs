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
    public class RiskLevelsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: RiskLevels
        public ActionResult Index()
        {
            return View(db.RiskLevel.ToList());
        }

        // GET: RiskLevels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskLevel riskLevel = db.RiskLevel.Find(id);
            if (riskLevel == null)
            {
                return HttpNotFound();
            }
            return View(riskLevel);
        }

        // GET: RiskLevels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiskLevels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RiskLevelId,RiskLevelName")] RiskLevel riskLevel)
        {
            if (ModelState.IsValid)
            {
                db.RiskLevel.Add(riskLevel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(riskLevel);
        }

        // GET: RiskLevels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskLevel riskLevel = db.RiskLevel.Find(id);
            if (riskLevel == null)
            {
                return HttpNotFound();
            }
            return View(riskLevel);
        }

        // POST: RiskLevels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RiskLevelId,RiskLevelName")] RiskLevel riskLevel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskLevel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riskLevel);
        }

        // GET: RiskLevels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskLevel riskLevel = db.RiskLevel.Find(id);
            if (riskLevel == null)
            {
                return HttpNotFound();
            }
            return View(riskLevel);
        }

        // POST: RiskLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RiskLevel riskLevel = db.RiskLevel.Find(id);
            db.RiskLevel.Remove(riskLevel);
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
