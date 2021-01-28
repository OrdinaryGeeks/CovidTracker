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
    public class UserDOesAPIController : ApiController
    {
        private DOContext db = new DOContext();

        // GET: api/UserDOesAPI
        public IQueryable<UserDO> GetUsers()
        {
            return db.Users;
        }

        // GET: api/UserDOesAPI/5
        [ResponseType(typeof(UserDO))]
        public IHttpActionResult GetUserDO(int id)
        {
            UserDO userDO = db.Users.Find(id);
            if (userDO == null)
            {
                return NotFound();
            }

            return Ok(userDO);
        }

        // PUT: api/UserDOesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserDO(int id, UserDO userDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userDO.UserDOID)
            {
                return BadRequest();
            }

            db.Entry(userDO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDOExists(id))
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

        // POST: api/UserDOesAPI
        [ResponseType(typeof(UserDO))]
        public IHttpActionResult PostUserDO(UserDO userDO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(userDO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userDO.UserDOID }, userDO);
        }

        // DELETE: api/UserDOesAPI/5
        [ResponseType(typeof(UserDO))]
        public IHttpActionResult DeleteUserDO(int id)
        {
            UserDO userDO = db.Users.Find(id);
            if (userDO == null)
            {
                return NotFound();
            }

            db.Users.Remove(userDO);
            db.SaveChanges();

            return Ok(userDO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserDOExists(int id)
        {
            return db.Users.Count(e => e.UserDOID == id) > 0;
        }
    }
}