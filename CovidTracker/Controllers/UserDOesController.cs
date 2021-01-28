using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CovidTracker.Models;

namespace CovidTracker.Controllers
{
    public class UserDOesController : Controller
    {
        private DOContext db = new DOContext();

        // GET: UserDOes
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: UserDOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDO userDO = db.Users.Find(id);
            if (userDO == null)
            {
                return HttpNotFound();
            }
            return View(userDO);
        }

        // GET: UserDOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserDOID,FName,LName,Password,PhoneNumber")] UserDO userDO)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(userDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDO);
        }

        // GET: UserDOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDO userDO = db.Users.Find(id);
            if (userDO == null)
            {
                return HttpNotFound();
            }
            return View(userDO);
        }

        // POST: UserDOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserDOID,FName,LName,Password,PhoneNumber")] UserDO userDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDO);
        }

        // GET: UserDOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDO userDO = db.Users.Find(id);
            if (userDO == null)
            {
                return HttpNotFound();
            }
            return View(userDO);
        }

        // POST: UserDOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDO userDO = db.Users.Find(id);
            db.Users.Remove(userDO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
