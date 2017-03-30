namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedsubcategoryrltnshpfrmprdcttable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", new[] { "Subcategory_CategoryId", "Subcategory_MinicategoryId" }, "dbo.Subcategories");
            DropIndex("dbo.Products", new[] { "Subcategory_CategoryId", "Subcategory_MinicategoryId" });
            DropColumn("dbo.Products", "Subcategory_CategoryId");
            DropColumn("dbo.Products", "Subcategory_MinicategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Subcategory_MinicategoryId", c => c.Byte());
            AddColumn("dbo.Products", "Subcategory_CategoryId", c => c.Byte());
            CreateIndex("dbo.Products", new[] { "Subcategory_CategoryId", "Subcategory_MinicategoryId" });
            AddForeignKey("dbo.Products", new[] { "Subcategory_CategoryId", "Subcategory_MinicategoryId" }, "dbo.Subcategories", new[] { "CategoryId", "MinicategoryId" });
        }
    }
}
