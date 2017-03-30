namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedminicategoryrltnshptoprdcttable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Minicategory_MinicategoryId", c => c.Byte());
            CreateIndex("dbo.Products", "Minicategory_MinicategoryId");
            AddForeignKey("dbo.Products", "Minicategory_MinicategoryId", "dbo.Minicategories", "MinicategoryId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Minicategory_MinicategoryId", "dbo.Minicategories");
            DropIndex("dbo.Products", new[] { "Minicategory_MinicategoryId" });
            DropColumn("dbo.Products", "Minicategory_MinicategoryId");
        }
    }
}
