namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductAndOrderDetailsRelationship : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.OrderDetails", "ProductId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
        }
    }
}
