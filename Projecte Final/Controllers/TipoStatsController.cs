using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projecte_Final.Models;
using Newtonsoft.Json;

namespace Projecte_Final.Controllers
{
    public class TipoStatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TipoStats
        public ActionResult Index()
        {
            return View(db.TipoStats.ToList());
        }

        // GET: TipoStats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoStat tipoStat = db.TipoStats.Find(id);
            if (tipoStat == null)
            {
                return HttpNotFound();
            }
            return View(tipoStat);
        }

        public ActionResult DetailsAngular(int? id)
        {
            TipoStat tipoStat = db.TipoStats.Find(id);
            var tipoStatAngular = JsonConvert.SerializeObject(tipoStat, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return Json(tipoStat, JsonRequestBehavior.AllowGet);

        }

        // GET: TipoStats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDStat,Tipo")] TipoStat tipoStat)
        {
            if (ModelState.IsValid)
            {
                db.TipoStats.Add(tipoStat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoStat);
        }

        // GET: TipoStats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoStat tipoStat = db.TipoStats.Find(id);
            if (tipoStat == null)
            {
                return HttpNotFound();
            }
            return View(tipoStat);
        }

        // POST: TipoStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDStat,Tipo")] TipoStat tipoStat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoStat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoStat);
        }

        // GET: TipoStats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoStat tipoStat = db.TipoStats.Find(id);
            if (tipoStat == null)
            {
                return HttpNotFound();
            }
            return View(tipoStat);
        }

        // POST: TipoStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoStat tipoStat = db.TipoStats.Find(id);
            db.TipoStats.Remove(tipoStat);
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
