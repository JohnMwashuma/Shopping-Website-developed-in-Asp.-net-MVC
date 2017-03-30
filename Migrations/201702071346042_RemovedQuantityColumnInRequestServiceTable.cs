namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedQuantityColumnInRequestServiceTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RequestServices", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RequestServices", "Quantity", c => c.Int(nullable: false));
        }
    }
}
