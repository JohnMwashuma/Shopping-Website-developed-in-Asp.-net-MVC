namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedProductNameColumnInRequestQuoteTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RequestQuotes", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestQuotes", "ProductName", c => c.String());
        }
    }
}
