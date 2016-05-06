using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Equipo
    {
        //Equipo compuesto de unidades del juego
        public int Unidad1ID { get; set; }
        public virtual Personaje Unidad1 { get; set; }
        public int Unidad2ID { get; set; }
        public virtual Personaje Unidad2 { get; set; }
        public int Unidad3ID { get; set; }
        public virtual Personaje Unidad3 { get; set; }
        public int Unidad4ID { get; set; }
        public virtual Personaje Unidad4 { get; set; }
        public int Unidad5ID { get; set; }
        public virtual Personaje Unidad5 { get; set; }
        public int Unidad6ID { get; set; }
        public virtual Personaje Unidad6 { get; set; }
        public int UsuarioID { get; set; }
    }
}