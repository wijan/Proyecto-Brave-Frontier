using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projecte_Final.Models;
using Microsoft.AspNet.Identity;

namespace Projecte_Final.Controllers
{
    public class EquipoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Equipoes
        public ActionResult Index()
        {
            var equipo = db.Equipo.Include(e => e.Unidad1).Include(e => e.Unidad2).Include(e => e.Unidad3).Include(e => e.Unidad4).Include(e => e.Unidad5).Include(e => e.Unidad6).Include(e => e.Usuario);
            var userID = User.Identity.GetUserId();
            return View(equipo.Where(x => x.UsuarioID ==userID).ToList());
        }

        // GET: Equipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // GET: Equipoes/Create
        public ActionResult Create()
        {
            ViewBag.Unidad1ID = new SelectList(db.Unidad, "ID", "ID");
            ViewBag.Unidad2ID = new SelectList(db.Unidad, "ID", "ID");
            ViewBag.Unidad3ID = new SelectList(db.Unidad, "ID", "ID");
            ViewBag.Unidad4ID = new SelectList(db.Unidad, "ID", "ID");
            ViewBag.Unidad5ID = new SelectList(db.Unidad, "ID", "ID");
            ViewBag.Unidad6ID = new SelectList(db.Unidad, "ID", "ID");
            return View();
        }

        // POST: Equipoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipoID,Unidad1ID,Unidad2ID,Unidad3ID,Unidad4ID,Unidad5ID,Unidad6ID,UsuarioID")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Equipo.Add(equipo);
                equipo.UsuarioID = User.Identity.GetUserId();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Unidad1ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad1ID);
            ViewBag.Unidad2ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad2ID);
            ViewBag.Unidad3ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad3ID);
            ViewBag.Unidad4ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad4ID);
            ViewBag.Unidad5ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad5ID);
            ViewBag.Unidad6ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad6ID);
            return View(equipo);
        }

        // GET: Equipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Unidad1ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad1ID);
            ViewBag.Unidad2ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad2ID);
            ViewBag.Unidad3ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad3ID);
            ViewBag.Unidad4ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad4ID);
            ViewBag.Unidad5ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad5ID);
            ViewBag.Unidad6ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad6ID);
            return View(equipo);
        }

        // POST: Equipoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipoID,Unidad1ID,Unidad2ID,Unidad3ID,Unidad4ID,Unidad5ID,Unidad6ID")] Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipo).State = EntityState.Modified;
                equipo.UsuarioID = User.Identity.GetUserId();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Unidad1ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad1ID);
            ViewBag.Unidad2ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad2ID);
            ViewBag.Unidad3ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad3ID);
            ViewBag.Unidad4ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad4ID);
            ViewBag.Unidad5ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad5ID);
            ViewBag.Unidad6ID = new SelectList(db.Unidad, "ID", "ID", equipo.Unidad6ID);
            return View(equipo);
        }

        // GET: Equipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipo equipo = db.Equipo.Find(id);
            if (equipo == null)
            {
                return HttpNotFound();
            }
            return View(equipo);
        }

        // POST: Equipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipo equipo = db.Equipo.Find(id);
            db.Equipo.Remove(equipo);
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
