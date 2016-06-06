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
    public class misEsferasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: misEsferas
        public ActionResult Index()
        {
            var misEsferas = db.misEsferas.Include(m => m.Esfera).Include(m => m.Usuario);
            return View(misEsferas.ToList());
        }

        // GET: misEsferas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            misEsferas misEsferas = db.misEsferas.Find(id);
            if (misEsferas == null)
            {
                return HttpNotFound();
            }
            return View(misEsferas);
        }

        // GET: misEsferas/Create
        public ActionResult Create()
        {
            var esferas = db.Esfera.Include(e => e.Crafteo).Include(e => e.Icona).Include(e => e.TipoEsfera);
            ViewBag.esferas = esferas;
            return View();
        }

        // POST: misEsferas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EsferaID,UsuarioID")] misEsferas misEsferas)
        {
            if (ModelState.IsValid)
            {
                misEsferas.UsuarioID = User.Identity.GetUserId();
                db.misEsferas.Add(misEsferas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EsferaID = new SelectList(db.Objeto, "ID", "NomObjeto", misEsferas.EsferaID);
            return View(misEsferas);
        }

        public ActionResult CrearEsfera(int id)
        {
            misEsferas miEsfera = new misEsferas();
            miEsfera.EsferaID = id;
            miEsfera.UsuarioID = User.Identity.GetUserId();
            db.misEsferas.Add(miEsfera);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: misEsferas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            misEsferas misEsferas = db.misEsferas.Find(id);
            if (misEsferas == null)
            {
                return HttpNotFound();
            }
            ViewBag.EsferaID = new SelectList(db.Objeto, "ID", "NomObjeto", misEsferas.EsferaID);
            return View(misEsferas);
        }

        // POST: misEsferas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EsferaID,UsuarioID")] misEsferas misEsferas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(misEsferas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EsferaID = new SelectList(db.Objeto, "ID", "NomObjeto", misEsferas.EsferaID);
            return View(misEsferas);
        }

        // GET: misEsferas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            misEsferas misEsferas = db.misEsferas.Find(id);
            if (misEsferas == null)
            {
                return HttpNotFound();
            }
            return View(misEsferas);
        }

        // POST: misEsferas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            misEsferas misEsferas = db.misEsferas.Find(id);
            db.misEsferas.Remove(misEsferas);
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
