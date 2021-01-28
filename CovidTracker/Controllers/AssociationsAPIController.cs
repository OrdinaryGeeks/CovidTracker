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
using CovidTracker.Models;

namespace CovidTracker.Controllers
{
    public class AssociationsAPIController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/AssociationsAPI
        public IQueryable<Association> GetAssociations()
        {
            return db.Associations;
        }

        // GET: api/AssociationsAPI/5
        [ResponseType(typeof(Association))]
        public IHttpActionResult GetAssociation(int id)
        {
            Association association = db.Associations.Find(id);
            if (association == null)
            {
                return NotFound();
            }

            return Ok(association);
        }

        // PUT: api/AssociationsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssociation(int id, Association association)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != association.AssociationID)
            {
                return BadRequest();
            }

            db.Entry(association).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociationExists(id))
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

        // POST: api/AssociationsAPI
        [ResponseType(typeof(Association))]
        public IHttpActionResult PostAssociation(Association association)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Associations.Add(association);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = association.AssociationID }, association);
        }

        // DELETE: api/AssociationsAPI/5
        [ResponseType(typeof(Association))]
        public IHttpActionResult DeleteAssociation(int id)
        {
            Association association = db.Associations.Find(id);
            if (association == null)
            {
                return NotFound();
            }

            db.Associations.Remove(association);
            db.SaveChanges();

            return Ok(association);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssociationExists(int id)
        {
            return db.Associations.Count(e => e.AssociationID == id) > 0;
        }
    }
}