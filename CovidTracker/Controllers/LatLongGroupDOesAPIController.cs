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
    public class LatLongGroupDOesAPIController : ApiController
    {
        private DOContext db = new DOContext();

        // GET: api/LatLongGroupDOesAPI
        public IQueryable<LatLongGroupDO> GetLatLongGroups()
        {
            return db.LatLongGroups;
        }

        // GET: api/LatLongGroupDOesAPI/5
        [ResponseType(typeof(LatLongGroupDO))]
        public IHttpActionResult GetLatLongGroupDO(int id)
        {
            LatLongGroupDO latLongGroupDO = db.LatLongGroups.Find(id);
            if (latLongGroupDO == null)
            {
                return NotFound();
            }

            return Ok(latLongGroupDO);
        }

        // PUT: api/LatLongGroupDOesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLatLongGroupDO(int id, LatLongGroupDO latLongGroupDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != latLongGroupDO.LatLongGroupDOID)
            {
                return BadRequest();
            }

            db.Entry(latLongGroupDO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LatLongGroupDOExists(id))
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

        // POST: api/LatLongGroupDOesAPI
        [ResponseType(typeof(LatLongGroupDO))]
        public IHttpActionResult PostLatLongGroupDO(LatLongGroupDO latLongGroupDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LatLongGroups.Add(latLongGroupDO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = latLongGroupDO.LatLongGroupDOID }, latLongGroupDO);
        }

        // DELETE: api/LatLongGroupDOesAPI/5
        [ResponseType(typeof(LatLongGroupDO))]
        public IHttpActionResult DeleteLatLongGroupDO(int id)
        {
            LatLongGroupDO latLongGroupDO = db.LatLongGroups.Find(id);
            if (latLongGroupDO == null)
            {
                return NotFound();
            }

            db.LatLongGroups.Remove(latLongGroupDO);
            db.SaveChanges();

            return Ok(latLongGroupDO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LatLongGroupDOExists(int id)
        {
            return db.LatLongGroups.Count(e => e.LatLongGroupDOID == id) > 0;
        }
    }
}