namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addservicecategoryrltnshptoservicetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ServiceCategory_ServiceCategoryId", c => c.Byte());
            CreateIndex("dbo.Services", "ServiceCategory_ServiceCategoryId");
            AddForeignKey("dbo.Services", "ServiceCategory_ServiceCategoryId", "dbo.ServiceCategories", "ServiceCategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ServiceCategory_ServiceCategoryId", "dbo.ServiceCategories");
            DropIndex("dbo.Services", new[] { "ServiceCategory_ServiceCategoryId" });
            DropColumn("dbo.Services", "ServiceCategory_ServiceCategoryId");
        }
    }
}
