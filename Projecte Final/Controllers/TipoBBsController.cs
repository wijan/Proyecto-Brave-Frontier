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
    public class TipoBBsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoBBs
        public ActionResult Index()
        {
            return View(db.TipoBB.ToList());
        }

        // GET: TipoBBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBB tipoBB = db.TipoBB.Find(id);
            if (tipoBB == null)
            {
                return HttpNotFound();
            }
            return View(tipoBB);
        }

        // GET: TipoBBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoBBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoID,NombreTipoBB")] TipoBB tipoBB)
        {
            if (ModelState.IsValid)
            {
                db.TipoBB.Add(tipoBB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoBB);
        }

        // GET: TipoBBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBB tipoBB = db.TipoBB.Find(id);
            if (tipoBB == null)
            {
                return HttpNotFound();
            }
            return View(tipoBB);
        }

        // POST: TipoBBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoID,NombreTipoBB")] TipoBB tipoBB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoBB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoBB);
        }

        // GET: TipoBBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoBB tipoBB = db.TipoBB.Find(id);
            if (tipoBB == null)
            {
                return HttpNotFound();
            }
            return View(tipoBB);
        }

        // POST: TipoBBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoBB tipoBB = db.TipoBB.Find(id);
            db.TipoBB.Remove(tipoBB);
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
