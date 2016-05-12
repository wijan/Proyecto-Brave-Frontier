using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Efectos
    {
        public int EfectoBBID { get; set; }
        public int AtkUp { get; set; }
        public int DefUp { get; set; }
        public int RecUp { get; set; }
        public int HpUp { get; set; }
        public int CritRate { get; set; }
        public int CritDmg { get; set; }
        public int BBDmg { get; set; }
        public int SparkDmg { get; set; }
        public int CargaBB { get; set; }
        public int CargaBBTurno { get; set; }
        public int CargaBBRecibir { get; set; }
        public int VelocidadBB { get; set; }
        public int CargaBBSpark { get; set; }
        public int CargaOD { get; set; }
        public int Mitigacion { get; set; }
        public int Barrera { get; set; }
        public int Heal { get; set; }
        public int HealTurno { get; set; }
        public int DropCB { get; set; }
        public int DropCC { get; set; }
        public int DropItems { get; set; }
        public int DañoAlAfligir { get; set; }
        public bool IgnDef { get; set; }
        public int DoT { get; set; }
        public int AumentoHits { get; set; }
        public int Revivir { get; set; }
        public int BBAtacar { get; set; }
        public int BBCritico { get; set; }
        public int ReduccionCosteBB { get; set; }
        public int ReduccionUsoBB { get; set; }
        public int RecargaGuard { get; set; }
        public int DropZel { get; set; }
        public int DropKarma { get; set; }
        public int EfectividadCC { get; set; }
        public int ReduccionDmgGuard { get; set; }


        public String MitigacionElemental { get; set; }
        public String EstadosAlterados { get; set; }
        public String Antiestados { get; set; }
        public String AtkDown { get; set; }
        public String DefDown2 { get; set; }
        public String VulnerabilidadSpark { get; set; }
        public String AñadirElementos { get; set; }
        public String DebilidadElemental { get; set; }
        public String Angel { get; set; }
        public String ReduccionDaño { get; set; }

        public virtual ICollection<BB> BBEfectos { get; set; }
    }
}