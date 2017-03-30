namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Details = c.String(),
                        Client_Id = c.String(maxLength: 128),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Client_Id)
                .ForeignKey("dbo.Orders", t => t.Order_Id)
                .Index(t => t.Client_Id)
                .Index(t => t.Order_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Products", "Client_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Products", new[] { "Order_Id" });
            DropIndex("dbo.Products", new[] { "Client_Id" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
        }
    }
}
