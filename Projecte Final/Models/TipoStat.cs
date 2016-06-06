using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Projecte_Final.Models
{
    public class TipoStat
    {
        [Key]
        public int IDStat { get; set; }
        public String Tipo { get; set; }
        [ScriptIgnore]
        public ICollection<Stats> Stats { get; set; }
        [ScriptIgnore]
        public ICollection<Unidad> Unidades { get; set; }
    }
}