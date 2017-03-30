namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedservicesrltnshpinproductstable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Services_ServiceId", "dbo.Services");
            DropIndex("dbo.Products", new[] { "Services_ServiceId" });
            DropColumn("dbo.Products", "Services_ServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Services_ServiceId", c => c.Int());
            CreateIndex("dbo.Products", "Services_ServiceId");
            AddForeignKey("dbo.Products", "Services_ServiceId", "dbo.Services", "ServiceId");
        }
    }
}
