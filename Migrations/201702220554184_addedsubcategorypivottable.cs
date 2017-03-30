namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedsubcategorypivottable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        CategoryId = c.Byte(nullable: false),
                        MinicategoryId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.MinicategoryId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Minicategories", t => t.MinicategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.MinicategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subcategories", "MinicategoryId", "dbo.Minicategories");
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Subcategories", new[] { "MinicategoryId" });
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            DropTable("dbo.Subcategories");
        }
    }
}
