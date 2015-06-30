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
    public class AssignedWorkersAPIController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/AssignedWorkersAPI
        public IQueryable<AssignedWorker> GetAssignedWorker()
        {
            return db.AssignedWorker;
        }

        // GET: api/AssignedWorkersAPI/5
        [ResponseType(typeof(AssignedWorker))]
        public IHttpActionResult GetAssignedWorker(int id)
        {
            AssignedWorker assignedWorker = db.AssignedWorker.Find(id);
            if (assignedWorker == null)
            {
                return NotFound();
            }

            return Ok(assignedWorker);
        }

        // PUT: api/AssignedWorkersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssignedWorker(int id, AssignedWorker assignedWorker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assignedWorker.AssignedWorkerId)
            {
                return BadRequest();
            }

            db.Entry(assignedWorker).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignedWorkerExists(id))
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

        // POST: api/AssignedWorkersAPI
        [ResponseType(typeof(AssignedWorker))]
        public IHttpActionResult PostAssignedWorker(AssignedWorker assignedWorker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssignedWorker.Add(assignedWorker);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = assignedWorker.AssignedWorkerId }, assignedWorker);
        }

        // DELETE: api/AssignedWorkersAPI/5
        [ResponseType(typeof(AssignedWorker))]
        public IHttpActionResult DeleteAssignedWorker(int id)
        {
            AssignedWorker assignedWorker = db.AssignedWorker.Find(id);
            if (assignedWorker == null)
            {
                return NotFound();
            }

            db.AssignedWorker.Remove(assignedWorker);
            db.SaveChanges();

            return Ok(assignedWorker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssignedWorkerExists(int id)
        {
            return db.AssignedWorker.Count(e => e.AssignedWorkerId == id) > 0;
        }
    }
}