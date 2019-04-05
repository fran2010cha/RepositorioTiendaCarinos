using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaMascotasCariños.Models
{
    public class Progenitor
    {
        public int ProgenitorID { get; set; }
        [Display(Name = "Nombre Progenitor")]
        public string NombreProgenitor { get; set; }
        public string Genero { get; set; }
        public int MascotaID { get; set; }
        public Mascota Mascota { get; set; }

    }
}