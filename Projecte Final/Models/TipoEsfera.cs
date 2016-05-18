using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class TipoEsfera
    {
        //Tipo de esfera; stats, crits, heal, def, etc...
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Esfera> Esferas { get; set; }
    }
}