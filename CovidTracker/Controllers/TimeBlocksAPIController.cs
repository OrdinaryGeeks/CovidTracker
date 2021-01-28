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
    public class TimeBlocksAPIController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/TimeBlocksAPI
        public IQueryable<TimeBlock> GetTimeBlocks()
        {
            return db.TimeBlocks;
        }

        // GET: api/TimeBlocksAPI/5
        [ResponseType(typeof(TimeBlock))]
        public IHttpActionResult GetTimeBlock(int id)
        {
            TimeBlock timeBlock = db.TimeBlocks.Find(id);
            if (timeBlock == null)
            {
                return NotFound();
            }

            return Ok(timeBlock);
        }

        // PUT: api/TimeBlocksAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTimeBlock(int id, TimeBlock timeBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != timeBlock.TimeBlockID)
            {
                return BadRequest();
            }

            db.Entry(timeBlock).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimeBlockExists(id))
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

        // POST: api/TimeBlocksAPI
        [ResponseType(typeof(TimeBlock))]
        public IHttpActionResult PostTimeBlock(TimeBlock timeBlock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TimeBlocks.Add(timeBlock);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = timeBlock.TimeBlockID }, timeBlock);
        }

        // DELETE: api/TimeBlocksAPI/5
        [ResponseType(typeof(TimeBlock))]
        public IHttpActionResult DeleteTimeBlock(int id)
        {
            TimeBlock timeBlock = db.TimeBlocks.Find(id);
            if (timeBlock == null)
            {
                return NotFound();
            }

            db.TimeBlocks.Remove(timeBlock);
            db.SaveChanges();

            return Ok(timeBlock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TimeBlockExists(int id)
        {
            return db.TimeBlocks.Count(e => e.TimeBlockID == id) > 0;
        }
    }
}