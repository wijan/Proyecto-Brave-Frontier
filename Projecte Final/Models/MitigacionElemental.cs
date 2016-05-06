using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class MitigacionElemental
    {
        public int ID { get; set; }
        public int Elemento1ID { get; set; }
        public virtual Elemento Elemento1 { get; set; }
        public int Elemento2ID { get; set; }
        public virtual Elemento Elemento2 { get; set; }
        public int Elemento3ID { get; set; }
        public virtual Elemento Elemento3 { get; set; }
        public int Elemento4ID { get; set; }
        public virtual Elemento Elemento4 { get; set; }
        public int Elemento5ID { get; set; }
        public virtual Elemento Elemento5 { get; set; }
        public int Elemento6ID { get; set; }
        public virtual Elemento Elemento6 { get; set; }
        public int Porcentaje { get; set; }
    }
}