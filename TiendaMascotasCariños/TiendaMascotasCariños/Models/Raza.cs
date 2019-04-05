using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaMascotasCariños.Models
{
    public class Raza
    {
        public int RazaID { get; set; }
        [Display(Name = "Nombre Raza")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EspecieID { get; set; }
        public Especie Especie { get; set; }
        public virtual ICollection<Mascota> Mascotas { get; set; }

    }
}