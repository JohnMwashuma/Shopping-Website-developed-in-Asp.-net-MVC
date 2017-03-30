namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsCheckedColumnInServiceTypeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceTypes", "IsChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ServiceTypes", "IsChecked");
        }
    }
}
