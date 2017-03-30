namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedservicecategorytable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceCategories",
                c => new
                    {
                        ServiceCategoryId = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ServiceCategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceCategories");
        }
    }
}
