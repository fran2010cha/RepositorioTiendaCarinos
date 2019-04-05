using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaMascotasCariños.Models
{
    public class Adoptar
    {
        public int AdoptarID { get; set; }
        public Boolean TieneMascota { get; set; }
        public int CuantasMascotas { get; set; }
        public int MascotaID { get; set; }
        public virtual Mascota Mascota { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuario Usuario { get; set; }
      
    }


}
