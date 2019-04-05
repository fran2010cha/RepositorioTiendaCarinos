namespace TiendaMascotasCariños.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracioncalificacion1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Mascotas", "Precio", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Mascotas", "Precio", c => c.Decimal(nullable: false, storeType: "money"));
        }
    }
}
