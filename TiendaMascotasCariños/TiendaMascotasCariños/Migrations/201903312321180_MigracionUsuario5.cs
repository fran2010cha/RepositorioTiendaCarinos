namespace TiendaMascotasCariños.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionUsuario5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comprars", "MedioPago", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comprars", "MedioPago", c => c.String());
        }
    }
}
