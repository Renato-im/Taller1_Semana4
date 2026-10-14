namespace AvengersBovedaMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bovedas", "nombre", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bovedas", "nombre", c => c.String(nullable: false));
        }
    }
}
