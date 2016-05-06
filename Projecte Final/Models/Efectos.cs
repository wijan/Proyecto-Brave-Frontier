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

        //MitigacionElemental
        public int MitigacionElementalID { get; set; }
        public virtual MitigacionElemental MitigacionElemental { get; set; }

        public String Barrera { get; set; }
        public String Heal { get; set; }
        public String HealTurno { get; set; }
        public int DropCB { get; set; }
        public int DropCC { get; set; }
        public int DropItems { get; set; }

        //Estados Alterados
        public int EstadosAlteradosID { get; set; }
        public virtual EstadosAlterados EstadosAlterados { get; set; }

        public int DañoAlAfligir { get; set; }

        //Antiestados
        public int AntiestadosID { get; set; }
        public virtual Antiestados Antiestados { get; set; }

        //StatDown
        public int AtkDownID { get; set; }
        public virtual StatDown AtkDown { get; set; }
        public int DefDown2ID { get; set; }
        public virtual StatDown DefDown2 { get; set; }

        //Vulnerabilidad Spark
        public int VulnerabilidadSparkID { get; set; }
        public virtual VulnerabilidadSpark VulnerabilidadSpark { get; set; }

        public bool IgnDef { get; set; }

        //Añadir Elementos
        public int AñadirElementosID { get; set; }
        public virtual AñadirElementos AñadirElementos { get; set; }

        //Debilidad Elemental
        public int DebilidadElementalID { get; set; }
        public virtual DebilidadElemental DebilidadElemental { get; set; }

        public int DoT { get; set; }
        public int AumentoHits { get; set; }
        public String Angel { get; set; }
        public int Revivir { get; set; }
    }
}