namespace AvengersBovedaMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artefactoes",
                c => new
                    {
                        artefactoID = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        poseedor = c.String(),
                        energia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.artefactoID);
            
            CreateTable(
                "dbo.Bovedas",
                c => new
                    {
                        bovedaID = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        ubicacion = c.String(),
                    })
                .PrimaryKey(t => t.bovedaID);
            
            CreateTable(
                "dbo.BovedaArtefactoes",
                c => new
                    {
                        Boveda_bovedaID = c.Int(nullable: false),
                        Artefacto_artefactoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Boveda_bovedaID, t.Artefacto_artefactoID })
                .ForeignKey("dbo.Bovedas", t => t.Boveda_bovedaID, cascadeDelete: true)
                .ForeignKey("dbo.Artefactoes", t => t.Artefacto_artefactoID, cascadeDelete: true)
                .Index(t => t.Boveda_bovedaID)
                .Index(t => t.Artefacto_artefactoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BovedaArtefactoes", "Artefacto_artefactoID", "dbo.Artefactoes");
            DropForeignKey("dbo.BovedaArtefactoes", "Boveda_bovedaID", "dbo.Bovedas");
            DropIndex("dbo.BovedaArtefactoes", new[] { "Artefacto_artefactoID" });
            DropIndex("dbo.BovedaArtefactoes", new[] { "Boveda_bovedaID" });
            DropTable("dbo.BovedaArtefactoes");
            DropTable("dbo.Bovedas");
            DropTable("dbo.Artefactoes");
        }
    }
}
