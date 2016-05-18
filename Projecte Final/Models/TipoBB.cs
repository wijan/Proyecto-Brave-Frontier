using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class TipoBB
    {
        [Key]
        public int TipoID { get; set; }
        public String Tipo { get; set; }
        public virtual ICollection<BB> BBTipo { get; set; }
    }
}