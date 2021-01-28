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
    public class LatLongGroupDOesController : Controller
    {
        private DOContext db = new DOContext();

        // GET: LatLongGroupDOes
        public ActionResult Index()
        {
            return View(db.LatLongGroups.ToList());
        }

        // GET: LatLongGroupDOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatLongGroupDO latLongGroupDO = db.LatLongGroups.Find(id);
            if (latLongGroupDO == null)
            {
                return HttpNotFound();
            }
            return View(latLongGroupDO);
        }

        // GET: LatLongGroupDOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LatLongGroupDOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LatLongGroupDOID,NorthWestLat,NorthWestLong,SouthEastLat,SouthEastLong")] LatLongGroupDO latLongGroupDO)
        {
            if (ModelState.IsValid)
            {
                db.LatLongGroups.Add(latLongGroupDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(latLongGroupDO);
        }

        // GET: LatLongGroupDOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatLongGroupDO latLongGroupDO = db.LatLongGroups.Find(id);
            if (latLongGroupDO == null)
            {
                return HttpNotFound();
            }
            return View(latLongGroupDO);
        }

        // POST: LatLongGroupDOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LatLongGroupDOID,NorthWestLat,NorthWestLong,SouthEastLat,SouthEastLong")] LatLongGroupDO latLongGroupDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(latLongGroupDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(latLongGroupDO);
        }

        // GET: LatLongGroupDOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LatLongGroupDO latLongGroupDO = db.LatLongGroups.Find(id);
            if (latLongGroupDO == null)
            {
                return HttpNotFound();
            }
            return View(latLongGroupDO);
        }

        // POST: LatLongGroupDOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LatLongGroupDO latLongGroupDO = db.LatLongGroups.Find(id);
            db.LatLongGroups.Remove(latLongGroupDO);
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
