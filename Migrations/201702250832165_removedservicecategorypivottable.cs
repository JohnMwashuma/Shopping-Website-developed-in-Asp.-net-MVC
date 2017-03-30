namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedservicecategorypivottable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceCategoryPivots", "ServiceCategoryId", "dbo.ServiceCategories");
            DropForeignKey("dbo.ServiceCategoryPivots", "ServiceId", "dbo.Services");
            DropIndex("dbo.ServiceCategoryPivots", new[] { "ServiceId" });
            DropIndex("dbo.ServiceCategoryPivots", new[] { "ServiceCategoryId" });
            DropTable("dbo.ServiceCategoryPivots");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceCategoryPivots",
                c => new
                    {
                        ServiceId = c.Int(nullable: false),
                        ServiceCategoryId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceId, t.ServiceCategoryId });
            
            CreateIndex("dbo.ServiceCategoryPivots", "ServiceCategoryId");
            CreateIndex("dbo.ServiceCategoryPivots", "ServiceId");
            AddForeignKey("dbo.ServiceCategoryPivots", "ServiceId", "dbo.Services", "ServiceId", cascadeDelete: true);
            AddForeignKey("dbo.ServiceCategoryPivots", "ServiceCategoryId", "dbo.ServiceCategories", "ServiceCategoryId", cascadeDelete: true);
        }
    }
}
