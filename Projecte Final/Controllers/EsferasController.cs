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
    public class EsferasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Esferas
        public ActionResult Index()
        {
            var esfera = db.Esfera.Include(e => e.Crafteo).Include(e => e.Icona).Include(e => e.TipoEsfera);
            return View(esfera.ToList());
        }

        // GET: Esferas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esfera esfera = db.Esfera.Find(id);
            if (esfera == null)
            {
                return HttpNotFound();
            }
            return View(esfera);
        }

        // GET: Esferas/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(db.Crafteo, "Craft", "Craft");
            ViewBag.IconaID = new SelectList(db.File, "FileId", "FileName");
            ViewBag.TipoID = new SelectList(db.TipoEsfera, "ID", "NombreTipoEsfera");
            return View();
        }

        // POST: Esferas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NomObjeto,IconaID,Descripcion,TipoID")] Esfera esfera, HttpPostedFileBase uploadIcono = null)
        {
            if (ModelState.IsValid)
            {
                if (uploadIcono != null && uploadIcono.ContentLength > 0)
                {
                    var icono = new File
                    {
                        FileName = System.IO.Path.GetFileName(uploadIcono.FileName),
                        FileType = FileType.Avatar,
                        ContentType = uploadIcono.ContentType
                    };
                    db.File.Add(icono);
                    using (var reader = new System.IO.BinaryReader(uploadIcono.InputStream))
                    {
                        icono.Content = reader.ReadBytes(uploadIcono.ContentLength);
                    }
                    esfera.Icona = icono;
                }
                db.Objeto.Add(esfera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID = new SelectList(db.Crafteo, "Craft", "Craft", esfera.ID);
            ViewBag.IconaID = new SelectList(db.File, "FileId", "FileName", esfera.IconaID);
            ViewBag.TipoID = new SelectList(db.TipoEsfera, "ID", "NombreTipoEsfera", esfera.TipoID);
            return View(esfera);
        }

        // GET: Esferas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esfera esfera = db.Esfera.Find(id);
            if (esfera == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = new SelectList(db.Crafteo, "Craft", "Craft", esfera.ID);
            ViewBag.IconaID = new SelectList(db.File, "FileId", "FileName", esfera.IconaID);
            ViewBag.TipoID = new SelectList(db.TipoEsfera, "ID", "NombreTipoEsfera", esfera.TipoID);
            return View(esfera);
        }

        // POST: Esferas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NomObjeto,IconaID,Descripcion,TipoID")] Esfera esfera, HttpPostedFileBase uploadIcono = null)
        {
            if (ModelState.IsValid)
            {
                if (uploadIcono != null && uploadIcono.ContentLength > 0)
                {
                    if (esfera.Icona != null)
                    {
                        db.File.Remove(esfera.Icona);
                    }
                    var icono = new File
                    {
                        FileName = System.IO.Path.GetFileName(uploadIcono.FileName),
                        FileType = FileType.Avatar,
                        ContentType = uploadIcono.ContentType
                    };
                    db.File.Add(icono);
                    using (var reader = new System.IO.BinaryReader(uploadIcono.InputStream))
                    {
                        icono.Content = reader.ReadBytes(uploadIcono.ContentLength);
                    }
                    esfera.Icona = icono;
                }
                db.Entry(esfera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID = new SelectList(db.Crafteo, "Craft", "Craft", esfera.ID);
            ViewBag.IconaID = new SelectList(db.File, "FileId", "FileName", esfera.IconaID);
            ViewBag.TipoID = new SelectList(db.TipoEsfera, "ID", "NombreTipoEsfera", esfera.TipoID);
            return View(esfera);
        }

        // GET: Esferas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Esfera esfera = db.Esfera.Find(id);
            if (esfera == null)
            {
                return HttpNotFound();
            }
            return View(esfera);
        }

        // POST: Esferas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Esfera esfera = db.Esfera.Find(id);
            db.Objeto.Remove(esfera);
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
