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
    public class FiscalYearsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: FiscalYears
        public ActionResult Index()
        {
            return View(db.FiscalYear.ToList());
        }

        // GET: FiscalYears/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYear fiscalYear = db.FiscalYear.Find(id);
            if (fiscalYear == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYear);
        }

        // GET: FiscalYears/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FiscalYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FiscalYearId")] FiscalYear fiscalYear)
        {
            if (ModelState.IsValid)
            {
                db.FiscalYear.Add(fiscalYear);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fiscalYear);
        }

        // GET: FiscalYears/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYear fiscalYear = db.FiscalYear.Find(id);
            if (fiscalYear == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYear);
        }

        // POST: FiscalYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FiscalYearId")] FiscalYear fiscalYear)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fiscalYear).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fiscalYear);
        }

        // GET: FiscalYears/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FiscalYear fiscalYear = db.FiscalYear.Find(id);
            if (fiscalYear == null)
            {
                return HttpNotFound();
            }
            return View(fiscalYear);
        }

        // POST: FiscalYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FiscalYear fiscalYear = db.FiscalYear.Find(id);
            db.FiscalYear.Remove(fiscalYear);
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
