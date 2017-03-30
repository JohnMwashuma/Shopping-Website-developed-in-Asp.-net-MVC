namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageAndChangedPriceTypeInPeoducts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Image", c => c.Binary());
            DropColumn("dbo.Products", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Image");
        }
    }
}
