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
    public class AssociationDOesAPIController : ApiController
    {
        private DOContext db = new DOContext();

        // GET: api/AssociationDOesAPI
        public IQueryable<AssociationDO> GetAssociations()
        {
            return db.Associations;
        }

        // GET: api/AssociationDOesAPI/5
        [ResponseType(typeof(AssociationDO))]
        public IHttpActionResult GetAssociationDO(int id)
        {
            AssociationDO associationDO = db.Associations.Find(id);
            if (associationDO == null)
            {
                return NotFound();
            }

            return Ok(associationDO);
        }

        // PUT: api/AssociationDOesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssociationDO(int id, AssociationDO associationDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != associationDO.AssociationDOID)
            {
                return BadRequest();
            }

            db.Entry(associationDO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssociationDOExists(id))
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

        // POST: api/AssociationDOesAPI
        [ResponseType(typeof(AssociationDO))]
        public IHttpActionResult PostAssociationDO(AssociationDO associationDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Associations.Add(associationDO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = associationDO.AssociationDOID }, associationDO);
        }

        // DELETE: api/AssociationDOesAPI/5
        [ResponseType(typeof(AssociationDO))]
        public IHttpActionResult DeleteAssociationDO(int id)
        {
            AssociationDO associationDO = db.Associations.Find(id);
            if (associationDO == null)
            {
                return NotFound();
            }

            db.Associations.Remove(associationDO);
            db.SaveChanges();

            return Ok(associationDO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssociationDOExists(int id)
        {
            return db.Associations.Count(e => e.AssociationDOID == id) > 0;
        }
    }
}