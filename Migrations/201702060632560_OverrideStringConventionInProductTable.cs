namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideStringConventionInProductTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Details", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Details", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
