namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedProductAndOrderDetailsRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.OrderDetails", "ProductId");
            AddForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
