namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedproductnameinproducttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestQuotes", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestQuotes", "ProductName");
        }
    }
}
