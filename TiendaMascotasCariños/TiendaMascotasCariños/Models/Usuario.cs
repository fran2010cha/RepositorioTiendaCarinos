using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TiendaMascotasCariños.Models
{
    public class Usuario
    {
        [DisplayName("Indentificacion")]
        [Required(ErrorMessage = "debe ser requerida la cedula ")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int UsuarioID { get; set; }
        [Display(Name = "Nombre Usuario")]
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get { return Nombre + " " + Apellido; } }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        public virtual ICollection<Adoptar> Adoptars { get; set; }
        public virtual ICollection<Comprar> Comprars { get; set; }

    }
}