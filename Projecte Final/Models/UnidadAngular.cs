using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class UnidadAngular
    {
        [Key]
        public int ID { get; set; }
        public int PersonajeID { get; set; }
        public int? TipoID { get; set; }
        public int? Esfera1ID { get; set; }
        public int? Esfera2ID { get; set; }
        public string UsuarioID { get; set; }

    }
}