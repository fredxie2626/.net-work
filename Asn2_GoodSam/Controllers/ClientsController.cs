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
    public class ClientsController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET: api/Clients
        public IQueryable<Client> GetClients()
        {
            return db.Clients;
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.ClientId)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.ClientId == id) > 0;
        }
		
		
        // GET: api/Clients/GetClientNum/status/workName
        [HttpGet]
        [ResponseType(typeof(int))]
        [Route("api/Clients/GetClientNum/{status}/{workName}")]
        public int GetClientNum(String status, String workName)
        {
            if(status != null && workName != null)
            {
                int idStatus = db.StatusOfFile.Where(p => p.StatusOfFileName == status).Select(p => p.StatusOfFileId).Single();
                int idWorker = db.AssignedWorker.Where(p => p.AssignedWorkerName == workName).Select(p => p.AssignedWorkerId).Single();

                return db.Clients.Count(e => e.AssignedWorkerId == idWorker && e.StatusOfFileId == idStatus);
            }
            return 0;
        }

        [HttpGet]
        [ResponseType(typeof(int))]
        [Route("api/Clients/GetClientNumTotal/{workName}")]
        public int GetClientNumTotal(String workName)
        {
            if (workName != null)
            {
                int idWorker = db.AssignedWorker.Where(p => p.AssignedWorkerName == workName).Select(p => p.AssignedWorkerId).Single();

                return db.Clients.Count(e => e.AssignedWorkerId == idWorker);
            }
            return 0;
        }

        //[HttpGet]
        //[Route("{workerName}")]
        //public IQueryable<Client> GetAllClients(String workerName)
        //{
        //    int id = db.AssignedWorker.Where(p => p.AssignedWorkerName == workerName).Select(p => p.AssignedWorkerId).Single();

        //    return db.Clients.Where(c => c.AssignedWorkerId == id);
        //}

        // GET: api/Clients/GetClientsWithAssignedWorker/workerName
        [HttpGet]
        [Route("api/Clients/GetClientsWithAssignedWorker/{workerName}")]
        public IQueryable<Client> GetClientsWithAssignedWorker(String workerName)
        {
            if(workerName != null)
            {
                int idWorker = db.AssignedWorker.Where(p => p.AssignedWorkerName == workerName).Select(p => p.AssignedWorkerId).Single();

                return db.Clients.Where(c => c.AssignedWorkerId == idWorker);
            }
            return null;
        }
    }
}