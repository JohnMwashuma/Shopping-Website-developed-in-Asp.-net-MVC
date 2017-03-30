namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientNameInOrderandOrderDetailsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "ClientName", c => c.String());
            AddColumn("dbo.OrderDetails", "ClientName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "ClientName");
            DropColumn("dbo.Orders", "ClientName");
        }
    }
}
