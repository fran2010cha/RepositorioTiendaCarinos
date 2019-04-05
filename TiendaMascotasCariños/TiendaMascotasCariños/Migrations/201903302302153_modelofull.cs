namespace TiendaMascotasCariños.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelofull : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mascotas", "GeneroMascota", c => c.Int(nullable: false));
            AddColumn("dbo.Mascotas", "EstadoMascota", c => c.Int(nullable: false));
            AlterColumn("dbo.Mascotas", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Mascotas", "HistorialMascota", c => c.String());
            AlterColumn("dbo.Mascotas", "Precio", c => c.Decimal(nullable: false, storeType: "money"));
            AlterColumn("dbo.Tiendas", "Nombre", c => c.String(nullable: false));
            DropColumn("dbo.Mascotas", "Genero");
            DropColumn("dbo.Mascotas", "Estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mascotas", "Estado", c => c.String());
            AddColumn("dbo.Mascotas", "Genero", c => c.String());
            AlterColumn("dbo.Tiendas", "Nombre", c => c.String());
            AlterColumn("dbo.Mascotas", "Precio", c => c.Int(nullable: false));
            AlterColumn("dbo.Mascotas", "HistorialMascota", c => c.String(nullable: false));
            AlterColumn("dbo.Mascotas", "Nombre", c => c.String());
            DropColumn("dbo.Mascotas", "EstadoMascota");
            DropColumn("dbo.Mascotas", "GeneroMascota");
        }
    }
}
