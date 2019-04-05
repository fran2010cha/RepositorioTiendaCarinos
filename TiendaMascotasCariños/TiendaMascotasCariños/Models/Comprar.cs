using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotasCariños.Models
{
    public enum MedioPago { PSE,TarjetaCredito,Paypal, Bitcoin }

    public class Comprar
    {

        public int ComprarID { get; set; }
        public MedioPago MedioPago { get; set; }
        public int MascotaID { get; set; }
        public virtual Mascota Mascota { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}