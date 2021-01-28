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
    public class LatLongGroupsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: LatLongGroups
        public ActionResult Index()
        {
            return View(db.LatLongGroups.ToList());
        }

        // GET: LatLongGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatLongGroup latLongGroup = db.LatLongGroups.Find(id);
            if (latLongGroup == null)
            {
                return HttpNotFound();
            }
            return View(latLongGroup);
        }

        // GET: LatLongGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LatLongGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LatLongGroupID,NorthWestLat,NorthWestLong,SouthEastLat,SouthEastLong")] LatLongGroup latLongGroup)
        {
            if (ModelState.IsValid)
            {
                db.LatLongGroups.Add(latLongGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(latLongGroup);
        }

        // GET: LatLongGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatLongGroup latLongGroup = db.LatLongGroups.Find(id);
            if (latLongGroup == null)
            {
                return HttpNotFound();
            }
            return View(latLongGroup);
        }

        // POST: LatLongGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LatLongGroupID,NorthWestLat,NorthWestLong,SouthEastLat,SouthEastLong")] LatLongGroup latLongGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(latLongGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(latLongGroup);
        }

        // GET: LatLongGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatLongGroup latLongGroup = db.LatLongGroups.Find(id);
            if (latLongGroup == null)
            {
                return HttpNotFound();
            }
            return View(latLongGroup);
        }

        // POST: LatLongGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LatLongGroup latLongGroup = db.LatLongGroups.Find(id);
            db.LatLongGroups.Remove(latLongGroup);
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
