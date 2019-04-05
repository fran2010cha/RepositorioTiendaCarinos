namespace TiendaMascotasCariños.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracion1Prueba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adoptars",
                c => new
                    {
                        AdoptarID = c.Int(nullable: false, identity: true),
                        TieneMascota = c.Boolean(nullable: false),
                        CuantasMascotas = c.Int(nullable: false),
                        MascotaID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AdoptarID)
                .ForeignKey("dbo.Mascotas", t => t.MascotaID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.MascotaID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Mascotas",
                c => new
                    {
                        MascotaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Color = c.String(),
                        Genero = c.String(),
                        HistorialMascota = c.String(nullable: false),
                        Estado = c.String(),
                        Precio = c.Int(nullable: false),
                        imagenMascota = c.Binary(),
                        TiendaID = c.Int(nullable: false),
                        RazaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MascotaID)
                .ForeignKey("dbo.Razas", t => t.RazaID, cascadeDelete: true)
                .ForeignKey("dbo.Tiendas", t => t.TiendaID, cascadeDelete: true)
                .Index(t => t.TiendaID)
                .Index(t => t.RazaID);
            
            CreateTable(
                "dbo.Comprars",
                c => new
                    {
                        ComprarID = c.Int(nullable: false, identity: true),
                        MedioPago = c.String(),
                        MascotaID = c.Int(nullable: false),
                        UsuarioID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ComprarID)
                .ForeignKey("dbo.Mascotas", t => t.MascotaID, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.MascotaID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                        Correo = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Progenitors",
                c => new
                    {
                        ProgenitorID = c.Int(nullable: false, identity: true),
                        NombreProgenitor = c.String(),
                        Genero = c.String(),
                        MascotaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgenitorID)
                .ForeignKey("dbo.Mascotas", t => t.MascotaID, cascadeDelete: true)
                .Index(t => t.MascotaID);
            
            CreateTable(
                "dbo.Razas",
                c => new
                    {
                        RazaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        EspecieID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RazaID)
                .ForeignKey("dbo.Especies", t => t.EspecieID, cascadeDelete: true)
                .Index(t => t.EspecieID);
            
            CreateTable(
                "dbo.Especies",
                c => new
                    {
                        EspecieID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.EspecieID);
            
            CreateTable(
                "dbo.Tiendas",
                c => new
                    {
                        TiendaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.TiendaID);
            
            CreateTable(
                "dbo.Calificars",
                c => new
                    {
                        CalificarID = c.Int(nullable: false, identity: true),
                        calificacion = c.Int(nullable: false),
                        Comentario = c.String(),
                        ComprarID = c.Int(nullable: false),
                        AdoptarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CalificarID)
                .ForeignKey("dbo.Adoptars", t => t.AdoptarID, cascadeDelete: false)
                .ForeignKey("dbo.Comprars", t => t.ComprarID, cascadeDelete: false)
                .Index(t => t.ComprarID)
                .Index(t => t.AdoptarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calificars", "ComprarID", "dbo.Comprars");
            DropForeignKey("dbo.Calificars", "AdoptarID", "dbo.Adoptars");
            DropForeignKey("dbo.Mascotas", "TiendaID", "dbo.Tiendas");
            DropForeignKey("dbo.Mascotas", "RazaID", "dbo.Razas");
            DropForeignKey("dbo.Razas", "EspecieID", "dbo.Especies");
            DropForeignKey("dbo.Progenitors", "MascotaID", "dbo.Mascotas");
            DropForeignKey("dbo.Comprars", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Adoptars", "UsuarioID", "dbo.Usuarios");
            DropForeignKey("dbo.Comprars", "MascotaID", "dbo.Mascotas");
            DropForeignKey("dbo.Adoptars", "MascotaID", "dbo.Mascotas");
            DropIndex("dbo.Calificars", new[] { "AdoptarID" });
            DropIndex("dbo.Calificars", new[] { "ComprarID" });
            DropIndex("dbo.Razas", new[] { "EspecieID" });
            DropIndex("dbo.Progenitors", new[] { "MascotaID" });
            DropIndex("dbo.Comprars", new[] { "UsuarioID" });
            DropIndex("dbo.Comprars", new[] { "MascotaID" });
            DropIndex("dbo.Mascotas", new[] { "RazaID" });
            DropIndex("dbo.Mascotas", new[] { "TiendaID" });
            DropIndex("dbo.Adoptars", new[] { "UsuarioID" });
            DropIndex("dbo.Adoptars", new[] { "MascotaID" });
            DropTable("dbo.Calificars");
            DropTable("dbo.Tiendas");
            DropTable("dbo.Especies");
            DropTable("dbo.Razas");
            DropTable("dbo.Progenitors");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Comprars");
            DropTable("dbo.Mascotas");
            DropTable("dbo.Adoptars");
        }
    }
}
