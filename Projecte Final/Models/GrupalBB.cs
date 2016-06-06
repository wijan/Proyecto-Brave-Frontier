using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class GrupalBB
    {
        //Si la habilidad es grupal o individual.
        [Key]
        public int ID { get; set; }
        public String NombreGrupal { get; set; }
        public virtual ICollection<BB> BBGrupal { get; set; }
    }
}