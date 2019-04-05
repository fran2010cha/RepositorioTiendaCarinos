namespace TiendaMascotasCariños.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracioncalificacion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Calificars", "AdoptarID", "dbo.Adoptars");
            DropForeignKey("dbo.Calificars", "ComprarID", "dbo.Comprars");
            DropIndex("dbo.Calificars", new[] { "ComprarID" });
            DropIndex("dbo.Calificars", new[] { "AdoptarID" });
            AlterColumn("dbo.Calificars", "ComprarID", c => c.Int());
            AlterColumn("dbo.Calificars", "AdoptarID", c => c.Int());
            CreateIndex("dbo.Calificars", "ComprarID");
            CreateIndex("dbo.Calificars", "AdoptarID");
            AddForeignKey("dbo.Calificars", "AdoptarID", "dbo.Adoptars", "AdoptarID");
            AddForeignKey("dbo.Calificars", "ComprarID", "dbo.Comprars", "ComprarID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calificars", "ComprarID", "dbo.Comprars");
            DropForeignKey("dbo.Calificars", "AdoptarID", "dbo.Adoptars");
            DropIndex("dbo.Calificars", new[] { "AdoptarID" });
            DropIndex("dbo.Calificars", new[] { "ComprarID" });
            AlterColumn("dbo.Calificars", "AdoptarID", c => c.Int(nullable: false));
            AlterColumn("dbo.Calificars", "ComprarID", c => c.Int(nullable: false));
            CreateIndex("dbo.Calificars", "AdoptarID");
            CreateIndex("dbo.Calificars", "ComprarID");
            AddForeignKey("dbo.Calificars", "ComprarID", "dbo.Comprars", "ComprarID", cascadeDelete: true);
            AddForeignKey("dbo.Calificars", "AdoptarID", "dbo.Adoptars", "AdoptarID", cascadeDelete: true);
        }
    }
}
