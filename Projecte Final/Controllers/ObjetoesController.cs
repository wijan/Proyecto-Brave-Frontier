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
    public class ObjetoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Objetoes
        public ActionResult Index()
        {
            var objeto = db.Objeto.Include(o => o.Crafteo).Include(o => o.Icona);
            return View(objeto.ToList());
        }

        // GET: Objetoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objeto objeto = db.Objeto.Find(id);
            if (objeto == null)
            {
                return HttpNotFound();
            }
            return View(objeto);
        }

        // GET: Objetoes/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Crafteo, "Craft", "Craft");
            ViewBag.IconaID = new SelectList(db.File, "FileId", "FileName");
            return View();
        }

        // POST: Objetoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NomObjeto,IconaID,Descripcion")] Objeto objeto)
        {
            if (ModelState.IsValid)
            {
                db.Objeto.Add(objeto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Crafteo, "Craft", "Craft", objeto.ID);
            ViewBag.IconaID = new SelectList(db.File, "FileId", "FileName", objeto.IconaID);
            return View(objeto);
        }

        // GET: Objetoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objeto objeto = db.Objeto.Find(id);
            if (objeto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Crafteo, "Craft", "Craft", objeto.ID);
            ViewBag.IconaID = new SelectList(db.File, "FileId", "FileName", objeto.IconaID);
            return View(objeto);
        }

        // POST: Objetoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NomObjeto,IconaID,Descripcion")] Objeto objeto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objeto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Crafteo, "Craft", "Craft", objeto.ID);
            ViewBag.IconaID = new SelectList(db.File, "FileId", "FileName", objeto.IconaID);
            return View(objeto);
        }

        // GET: Objetoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objeto objeto = db.Objeto.Find(id);
            if (objeto == null)
            {
                return HttpNotFound();
            }
            return View(objeto);
        }

        // POST: Objetoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objeto objeto = db.Objeto.Find(id);
            db.Objeto.Remove(objeto);
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
