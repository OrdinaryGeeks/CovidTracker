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
    public class TimeBlocksController : Controller
    {
        private DBContext db = new DBContext();

        // GET: TimeBlocks
        public ActionResult Index()
        {
            return View(db.TimeBlocks.ToList());
        }

        // GET: TimeBlocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeBlock timeBlock = db.TimeBlocks.Find(id);
            if (timeBlock == null)
            {
                return HttpNotFound();
            }
            return View(timeBlock);
        }

        // GET: TimeBlocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeBlocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeBlockID,Begin,End")] TimeBlock timeBlock)
        {
            if (ModelState.IsValid)
            {
                db.TimeBlocks.Add(timeBlock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeBlock);
        }

        // GET: TimeBlocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeBlock timeBlock = db.TimeBlocks.Find(id);
            if (timeBlock == null)
            {
                return HttpNotFound();
            }
            return View(timeBlock);
        }

        // POST: TimeBlocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeBlockID,Begin,End")] TimeBlock timeBlock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeBlock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeBlock);
        }

        // GET: TimeBlocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeBlock timeBlock = db.TimeBlocks.Find(id);
            if (timeBlock == null)
            {
                return HttpNotFound();
            }
            return View(timeBlock);
        }

        // POST: TimeBlocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeBlock timeBlock = db.TimeBlocks.Find(id);
            db.TimeBlocks.Remove(timeBlock);
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
