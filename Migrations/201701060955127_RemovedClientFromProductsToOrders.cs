namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedClientFromProductsToOrders : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Client_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "Client_Id" });
            AddColumn("dbo.Orders", "Client_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Orders", "Client_Id");
            AddForeignKey("dbo.Orders", "Client_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Products", "Client_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Client_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Orders", "Client_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Orders", new[] { "Client_Id" });
            DropColumn("dbo.Orders", "Client_Id");
            CreateIndex("dbo.Products", "Client_Id");
            AddForeignKey("dbo.Products", "Client_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
