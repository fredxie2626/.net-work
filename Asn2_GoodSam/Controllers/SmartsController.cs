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
    public class SmartsController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Smarts
        public ActionResult Index()
        {
            var smarts = db.Smarts.Include(s => s.BadDateReport).Include(s => s.CityOfAssault).Include(s => s.CityOfResidence).Include(s => s.Client).Include(s => s.DrugFacilitatedAssault).Include(s => s.EvidenceStored).Include(s => s.HIVMeds).Include(s => s.HospitalAttended).Include(s => s.MedicalOnly).Include(s => s.MultiplePerpetrators).Include(s => s.PoliceAttendance).Include(s => s.PoliceReported).Include(s => s.ReferredToCBVS).Include(s => s.ReferringHospital).Include(s => s.SexWork).Include(s => s.SocialWorkAttendance).Include(s => s.ThirdPartyReport).Include(s => s.VictimServicesAttendance);
            return View(smarts.ToList());
        }

        // GET: Smarts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = db.Smarts.Find(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            return View(smart);
        }

        // GET: Smarts/Create
        public ActionResult Create()
        {

            PopulateClientIdDropDownList();
            ViewBag.BadDateReportId = new SelectList(db.BadDateReport, "BadDateReportId", "BadDateReportName");
            ViewBag.CityOfAssaultId = new SelectList(db.CityOfAssault, "CityOfAssaultId", "CityOfAssaultName");
            ViewBag.CityOfResidenceId = new SelectList(db.CityOfResidence, "CityOfResidenceId", "CityOfResidenceName");

            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssault, "DrugFacilitatedAssaultId", "DrugFacilitatedAssaultName");
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStored, "EvidenceStoredId", "EvidenceStoredName");
            ViewBag.HIVMedsId = new SelectList(db.HIVMeds, "HIVMedsId", "HIVMedsName");
            ViewBag.HospitalAttendedId = new SelectList(db.HospitalAttended, "HospitalAttendedId", "HospitalAttendedName");
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnly, "MedicalOnlyId", "MedicalOnlyName");
            ViewBag.MultiplePerpetratorsId = new SelectList(db.MultiplePerpetrators, "MultiplePerpetratorsId", "MultiplePerpetratorsName");
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendance, "PoliceAttendanceId", "PoliceAttendanceName");
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReported, "PoliceReportedId", "PoliceReportedName");
            ViewBag.ReferredToCBVSId = new SelectList(db.ReferredToCBVS, "ReferredToCBVSId", "ReferredToCBVSName");
            ViewBag.ReferringHospitalId = new SelectList(db.ReferringHospital, "ReferringHospitalId", "ReferringHospitalName");
            ViewBag.SexWorkId = new SelectList(db.SexWork, "SexWorkId", "SexWorkName");
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendance, "SocialWorkAttendanceId", "SocialWorkAttendanceName");
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReport, "ThirdPartyReportId", "ThirdPartyReportName");
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendance, "VictimServicesAttendanceId", "VictimServicesAttendanceName");
            return View();
        }

        // POST: Smarts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,AccompanimentMinutes,NumberTransportsProvided,RefferedToNursePractitioner,SexWorkId,MultiplePerpetratorsId,DrugFacilitatedAssaultId,CityOfAssaultId,CityOfResidenceId,ReferringHospitalId,HospitalAttendedId,SocialWorkAttendanceId,PoliceAttendanceId,VictimServicesAttendanceId,MedicalOnlyId,EvidenceStoredId,HIVMedsId,ReferredToCBVSId,PoliceReportedId,ThirdPartyReportId,BadDateReportId")] Smart smart)
        {
            if (ModelState.IsValid)
            {
                db.Smarts.Add(smart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateClientIdDropDownList(smart.ClientID);

            ViewBag.BadDateReportId = new SelectList(db.BadDateReport, "BadDateReportId", "BadDateReportName", smart.BadDateReportId);
            ViewBag.CityOfAssaultId = new SelectList(db.CityOfAssault, "CityOfAssaultId", "CityOfAssaultName", smart.CityOfAssaultId);
            ViewBag.CityOfResidenceId = new SelectList(db.CityOfResidence, "CityOfResidenceId", "CityOfResidenceName", smart.CityOfResidenceId);

            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssault, "DrugFacilitatedAssaultId", "DrugFacilitatedAssaultName", smart.DrugFacilitatedAssaultId);
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStored, "EvidenceStoredId", "EvidenceStoredName", smart.EvidenceStoredId);
            ViewBag.HIVMedsId = new SelectList(db.HIVMeds, "HIVMedsId", "HIVMedsName", smart.HIVMedsId);
            ViewBag.HospitalAttendedId = new SelectList(db.HospitalAttended, "HospitalAttendedId", "HospitalAttendedName", smart.HospitalAttendedId);
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnly, "MedicalOnlyId", "MedicalOnlyName", smart.MedicalOnlyId);
            ViewBag.MultiplePerpetratorsId = new SelectList(db.MultiplePerpetrators, "MultiplePerpetratorsId", "MultiplePerpetratorsName", smart.MultiplePerpetratorsId);
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendance, "PoliceAttendanceId", "PoliceAttendanceName", smart.PoliceAttendanceId);
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReported, "PoliceReportedId", "PoliceReportedName", smart.PoliceReportedId);
            ViewBag.ReferredToCBVSId = new SelectList(db.ReferredToCBVS, "ReferredToCBVSId", "ReferredToCBVSName", smart.ReferredToCBVSId);
            ViewBag.ReferringHospitalId = new SelectList(db.ReferringHospital, "ReferringHospitalId", "ReferringHospitalName", smart.ReferringHospitalId);
            ViewBag.SexWorkId = new SelectList(db.SexWork, "SexWorkId", "SexWorkName", smart.SexWorkId);
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendance, "SocialWorkAttendanceId", "SocialWorkAttendanceName", smart.SocialWorkAttendanceId);
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReport, "ThirdPartyReportId", "ThirdPartyReportName", smart.ThirdPartyReportId);
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendance, "VictimServicesAttendanceId", "VictimServicesAttendanceName", smart.VictimServicesAttendanceId);
            return View(smart);
        }

        // GET: Smarts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = db.Smarts.Find(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            ViewBag.BadDateReportId = new SelectList(db.BadDateReport, "BadDateReportId", "BadDateReportName", smart.BadDateReportId);
            ViewBag.CityOfAssaultId = new SelectList(db.CityOfAssault, "CityOfAssaultId", "CityOfAssaultName", smart.CityOfAssaultId);
            ViewBag.CityOfResidenceId = new SelectList(db.CityOfResidence, "CityOfResidenceId", "CityOfResidenceName", smart.CityOfResidenceId);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientId", "Surname", smart.ClientID);
            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssault, "DrugFacilitatedAssaultId", "DrugFacilitatedAssaultName", smart.DrugFacilitatedAssaultId);
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStored, "EvidenceStoredId", "EvidenceStoredName", smart.EvidenceStoredId);
            ViewBag.HIVMedsId = new SelectList(db.HIVMeds, "HIVMedsId", "HIVMedsName", smart.HIVMedsId);
            ViewBag.HospitalAttendedId = new SelectList(db.HospitalAttended, "HospitalAttendedId", "HospitalAttendedName", smart.HospitalAttendedId);
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnly, "MedicalOnlyId", "MedicalOnlyName", smart.MedicalOnlyId);
            ViewBag.MultiplePerpetratorsId = new SelectList(db.MultiplePerpetrators, "MultiplePerpetratorsId", "MultiplePerpetratorsName", smart.MultiplePerpetratorsId);
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendance, "PoliceAttendanceId", "PoliceAttendanceName", smart.PoliceAttendanceId);
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReported, "PoliceReportedId", "PoliceReportedName", smart.PoliceReportedId);
            ViewBag.ReferredToCBVSId = new SelectList(db.ReferredToCBVS, "ReferredToCBVSId", "ReferredToCBVSName", smart.ReferredToCBVSId);
            ViewBag.ReferringHospitalId = new SelectList(db.ReferringHospital, "ReferringHospitalId", "ReferringHospitalName", smart.ReferringHospitalId);
            ViewBag.SexWorkId = new SelectList(db.SexWork, "SexWorkId", "SexWorkName", smart.SexWorkId);
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendance, "SocialWorkAttendanceId", "SocialWorkAttendanceName", smart.SocialWorkAttendanceId);
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReport, "ThirdPartyReportId", "ThirdPartyReportName", smart.ThirdPartyReportId);
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendance, "VictimServicesAttendanceId", "VictimServicesAttendanceName", smart.VictimServicesAttendanceId);
            return View(smart);
        }

        // POST: Smarts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,AccompanimentMinutes,NumberTransportsProvided,RefferedToNursePractitioner,SexWorkId,MultiplePerpetratorsId,DrugFacilitatedAssaultId,CityOfAssaultId,CityOfResidenceId,ReferringHospitalId,HospitalAttendedId,SocialWorkAttendanceId,PoliceAttendanceId,VictimServicesAttendanceId,MedicalOnlyId,EvidenceStoredId,HIVMedsId,ReferredToCBVSId,PoliceReportedId,ThirdPartyReportId,BadDateReportId")] Smart smart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BadDateReportId = new SelectList(db.BadDateReport, "BadDateReportId", "BadDateReportName", smart.BadDateReportId);
            ViewBag.CityOfAssaultId = new SelectList(db.CityOfAssault, "CityOfAssaultId", "CityOfAssaultName", smart.CityOfAssaultId);
            ViewBag.CityOfResidenceId = new SelectList(db.CityOfResidence, "CityOfResidenceId", "CityOfResidenceName", smart.CityOfResidenceId);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientId", "Surname", smart.ClientID);
            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssault, "DrugFacilitatedAssaultId", "DrugFacilitatedAssaultName", smart.DrugFacilitatedAssaultId);
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStored, "EvidenceStoredId", "EvidenceStoredName", smart.EvidenceStoredId);
            ViewBag.HIVMedsId = new SelectList(db.HIVMeds, "HIVMedsId", "HIVMedsName", smart.HIVMedsId);
            ViewBag.HospitalAttendedId = new SelectList(db.HospitalAttended, "HospitalAttendedId", "HospitalAttendedName", smart.HospitalAttendedId);
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnly, "MedicalOnlyId", "MedicalOnlyName", smart.MedicalOnlyId);
            ViewBag.MultiplePerpetratorsId = new SelectList(db.MultiplePerpetrators, "MultiplePerpetratorsId", "MultiplePerpetratorsName", smart.MultiplePerpetratorsId);
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendance, "PoliceAttendanceId", "PoliceAttendanceName", smart.PoliceAttendanceId);
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReported, "PoliceReportedId", "PoliceReportedName", smart.PoliceReportedId);
            ViewBag.ReferredToCBVSId = new SelectList(db.ReferredToCBVS, "ReferredToCBVSId", "ReferredToCBVSName", smart.ReferredToCBVSId);
            ViewBag.ReferringHospitalId = new SelectList(db.ReferringHospital, "ReferringHospitalId", "ReferringHospitalName", smart.ReferringHospitalId);
            ViewBag.SexWorkId = new SelectList(db.SexWork, "SexWorkId", "SexWorkName", smart.SexWorkId);
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendance, "SocialWorkAttendanceId", "SocialWorkAttendanceName", smart.SocialWorkAttendanceId);
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReport, "ThirdPartyReportId", "ThirdPartyReportName", smart.ThirdPartyReportId);
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendance, "VictimServicesAttendanceId", "VictimServicesAttendanceName", smart.VictimServicesAttendanceId);
            return View(smart);
        }

        // GET: Smarts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Smart smart = db.Smarts.Find(id);
            if (smart == null)
            {
                return HttpNotFound();
            }
            return View(smart);
        }

        // POST: Smarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Smart smart = db.Smarts.Find(id);
            db.Smarts.Remove(smart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateClientIdDropDownList(object selectedClientId = null)
        {
            var ClientIdQuery = from d in db.Clients
                                orderby d.ClientId
                                where d.ProgramId.Equals(5) &&
                                d.Smart.Equals(null)
                                select d;
            ViewBag.ClientId = new SelectList(ClientIdQuery, "ClientId", "Surname", selectedClientId);
        }

        private void PopulateSexWorkDropDownList(object selectedSexWork = null)
        {
            var SexWorkQuery = from d in db.SexWork
                               orderby d.SexWorkName
                               select d;
            ViewBag.SexWorkId = new SelectList(SexWorkQuery, "SexWorkId", "SexWorkName", selectedSexWork);
        }

        private void PopulateMultiplePerpetratorsDropDownList(object selectedMultiplePerpetrators = null)
        {
            var MultiplePerpetratorsQuery = from d in db.MultiplePerpetrators
                                            orderby d.MultiplePerpetratorsName
                                            select d;
            ViewBag.MultiplePerpetratorsId = new SelectList(MultiplePerpetratorsQuery, "MultiplePerpetratorsId", "MultiplePerpetratorsName", selectedMultiplePerpetrators);
        }

        private void PopulateDrugFacilitatedAssaultDropDownList(object selectedDrugFacilitatedAssault = null)
        {
            var DrugFacilitatedAssaultQuery = from d in db.DrugFacilitatedAssault
                                              orderby d.DrugFacilitatedAssaultName
                                              select d;
            ViewBag.DrugFacilitatedAssaultId = new SelectList(DrugFacilitatedAssaultQuery, "DrugFacilitatedAssaultId", "DrugFacilitatedAssaultName", selectedDrugFacilitatedAssault);
        }

        private void PopulateCityOfAssaultDropDownList(object selectedCityOfAssault = null)
        {
            var CityOfAssaultQuery = from d in db.CityOfAssault
                                     orderby d.CityOfAssaultName
                                     select d;
            ViewBag.CityOfAssaultId = new SelectList(CityOfAssaultQuery, "CityOfAssaultId", "CityOfAssaultName", selectedCityOfAssault);
        }

        private void PopulateCityOfResidenceDropDownList(object selectedCityOfResidence = null)
        {
            var CityOfResidenceQuery = from d in db.CityOfResidence
                                       orderby d.CityOfResidenceName
                                       select d;
            ViewBag.CityOfResidenceId = new SelectList(CityOfResidenceQuery, "CityOfResidenceId", "CityOfResidenceName", selectedCityOfResidence);
        }

        private void PopulateReferringHospitalDropDownList(object selectedReferringHospital = null)
        {
            var ReferringHospitalQuery = from d in db.ReferringHospital
                                         orderby d.ReferringHospitalName
                                         select d;
            ViewBag.ReferringHospitalId = new SelectList(ReferringHospitalQuery, "ReferringHospitalId", "ReferringHospitalName", selectedReferringHospital);
        }

        private void PopulateHospitalAttendedDropDownList(object selectedHospitalAttended = null)
        {
            var HospitalAttendedQuery = from d in db.HospitalAttended
                                        orderby d.HospitalAttendedName
                                        select d;
            ViewBag.HospitalAttendedId = new SelectList(HospitalAttendedQuery, "HospitalAttendedId", "HospitalAttendedName", selectedHospitalAttended);
        }

        private void PopulateSocialWorkAttendanceDropDownList(object selectedSocialWorkAttendance = null)
        {
            var SocialWorkAttendanceQuery = from d in db.SocialWorkAttendance
                                            orderby d.SocialWorkAttendanceName
                                            select d;
            ViewBag.SocialWorkAttendanceId = new SelectList(SocialWorkAttendanceQuery, "SocialWorkAttendanceId", "SocialWorkAttendanceName", selectedSocialWorkAttendance);
        }

        private void PopulatePoliceAttendanceDropDownList(object selectedPoliceAttendance = null)
        {
            var PoliceAttendanceQuery = from d in db.PoliceAttendance
                                        orderby d.PoliceAttendanceName
                                        select d;
            ViewBag.PoliceAttendanceId = new SelectList(PoliceAttendanceQuery, "PoliceAttendanceId", "PoliceAttendanceName", selectedPoliceAttendance);
        }

        private void PopulateVictimServicesAttendanceDropDownList(object selectedVictimServicesAttendance = null)
        {
            var VictimServicesAttendanceQuery = from d in db.VictimServicesAttendance
                                                orderby d.VictimServicesAttendanceName
                                                select d;
            ViewBag.VictimServicesAttendanceId = new SelectList(VictimServicesAttendanceQuery, "VictimServicesAttendanceId", "VictimServicesAttendanceName", selectedVictimServicesAttendance);
        }

        private void PopulateMedicalOnlyDropDownList(object selectedMedicalOnly = null)
        {
            var MedicalOnlyQuery = from d in db.MedicalOnly
                                   orderby d.MedicalOnlyName
                                   select d;
            ViewBag.MedicalOnlyId = new SelectList(MedicalOnlyQuery, "MedicalOnlyId", "MedicalOnlyName", selectedMedicalOnly);
        }

        private void PopulateEvidenceStoredDropDownList(object selectedEvidenceStored = null)
        {
            var EvidenceStoredQuery = from d in db.EvidenceStored
                                      orderby d.EvidenceStoredName
                                      select d;
            ViewBag.EvidenceStoredId = new SelectList(EvidenceStoredQuery, "EvidenceStoredId", "EvidenceStoredName", selectedEvidenceStored);
        }
        private void PopulateHIVMedsDropDownList(object selectedHIVMeds = null)
        {
            var HIVMedsQuery = from d in db.HIVMeds
                               orderby d.HIVMedsName
                               select d;
            ViewBag.HIVMedsId = new SelectList(HIVMedsQuery, "HIVMedsId", "HIVMedsName", selectedHIVMeds);
        }
        private void PopulateReferredToCBVSDropDownList(object selectedReferredToCBVS = null)
        {
            var ReferredToCBVSQuery = from d in db.ReferredToCBVS
                                      orderby d.ReferredToCBVSName
                                      select d;
            ViewBag.ReferredToCBVSId = new SelectList(ReferredToCBVSQuery, "ReferredToCBVSId", "ReferredToCBVSName", selectedReferredToCBVS);
        }
        private void PopulatePoliceReportedDropDownList(object selectedPoliceReported = null)
        {
            var PoliceReportedQuery = from d in db.PoliceReported
                                      orderby d.PoliceReportedName
                                      select d;
            ViewBag.PoliceReportedId = new SelectList(PoliceReportedQuery, "PoliceReportedId", "PoliceReportedName", selectedPoliceReported);
        }
        private void PopulateThirdPartyReportDropDownList(object selectedThirdPartyReport = null)
        {
            var ThirdPartyReportQuery = from d in db.ThirdPartyReport
                                        orderby d.ThirdPartyReportName
                                        select d;
            ViewBag.ThirdPartyReportId = new SelectList(ThirdPartyReportQuery, "ThirdPartyReportId", "ThirdPartyReportName", selectedThirdPartyReport);
        }
        private void PopulateBadDateReportDropDownList(object selectedBadDateReport = null)
        {
            var BadDateReportQuery = from d in db.BadDateReport
                                     orderby d.BadDateReportName
                                     select d;
            ViewBag.BadDateReportId = new SelectList(BadDateReportQuery, "BadDateReportId", "BadDateReportName", selectedBadDateReport);
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
