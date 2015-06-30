using Asn2_GoodSam.Models.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asn2_GoodSam.Controllers
{
    public class ReportController : Controller
    {
        private ClientContext db = new ClientContext();
        // GET: Report
        public ActionResult Index()
        {
            var AssignedWorkersQuery = from d in db.AssignedWorker
                                       orderby d.AssignedWorkerName
                                       select d;
            ViewBag.AssignedWorkerId = new SelectList(AssignedWorkersQuery, "AssignedWorkerId", "AssignedWorkerName");

            var StatusOfFilesQuery = from d in db.StatusOfFile
                                     orderby d.StatusOfFileName
                                     select d;
            ViewBag.StatusOfFileId = new SelectList(StatusOfFilesQuery, "StatusOfFileId", "StatusOfFileName");

            //var selectedId = AssignedWorkerId;

            //return RedirectToAction("Report", "Home", new { Id = selectedId });

            return View();
        }

        // GET: ClientsCrud
        public ActionResult Report(int AssignedWorkerId, int StatusOfFileId)
        {
            ViewBag.WorkerName = db.AssignedWorker.Where(w => w.AssignedWorkerId == AssignedWorkerId).Select(w => w.AssignedWorkerName).Single();
            ViewBag.StatusSelected = db.StatusOfFile.Where(s => s.StatusOfFileId == StatusOfFileId).Select(s => s.StatusOfFileName).Single();

            ViewBag.SelectedCount = db.Clients.Count(e => e.AssignedWorkerId == AssignedWorkerId && e.StatusOfFileId == StatusOfFileId);
            ViewBag.TotalCount = db.Clients.Count(e => e.AssignedWorkerId == AssignedWorkerId);
            ViewBag.OpenCount = db.Clients.Count(e => e.AssignedWorkerId == AssignedWorkerId && e.StatusOfFileId == 1);
            ViewBag.ReopenedCount = db.Clients.Count(e => e.AssignedWorkerId == AssignedWorkerId && e.StatusOfFileId == 2);
            ViewBag.ClosedCount = db.Clients.Count(e => e.AssignedWorkerId == AssignedWorkerId && e.StatusOfFileId == 3);
            ViewBag.NoneCount = db.Clients.Count(e => e.AssignedWorkerId == AssignedWorkerId && e.StatusOfFileId == 4);

            return View(db.Clients.Where(c => c.AssignedWorkerId == AssignedWorkerId));
        }
    }
}