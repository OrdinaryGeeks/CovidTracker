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
    public class LatLongGroupsAPIController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/LatLongGroupsAPI
        public IQueryable<LatLongGroup> GetLatLongGroups()
        {
            return db.LatLongGroups;
        }

        // GET: api/LatLongGroupsAPI/5
        [ResponseType(typeof(LatLongGroup))]
        public IHttpActionResult GetLatLongGroup(int id)
        {
            LatLongGroup latLongGroup = db.LatLongGroups.Find(id);
            if (latLongGroup == null)
            {
                return NotFound();
            }

            return Ok(latLongGroup);
        }

        // PUT: api/LatLongGroupsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLatLongGroup(int id, LatLongGroup latLongGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != latLongGroup.LatLongGroupID)
            {
                return BadRequest();
            }

            db.Entry(latLongGroup).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LatLongGroupExists(id))
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

        // POST: api/LatLongGroupsAPI
        [ResponseType(typeof(LatLongGroup))]
        public IHttpActionResult PostLatLongGroup(LatLongGroup latLongGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LatLongGroups.Add(latLongGroup);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = latLongGroup.LatLongGroupID }, latLongGroup);
        }

        // DELETE: api/LatLongGroupsAPI/5
        [ResponseType(typeof(LatLongGroup))]
        public IHttpActionResult DeleteLatLongGroup(int id)
        {
            LatLongGroup latLongGroup = db.LatLongGroups.Find(id);
            if (latLongGroup == null)
            {
                return NotFound();
            }

            db.LatLongGroups.Remove(latLongGroup);
            db.SaveChanges();

            return Ok(latLongGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LatLongGroupExists(int id)
        {
            return db.LatLongGroups.Count(e => e.LatLongGroupID == id) > 0;
        }
    }
}