using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Afliccion
    {
        public int ID { get; set; }
        public String Estado { get; set; }
        public int CondicionID { get; set; }
        public virtual CondicionAfliccion Condicion { get; set; }
        public int Porcentaje { get; set; }
    }
}