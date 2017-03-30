namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedServiceTypeConventionsTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ServiceTypes", "IsChecked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceTypes", "IsChecked", c => c.Boolean(nullable: false));
        }
    }
}
