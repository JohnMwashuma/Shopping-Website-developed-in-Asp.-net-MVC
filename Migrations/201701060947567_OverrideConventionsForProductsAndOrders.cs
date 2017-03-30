namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForProductsAndOrders : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Products", "Details", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Details", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
