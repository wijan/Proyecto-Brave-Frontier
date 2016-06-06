using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class misEsferas
    {
        [Key]
        public int ID { get; set; }
        public int EsferaID { get; set; }
        public virtual Esfera Esfera { get; set; }
        public string UsuarioID { get; set; }
        public virtual ApplicationUser Usuario { get; set; }
        public ICollection<Unidad> Unidades1 { get; set; }
        public ICollection<Unidad> Unidades2 { get; set; }
    }
}