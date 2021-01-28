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
    public class TimeBlockDOesAPIController : ApiController
    {
        private DOContext db = new DOContext();

        // GET: api/TimeBlockDOesAPI
        public IQueryable<TimeBlockDO> GetTimeBlocks()
        {
            return db.TimeBlocks;
        }

        // GET: api/TimeBlockDOesAPI/5
        [ResponseType(typeof(TimeBlockDO))]
        public IHttpActionResult GetTimeBlockDO(int id)
        {
            TimeBlockDO timeBlockDO = db.TimeBlocks.Find(id);
            if (timeBlockDO == null)
            {
                return NotFound();
            }

            return Ok(timeBlockDO);
        }

        // PUT: api/TimeBlockDOesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimeBlockDO(int id, TimeBlockDO timeBlockDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeBlockDO.TimeBlockDOID)
            {
                return BadRequest();
            }

            db.Entry(timeBlockDO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeBlockDOExists(id))
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

        // POST: api/TimeBlockDOesAPI
        [ResponseType(typeof(TimeBlockDO))]
        public IHttpActionResult PostTimeBlockDO(TimeBlockDO timeBlockDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeBlocks.Add(timeBlockDO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timeBlockDO.TimeBlockDOID }, timeBlockDO);
        }

        // DELETE: api/TimeBlockDOesAPI/5
        [ResponseType(typeof(TimeBlockDO))]
        public IHttpActionResult DeleteTimeBlockDO(int id)
        {
            TimeBlockDO timeBlockDO = db.TimeBlocks.Find(id);
            if (timeBlockDO == null)
            {
                return NotFound();
            }

            db.TimeBlocks.Remove(timeBlockDO);
            db.SaveChanges();

            return Ok(timeBlockDO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeBlockDOExists(int id)
        {
            return db.TimeBlocks.Count(e => e.TimeBlockDOID == id) > 0;
        }
    }
}