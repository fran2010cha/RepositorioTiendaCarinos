namespace TiendaMascotasCariños.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracioncalificacion11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mascotas", "Precio", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mascotas", "Precio", c => c.Double(nullable: false));
        }
    }
}
