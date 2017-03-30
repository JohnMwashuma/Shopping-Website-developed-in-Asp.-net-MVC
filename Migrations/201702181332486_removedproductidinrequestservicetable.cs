namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedproductidinrequestservicetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequestServices", "ProductId", "dbo.Products");
            DropIndex("dbo.RequestServices", new[] { "ProductId" });
            RenameColumn(table: "dbo.RequestServices", name: "ProductId", newName: "Product_Id");
            AlterColumn("dbo.RequestServices", "Product_Id", c => c.Int());
            CreateIndex("dbo.RequestServices", "Product_Id");
            AddForeignKey("dbo.RequestServices", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestServices", "Product_Id", "dbo.Products");
            DropIndex("dbo.RequestServices", new[] { "Product_Id" });
            AlterColumn("dbo.RequestServices", "Product_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.RequestServices", name: "Product_Id", newName: "ProductId");
            CreateIndex("dbo.RequestServices", "ProductId");
            AddForeignKey("dbo.RequestServices", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
