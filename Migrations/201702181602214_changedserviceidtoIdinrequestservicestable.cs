namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedserviceidtoIdinrequestservicestable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RequestServices");
            AddColumn("dbo.RequestServices", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RequestServices", "Id");
            DropColumn("dbo.RequestServices", "ServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestServices", "ServiceId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.RequestServices");
            DropColumn("dbo.RequestServices", "Id");
            AddPrimaryKey("dbo.RequestServices", "ServiceId");
        }
    }
}
