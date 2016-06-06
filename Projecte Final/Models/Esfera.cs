using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Esfera:Objeto
    {
        //Esfera
        [Key]
        public int TipoID { get; set; }
        public virtual TipoEsfera TipoEsfera { get; set; }
        public ICollection<EfectoEsfera> EfectosEsfera { get; set; }
        public ICollection<misEsferas> misEsferas { get; set; }
    }
}