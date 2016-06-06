using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class RamaBB
    {
        //Tipo del BB (Heal, Supp, Atk)
        [Key]
        public int ID { get; set; }
        public String NombreRamaBB { get; set; }
        public virtual ICollection<BB> BBRama { get; set; }
        //Comentario de prueba de edicion git.
    }
}