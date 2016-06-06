using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Projecte_Final.Models
{
    public class Elemento
    {
        //Elemento del juego
        [Key]
        public int ElementoID { get; set; }
        public String Nombre { get; set; }

        [ScriptIgnore]
        public int? DebilVSID { get; set; }
        [ScriptIgnore]
        public virtual Elemento DebilVS { get; set; }

        [ScriptIgnore]
        public int? FuerteVSID { get; set; }
        [ScriptIgnore]
        public virtual Elemento FuerteVS { get; set; }


        //public HttpPostedFileBase Icono { get; set; }
        public int? IconoID { get; set; }
        public File Icono { get; set; } = null;

        [ScriptIgnore]
        public virtual ICollection<Personaje> Personajes { get; set; }
        [ScriptIgnore]
        public virtual ICollection<Elemento> SoyDebilContra { get; set; }
        [ScriptIgnore]
        public virtual ICollection<Elemento> SoyFuerteContra { get; set; }
    }
}