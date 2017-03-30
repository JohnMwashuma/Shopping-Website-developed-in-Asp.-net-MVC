namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedservicenameinrequestservicestable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestServices", "ServiceName", c => c.String());
            DropColumn("dbo.RequestServices", "ServiceType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestServices", "ServiceType", c => c.String());
            DropColumn("dbo.RequestServices", "ServiceName");
        }
    }
}
