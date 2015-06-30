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
    public class AssignedWorkersController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: AssignedWorkers
        public ActionResult Index()
        {
            return View(db.AssignedWorker.ToList());
        }

        // GET: AssignedWorkers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedWorker assignedWorker = db.AssignedWorker.Find(id);
            if (assignedWorker == null)
            {
                return HttpNotFound();
            }
            return View(assignedWorker);
        }

        // GET: AssignedWorkers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssignedWorkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignedWorkerId,AssignedWorkerName")] AssignedWorker assignedWorker)
        {
            if (ModelState.IsValid)
            {
                db.AssignedWorker.Add(assignedWorker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assignedWorker);
        }

        // GET: AssignedWorkers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedWorker assignedWorker = db.AssignedWorker.Find(id);
            if (assignedWorker == null)
            {
                return HttpNotFound();
            }
            return View(assignedWorker);
        }

        // POST: AssignedWorkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignedWorkerId,AssignedWorkerName")] AssignedWorker assignedWorker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignedWorker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignedWorker);
        }

        // GET: AssignedWorkers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignedWorker assignedWorker = db.AssignedWorker.Find(id);
            if (assignedWorker == null)
            {
                return HttpNotFound();
            }
            return View(assignedWorker);
        }

        // POST: AssignedWorkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignedWorker assignedWorker = db.AssignedWorker.Find(id);
            db.AssignedWorker.Remove(assignedWorker);
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
