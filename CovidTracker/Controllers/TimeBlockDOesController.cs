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
    public class TimeBlockDOesController : Controller
    {
        private DOContext db = new DOContext();

        // GET: TimeBlockDOes
        public ActionResult Index()
        {
            return View(db.TimeBlocks.ToList());
        }

        // GET: TimeBlockDOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeBlockDO timeBlockDO = db.TimeBlocks.Find(id);
            if (timeBlockDO == null)
            {
                return HttpNotFound();
            }
            return View(timeBlockDO);
        }

        // GET: TimeBlockDOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeBlockDOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeBlockDOID,Begin,End")] TimeBlockDO timeBlockDO)
        {
            if (ModelState.IsValid)
            {
                db.TimeBlocks.Add(timeBlockDO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeBlockDO);
        }

        // GET: TimeBlockDOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeBlockDO timeBlockDO = db.TimeBlocks.Find(id);
            if (timeBlockDO == null)
            {
                return HttpNotFound();
            }
            return View(timeBlockDO);
        }

        // POST: TimeBlockDOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeBlockDOID,Begin,End")] TimeBlockDO timeBlockDO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeBlockDO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeBlockDO);
        }

        // GET: TimeBlockDOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeBlockDO timeBlockDO = db.TimeBlocks.Find(id);
            if (timeBlockDO == null)
            {
                return HttpNotFound();
            }
            return View(timeBlockDO);
        }

        // POST: TimeBlockDOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeBlockDO timeBlockDO = db.TimeBlocks.Find(id);
            db.TimeBlocks.Remove(timeBlockDO);
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
