namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewservicecategorypivottable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceCategoryPivots",
                c => new
                    {
                        ServiceId = c.Int(nullable: false),
                        ServiceCategoryId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceId, t.ServiceCategoryId })
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Services", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.ServiceCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceCategoryPivots", "ServiceId", "dbo.Services");
            DropForeignKey("dbo.ServiceCategoryPivots", "ServiceCategoryId", "dbo.ServiceCategories");
            DropIndex("dbo.ServiceCategoryPivots", new[] { "ServiceCategoryId" });
            DropIndex("dbo.ServiceCategoryPivots", new[] { "ServiceId" });
            DropTable("dbo.ServiceCategoryPivots");
        }
    }
}
