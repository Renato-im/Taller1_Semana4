namespace AvengersBovedaMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Artefactoes", "nombre", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Artefactoes", "nombre", c => c.String(nullable: false));
        }
    }
}
