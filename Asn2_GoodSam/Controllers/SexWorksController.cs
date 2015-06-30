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
    public class SexWorksController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: SexWorks
        public ActionResult Index()
        {
            return View(db.SexWork.ToList());
        }

        // GET: SexWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SexWork sexWork = db.SexWork.Find(id);
            if (sexWork == null)
            {
                return HttpNotFound();
            }
            return View(sexWork);
        }

        // GET: SexWorks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SexWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SexWorkId,SexWorkName")] SexWork sexWork)
        {
            if (ModelState.IsValid)
            {
                db.SexWork.Add(sexWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sexWork);
        }

        // GET: SexWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SexWork sexWork = db.SexWork.Find(id);
            if (sexWork == null)
            {
                return HttpNotFound();
            }
            return View(sexWork);
        }

        // POST: SexWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SexWorkId,SexWorkName")] SexWork sexWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sexWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sexWork);
        }

        // GET: SexWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SexWork sexWork = db.SexWork.Find(id);
            if (sexWork == null)
            {
                return HttpNotFound();
            }
            return View(sexWork);
        }

        // POST: SexWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SexWork sexWork = db.SexWork.Find(id);
            db.SexWork.Remove(sexWork);
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
