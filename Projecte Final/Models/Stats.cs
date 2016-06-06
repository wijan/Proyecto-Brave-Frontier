using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Stats
    {
        //Estadísticas de los personajes en función de su tipo.
        [Key]
        public int StatsID { get; set; }
        public int PersonajeID { get; set; }
        public virtual Personaje Personaje { get; set; }
        //Alma Señor Guardian Rompedor Protector
        public int TipoPersonajeID { get; set; }
        public virtual TipoStat TipoPersonaje { get; set; }
        public int Hp { get; set; }
        public int Ataque { get; set; }
        public int Defensa { get; set; }
        public int Recuperacion { get; set; }

        
    }
}