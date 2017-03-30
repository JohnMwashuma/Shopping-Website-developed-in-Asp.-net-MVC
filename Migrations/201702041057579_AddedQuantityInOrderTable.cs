namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedQuantityInOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Quantity");
        }
    }
}
