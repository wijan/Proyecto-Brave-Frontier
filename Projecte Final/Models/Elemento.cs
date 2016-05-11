using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Elemento
    {
        //Elemento del juego
        public int ID { get; set; }
        public String Nombre { get; set; }
        public int? DebilVSID { get; set; }
        public virtual Elemento DebilVS { get; set; }
        public int? FuerteVSID { get; set; }
        public virtual Elemento FuerteVS { get; set; }
        public HttpPostedFileBase Icono { get; set; }
        public virtual List<Personaje> Personajes { get; set; }
        public virtual List<Elemento> Elementos { get; set; }
    }
}