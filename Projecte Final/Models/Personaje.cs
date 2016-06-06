using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Projecte_Final.Models
{
    public class Personaje
    {
        //Personaje del juego.

        //Datos generales
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Numero { get; set; }
        public String Nombre { get; set; }
        public int NivelMax { get; set; }
        public int Estrellas { get; set; }
        public int Coste { get; set; }

        [ScriptIgnore]
        public virtual ICollection<Stats> Stats { get; set; }

        //Elemento
        public int ElementoID { get; set; }
        public virtual Elemento Elemento { get; set; }

        //Genero
        public int GeneroID { get; set; }
        [ScriptIgnore]
        public virtual Genero Genero { get; set; }



        //Datos combate
        public int NHits { get; set; }
        public int DC { get; set; }

        [ScriptIgnore]
        public virtual ICollection<BB> BBs { get; set; }


        //Datos IMPS
        public int ImpHP { get; set; }
        public int ImpAtk { get; set; }
        public int ImpDef { get; set; }
        public int ImpRec { get; set; }

        


        //Pre i post evoluciones
        public int? PreEvoNum { get; set; }
        [ScriptIgnore]
        public virtual Personaje PreEvo { get; set; }
        
        public int? PostEvoNum { get; set; }
        [ScriptIgnore]
        public virtual Personaje PostEvo { get; set; }


        //Imágenes
        public int? ImagenID { get; set; }
        [ScriptIgnore]
        public virtual File Imagen { get; set; }
        public int? IconoID { get; set; }
        [ScriptIgnore]
        public virtual File Icono { get; set; }
        public int? GifID { get; set; }
        [ScriptIgnore]
        public virtual File Gif { get; set; }
        public int? GifAtaqueID { get; set; }
        [ScriptIgnore]
        public virtual File GifAtaque { get; set; }

        public Boolean Healer { get; set; }
        public Boolean Mitigador { get; set; }
        public Boolean Antiestados { get; set; }
        public Boolean BBFill{ get; set; }
        public Boolean AumentoDrop{ get; set; }
        public Boolean Sparker{ get; set; }
        public Boolean Criticos{ get; set; }
        public Boolean AumentoStats { get; set; }
        public Boolean Nuker { get; set; }

        public int? IAArena { get; set; }

        //Propiedad de navegacion a ES
        public virtual ICollection<ES> ES { get; set; }
        public virtual ICollection<LS> LS { get; set; }

        //Propiedad de navegacion propia
        [ScriptIgnore]
        public virtual ICollection<Personaje> PersonajesPost { get; set; }
        [ScriptIgnore]
        public virtual ICollection<Personaje> PersonajesPre { get; set; }

        //Propiedad de navegacion a Unidad
        [ScriptIgnore]
        public virtual ICollection<Unidad> Unidades { get; set; }
    }
}