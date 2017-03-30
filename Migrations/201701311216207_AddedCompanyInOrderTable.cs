namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCompanyInOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Company", c => c.String(nullable: false, maxLength: 160));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Company");
        }
    }
}
