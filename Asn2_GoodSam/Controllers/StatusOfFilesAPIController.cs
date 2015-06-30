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
    public class StatusOfFilesAPIController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/StatusOfFilesAPI
        public IQueryable<StatusOfFile> GetStatusOfFile()
        {
            return db.StatusOfFile;
        }

        // GET: api/StatusOfFilesAPI/5
        [ResponseType(typeof(StatusOfFile))]
        public IHttpActionResult GetStatusOfFile(int id)
        {
            StatusOfFile statusOfFile = db.StatusOfFile.Find(id);
            if (statusOfFile == null)
            {
                return NotFound();
            }

            return Ok(statusOfFile);
        }

        // PUT: api/StatusOfFilesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusOfFile(int id, StatusOfFile statusOfFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusOfFile.StatusOfFileId)
            {
                return BadRequest();
            }

            db.Entry(statusOfFile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusOfFileExists(id))
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

        // POST: api/StatusOfFilesAPI
        [ResponseType(typeof(StatusOfFile))]
        public IHttpActionResult PostStatusOfFile(StatusOfFile statusOfFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusOfFile.Add(statusOfFile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusOfFile.StatusOfFileId }, statusOfFile);
        }

        // DELETE: api/StatusOfFilesAPI/5
        [ResponseType(typeof(StatusOfFile))]
        public IHttpActionResult DeleteStatusOfFile(int id)
        {
            StatusOfFile statusOfFile = db.StatusOfFile.Find(id);
            if (statusOfFile == null)
            {
                return NotFound();
            }

            db.StatusOfFile.Remove(statusOfFile);
            db.SaveChanges();

            return Ok(statusOfFile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusOfFileExists(int id)
        {
            return db.StatusOfFile.Count(e => e.StatusOfFileId == id) > 0;
        }
    }
}