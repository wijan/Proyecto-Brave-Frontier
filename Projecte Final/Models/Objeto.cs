using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Objeto
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        public HttpPostedFileBase Imagen { get; set; }
        public int EfectoID { get; set; }
        public virtual EfectoEsfera Efecto { get; set; }
        public int CrafteoID { get; set; }
        public String Descripcion { get; set; }
    }
}