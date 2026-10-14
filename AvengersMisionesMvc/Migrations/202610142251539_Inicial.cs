namespace AvengersMisionesMvc.Migrations
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
                "dbo.Misions",
                c => new
                    {
                        MisionId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false),
                        Amenaza = c.String(),
                        Estado = c.String(),
                        HeroeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MisionId)
                .ForeignKey("dbo.Heroes", t => t.HeroeId, cascadeDelete: true)
                .Index(t => t.HeroeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Misions", "HeroeId", "dbo.Heroes");
            DropIndex("dbo.Misions", new[] { "HeroeId" });
            DropTable("dbo.Misions");
            DropTable("dbo.Heroes");
        }
    }
}
