namespace GrandLabFixers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOrderDetailTableAndModifiedOrderTableConventions : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Orders", name: "Client_Id", newName: "UserName_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_Client_Id", newName: "IX_UserName_Id");
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(),
                        UserName_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Orders", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserName_Id)
                .Index(t => t.Id)
                .Index(t => t.ProductId)
                .Index(t => t.UserName_Id);
            
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "FirstName", c => c.String(nullable: false, maxLength: 160));
            AddColumn("dbo.Orders", "LastName", c => c.String(nullable: false, maxLength: 160));
            AddColumn("dbo.Orders", "Address", c => c.String(nullable: false, maxLength: 70));
            AddColumn("dbo.Orders", "City", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "State", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "PostalCode", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Orders", "Country", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Orders", "Phone", c => c.String(nullable: false, maxLength: 24));
            AddColumn("dbo.Orders", "AdditionalPhone", c => c.String(maxLength: 24));
            AddColumn("dbo.Orders", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "DateTime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.OrderDetails", "UserName_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "Id", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "UserName_Id" });
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "Id" });
            DropColumn("dbo.Orders", "Total");
            DropColumn("dbo.Orders", "Email");
            DropColumn("dbo.Orders", "AdditionalPhone");
            DropColumn("dbo.Orders", "Phone");
            DropColumn("dbo.Orders", "Country");
            DropColumn("dbo.Orders", "PostalCode");
            DropColumn("dbo.Orders", "State");
            DropColumn("dbo.Orders", "City");
            DropColumn("dbo.Orders", "Address");
            DropColumn("dbo.Orders", "LastName");
            DropColumn("dbo.Orders", "FirstName");
            DropColumn("dbo.Orders", "OrderDate");
            DropTable("dbo.OrderDetails");
            RenameIndex(table: "dbo.Orders", name: "IX_UserName_Id", newName: "IX_Client_Id");
            RenameColumn(table: "dbo.Orders", name: "UserName_Id", newName: "Client_Id");
        }
    }
}
