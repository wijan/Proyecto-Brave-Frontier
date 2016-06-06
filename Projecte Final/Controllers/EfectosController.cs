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
    public class EfectosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Efectos
        public ActionResult Index()
        {
            var efectos = db.Efectos.Include(e => e.BB);
            return View(efectos.ToList());
        }

        // GET: Efectos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Efectos efectos = db.Efectos.Find(id);
            if (efectos == null)
            {
                return HttpNotFound();
            }
            return View(efectos);
        }

        // GET: Efectos/Create
        public ActionResult Create()
        {
            ViewBag.BBID = new SelectList(db.BB, "ID", "NombreBB");
            return View();
        }

        // POST: Efectos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EfectoID,AtkUp,DefUp,RecUp,HpUp,CritRate,CritDmg,BBDmg,SparkDmg,CargaBB,CargaBBTurno,CargaBBRecibir,VelocidadBB,CargaBBSpark,CargaOD,Mitigacion,Barrera,Heal,HealTurno,DropCB,DropCC,DropItems,DañoAlAfligir,IgnDef,DoT,AumentoHits,Revivir,BBAtacar,BBCritico,ReduccionCosteBB,ReduccionUsoBB,RecargaGuard,DropZel,DropKarma,EfectividadCC,ReduccionDmgGuard,MitigacionElemental,EstadosAlterados,Antiestados,AtkDown,DefDown2,VulnerabilidadSpark,AñadirElementos,DebilidadElemental,Angel,ReduccionDaño,BBID")] Efectos efectos)
        {
            if (ModelState.IsValid)
            {
                db.Efectos.Add(efectos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BBID = new SelectList(db.BB, "ID", "NombreBB", efectos.BBID);
            return View(efectos);
        }

        // GET: Efectos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Efectos efectos = db.Efectos.Find(id);
            if (efectos == null)
            {
                return HttpNotFound();
            }
            ViewBag.BBID = new SelectList(db.BB, "ID", "NombreBB", efectos.BBID);
            return View(efectos);
        }

        // POST: Efectos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EfectoID,AtkUp,DefUp,RecUp,HpUp,CritRate,CritDmg,BBDmg,SparkDmg,CargaBB,CargaBBTurno,CargaBBRecibir,VelocidadBB,CargaBBSpark,CargaOD,Mitigacion,Barrera,Heal,HealTurno,DropCB,DropCC,DropItems,DañoAlAfligir,IgnDef,DoT,AumentoHits,Revivir,BBAtacar,BBCritico,ReduccionCosteBB,ReduccionUsoBB,RecargaGuard,DropZel,DropKarma,EfectividadCC,ReduccionDmgGuard,MitigacionElemental,EstadosAlterados,Antiestados,AtkDown,DefDown2,VulnerabilidadSpark,AñadirElementos,DebilidadElemental,Angel,ReduccionDaño,BBID")] Efectos efectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(efectos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BBID = new SelectList(db.BB, "ID", "NombreBB", efectos.BBID);
            return View(efectos);
        }

        // GET: Efectos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Efectos efectos = db.Efectos.Find(id);
            if (efectos == null)
            {
                return HttpNotFound();
            }
            return View(efectos);
        }

        // POST: Efectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Efectos efectos = db.Efectos.Find(id);
            db.Efectos.Remove(efectos);
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
