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
    public class EfectoEsferasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EfectoEsferas
        public ActionResult Index()
        {
            return View(db.EfectoEsfera.ToList());
        }

        // GET: EfectoEsferas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EfectoEsfera efectoEsfera = db.EfectoEsfera.Find(id);
            if (efectoEsfera == null)
            {
                return HttpNotFound();
            }
            return View(efectoEsfera);
        }

        // GET: EfectoEsferas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EfectoEsferas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EfectoID,Descripcion")] EfectoEsfera efectoEsfera)
        {
            if (ModelState.IsValid)
            {
                db.EfectoEsfera.Add(efectoEsfera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(efectoEsfera);
        }

        // GET: EfectoEsferas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EfectoEsfera efectoEsfera = db.EfectoEsfera.Find(id);
            if (efectoEsfera == null)
            {
                return HttpNotFound();
            }
            return View(efectoEsfera);
        }

        // POST: EfectoEsferas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EfectoID,Descripcion")] EfectoEsfera efectoEsfera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(efectoEsfera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(efectoEsfera);
        }

        // GET: EfectoEsferas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EfectoEsfera efectoEsfera = db.EfectoEsfera.Find(id);
            if (efectoEsfera == null)
            {
                return HttpNotFound();
            }
            return View(efectoEsfera);
        }

        // POST: EfectoEsferas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EfectoEsfera efectoEsfera = db.EfectoEsfera.Find(id);
            db.EfectoEsfera.Remove(efectoEsfera);
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
