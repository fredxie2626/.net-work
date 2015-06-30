using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Asn2_GoodSam.Models.Client;

namespace Asn2_GoodSam.Controllers
{
    public class FiscalYearsAPIController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/FiscalYearsAPI
        public IQueryable<FiscalYear> GetFiscalYear()
        {
            return db.FiscalYear;
        }

        // GET: api/FiscalYearsAPI/5
        [ResponseType(typeof(FiscalYear))]
        public IHttpActionResult GetFiscalYear(int id)
        {
            FiscalYear fiscalYear = db.FiscalYear.Find(id);
            if (fiscalYear == null)
            {
                return NotFound();
            }

            return Ok(fiscalYear);
        }

        // PUT: api/FiscalYearsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFiscalYear(int id, FiscalYear fiscalYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fiscalYear.FiscalYearId)
            {
                return BadRequest();
            }

            db.Entry(fiscalYear).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FiscalYearExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/FiscalYearsAPI
        [ResponseType(typeof(FiscalYear))]
        public IHttpActionResult PostFiscalYear(FiscalYear fiscalYear)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FiscalYear.Add(fiscalYear);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fiscalYear.FiscalYearId }, fiscalYear);
        }

        // DELETE: api/FiscalYearsAPI/5
        [ResponseType(typeof(FiscalYear))]
        public IHttpActionResult DeleteFiscalYear(int id)
        {
            FiscalYear fiscalYear = db.FiscalYear.Find(id);
            if (fiscalYear == null)
            {
                return NotFound();
            }

            db.FiscalYear.Remove(fiscalYear);
            db.SaveChanges();

            return Ok(fiscalYear);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FiscalYearExists(int id)
        {
            return db.FiscalYear.Count(e => e.FiscalYearId == id) > 0;
        }
    }
}