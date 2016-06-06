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
    public class StatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stats
        public ActionResult Index()
        {
            var stats = db.Stats.Include(s => s.Personaje).Include(s => s.TipoPersonaje);
            return View(stats.ToList());
        }

        // GET: Stats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stats stats = db.Stats.Find(id);
            if (stats == null)
            {
                return HttpNotFound();
            }
            return View(stats);
        }

        // GET: Stats/Create
        public ActionResult Create(int? PersonajeID)
        {
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre");
            ViewBag.TipoPersonajeID = new SelectList(db.TipoStats, "IDStat", "Tipo");
            return View();
        }

        public ActionResult CreateStatsUnidad(int? PersonajeID, int? tipoPersonajeID, int? idUnidad)
        {
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre");
            ViewBag.TipoPersonajeID = new SelectList(db.TipoStats, "IDStat", "Tipo");
            ViewBag.idUnidad = idUnidad;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStatsUnidad([Bind(Include = "StatsID,PersonajeID,TipoPersonajeID,Hp,Ataque,Defensa,Recuperacion")] Stats stats)
        {
            if (ModelState.IsValid)
            {
                db.Stats.Add(stats);
                db.SaveChanges();
                return RedirectToAction("Index", "Unidads");
            }

            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", stats.PersonajeID);
            ViewBag.TipoPersonajeID = new SelectList(db.TipoStats, "IDStat", "Tipo", stats.TipoPersonajeID);
            return RedirectToAction("Details", "Personajes", new
            {
                id = stats.PersonajeID,
            });
        }



        // POST: Stats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatsID,PersonajeID,TipoPersonajeID,Hp,Ataque,Defensa,Recuperacion")] Stats stats)
        {
            if (ModelState.IsValid)
            {
                db.Stats.Add(stats);
                db.SaveChanges();
                return RedirectToAction("Details", "Personajes", new
                {
                    id = stats.PersonajeID,
                });
            }

            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", stats.PersonajeID);
            ViewBag.TipoPersonajeID = new SelectList(db.TipoStats, "IDStat", "Tipo", stats.TipoPersonajeID);
            return RedirectToAction("Details","Personajes", new
            {
                id = stats.PersonajeID,
            });
        }

        // GET: Stats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stats stats = db.Stats.Find(id);
            if (stats == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", stats.PersonajeID);
            ViewBag.TipoPersonajeID = new SelectList(db.TipoStats, "IDStat", "Tipo", stats.TipoPersonajeID);
            return View(stats);
        }

        // POST: Stats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatsID,PersonajeID,TipoPersonajeID,Hp,Ataque,Defensa,Recuperacion")] Stats stats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonajeID = new SelectList(db.Personaje, "Numero", "Nombre", stats.PersonajeID);
            ViewBag.TipoPersonajeID = new SelectList(db.TipoStats, "IDStat", "Tipo", stats.TipoPersonajeID);
            return View(stats);
        }

        // GET: Stats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stats stats = db.Stats.Find(id);
            if (stats == null)
            {
                return HttpNotFound();
            }
            return View(stats);
        }

        // POST: Stats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stats stats = db.Stats.Find(id);
            db.Stats.Remove(stats);
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
