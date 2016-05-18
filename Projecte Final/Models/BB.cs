using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class BB
    {
        [Key]
        public int ID { get; set; }
        //Habilidades de los personajes
        public String Nombre { get; set; }
        public String BBDesc { get; set; }

        //Rama del BB (Heal, Support o Atk)
        public int RamaBBID { get; set; }
        public virtual RamaBB RamaBB { get; set; }

        //Tipo del BB (BB, SBB, UBB)
        public int TipoBBID { get; set; }
        public virtual TipoBB TipoBB { get; set; }

        //Grupalidad del BB
        public int GrupalBBID { get; set; }
        public virtual GrupalBB GrupalBB { get; set; }

        public int NhitsBB { get; set; }
        public int DCBB { get; set; }
        public int CosteBB { get; set; }
        public int MultiplicadorBB { get; set; }

        public int EfectoBBID { get; set; }
        public virtual Efectos EfectoBB { get; set; }


        public virtual ICollection<Personaje> PersonajesBB { get; set; }
        public virtual ICollection<Personaje> PersonajesSBB { get; set; }
        public virtual ICollection<Personaje> PersonajesUBB { get; set; }
    }
}