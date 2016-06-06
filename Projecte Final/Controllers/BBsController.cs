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
    public class BBsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BBs
        public ActionResult Index()
        {
            var bB = db.BB.Include(b => b.GrupalBB).Include(b => b.Personaje).Include(b => b.RamaBB).Include(b => b.TipoBB);
            return View(bB.ToList());
        }

        // GET: BBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BB bB = db.BB.Find(id);
            if (bB == null)
            {
                return HttpNotFound();
            }
            return View(bB);
        }

        // GET: BBs/Create
        public ActionResult Create(int? PersonajeID, int? TipoBBID)
        {
            ViewBag.GrupalBBID = new SelectList(db.GrupalBB, "ID", "NombreGrupal");
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre");
            ViewBag.RamaBBID = new SelectList(db.RamaBB, "ID", "NombreRamaBB");
            ViewBag.TipoBBID = new SelectList(db.TipoBB, "TipoID", "NombreTipoBB");
            return View();
        }

        // POST: BBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NombreBB,BBDesc,RamaBBID,TipoBBID,GrupalBBID,NhitsBB,DCBB,CosteBB,MultiplicadorBB,PersonajeID")] BB bB)
        {
            if (ModelState.IsValid)
            {
                db.BB.Add(bB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GrupalBBID = new SelectList(db.GrupalBB, "ID", "NombreGrupal", bB.GrupalBBID);
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", bB.PersonajeID);
            ViewBag.RamaBBID = new SelectList(db.RamaBB, "ID", "NombreRamaBB", bB.RamaBBID);
            ViewBag.TipoBBID = new SelectList(db.TipoBB, "TipoID", "NombreTipoBB", bB.TipoBBID);
            return View(bB);
        }

        // GET: BBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BB bB = db.BB.Find(id);
            if (bB == null)
            {
                return HttpNotFound();
            }
            ViewBag.GrupalBBID = new SelectList(db.GrupalBB, "ID", "NombreGrupal", bB.GrupalBBID);
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", bB.PersonajeID);
            ViewBag.RamaBBID = new SelectList(db.RamaBB, "ID", "NombreRamaBB", bB.RamaBBID);
            ViewBag.TipoBBID = new SelectList(db.TipoBB, "TipoID", "NombreTipoBB", bB.TipoBBID);
            return View(bB);
        }

        // POST: BBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NombreBB,BBDesc,RamaBBID,TipoBBID,GrupalBBID,NhitsBB,DCBB,CosteBB,MultiplicadorBB,PersonajeID")] BB bB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GrupalBBID = new SelectList(db.GrupalBB, "ID", "NombreGrupal", bB.GrupalBBID);
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", bB.PersonajeID);
            ViewBag.RamaBBID = new SelectList(db.RamaBB, "ID", "NombreRamaBB", bB.RamaBBID);
            ViewBag.TipoBBID = new SelectList(db.TipoBB, "TipoID", "NombreTipoBB", bB.TipoBBID);
            return View(bB);
        }

        // GET: BBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BB bB = db.BB.Find(id);
            if (bB == null)
            {
                return HttpNotFound();
            }
            return View(bB);
        }

        // POST: BBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BB bB = db.BB.Find(id);
            db.BB.Remove(bB);
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
