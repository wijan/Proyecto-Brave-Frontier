﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projecte_Final.Models
{
    public class RamaBB
    {
        //Tipo del BB (Heal, Supp, Atk)
        public int ID { get; set; }
        public String Nombre { get; set; }
        public virtual List<BB> BBRama { get; set; }
        //Comentario de prueba de edicion git.
    }
}