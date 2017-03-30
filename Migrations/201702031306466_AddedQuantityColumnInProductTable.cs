namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuantityColumnInProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
