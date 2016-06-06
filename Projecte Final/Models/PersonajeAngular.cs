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
    public class PersonajeAngular
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
        public int? IAArena { get; set; }
        
        public String Elemento { get; set; }
        
        public String Genero { get; set; }

        public String Cerca { get; set; }

        //Datos combate
        public int NHits { get; set; }
        public int DC { get; set; }


        //Datos IMPS
        public int ImpHP { get; set; }
        public int ImpAtk { get; set; }
        public int ImpDef { get; set; }
        public int ImpRec { get; set; }


        //Pre i post evoluciones
        public int? PreEvoNum { get; set; }

        public int? PostEvoNum { get; set; }


        //Imágenes
        public int? ImagenID { get; set; }
        public int? IconoID { get; set; }
        public int? GifID { get; set; }
        public int? GifAtaqueID { get; set; }

        public Boolean Healer { get; set; }
        public Boolean Mitigador { get; set; }
        public Boolean Antiestados { get; set; }
        public Boolean BBFill { get; set; }
        public Boolean AumentoDrop { get; set; }
        public Boolean Sparker { get; set; }
        public Boolean Criticos { get; set; }
        public Boolean AumentoStats { get; set; }
        public Boolean Nuker { get; set; }

    }
}