namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedservicesrltnshpinproductstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Services_ServiceId", c => c.Int());
            CreateIndex("dbo.Products", "Services_ServiceId");
            AddForeignKey("dbo.Products", "Services_ServiceId", "dbo.Services", "ServiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Services_ServiceId", "dbo.Services");
            DropIndex("dbo.Products", new[] { "Services_ServiceId" });
            DropColumn("dbo.Products", "Services_ServiceId");
        }
    }
}
