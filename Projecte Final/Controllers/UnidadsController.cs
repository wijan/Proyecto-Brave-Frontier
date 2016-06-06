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
    public class UnidadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Unidads
        public ActionResult Index()
        {
            var userID = User.Identity.GetUserId();
            var unidad = db.Unidad.Include(u => u.Esfera1).Include(u => u.Esfera2).Include(u => u.Personaje).Include(u => u.Tipo).Include(u => u.Usuario);
            var unidades = unidad.Where(x => x.UsuarioID == userID).ToList();
            List<string> l = new List<string>();
            foreach( var u in unidades )
            {
                l.Add(u.Personaje.Nombre);
            }
            return View(unidades);
        }

        // GET: Unidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidad unidad = db.Unidad.Find(id);
            if (unidad == null)
            {
                return HttpNotFound();
            }
            LS ls = db.LS.Where(x => x.PersonajeID == unidad.PersonajeID).FirstOrDefault();
            ES es = db.ES.Where(x => x.PersonajeID == unidad.PersonajeID).FirstOrDefault();
            BB bb = db.BB.Where(x => x.PersonajeID == unidad.PersonajeID && x.TipoBBID == 1).FirstOrDefault();
            BB sbb = db.BB.Where(x => x.PersonajeID == unidad.PersonajeID && x.TipoBBID == 2).FirstOrDefault();
            BB ubb = db.BB.Where(x => x.PersonajeID == unidad.PersonajeID && x.TipoBBID == 3).FirstOrDefault();
            Stats stats = db.Stats.Where(x => x.PersonajeID == unidad.PersonajeID && x.TipoPersonajeID == unidad.TipoID).FirstOrDefault();
            ViewBag.LS = ls;
            ViewBag.ES = es;
            ViewBag.BB = bb;
            ViewBag.SBB = sbb;
            ViewBag.UBB = ubb;
            ViewBag.stats = stats;
            return View(unidad);
        }

        // GET: Unidads/Create
        public ActionResult AsignarEsfera(int? nEsfera, int? idUnidad)
        {
            ViewBag.nEsfera = nEsfera;
            ViewBag.idUnidad = idUnidad;
            var misEsferitas = db.misEsferas.Include(m => m.Esfera).Include(m => m.Usuario);
            ViewBag.misEsferitas = misEsferitas;
            return View();
        }
        public ActionResult AsignacionEsfera(int? idEsfera, int? nEsfera, int? idUnidad)
        {
            Unidad unidad = db.Unidad.Find(idUnidad);
            switch (nEsfera)
            {
                case 1:
                    unidad.Esfera1ID = idEsfera;
                    break;
                case 2:
                    unidad.Esfera2ID = idEsfera;
                    break;
            }
            db.SaveChanges();
            return RedirectToAction("Details", new { id = idUnidad });
        }

        

        public ActionResult Create()
        {
            var personaje = db.Personaje.Include(p => p.Elemento).Include(p => p.ES).Include(p => p.Genero).Include(p => p.Gif).Include(p => p.GifAtaque).Include(p => p.Icono).Include(p => p.Imagen).Include(p => p.LS).Include(p => p.PostEvo).Include(p => p.PreEvo);
            ViewBag.personajes = personaje.ToList();
            return View();
        }

        // POST: Unidads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PersonajeID,TipoID,Esfera1ID,Esfera2ID")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                db.Unidad.Add(unidad);
                unidad.UsuarioID = User.Identity.GetUserId();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Esfera1ID = new SelectList(db.Objeto, "ID", "NomObjeto", unidad.Esfera1ID);
            ViewBag.Esfera2ID = new SelectList(db.Objeto, "ID", "NomObjeto", unidad.Esfera2ID);
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", unidad.PersonajeID);
            ViewBag.TipoID = new SelectList(db.TipoStats, "IDStat", "Tipo", unidad.TipoID);
            return View(unidad);
        }

        public ActionResult CrearUnidad(int id)
        {
            Unidad unidad = new Unidad();
            unidad.PersonajeID = id;
            unidad.Personaje = db.Personaje.Find(id);
            unidad.UsuarioID = User.Identity.GetUserId();
            db.Unidad.Add(unidad);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditarTipo(int? idTipo, int? idUnidad)
        {
            if(idUnidad == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidad unidad = db.Unidad.Find(idUnidad);
            if (unidad == null)
            {
                return HttpNotFound();
            }
            unidad.UsuarioID = User.Identity.GetUserId();
            unidad.TipoID = idTipo;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Unidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidad unidad = db.Unidad.Find(id);
            if (unidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.Esfera1ID = new SelectList(db.Objeto, "ID", "NomObjeto", unidad.Esfera1ID);
            ViewBag.Esfera2ID = new SelectList(db.Objeto, "ID", "NomObjeto", unidad.Esfera2ID);
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", unidad.PersonajeID);
            ViewBag.TipoID = new SelectList(db.TipoStats, "IDStat", "Tipo", unidad.TipoID);
            return View(unidad);
        }

        // POST: Unidads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TipoID,Esfera1ID,Esfera2ID")] Unidad unidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidad).State = EntityState.Modified;
                db.Entry(unidad).Property(x => x.PersonajeID).IsModified = false;
                unidad.UsuarioID = User.Identity.GetUserId();

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Esfera1ID = new SelectList(db.Objeto, "ID", "NomObjeto", unidad.Esfera1ID);
            ViewBag.Esfera2ID = new SelectList(db.Objeto, "ID", "NomObjeto", unidad.Esfera2ID);
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", unidad.PersonajeID);
            ViewBag.TipoID = new SelectList(db.TipoStats, "IDStat", "Tipo", unidad.TipoID);
            return View(unidad);
        }

        // GET: Unidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unidad unidad = db.Unidad.Find(id);
            if (unidad == null)
            {
                return HttpNotFound();
            }
            return View(unidad);
        }

        // POST: Unidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unidad unidad = db.Unidad.Find(id);
            db.Unidad.Remove(unidad);
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
