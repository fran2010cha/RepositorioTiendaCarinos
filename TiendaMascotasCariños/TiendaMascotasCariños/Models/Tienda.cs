using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TiendaMascotasCariños.Models
{
    public class Tienda
    {
        public int TiendaID { get; set; }
        [Display(Name = "Nombre Tienda")]
        [Required]
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public virtual ICollection<Mascota> Mascotas { get; set; }
    }
}