namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductIdInOrdersTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "Product_Id", newName: "ProductId");
            RenameIndex(table: "dbo.Orders", name: "IX_Product_Id", newName: "IX_ProductId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Orders", name: "IX_ProductId", newName: "IX_Product_Id");
            RenameColumn(table: "dbo.Orders", name: "ProductId", newName: "Product_Id");
        }
    }
}
