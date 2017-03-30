namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedserviceidinrequestservicetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestServices", "ServicesId", c => c.Int(nullable: false));
            AddColumn("dbo.RequestServices", "Services_ServiceId", c => c.Int());
            CreateIndex("dbo.RequestServices", "Services_ServiceId");
            AddForeignKey("dbo.RequestServices", "Services_ServiceId", "dbo.Services", "ServiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestServices", "Services_ServiceId", "dbo.Services");
            DropIndex("dbo.RequestServices", new[] { "Services_ServiceId" });
            DropColumn("dbo.RequestServices", "Services_ServiceId");
            DropColumn("dbo.RequestServices", "ServicesId");
        }
    }
}
