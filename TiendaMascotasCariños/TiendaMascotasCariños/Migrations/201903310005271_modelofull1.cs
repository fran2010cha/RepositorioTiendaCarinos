namespace TiendaMascotasCariños.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelofull1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mascotas", "Genero", c => c.Int(nullable: false));
            AddColumn("dbo.Mascotas", "Estado", c => c.Int(nullable: false));
            DropColumn("dbo.Mascotas", "GeneroMascota");
            DropColumn("dbo.Mascotas", "EstadoMascota");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mascotas", "EstadoMascota", c => c.Int(nullable: false));
            AddColumn("dbo.Mascotas", "GeneroMascota", c => c.Int(nullable: false));
            DropColumn("dbo.Mascotas", "Estado");
            DropColumn("dbo.Mascotas", "Genero");
        }
    }
}
