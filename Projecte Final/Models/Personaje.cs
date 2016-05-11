using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class Personaje
    {
        //Personaje del juego.

        //Datos generales
        public int Numero { get; set; }
        public String Nombre { get; set; }
        public int NivelMax { get; set; }
        public int Estrellas { get; set; }
        public int Coste { get; set; }

        public virtual List<Stats> Stats { get; set; }

        //Elemento
        public int ElementoID { get; set; }
        public virtual Elemento Elemento { get; set; }

        //Genero
        public int GeneroID { get; set; }
        public virtual Genero Genero { get; set; }



        //Datos combate
        public int NHits { get; set; }
        public int DC { get; set; }


        //BB
        public int BBID { get; set; }
        public virtual BB BB { get; set; }

        //SBB
        public int SBBID { get; set; }
        public virtual BB SBB { get; set; }

        //UBB
        public int UBBID { get; set; }
        public virtual BB UBB { get; set; }


        //Datos IMPS
        public int ImpHP { get; set; }
        public int ImpAtk { get; set; }
        public int ImpDef { get; set; }
        public int ImpRec { get; set; }

        
        //Descripciones extras
        public int LSID { get; set; }
        public virtual LS LS { get; set; }

        public int ESID { get; set; }
        public virtual ES ES { get; set; }


        //Pre i post evoluciones
        public int PreEvoNum { get; set; }
        public virtual Personaje PreEvo { get; set; }
        public int PostEvoNum { get; set; }
        public virtual Personaje PostEvo { get; set; }


        //Imágenes
        public HttpPostedFileBase Imagen { get; set; }
        public HttpPostedFileBase Icono { get; set; }
        public HttpPostedFileBase Gif { get; set; }
        public HttpPostedFileBase GifAtaque { get; set; }


        //Propiedad de navegacion propia
        public virtual List<Personaje> Personajes { get; set; }

        //Propiedad de navegacion a Unidad
        public virtual List<Unidad> Unidades { get; set; }
    }
}