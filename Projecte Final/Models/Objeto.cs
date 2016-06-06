using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Objeto
    {
        [Key]
        public int ID { get; set; }
        public String NomObjeto { get; set; }
        public int? IconaID { get; set; }
        public virtual File Icona { get; set; }
        //public int CrafteoID { get; set; }
        public virtual Crafteo Crafteo { get; set; }
        public String Descripcion { get; set; }
    }
}