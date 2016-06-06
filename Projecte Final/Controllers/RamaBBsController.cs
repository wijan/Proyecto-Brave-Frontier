using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projecte_Final.Models;

namespace Projecte_Final.Controllers
{
    public class RamaBBsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RamaBBs
        public ActionResult Index()
        {
            return View(db.RamaBB.ToList());
        }

        // GET: RamaBBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RamaBB ramaBB = db.RamaBB.Find(id);
            if (ramaBB == null)
            {
                return HttpNotFound();
            }
            return View(ramaBB);
        }

        // GET: RamaBBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RamaBBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NombreRamaBB")] RamaBB ramaBB)
        {
            if (ModelState.IsValid)
            {
                db.RamaBB.Add(ramaBB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ramaBB);
        }

        // GET: RamaBBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RamaBB ramaBB = db.RamaBB.Find(id);
            if (ramaBB == null)
            {
                return HttpNotFound();
            }
            return View(ramaBB);
        }

        // POST: RamaBBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NombreRamaBB")] RamaBB ramaBB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ramaBB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ramaBB);
        }

        // GET: RamaBBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RamaBB ramaBB = db.RamaBB.Find(id);
            if (ramaBB == null)
            {
                return HttpNotFound();
            }
            return View(ramaBB);
        }

        // POST: RamaBBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RamaBB ramaBB = db.RamaBB.Find(id);
            db.RamaBB.Remove(ramaBB);
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
