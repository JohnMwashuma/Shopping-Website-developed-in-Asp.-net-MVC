namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedProductIdColumnToIdInRequestQuoteTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.RequestQuotes", name: "ProductId", newName: "Id");
            RenameIndex(table: "dbo.RequestQuotes", name: "IX_ProductId", newName: "IX_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.RequestQuotes", name: "IX_Id", newName: "IX_ProductId");
            RenameColumn(table: "dbo.RequestQuotes", name: "Id", newName: "ProductId");
        }
    }
}
