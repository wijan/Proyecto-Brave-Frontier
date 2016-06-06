using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projecte_Final.Models;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace Projecte_Final.Controllers
{
    public class PersonajesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personajes
        public ActionResult Index()
        {
            var personaje = db.Personaje.Include(p => p.Elemento).Include(p => p.Genero).Include(p => p.Gif).Include(p => p.GifAtaque).Include(p => p.Icono).Include(p => p.Imagen).Include(p => p.PostEvo).Include(p => p.PreEvo);
            return View(personaje.ToList());
        }


        public ActionResult IndexAngular()
        {
            var per = db.Personaje.Include(p => p.Elemento).Include(p => p.Genero).Include(p => p.GifAtaque).Include(p => p.Icono).Include(p => p.Imagen).Include(p => p.PostEvo).Include(p => p.PreEvo);
            var personajes = per.ToList();
            List<PersonajeAngular> personajesAngular = new List<PersonajeAngular>();
            foreach(Personaje personaje in personajes)
            {
                PersonajeAngular personajeAngular = new PersonajeAngular
                {
                    Numero = personaje.Numero,
                    Nombre = personaje.Nombre,
                    NivelMax = personaje.NivelMax,
                    Estrellas = personaje.Estrellas,
                    Coste = personaje.Coste,
                    Elemento = personaje.Elemento.Nombre,
                    Genero = personaje.Genero.NombreGenero,
                    NHits = personaje.NHits,
                    DC = personaje.DC,
                    ImpHP = personaje.ImpHP,
                    ImpAtk = personaje.ImpAtk,
                    ImpDef = personaje.ImpDef,
                    ImpRec = personaje.ImpRec,
                    PreEvoNum = personaje.PreEvoNum,
                    PostEvoNum = personaje.PostEvoNum,
                    ImagenID = personaje.ImagenID,
                    IconoID = personaje.IconoID,
                    GifID = personaje.GifID,
                    GifAtaqueID = personaje.GifAtaqueID,
                    Healer = personaje.Healer,
                    Mitigador = personaje.Mitigador,
                    Antiestados = personaje.Antiestados,
                    BBFill = personaje.BBFill,
                    AumentoDrop = personaje.AumentoDrop,
                    Sparker = personaje.Sparker,
                    Criticos = personaje.Criticos,
                    AumentoStats=personaje.AumentoStats,
                    Cerca = personaje.Numero+personaje.Nombre,
                    IAArena=personaje.IAArena,
                };
                personajesAngular.Add(personajeAngular);
            }
            



            var personajesJson = JsonConvert.SerializeObject(personajesAngular);
            return Json(personajesJson, JsonRequestBehavior.AllowGet);
        }

        // GET: Personajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Personaje personaje = db.Personaje.Find(id);
            var BBpersonaje = db.BB.Where(x => x.PersonajeID == id).ToList();
            var stats = db.Stats.Where(x => x.PersonajeID == id).ToList();
            var imagen = personaje.ImagenID;
            var icono = personaje.IconoID;
            var gif = personaje.GifID;
            var gifAtaque = personaje.GifAtaqueID;
            var bb = BBpersonaje.Where(x => x.TipoBBID == 1).FirstOrDefault();
            var sbb = BBpersonaje.Where(x => x.TipoBBID == 2).FirstOrDefault();
            var ubb = BBpersonaje.Where(x => x.TipoBBID == 3).FirstOrDefault();
            List<Personaje> personajesPre = new List<Personaje>();
            Personaje personajePre = personaje;
            while (personajePre.PreEvoNum.HasValue)
            {
                personajePre = personajePre.PreEvo;
                personajesPre.Add(personajePre);
            }
            personajesPre.Reverse();

            List<Personaje> personajesPost = new List<Personaje>();
            var personajePost = personaje;

            while (personajePost.PostEvoNum.HasValue)
            {
                personajePost = personajePost.PostEvo;
                personajesPost.Add(personajePost);
            }

            ViewBag.PersonajesPre = personajesPre;
            ViewBag.PersonajesPost = personajesPost;

            ViewBag.BB = bb;
            ViewBag.SBB = sbb;
            ViewBag.UBB = ubb;

            ViewBag.imagen = imagen;
            ViewBag.icono = icono;
            ViewBag.gif = gif;
            ViewBag.gifAtaque = gifAtaque;
            ViewBag.stats = stats;

            if (personaje == null)
            {
                return HttpNotFound();
            }
            return View(personaje);
        }

        public ActionResult DetailsAngular(int? id)
        {
            Personaje personaje = db.Personaje.Find(id);

            PersonajeAngular personajeAngular = new PersonajeAngular
            {
                Numero = personaje.Numero,
                Nombre = personaje.Nombre,
                NivelMax=personaje.NivelMax,
                Estrellas=personaje.Estrellas,
                Coste=personaje.Coste,
                Elemento=personaje.Elemento.Nombre,
                Genero=personaje.Genero.NombreGenero,
                NHits=personaje.NHits,
                DC=personaje.DC,
                ImpHP=personaje.ImpHP,
                ImpAtk=personaje.ImpAtk,
                ImpDef=personaje.ImpDef,
                ImpRec=personaje.ImpRec,
                PreEvoNum=personaje.PreEvoNum,
                PostEvoNum=personaje.PostEvoNum,
                ImagenID=personaje.ImagenID,
                IconoID=personaje.IconoID,
                GifID=personaje.GifID,
                GifAtaqueID=personaje.GifAtaqueID,
                Healer=personaje.Healer,
                Mitigador=personaje.Mitigador,
                Antiestados=personaje.Antiestados,
                BBFill=personaje.BBFill,
                AumentoDrop=personaje.AumentoDrop,
                Sparker=personaje.Sparker,
                Criticos=personaje.Criticos,
                AumentoStats=personaje.AumentoStats,
                Nuker=personaje.Nuker,
                IAArena=personaje.IAArena,
        };



            var personajeJson = JsonConvert.SerializeObject(personajeAngular);
            return Json(personajeJson, JsonRequestBehavior.AllowGet);
        }

        // GET: Personajes/Create
        public ActionResult Create()
        {
            ViewBag.ElementoID = new SelectList(db.Elemento, "ElementoID", "Nombre");
            ViewBag.GeneroID = new SelectList(db.Genero, "ID", "NombreGenero");
            ViewBag.GifID = new SelectList(db.File, "FileId", "FileName");
            ViewBag.GifAtaqueID = new SelectList(db.File, "FileId", "FileName");
            ViewBag.IconoID = new SelectList(db.File, "FileId", "FileName");
            ViewBag.ImagenID = new SelectList(db.File, "FileId", "FileName");
            ViewBag.PostEvoNum = new SelectList(db.Personaje, "Numero", "Nombre");
            ViewBag.PreEvoNum = new SelectList(db.Personaje, "Numero", "Nombre");
            return View();
        }

        // POST: Personajes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Numero,Nombre,NivelMax,Estrellas,Coste,IAArena,ElementoID,GeneroID,NHits,DC,ImpHP,ImpAtk,ImpDef,ImpRec,PreEvoNum,PostEvoNum,ImagenID,IconoID,GifID,GifAtaqueID,Healer,Mitigador,Antiestados,BBFill,AumentoDrop,Sparker,Criticos,AumentoStats,Nuker")] Personaje personaje, HttpPostedFileBase uploadImagen = null, HttpPostedFileBase uploadIcono = null, HttpPostedFileBase uploadGif = null, HttpPostedFileBase uploadGifAtaque = null)
        {
            if (ModelState.IsValid)
            {
                //Imagen

                if (uploadImagen != null && uploadImagen.ContentLength > 0)
                {
                    var imagen = new File
                    {
                        FileName = System.IO.Path.GetFileName(uploadImagen.FileName),
                        FileType = FileType.Avatar,
                        ContentType = uploadImagen.ContentType
                    };
                    db.File.Add(imagen);
                    using (var reader = new System.IO.BinaryReader(uploadImagen.InputStream))
                    {
                        imagen.Content = reader.ReadBytes(uploadImagen.ContentLength);
                    }
                    personaje.Imagen = imagen;
                }

                // Icono

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
                    personaje.Icono = icono;
                }

                // Gif

                if (uploadGif != null && uploadGif.ContentLength > 0)
                {
                    var gif = new File
                    {
                        FileName = System.IO.Path.GetFileName(uploadGif.FileName),
                        FileType = FileType.Avatar,
                        ContentType = uploadGif.ContentType
                    };
                    db.File.Add(gif);
                    using (var reader = new System.IO.BinaryReader(uploadGif.InputStream))
                    {
                        gif.Content = reader.ReadBytes(uploadGif.ContentLength);
                    }
                    personaje.Gif = gif;
                }

                //Gif Ataque


                if (uploadGifAtaque != null && uploadGifAtaque.ContentLength > 0)
                {
                    var gifAtaque = new File
                    {
                        FileName = System.IO.Path.GetFileName(uploadGifAtaque.FileName),
                        FileType = FileType.Avatar,
                        ContentType = uploadGifAtaque.ContentType
                    };
                    db.File.Add(gifAtaque);
                    using (var reader = new System.IO.BinaryReader(uploadGifAtaque.InputStream))
                    {
                        gifAtaque.Content = reader.ReadBytes(uploadGifAtaque.ContentLength);
                    }
                    personaje.GifAtaque = gifAtaque;
                }



                db.Personaje.Add(personaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.ElementoID = new SelectList(db.Elemento, "ElementoID", "Nombre", personaje.ElementoID);
            ViewBag.GeneroID = new SelectList(db.Genero, "ID", "NombreGenero", personaje.GeneroID);
            ViewBag.GifID = new SelectList(db.File, "FileId", "FileName", personaje.GifID);
            ViewBag.GifAtaqueID = new SelectList(db.File, "FileId", "FileName", personaje.GifAtaqueID);
            ViewBag.IconoID = new SelectList(db.File, "FileId", "FileName", personaje.IconoID);
            ViewBag.ImagenID = new SelectList(db.File, "FileId", "FileName", personaje.ImagenID);
            ViewBag.PostEvoNum = new SelectList(db.Personaje, "Numero", "Nombre", personaje.PostEvoNum);
            ViewBag.PreEvoNum = new SelectList(db.Personaje, "Numero", "Nombre", personaje.PreEvoNum);
            return View(personaje);
        }

        // GET: Personajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personaje personaje = db.Personaje.Include(x => x.Imagen).SingleOrDefault(s => s.Numero == id);

            if (personaje == null)
            {
                return HttpNotFound();
            }
            ViewBag.ElementoID = new SelectList(db.Elemento, "ElementoID", "Nombre", personaje.ElementoID);
            ViewBag.GeneroID = new SelectList(db.Genero, "ID", "NombreGenero", personaje.GeneroID);
            ViewBag.GifID = new SelectList(db.File, "FileId", "FileName", personaje.GifID);
            ViewBag.GifAtaqueID = new SelectList(db.File, "FileId", "FileName", personaje.GifAtaqueID);
            ViewBag.IconoID = new SelectList(db.File, "FileId", "FileName", personaje.IconoID);
            ViewBag.ImagenID = new SelectList(db.File, "FileId", "FileName", personaje.ImagenID);
            ViewBag.PostEvoNum = new SelectList(db.Personaje, "Numero", "Nombre", personaje.PostEvoNum);
            ViewBag.PreEvoNum = new SelectList(db.Personaje, "Numero", "Nombre", personaje.PreEvoNum);
            return View(personaje);
        }

        // POST: Personajes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Numero,Nombre,NivelMax,Estrellas,Coste,IAArena,ElementoID,GeneroID,NHits,DC,ImpHP,ImpAtk,ImpDef,ImpRec,PreEvoNum,PostEvoNum,ImagenID,IconoID,GifID,GifAtaqueID,Healer,Mitigador,Antiestados,BBFill,AumentoDrop,Sparker,Criticos,AumentoStats,Nuker")] Personaje personaje, HttpPostedFileBase uploadImagen = null, HttpPostedFileBase uploadIcono = null, HttpPostedFileBase uploadGif = null, HttpPostedFileBase uploadGifAtaque = null)
        {
            if (ModelState.IsValid)
            {
                //Edición imagen personaje

                if (uploadImagen != null && uploadImagen.ContentLength > 0)
                {
                    if (personaje.Imagen != null)
                    {
                        db.File.Remove(personaje.Imagen);
                    }
                    var imagen = new File
                    {
                        FileName = System.IO.Path.GetFileName(uploadImagen.FileName),
                        FileType = FileType.Avatar,
                        ContentType = uploadImagen.ContentType
                    };
                    db.File.Add(imagen);
                    using (var reader = new System.IO.BinaryReader(uploadImagen.InputStream))
                    {
                        imagen.Content = reader.ReadBytes(uploadImagen.ContentLength);
                    }
                    personaje.Imagen = imagen;
                }

                //Edición icono personaje

                if (uploadIcono != null && uploadIcono.ContentLength > 0)
                {
                    if (personaje.Icono != null)
                    {
                        db.File.Remove(personaje.Icono);
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
                    personaje.Icono = icono;
                }


                //Edicio Gif

                if (uploadGif != null && uploadGif.ContentLength > 0)
                {
                    if (personaje.Gif != null)
                    {
                        db.File.Remove(personaje.Gif);
                    }
                    var gif = new File
                    {
                        FileName = System.IO.Path.GetFileName(uploadGif.FileName),
                        FileType = FileType.Avatar,
                        ContentType = uploadGif.ContentType
                    };
                    db.File.Add(gif);
                    using (var reader = new System.IO.BinaryReader(uploadGif.InputStream))
                    {
                        gif.Content = reader.ReadBytes(uploadGif.ContentLength);
                    }
                    personaje.Gif = gif;
                }

                //Edicio GifAtaque

                if (uploadGifAtaque != null && uploadGifAtaque.ContentLength > 0)
                {
                    if (personaje.GifAtaque != null)
                    {
                        db.File.Remove(personaje.GifAtaque);
                    }
                    var gifAtaque = new File
                    {
                        FileName = System.IO.Path.GetFileName(uploadGifAtaque.FileName),
                        FileType = FileType.Avatar,
                        ContentType = uploadGifAtaque.ContentType
                    };
                    db.File.Add(gifAtaque);
                    using (var reader = new System.IO.BinaryReader(uploadGifAtaque.InputStream))
                    {
                        gifAtaque.Content = reader.ReadBytes(uploadGifAtaque.ContentLength);
                    }
                    personaje.GifAtaque = gifAtaque;
                }

                db.Entry(personaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ElementoID = new SelectList(db.Elemento, "ElementoID", "Nombre", personaje.ElementoID);
            ViewBag.GeneroID = new SelectList(db.Genero, "ID", "NombreGenero", personaje.GeneroID);
            ViewBag.GifID = new SelectList(db.File, "FileId", "FileName", personaje.GifID);
            ViewBag.GifAtaqueID = new SelectList(db.File, "FileId", "FileName", personaje.GifAtaqueID);
            ViewBag.IconoID = new SelectList(db.File, "FileId", "FileName", personaje.IconoID);
            ViewBag.ImagenID = new SelectList(db.File, "FileId", "FileName", personaje.ImagenID);
            ViewBag.PostEvoNum = new SelectList(db.Personaje, "Numero", "Nombre", personaje.PostEvoNum);
            ViewBag.PreEvoNum = new SelectList(db.Personaje, "Numero", "Nombre", personaje.PreEvoNum);
            return View(personaje);
        }

        // GET: Personajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personaje personaje = db.Personaje.Find(id);
            if (personaje == null)
            {
                return HttpNotFound();
            }
            return View(personaje);
        }

        // POST: Personajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personaje personaje = db.Personaje.Find(id);
            db.Personaje.Remove(personaje);
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