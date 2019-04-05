namespace TiendaMascotasCariños.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionUsuario : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterViewModels",
                c => new
                    {
                        UsuarioID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                    })
                .PrimaryKey(t => t.UsuarioID);
            
            AddForeignKey("dbo.Adoptars", "UsuarioID", "dbo.RegisterViewModels", "UsuarioID", cascadeDelete: true);
            AddForeignKey("dbo.Comprars", "UsuarioID", "dbo.RegisterViewModels", "UsuarioID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comprars", "UsuarioID", "dbo.RegisterViewModels");
            DropForeignKey("dbo.Adoptars", "UsuarioID", "dbo.RegisterViewModels");
            DropTable("dbo.RegisterViewModels");
        }
    }
}
