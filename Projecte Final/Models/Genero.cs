using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Genero
    {
        //Género del personaje
        [Key]
        public int ID { get; set; }
        public String Nombre { get; set; }
        public virtual ICollection<Personaje> Personajes { get; set; }
    }
}