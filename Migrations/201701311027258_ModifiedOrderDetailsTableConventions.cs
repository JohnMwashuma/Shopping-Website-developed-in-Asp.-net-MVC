namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedOrderDetailsTableConventions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Double());
        }
    }
}
