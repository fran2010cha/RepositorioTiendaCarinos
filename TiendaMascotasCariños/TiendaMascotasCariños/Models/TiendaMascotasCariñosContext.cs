using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TiendaMascotasCariños.Models
{
    public class TiendaMascotasCariñosContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TiendaMascotasCariñosContext() : base("name=TiendaMascotasCariñosContext")
        {
        }

        public System.Data.Entity.DbSet<TiendaMascotasCariños.Models.Tienda> Tiendas { get; set; }

        public System.Data.Entity.DbSet<TiendaMascotasCariños.Models.Especie> Especies { get; set; }

        public System.Data.Entity.DbSet<TiendaMascotasCariños.Models.Raza> Razas { get; set; }

        public System.Data.Entity.DbSet<TiendaMascotasCariños.Models.Mascota> Mascotas { get; set; }

        public System.Data.Entity.DbSet<TiendaMascotasCariños.Models.Progenitor> Progenitors { get; set; }

        public System.Data.Entity.DbSet<TiendaMascotasCariños.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<TiendaMascotasCariños.Models.Adoptar> Adoptars { get; set; }

        public System.Data.Entity.DbSet<TiendaMascotasCariños.Models.Comprar> Comprars { get; set; }

        public System.Data.Entity.DbSet<TiendaMascotasCariños.Models.Calificar> Calificars { get; set; }

      
    }
}
