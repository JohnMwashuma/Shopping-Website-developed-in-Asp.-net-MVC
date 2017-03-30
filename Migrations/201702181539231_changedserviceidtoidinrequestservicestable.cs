namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedserviceidtoidinrequestservicestable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequestServices", "Services_ServiceId", "dbo.Services");
            DropIndex("dbo.RequestServices", new[] { "Services_ServiceId" });
            DropColumn("dbo.RequestServices", "ServicesId");
            DropColumn("dbo.RequestServices", "Services_ServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestServices", "Services_ServiceId", c => c.Int());
            AddColumn("dbo.RequestServices", "ServicesId", c => c.Int(nullable: false));
            CreateIndex("dbo.RequestServices", "Services_ServiceId");
            AddForeignKey("dbo.RequestServices", "Services_ServiceId", "dbo.Services", "ServiceId");
        }
    }
}
