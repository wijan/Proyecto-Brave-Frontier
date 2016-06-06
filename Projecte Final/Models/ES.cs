using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class ES
    {
        [Key]
        public int ESID { get; set; }
        public String Nombre { get; set; }
        public String Desc { get; set; }
        public int PersonajeID { get; set; }
        public virtual Personaje Personaje { get; set; }
    }
}