namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductRelationshipInOrdersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Product_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Product_Id");
            AddForeignKey("dbo.Orders", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Product_Id", "dbo.Products");
            DropIndex("dbo.Orders", new[] { "Product_Id" });
            DropColumn("dbo.Orders", "Product_Id");
        }
    }
}
