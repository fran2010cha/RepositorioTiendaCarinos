using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiendaMascotasCariños.Models
{

    public enum Estado { Adopcion, Venta }
    public enum Genero { Macho, Hembra }


    public class Mascota
    {        
        public int MascotaID { get; set; }
        [Display(Name = "Nombre Mascota")]
        [Required]
        public string Nombre { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        public string Color { get; set; }
        public Genero Genero { get; set; }
        public string HistorialMascota { get; set; }
        public Estado Estado { get; set; }
        public double? Precio { get; set; }
        [Display(Name = "Imagen"), DataType(DataType.Upload)]
        public byte[] imagenMascota { get; set; }
        public virtual ICollection<Adoptar> Adoptars { get; set; }
        public virtual ICollection<Comprar> Comprars { get; set; }
        public virtual ICollection<Progenitor> Progenitors { get; set; }
        public int TiendaID { get; set; }
        public Tienda Tienda { get; set; }
        public int RazaID { get; set; }
        public Raza Raza { get; set; }

    }
}