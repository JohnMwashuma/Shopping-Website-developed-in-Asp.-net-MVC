namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedServiceTypeInRequestServiceTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RequestServices", "ServiceType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RequestServices", "ServiceType");
        }
    }
}
