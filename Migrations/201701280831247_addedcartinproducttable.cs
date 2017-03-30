namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcartinproducttable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            AddColumn("dbo.Products", "Cart_RecordId", c => c.Int());
            CreateIndex("dbo.Products", "Cart_RecordId");
            AddForeignKey("dbo.Products", "Cart_RecordId", "dbo.Carts", "RecordId");
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Cart_RecordId", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "Cart_RecordId" });
            DropColumn("dbo.Products", "Cart_RecordId");
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
