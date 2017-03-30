namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedServiceTypeInRequestServiceTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RequestServices", "ServiceType_Id", "dbo.ServiceTypes");
            DropIndex("dbo.RequestServices", new[] { "ServiceType_Id" });
            DropColumn("dbo.RequestServices", "ServiceType_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestServices", "ServiceType_Id", c => c.Byte());
            CreateIndex("dbo.RequestServices", "ServiceType_Id");
            AddForeignKey("dbo.RequestServices", "ServiceType_Id", "dbo.ServiceTypes", "Id");
        }
    }
}
