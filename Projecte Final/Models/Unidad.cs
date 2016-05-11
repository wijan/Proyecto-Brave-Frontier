using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Unidad
    {
        public int ID { get; set; }
        public int PersonajeID { get; set; }
        public virtual Personaje Personaje { get; set; }
        public int Esfera1ID { get; set; }
        public virtual Esfera Esfera1 { get; set; }
        public int Esfera2ID { get; set; }
        public virtual Esfera Esfera2 { get; set; }
        public int EquipoID { get; set; }
        public virtual List<Equipo> Equipos { get; set; }
    }
}