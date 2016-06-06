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
    public class TipoEsferasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoEsferas
        public ActionResult Index()
        {
            return View(db.TipoEsfera.ToList());
        }

        // GET: TipoEsferas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEsfera tipoEsfera = db.TipoEsfera.Find(id);
            if (tipoEsfera == null)
            {
                return HttpNotFound();
            }
            return View(tipoEsfera);
        }

        // GET: TipoEsferas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEsferas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NombreTipoEsfera")] TipoEsfera tipoEsfera)
        {
            if (ModelState.IsValid)
            {
                db.TipoEsfera.Add(tipoEsfera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoEsfera);
        }

        // GET: TipoEsferas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEsfera tipoEsfera = db.TipoEsfera.Find(id);
            if (tipoEsfera == null)
            {
                return HttpNotFound();
            }
            return View(tipoEsfera);
        }

        // POST: TipoEsferas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NombreTipoEsfera")] TipoEsfera tipoEsfera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoEsfera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoEsfera);
        }

        // GET: TipoEsferas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEsfera tipoEsfera = db.TipoEsfera.Find(id);
            if (tipoEsfera == null)
            {
                return HttpNotFound();
            }
            return View(tipoEsfera);
        }

        // POST: TipoEsferas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEsfera tipoEsfera = db.TipoEsfera.Find(id);
            db.TipoEsfera.Remove(tipoEsfera);
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
