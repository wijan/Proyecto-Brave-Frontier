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
    public class ElementoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Elementoes
        public ActionResult Index()
        {
            var elemento = db.Elemento.Include(e => e.DebilVS).Include(e => e.FuerteVS).Include(e => e.Icono);
            return View(elemento.ToList());
        }

        // GET: Elementoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento elemento = db.Elemento.Find(id);
            if (elemento == null)
            {
                return HttpNotFound();
            }
            return View(elemento);
        }
        public ActionResult DetailsAngular(int? id)
        {
            Elemento elemento = db.Elemento.Find(id);
            var elementoAngular = JsonConvert.SerializeObject(elemento, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return Json(elemento, JsonRequestBehavior.AllowGet);
        }


        // GET: Elementoes/Create
        public ActionResult Create()
        {
            ViewBag.DebilVSID = new SelectList(db.Elemento, "ElementoID", "Nombre");
            ViewBag.FuerteVSID = new SelectList(db.Elemento, "ElementoID", "Nombre");
            ViewBag.IconoID = new SelectList(db.File, "FileId", "FileName");
            return View();
        }

        // POST: Elementoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ElementoID,Nombre,DebilVSID,FuerteVSID,IconoID")] Elemento elemento, HttpPostedFileBase uploadIcono = null)
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
                    elemento.Icono = icono;
                }
                db.Elemento.Add(elemento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DebilVSID = new SelectList(db.Elemento, "ElementoID", "Nombre", elemento.DebilVSID);
            ViewBag.FuerteVSID = new SelectList(db.Elemento, "ElementoID", "Nombre", elemento.FuerteVSID);
            ViewBag.IconoID = new SelectList(db.File, "FileId", "FileName", elemento.IconoID);
            return View(elemento);
        }

        // GET: Elementoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento elemento = db.Elemento.Find(id);
            if (elemento == null)
            {
                return HttpNotFound();
            }
            ViewBag.DebilVSID = new SelectList(db.Elemento, "ElementoID", "Nombre", elemento.DebilVSID);
            ViewBag.FuerteVSID = new SelectList(db.Elemento, "ElementoID", "Nombre", elemento.FuerteVSID);
            ViewBag.IconoID = new SelectList(db.File, "FileId", "FileName", elemento.IconoID);
            return View(elemento);
        }

        // POST: Elementoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ElementoID,Nombre,DebilVSID,FuerteVSID,IconoID")] Elemento elemento, HttpPostedFileBase uploadIcono= null)
        {
            if (ModelState.IsValid)
            {
                if (uploadIcono != null && uploadIcono.ContentLength > 0)
                {
                    if (elemento.Icono != null)
                    {
                        db.File.Remove(elemento.Icono);
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
                    elemento.Icono = icono;
                }
                db.Entry(elemento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DebilVSID = new SelectList(db.Elemento, "ElementoID", "Nombre", elemento.DebilVSID);
            ViewBag.FuerteVSID = new SelectList(db.Elemento, "ElementoID", "Nombre", elemento.FuerteVSID);
            ViewBag.IconoID = new SelectList(db.File, "FileId", "FileName", elemento.IconoID);
            return View(elemento);
        }

        // GET: Elementoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elemento elemento = db.Elemento.Find(id);
            if (elemento == null)
            {
                return HttpNotFound();
            }
            return View(elemento);
        }

        // POST: Elementoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elemento elemento = db.Elemento.Find(id);
            db.Elemento.Remove(elemento);
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
