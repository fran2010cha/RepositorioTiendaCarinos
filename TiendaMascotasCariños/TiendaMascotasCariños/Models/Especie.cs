using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaMascotasCariños.Models
{
    public class Especie
    {

        public int EspecieID { get; set; }
        [Display(Name = "Nombre Especie")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Raza> Razas { get; set; }

    }
}