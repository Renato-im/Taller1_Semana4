namespace AvengersCuartelMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        HeroeId = c.Int(nullable: false, identity: true),
                        Alias = c.String(nullable: false),
                        NombreReal = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.HeroeId);
            
            CreateTable(
                "dbo.Poders",
                c => new
                    {
                        PoderId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PoderId);
            
            CreateTable(
                "dbo.PoderHeroes",
                c => new
                    {
                        Poder_PoderId = c.Int(nullable: false),
                        Heroe_HeroeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Poder_PoderId, t.Heroe_HeroeId })
                .ForeignKey("dbo.Poders", t => t.Poder_PoderId, cascadeDelete: true)
                .ForeignKey("dbo.Heroes", t => t.Heroe_HeroeId, cascadeDelete: true)
                .Index(t => t.Poder_PoderId)
                .Index(t => t.Heroe_HeroeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PoderHeroes", "Heroe_HeroeId", "dbo.Heroes");
            DropForeignKey("dbo.PoderHeroes", "Poder_PoderId", "dbo.Poders");
            DropIndex("dbo.PoderHeroes", new[] { "Heroe_HeroeId" });
            DropIndex("dbo.PoderHeroes", new[] { "Poder_PoderId" });
            DropTable("dbo.PoderHeroes");
            DropTable("dbo.Poders");
            DropTable("dbo.Heroes");
        }
    }
}
