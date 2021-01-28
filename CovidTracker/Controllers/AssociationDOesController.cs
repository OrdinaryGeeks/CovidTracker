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
    public class AssociationDOesController : Controller
    {
        private DOContext db = new DOContext();

        // GET: AssociationDOes
        public ActionResult Index()
        {
            return View(db.Associations.ToList());
        }

        // GET: AssociationDOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationDO associationDO = db.Associations.Find(id);
            if (associationDO == null)
            {
                return HttpNotFound();
            }
            return View(associationDO);
        }

        // GET: AssociationDOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssociationDOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssociationDOID,TimeBlockID,LatLongGroupID")] AssociationDO associationDO)
        {
            if (ModelState.IsValid)
            {
                db.Associations.Add(associationDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(associationDO);
        }

        // GET: AssociationDOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationDO associationDO = db.Associations.Find(id);
            if (associationDO == null)
            {
                return HttpNotFound();
            }
            return View(associationDO);
        }

        // POST: AssociationDOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssociationDOID,TimeBlockID,LatLongGroupID")] AssociationDO associationDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associationDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(associationDO);
        }

        // GET: AssociationDOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociationDO associationDO = db.Associations.Find(id);
            if (associationDO == null)
            {
                return HttpNotFound();
            }
            return View(associationDO);
        }

        // POST: AssociationDOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssociationDO associationDO = db.Associations.Find(id);
            db.Associations.Remove(associationDO);
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
