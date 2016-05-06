using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class EstadosAlterados
    {
        public int ID { get; set; }
        public List<Afliccion> Aflicciones { get; set; }
    }
}