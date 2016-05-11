using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Objeto
    {
        public int ID { get; set; }
        public String Nombre { get; set; }
        [NotMapped]
        public HttpPostedFileBase Imagen { get; set; }
        //public int CrafteoID { get; set; }
        public virtual Crafteo Crafteo { get; set; }
        public String Descripcion { get; set; }
    }
}