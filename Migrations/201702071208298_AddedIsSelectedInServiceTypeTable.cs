namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsSelectedInServiceTypeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceTypes", "IsSelected", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceTypes", "IsSelected");
        }
    }
}
