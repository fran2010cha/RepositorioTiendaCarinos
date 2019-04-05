using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiendaMascotasCariños.Models
{
    public class Calificar
    {
        [Required]
        public int CalificarID { get; set; }
        [Required]
        public int calificacion { get; set; }
        public string Comentario { get; set; }
        public int? ComprarID { get; set; }
        public virtual Comprar Comprar { get; set; }
        public int? AdoptarID { get; set; }
        public virtual Adoptar Adoptar { get; set; }
        
        
    }
}