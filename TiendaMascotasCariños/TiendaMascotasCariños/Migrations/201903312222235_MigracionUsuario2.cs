namespace TiendaMascotasCariños.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionUsuario2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "Password", c => c.String(maxLength: 100));
            AddColumn("dbo.Usuarios", "ConfirmPassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "ConfirmPassword");
            DropColumn("dbo.Usuarios", "Password");
        }
    }
}
