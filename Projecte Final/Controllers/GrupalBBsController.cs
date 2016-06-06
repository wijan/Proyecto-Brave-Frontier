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
    public class GrupalBBsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GrupalBBs
        public ActionResult Index()
        {
            return View(db.GrupalBB.ToList());
        }

        // GET: GrupalBBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupalBB grupalBB = db.GrupalBB.Find(id);
            if (grupalBB == null)
            {
                return HttpNotFound();
            }
            return View(grupalBB);
        }

        // GET: GrupalBBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupalBBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NombreGrupal")] GrupalBB grupalBB)
        {
            if (ModelState.IsValid)
            {
                db.GrupalBB.Add(grupalBB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupalBB);
        }

        // GET: GrupalBBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupalBB grupalBB = db.GrupalBB.Find(id);
            if (grupalBB == null)
            {
                return HttpNotFound();
            }
            return View(grupalBB);
        }

        // POST: GrupalBBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NombreGrupal")] GrupalBB grupalBB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupalBB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupalBB);
        }

        // GET: GrupalBBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupalBB grupalBB = db.GrupalBB.Find(id);
            if (grupalBB == null)
            {
                return HttpNotFound();
            }
            return View(grupalBB);
        }

        // POST: GrupalBBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupalBB grupalBB = db.GrupalBB.Find(id);
            db.GrupalBB.Remove(grupalBB);
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
