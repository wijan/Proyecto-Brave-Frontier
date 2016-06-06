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
    public class ESController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ES
        public ActionResult Index()
        {
            return View(db.ES.ToList());
        }

        // GET: ES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ES eS = db.ES.Find(id);
            if (eS == null)
            {
                return HttpNotFound();
            }
            return View(eS);
        }

        // GET: ES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ESID,Desc")] ES eS)
        {
            if (ModelState.IsValid)
            {
                db.ES.Add(eS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eS);
        }

        // GET: ES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ES eS = db.ES.Find(id);
            if (eS == null)
            {
                return HttpNotFound();
            }
            return View(eS);
        }

        // POST: ES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ESID,Desc")] ES eS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eS);
        }

        // GET: ES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ES eS = db.ES.Find(id);
            if (eS == null)
            {
                return HttpNotFound();
            }
            return View(eS);
        }

        // POST: ES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ES eS = db.ES.Find(id);
            db.ES.Remove(eS);
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
