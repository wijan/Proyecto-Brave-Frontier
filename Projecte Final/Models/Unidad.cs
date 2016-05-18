using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Unidad
    {
        [Key]
        public int ID { get; set; }
        public int PersonajeID { get; set; }
        public virtual Personaje Personaje { get; set; }
        public int Esfera1ID { get; set; }
        public virtual Esfera Esfera1 { get; set; }
        public int Esfera2ID { get; set; }
        public virtual Esfera Esfera2 { get; set; }
        public int EquiposUnidad1ID { get; set; }
        public virtual ICollection<Equipo> EquiposUnidad1 { get; set; }
        public int EquiposUnidad2ID { get; set; }
        public virtual ICollection<Equipo> EquiposUnidad2 { get; set; }
        public int EquiposUnidad3ID { get; set; }
        public virtual ICollection<Equipo> EquiposUnidad3 { get; set; }
        public int EquiposUnidad4ID { get; set; }
        public virtual ICollection<Equipo> EquiposUnidad4 { get; set; }
        public int EquiposUnidad5ID { get; set; }
        public virtual ICollection<Equipo> EquiposUnidad5 { get; set; }
        public int EquiposUnidad6ID { get; set; }
        public virtual ICollection<Equipo> EquiposUnidad6 { get; set; }

    }
}