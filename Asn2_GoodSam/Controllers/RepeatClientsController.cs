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
    public class RepeatClientsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: RepeatClients
        public ActionResult Index()
        {
            return View(db.RepeatClient.ToList());
        }

        // GET: RepeatClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepeatClient repeatClient = db.RepeatClient.Find(id);
            if (repeatClient == null)
            {
                return HttpNotFound();
            }
            return View(repeatClient);
        }

        // GET: RepeatClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RepeatClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RepeatClientId,RepeatClientName")] RepeatClient repeatClient)
        {
            if (ModelState.IsValid)
            {
                db.RepeatClient.Add(repeatClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(repeatClient);
        }

        // GET: RepeatClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepeatClient repeatClient = db.RepeatClient.Find(id);
            if (repeatClient == null)
            {
                return HttpNotFound();
            }
            return View(repeatClient);
        }

        // POST: RepeatClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepeatClientId,RepeatClientName")] RepeatClient repeatClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repeatClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repeatClient);
        }

        // GET: RepeatClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepeatClient repeatClient = db.RepeatClient.Find(id);
            if (repeatClient == null)
            {
                return HttpNotFound();
            }
            return View(repeatClient);
        }

        // POST: RepeatClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepeatClient repeatClient = db.RepeatClient.Find(id);
            db.RepeatClient.Remove(repeatClient);
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
