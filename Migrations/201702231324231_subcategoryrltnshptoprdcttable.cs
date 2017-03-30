namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subcategoryrltnshptoprdcttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Subcategory_CategoryId", c => c.Byte());
            AddColumn("dbo.Products", "Subcategory_MinicategoryId", c => c.Byte());
            CreateIndex("dbo.Products", new[] { "Subcategory_CategoryId", "Subcategory_MinicategoryId" });
            AddForeignKey("dbo.Products", new[] { "Subcategory_CategoryId", "Subcategory_MinicategoryId" }, "dbo.Subcategories", new[] { "CategoryId", "MinicategoryId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", new[] { "Subcategory_CategoryId", "Subcategory_MinicategoryId" }, "dbo.Subcategories");
            DropIndex("dbo.Products", new[] { "Subcategory_CategoryId", "Subcategory_MinicategoryId" });
            DropColumn("dbo.Products", "Subcategory_MinicategoryId");
            DropColumn("dbo.Products", "Subcategory_CategoryId");
        }
    }
}
