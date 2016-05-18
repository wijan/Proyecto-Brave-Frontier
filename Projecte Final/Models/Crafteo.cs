using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Crafteo
    {
        [Key]
        public int ID { get; set; }
        public ICollection<Objeto> Objetos { get; set; }
        //public int ObjetoID { get; set; }
        public virtual Objeto Objeto { get; set; }
    }
}