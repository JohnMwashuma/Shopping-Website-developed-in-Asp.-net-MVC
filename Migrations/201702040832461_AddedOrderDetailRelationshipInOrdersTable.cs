namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderDetailRelationshipInOrdersTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Id", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Id" });
            AddColumn("dbo.Orders", "OrderDetail_OrderDetailId", c => c.Int());
            AddColumn("dbo.OrderDetails", "Order_Id", c => c.Int());
            AddColumn("dbo.OrderDetails", "Order_Id1", c => c.Int());
            CreateIndex("dbo.Orders", "OrderDetail_OrderDetailId");
            CreateIndex("dbo.OrderDetails", "Order_Id");
            CreateIndex("dbo.OrderDetails", "Order_Id1");
            AddForeignKey("dbo.Orders", "OrderDetail_OrderDetailId", "dbo.OrderDetails", "OrderDetailId");
            AddForeignKey("dbo.OrderDetails", "Order_Id1", "dbo.Orders", "Id");
            AddForeignKey("dbo.OrderDetails", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "Order_Id1", "dbo.Orders");
            DropForeignKey("dbo.Orders", "OrderDetail_OrderDetailId", "dbo.OrderDetails");
            DropIndex("dbo.OrderDetails", new[] { "Order_Id1" });
            DropIndex("dbo.OrderDetails", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "OrderDetail_OrderDetailId" });
            DropColumn("dbo.OrderDetails", "Order_Id1");
            DropColumn("dbo.OrderDetails", "Order_Id");
            DropColumn("dbo.Orders", "OrderDetail_OrderDetailId");
            CreateIndex("dbo.OrderDetails", "Id");
            AddForeignKey("dbo.OrderDetails", "Id", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
