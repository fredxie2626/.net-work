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
    public class ClientsCrudController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: ClientsCrud
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: ClientsCrud/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: ClientsCrud/Create
        public ActionResult Create()
        {
            PopulateEthnicitiesDropDownList();
            PopulateGendersDropDownList();
            PopulateAgesDropDownList();
            PopulateFiscalYearsDropDownList();
            PopulateRiskLevelsDropDownList();
            PopulateCrisesDropDownList();
            PopulateServicesDropDownList();
            PopulateProgramsDropDownList();
            PopulateAssignedWorkersDropDownList();
            PopulateReferralSourcesDropDownList();
            PopulateReferralContactsDropDownList();
            PopulateIncidentsDropDownList();
           
            PopulateAbuserRelationshipsDropDownList();
            PopulateVictimOfIncidentsDropDownList();
            PopulateFamilyViolenceFilesDropDownList();
            PopulateDuplicateFilesDropDownList();
            PopulateRepeatClientsDropDownList();
            PopulateStatusOfFilesDropDownList();
            return View();
        }

        // POST: ClientsCrud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,Surname,FirstName,ChildrenZeroToSix,ChildrenSevenToTwelve,ChildrenThirteenToEighteen," +
       "EthnicityId,AbuserRelationshipId,AgeId,AssignedWorkerId,GenderId,FiscalYearId,RiskLevelId,CrisisId,ServiceId,ProgramId,ReferralSourceId," +
       "ReferralContactId,IncidentId,AbuserRelationshipId,VictimOfIncidentId,FamilyViolenceFileId,DuplicateFileId,RepeatClientId,StatusOfFileId," +
       "Smart")] Client client)
        {

            if (ModelState.IsValid)
            {
               
               if (client.ProgramId != 5)
               {

                   System.Diagnostics.Debug.WriteLine("This was hit");
                   client.Smart = null;
               }
               client.Smart = null;
               db.Clients.Add(client);
               db.SaveChanges();
               return RedirectToAction("Index");
            }


            PopulateEthnicitiesDropDownList(client.EthnicityId);
            PopulateGendersDropDownList(client.GenderId);
            PopulateAgesDropDownList(client.AgeId);
            PopulateFiscalYearsDropDownList(client.FiscalYearId);
            PopulateRiskLevelsDropDownList(client.RiskLevelId);
            PopulateCrisesDropDownList(client.CrisisId);
            PopulateServicesDropDownList(client.ServiceId);
            PopulateProgramsDropDownList(client.ProgramId);
            PopulateAssignedWorkersDropDownList(client.AssignedWorkerId);
            PopulateReferralSourcesDropDownList(client.ReferralSourceId);
            PopulateReferralContactsDropDownList(client.ReferralContactId);
            PopulateIncidentsDropDownList(client.IncidentId);
            PopulateAbuserRelationshipsDropDownList(client.AbuserRelationshipId);
            PopulateVictimOfIncidentsDropDownList(client.VictimOfIncidentId);
            PopulateFamilyViolenceFilesDropDownList(client.FamilyViolenceFileId);
            PopulateDuplicateFilesDropDownList(client.DuplicateFileId);
            PopulateRepeatClientsDropDownList(client.RepeatClientId);
            PopulateStatusOfFilesDropDownList(client.StatusOfFileId);

            db.Clients.Add(client);
            return View(client);
        }

        // GET: ClientsCrud/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }

            PopulateEthnicitiesDropDownList();
            PopulateGendersDropDownList();
            PopulateAgesDropDownList();
            PopulateFiscalYearsDropDownList();
            PopulateRiskLevelsDropDownList();
            PopulateCrisesDropDownList();
            PopulateServicesDropDownList();
            PopulateProgramsDropDownList();
            PopulateAssignedWorkersDropDownList();
            PopulateReferralSourcesDropDownList();
            PopulateReferralContactsDropDownList();
            PopulateIncidentsDropDownList();

            PopulateAbuserRelationshipsDropDownList();
            PopulateVictimOfIncidentsDropDownList();
            PopulateFamilyViolenceFilesDropDownList();
            PopulateDuplicateFilesDropDownList();
            PopulateRepeatClientsDropDownList();
            PopulateStatusOfFilesDropDownList();
            return View(client);
        }

        // POST: ClientsCrud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Surname,FirstName,ChildrenZeroToSix,ChildrenSevenToTwelve,ChildrenThirteenToEighteen," +
       "EthnicityId,AbuserRelationshipId,AgeId,AssignedWorkerId,GenderId,FiscalYearId,RiskLevelId,CrisisId,ServiceId,ProgramId,ReferralSourceId," +
       "ReferralContactId,IncidentId,AbuserRelationshipId,VictimOfIncidentId,FamilyViolenceFileId,DuplicateFileId,RepeatClientId,StatusOfFileId," +
       "Smart")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: ClientsCrud/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: ClientsCrud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            if (client.ProgramId == 5)
            {
                Smart smart = db.Smarts.Find(id);
                if (smart != null)
                    db.Smarts.Remove(smart);
            }

            db.Clients.Remove(client);
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

        /*
         * DropDownList creation methods
         */
        private void PopulateEthnicitiesDropDownList(object selectedEthnicity = null)
        {
            var ethnicitiesQuery = from d in db.Ethnicity
                                   orderby d.EthnicityName
                                   select d;
            ViewBag.EthnicityId = new SelectList(ethnicitiesQuery, "EthnicityId", "EthnicityName", selectedEthnicity);
        }
        private void PopulateGendersDropDownList(object selectedGender = null)
        {
            var GendersQuery = from d in db.Gender
                                   orderby d.GenderName
                                   select d;
            ViewBag.GenderId = new SelectList(GendersQuery, "GenderId", "GenderName", selectedGender);
        }
            private void PopulateAgesDropDownList(object selectedAge = null)
        {
            var AgesQuery = from d in db.Age
                                   orderby d.AgeName
                                   select d;
            ViewBag.AgeId = new SelectList(AgesQuery, "AgeId", "AgeName", selectedAge);
        }
        private void PopulateFiscalYearsDropDownList(object selectedFiscalYear = null)
        {
            var FiscalYearsQuery = from d in db.FiscalYear
                                   orderby d.FiscalYearName
                                   select d;
            ViewBag.FiscalYearId = new SelectList(FiscalYearsQuery, "FiscalYearId", "FiscalYearName", selectedFiscalYear);
        }
        private void PopulateRiskLevelsDropDownList(object selectedRiskLevel = null)
        {
            var RiskLevelsQuery = from d in db.RiskLevel
                                   orderby d.RiskLevelName
                                   select d;
            ViewBag.RiskLevelId = new SelectList(RiskLevelsQuery, "RiskLevelId", "RiskLevelName", selectedRiskLevel);
        }
        private void PopulateCrisesDropDownList(object selectedCrisis = null)
        {
            var CrisesQuery = from d in db.Crisis
                                   orderby d.CrisisName
                                   select d;
            ViewBag.CrisisId = new SelectList(CrisesQuery, "CrisisId", "CrisisName", selectedCrisis);
        }
        private void PopulateServicesDropDownList(object selectedService = null)
        {
            var ServicesQuery = from d in db.Service
                                   orderby d.ServiceName
                                   select d;
            ViewBag.ServiceId = new SelectList(ServicesQuery, "ServiceId", "ServiceName", selectedService);
        }
        private void PopulateProgramsDropDownList(object selectedProgram = null)
        {
            var ProgramsQuery = from d in db.Program
                                   orderby d.ProgramName
                                   select d;
            ViewBag.ProgramId = new SelectList(ProgramsQuery, "ProgramId", "ProgramName", selectedProgram);
}   
        private void PopulateAssignedWorkersDropDownList(object selectedAssignedWorker = null)
        {
            var AssignedWorkersQuery = from d in db.AssignedWorker
                                   orderby d.AssignedWorkerName
                                   select d;
            ViewBag.AssignedWorkerId = new SelectList(AssignedWorkersQuery, "AssignedWorkerId", "AssignedWorkerName", selectedAssignedWorker);
}
        private void PopulateReferralSourcesDropDownList(object selectedReferralSource = null)
        {
            var ReferralSourcesQuery = from d in db.ReferralSource
                                   orderby d.ReferralSourceName
                                   select d;
            ViewBag.ReferralSourceId = new SelectList(ReferralSourcesQuery, "ReferralSourceId", "ReferralSourceName", selectedReferralSource);
        }
        private void PopulateReferralContactsDropDownList(object selectedReferralContact = null)
        {
            var ReferralContactsQuery = from d in db.ReferralContact
                                   orderby d.ReferralContactName
                                   select d;
            ViewBag.ReferralContactId = new SelectList(ReferralContactsQuery, "ReferralContactId", "ReferralContactName", selectedReferralContact);
        }
        private void PopulateIncidentsDropDownList(object selectedIncident = null)
        {
            var IncidentsQuery = from d in db.Incident
                                   orderby d.IncidentName
                                   select d;
            ViewBag.IncidentId = new SelectList(IncidentsQuery, "IncidentId", "IncidentName", selectedIncident);
        }

        private void PopulateAbuserRelationshipsDropDownList(object selectedAbuserRelationship = null)
        {
            var AbuserRelationshipsQuery = from d in db.AbuserRelationship
                                   orderby d.AbuserRelationshipName
                                   select d;
            ViewBag.AbuserRelationshipId = new SelectList(AbuserRelationshipsQuery, "AbuserRelationshipId", "AbuserRelationshipName", selectedAbuserRelationship);
        }
        private void PopulateVictimOfIncidentsDropDownList(object selectedVictimOfIncident = null)
        {
            var VictimOfIncidentsQuery = from d in db.VictimOfIncident
                                   orderby d.VictimOfIncidentName
                                   select d;
            ViewBag.VictimOfIncidentId = new SelectList(VictimOfIncidentsQuery, "VictimOfIncidentId", "VictimOfIncidentName", selectedVictimOfIncident);
        }

        private void PopulateFamilyViolenceFilesDropDownList(object selectedFamilyViolenceFile = null)
        {
            var FamilyViolenceFilesQuery = from d in db.FamilyViolenceFile
                                   orderby d.FamilyViolenceFileName
                                   select d;
            ViewBag.FamilyViolenceFileId = new SelectList(FamilyViolenceFilesQuery, "FamilyViolenceFileId", "FamilyViolenceFileName", selectedFamilyViolenceFile);
        }

        private void PopulateDuplicateFilesDropDownList(object selectedDuplicateFile = null)
        {
            var DuplicateFilesQuery = from d in db.DuplicateFile
                                   orderby d.DuplicateFileName
                                   select d;
            ViewBag.DuplicateFileId = new SelectList(DuplicateFilesQuery, "DuplicateFileId", "DuplicateFileName", selectedDuplicateFile);
        }

        private void PopulateRepeatClientsDropDownList(object selectedRepeatClient = null)
        {
            var RepeatClientsQuery = from d in db.RepeatClient
                                   orderby d.RepeatClientName
                                   select d;
            ViewBag.RepeatClientId = new SelectList(RepeatClientsQuery, "RepeatClientId", "RepeatClientName", selectedRepeatClient);
        }

        private void PopulateStatusOfFilesDropDownList(object selectedStatusOfFile = null)
        {
            var StatusOfFilesQuery = from d in db.StatusOfFile
                                   orderby d.StatusOfFileName
                                   select d;
            ViewBag.StatusOfFileId = new SelectList(StatusOfFilesQuery, "StatusOfFileId", "StatusOfFileName", selectedStatusOfFile);
        }

        
    }
}
