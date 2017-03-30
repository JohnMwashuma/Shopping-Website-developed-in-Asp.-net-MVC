namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeservicesinrqstsrvctbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequestServices", "Services_ServiceId", "dbo.Services");
            DropIndex("dbo.RequestServices", new[] { "Services_ServiceId" });
            AlterColumn("dbo.RequestServices", "Services_ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.RequestServices", "Services_ServiceId");
            AddForeignKey("dbo.RequestServices", "Services_ServiceId", "dbo.Services", "ServiceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestServices", "Services_ServiceId", "dbo.Services");
            DropIndex("dbo.RequestServices", new[] { "Services_ServiceId" });
            AlterColumn("dbo.RequestServices", "Services_ServiceId", c => c.Int());
            CreateIndex("dbo.RequestServices", "Services_ServiceId");
            AddForeignKey("dbo.RequestServices", "Services_ServiceId", "dbo.Services", "ServiceId");
        }
    }
}
