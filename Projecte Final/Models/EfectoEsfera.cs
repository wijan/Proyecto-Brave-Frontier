using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class EfectoEsfera
    {
        [Key]
        public int EfectoID { get; set; }
        public String Descripcion { get; set; }
        public int EsferaID { get; set; }
        public virtual Esfera Esfera { get; set; }
    }
}