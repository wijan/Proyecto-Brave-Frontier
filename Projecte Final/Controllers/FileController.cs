using Projecte_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projecte_Final.Controllers
{
    public class FileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.File.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}