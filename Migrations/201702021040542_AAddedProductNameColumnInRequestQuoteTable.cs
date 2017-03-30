namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AAddedProductNameColumnInRequestQuoteTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestQuotes", "ProductName", c => c.String(nullable: false));
            AddColumn("dbo.RequestQuotes", "Product_Id", c => c.Int());
            CreateIndex("dbo.RequestQuotes", "Product_Id");
            AddForeignKey("dbo.RequestQuotes", "Product_Id", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestQuotes", "Product_Id", "dbo.Products");
            DropIndex("dbo.RequestQuotes", new[] { "Product_Id" });
            DropColumn("dbo.RequestQuotes", "Product_Id");
            DropColumn("dbo.RequestQuotes", "ProductName");
        }
    }
}
