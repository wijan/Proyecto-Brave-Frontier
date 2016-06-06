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
    public class LSController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LS
        public ActionResult Index()
        {
            var lS = db.LS.Include(l => l.Personaje);
            return View(lS.ToList());
        }

        // GET: LS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LS lS = db.LS.Find(id);
            if (lS == null)
            {
                return HttpNotFound();
            }
            return View(lS);
        }

        // GET: LS/Create
        public ActionResult Create(int? PersonajeID)
        {
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre");
            return View();
        }

        // POST: LS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Desc,PersonajeID")] LS lS)
        {
            if (ModelState.IsValid)
            {
                db.LS.Add(lS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", lS.PersonajeID);
            return View(lS);
        }

        // GET: LS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LS lS = db.LS.Find(id);
            if (lS == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", lS.PersonajeID);
            return View(lS);
        }

        // POST: LS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Desc,PersonajeID")] LS lS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", lS.PersonajeID);
            return View(lS);
        }

        // GET: LS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LS lS = db.LS.Find(id);
            if (lS == null)
            {
                return HttpNotFound();
            }
            return View(lS);
        }

        // POST: LS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LS lS = db.LS.Find(id);
            db.LS.Remove(lS);
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
