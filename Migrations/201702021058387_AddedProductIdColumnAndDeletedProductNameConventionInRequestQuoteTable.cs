namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductIdColumnAndDeletedProductNameConventionInRequestQuoteTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequestQuotes", "Product_Id", "dbo.Products");
            DropIndex("dbo.RequestQuotes", new[] { "Product_Id" });
            RenameColumn(table: "dbo.RequestQuotes", name: "Product_Id", newName: "ProductId");
            AlterColumn("dbo.RequestQuotes", "ProductName", c => c.String());
            AlterColumn("dbo.RequestQuotes", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.RequestQuotes", "ProductId");
            AddForeignKey("dbo.RequestQuotes", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestQuotes", "ProductId", "dbo.Products");
            DropIndex("dbo.RequestQuotes", new[] { "ProductId" });
            AlterColumn("dbo.RequestQuotes", "ProductId", c => c.Int());
            AlterColumn("dbo.RequestQuotes", "ProductName", c => c.String(nullable: false));
            RenameColumn(table: "dbo.RequestQuotes", name: "ProductId", newName: "Product_Id");
            CreateIndex("dbo.RequestQuotes", "Product_Id");
            AddForeignKey("dbo.RequestQuotes", "Product_Id", "dbo.Products", "Id");
        }
    }
}
