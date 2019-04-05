namespace TiendaMascotasCariños.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionUsuario4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Adoptars", "UsuarioID", "dbo.RegisterViewModels");
            DropForeignKey("dbo.Comprars", "UsuarioID", "dbo.RegisterViewModels");
            DropTable("dbo.RegisterViewModels");
        }
        
        public override void Down()
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
            
            AddForeignKey("dbo.Comprars", "UsuarioID", "dbo.RegisterViewModels", "UsuarioID", cascadeDelete: true);
            AddForeignKey("dbo.Adoptars", "UsuarioID", "dbo.RegisterViewModels", "UsuarioID", cascadeDelete: true);
        }
    }
}
