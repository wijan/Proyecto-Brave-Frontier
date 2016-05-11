using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Crafteo
    {
        public int ID { get; set; }
        public List<Objeto> Objetos { get; set; }
        //public int ObjetoID { get; set; }
        public virtual Objeto Objeto { get; set; }
    }
}